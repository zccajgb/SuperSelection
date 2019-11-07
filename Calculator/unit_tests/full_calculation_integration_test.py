import numpy as np
from functools import partial
import sys
import unittest
sys.path.append('C:\\Users\\josep\\Dropbox\\PhD\\Source\\SuperSelection\\Calculator\\calculators')
sys.path.append('C:\\Users\\josep\\Dropbox\\PhD\\Source\\SuperSelection\\Calculator\\Models')
from selectivity import calculate
from data import Data
from selectivity_calculation_model import SelectivityCalculationModel
from pprint import pprint

class Full_Calc_Integration_Test(unittest.TestCase):

    def test_correct_result_is_returned_3(self):
        data = Data("{\"Name\": \"Name\"}")
        data.Chi = np.array([[0, 1, 2], [1, 0, 0], [2, 0, 0]])
        data.N = np.array([2, 1, 2])
        data.InitialProbability = np.array([0.5, 0.5, 0.5])
        data.Tolerance = 1e-11
        data.TetherLength = 1e-9
        data.NanoparticleRadius = 50e-9
        data.NanoparticleConc = 1
        data.GlycolInterferenceParameter = 0
        data.InterchainDistance = 1
        selectivity = SelectivityCalculationModel(data)

        expected_binding_probabilities = np.array([0.28533, 0.63668, 0.467])
        expected_partition_function = 4.2673
        expected_volume = 2.8584e-22
        expected_selectivity = 0.99860

        result = calculate(selectivity)
        np.testing.assert_almost_equal(expected_binding_probabilities, result.binding_probability, decimal=5)
        np.testing.assert_approx_equal(expected_partition_function, result.partition_function, 5)
        np.testing.assert_approx_equal(expected_volume, result.volume, 5)
        np.testing.assert_approx_equal(expected_selectivity, result.selectivity, 4)



if __name__ == '__main__':
    unittest.main()
