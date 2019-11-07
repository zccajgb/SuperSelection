import numpy as np
import scipy.constants as spc
import sys
from functools import partial
sys.path.append('C:\\Users\\josep\\Dropbox\\PhD\\Source\\SuperSelection\\Calculator\\calculators')
from newton_rapheson import vector_function, jacobin_matrix, newton_rapheson_iteration, newton_rapheson
from single_state_partition_function import single_state_partition_function


def selectivity_calculator(avagadros_number, volume, nanoparticle_conc, steric_partition_function, partition_function):
    denominator = nanoparticle_conc * avagadros_number * volume * partition_function * steric_partition_function
    fraction = 1 / denominator
    selectivity = np.power(fraction + 1, -1) 
    return selectivity

def volume_calculator(nanoparticle_radius, tether_length):
    Rd3 = np.power(nanoparticle_radius + np.mean(tether_length), 3)
    R3 = np.power(nanoparticle_radius, 3)
    volume = (np.pi/3) * (3*Rd3 - R3)
    return volume

def steric_potential_calculator(nanoparticle_radius, glycol_interference_parameter, interchain_distance):
    if (interchain_distance == 0):
        return 0
    volume = 4*np.pi*np.power(nanoparticle_radius, 3)/3
    interference_contribution = np.power(1-glycol_interference_parameter, 9/4)
    area_per_chain = interchain_distance * np.pi / 24
    area_contribution = 3 * np.power(area_per_chain, 3/2)
    steric_potential = volume * interference_contribution / area_contribution
    return steric_potential

def calculate(data):
    binding_probability_calculator = partial(newton_rapheson, setup_binding_prob_calc(data.chi, data.N))
    data.binding_probability = binding_probability_calculator(data.initial_probability, data.tolerance)
    data.binding_partition_function = single_state_partition_function(data.binding_probability)
    data.volume = volume_calculator(data.nanoparticle_radius, data.tether_length)
    data.steric_potential = steric_potential_calculator(data.nanoparticle_radius, data.glycol_interference_parameter, data.interchain_distance)
    data.steric_partition_function = np.exp(data.steric_potential)
    data.selectivity = selectivity_calculator(spc.Avogadro, data.volume, data.nanoparticle_conc, data.steric_partition_function, data.binding_partition_function)
    return data

def setup_binding_prob_calc(chi, N):
    fcn = partial(vector_function, chi, N)
    jcb = partial(jacobin_matrix, chi, N)
    nr_iter = partial(newton_rapheson_iteration, fcn, jcb)
    return nr_iter