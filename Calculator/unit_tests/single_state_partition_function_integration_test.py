import numpy as np
import sys
import unittest
sys.path.append('C:\\Users\\josep\\Dropbox\\PhD\\Source\\SuperSelection\\Calculator\\calculators')
from single_state_partition_function import single_state_partition_function
from pprint import pprint

class FunctionTest(unittest.TestCase):
    def test_correct_result_is_returned(self):
        input_data = np.array([1, 2, 3])
        output = single_state_partition_function(input_data)
        expected = -0.2530518
        self.assertAlmostEqual(expected, output)

    def test_correct_result_is_returned_2(self):
        input_data = np.array([1, 1, 1])
        output = single_state_partition_function(input_data)
        expected = 0
        self.assertAlmostEqual(expected, output)

if __name__ == '__main__':
    unittest.main()