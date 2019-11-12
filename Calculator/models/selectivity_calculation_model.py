import numpy as np

class SelectivityCalculationModel(object):
    def __init__(self, data):
        self.chi : np.ndarray = np.array(data.Chi)
        self.Name = data.Name
        self.calculation_id = data.CalculationID
        self.N : np.ndarray = np.array(data.N)
        self.initial_probability : np.ndarray = np.array(data.InitialProbability)
        self.tolerance = data.Tolerance
        self.tether_length = np.array(data.TetherLength) * 1e-9
        self.nanoparticle_radius = data.NanoparticleRadius * 1e-9
        self.nanoparticle_conc = data.NanoparticleConc
        self.binding_probability : np.ndarray = np.array([])
        self.interchain_distance = data.InterchainDistance
        self.glycol_interference_parameter = data.GlycolInterferenceParameter


    def tolist(self):
        self.chi = self.chi.tolist()
        self.N = self.N.tolist()
        self.initial_probability = self.initial_probability.tolist()
        self.binding_probability = self.binding_probability.tolist()
        return self