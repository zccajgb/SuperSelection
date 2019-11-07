import numpy as np

class SelectivityCalculationEntity(object):
    def __init__(self, selectivity_model):
        self.Chi : selectivity_model.chi.tolist()
        self.CalculationId = selectivity_model.calculation_id
        self.BindingProbability = selectivity_model.binding_probability.tolist()
        self.BindingPartitionFunction = selectivity_model.binding_partition_function
        self.Volume = selectivity_model.volume
        self.StericPotential = selectivity_model.steric_potential
        self.StericPartitionFunction = selectivity_model.steric_partition_function
        self.Selectivity = selectivity_model.selectivity