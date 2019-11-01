import numpy as np
import scipy.constants as spc
import sys
from functools import partial
sys.path.append('C:\\Users\\josep\\Dropbox\\PhD\\Source\\SuperSelection\\Calculator\\calculators')
from newton_rapheson import vector_function, jacobin_matrix, newton_rapheson_iteration, newton_rapheson
from single_state_partition_function import single_state_partition_function


def selectivity_calculator(avagadros_number, volume, nanoparticle_conc, partition_function):
    denominator = nanoparticle_conc * avagadros_number * volume * partition_function
    fraction = 1 / denominator
    selectivity = np.power(fraction - 1, -1) 
    return selectivity

def volume_calculator(nanoparticle_radius, tether_length):
    Rd3 = np.power(nanoparticle_radius + np.mean(tether_length), 3)
    R3 = np.power(nanoparticle_radius, 3)
    volume = (np.pi/3) * (3*Rd3 - R3)
    return volume

def calculate(data):
    binding_probability_calculator = partial(newton_rapheson, setup_binding_prob_calc(data.chi, data.N))
    data.binding_probability = binding_probability_calculator(data.initial_probability, data.tolerance)
    data.partition_function = single_state_partition_function(data.binding_probability)
    data.volume = volume_calculator(data.nanoparticle_radius, data.tether_length)
    data.selectivity = selectivity_calculator(spc.Avogadro, data.volume, data.nanoparticle_conc, data.partition_function)
    return data

def setup_binding_prob_calc(chi, N):
    fcn = partial(vector_function, chi, N)
    jcb = partial(jacobin_matrix, chi, N)
    nr_iter = partial(newton_rapheson_iteration, fcn, jcb)
    return nr_iter