import numpy as np

class SelectivityCalculationModel(object):
    def __init__(self, data):
        self.chi : np.ndarray = np.array(data.Chi)
        self.N : np.ndarray = np.array(data.N)
        self.initial_probability : np.ndarray = np.array(data.InitialProbability)
        self.tolerance = data.Tolerance
        self.tether_length = data.TetherLength
        self.nanoparticle_radius = data.NanoparticleRadius
        self.nanoparticle_conc = data.NanoparticleConc
        self.binding_probability : np.ndarray = np.array([])


    def tolist(self):
        self.chi = self.chi.tolist()
        self.N = self.N.tolist()
        self.initial_probability = self.initial_probability.tolist()
        self.binding_probability = self.binding_probability.tolist()
        return self