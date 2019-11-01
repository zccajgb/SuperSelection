import numpy as np
import sys
import unittest
sys.path.append('C:\\Users\\josep\\Dropbox\\PhD\\Source\\SuperSelection\\Calculator\\calculators')
from single_state_partition_function import free_energy_of_bond_formation_calculator
from pprint import pprint

class FunctionTest(unittest.TestCase):
    def test_correct_result_is_returned(self):
        mock_function = lambda x: x
        input_data = np.ones([10, 1])
        output = free_energy_of_bond_formation_calculator(mock_function, input_data)
        self.assertEqual(10, output)

    def test_correct_result_is_returned_2(self):
        mock_function = lambda x: 2*x
        input_data = np.ones([10, 1])
        output = free_energy_of_bond_formation_calculator(mock_function, input_data)
        self.assertEqual(20, output)

if __name__ == '__main__':
    unittest.main()