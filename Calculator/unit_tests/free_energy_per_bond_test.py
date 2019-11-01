import numpy as np
import sys
import unittest
sys.path.append('C:\\Users\\josep\\Dropbox\\PhD\\Source\\SuperSelection\\Calculator\\calculators')
from single_state_partition_function import free_energy_per_bond_calculator
from pprint import pprint

class FunctionTest(unittest.TestCase):
    def test_correct_result_is_returned(self):
        input_data = np.exp(1)
        output = free_energy_per_bond_calculator(input_data)
        expected = 0.14085908577
        self.assertAlmostEqual(expected, output)

    def test_correct_result_is_returned_2(self):
        input_data = 10
        output = free_energy_per_bond_calculator(input_data)
        self.assertAlmostEqual(-2.19741490701, output)

if __name__ == '__main__':
    unittest.main()