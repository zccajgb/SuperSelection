import numpy as np
import sys
import unittest
sys.path.append('C:\\Users\\josep\\Dropbox\\PhD\\Source\\SuperSelection\\Calculator\\calculators')
from newton_rapheson import jacobin_matrix
from pprint import pprint


class JacobinTest(unittest.TestCase):
    def test_correct_jacboin_is_formed_1(self):
        p = np.array([1,2,3])
        chi = np.array([[0,1,2],[1,0,3],[2,3,0]])
        N = np.array([1,1,1])
        expected = np.array([[9,1,2],[2,11,6],[6,9,9]])

        output = jacobin_matrix(chi, N, p)
        self.assertTrue(np.array_equal(expected, output))

    def test_correct_jacboin_is_formed_2(self):
        p = np.array([1,2,10])
        chi = np.array([[0,1,10],[1,0,2],[10,2,0]])
        N = np.array([1,1,1])
        expected = np.array([[103,1,10],[2,22,4],[100,20,15]])

        output = jacobin_matrix(chi, N, p)
        self.assertTrue(np.array_equal(expected, output))

if __name__ == '__main__':
    unittest.main()