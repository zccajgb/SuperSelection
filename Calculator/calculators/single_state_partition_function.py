import numpy as np
from functools import partial, reduce

def free_energy_per_bond_calculator(probablities_vector):
    log_prob = np.log(probablities_vector)
    energy_per_bond = log_prob + 0.5*(1-probablities_vector)
    return energy_per_bond

def free_energy_of_bond_formation_calculator(free_energy_per_bond_calculator, probablities_vector):
    energy_per_bond = map(free_energy_per_bond_calculator, probablities_vector)
    total_free_energy = sum(energy_per_bond)
    return total_free_energy

def single_state_partition_function_calculator(free_energy_calculator, free_energy_inputs):
    free_energy_in_kT = free_energy_calculator(free_energy_inputs)
    exponentiated_free_energy = np.exp(free_energy_in_kT)
    single_state_partition_function = exponentiated_free_energy - 1
    return single_state_partition_function

free_energy_calculator = partial(free_energy_of_bond_formation_calculator, free_energy_per_bond_calculator)

single_state_partition_function = partial(single_state_partition_function_calculator, free_energy_calculator)