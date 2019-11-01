import numpy as np
import sys
import unittest
sys.path.append('C:\\Users\\josep\\Dropbox\\PhD\\Source\\SuperSelection\\Calculator\\calculators')
from newton_rapheson import vector_function
from pprint import pprint

class FunctionTest(unittest.TestCase):
    def test_correct_function_is_returned(self):
        p = np.array([1,2,3])
        N = np.array([1,1,1])
        chi = np.array([[0,1,2],[1,0,3],[2,3,0]])
        expected = np.array([8,21,26])
        output = vector_function(chi, N, p)
        self.assertTrue(np.array_equal(expected, output))

    def test_correct_function_is_returned2(self):
        p = np.array([1,2,10])
        N = np.array([1,1,1])
        chi = np.array([[0,1,10],[1,0,2],[10,2,0]])
        expected = np.array([102, 43, 149])
        output = vector_function(chi, N, p)
        self.assertTrue(np.array_equal(expected, output))


if __name__ == '__main__':
    unittest.main()