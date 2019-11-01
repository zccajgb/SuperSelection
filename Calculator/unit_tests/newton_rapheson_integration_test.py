import numpy as np
from functools import partial
import sys
import unittest
sys.path.append('C:\\Users\\josep\\Dropbox\\PhD\\Source\\SuperSelection\\Calculator\\calculators')
from newton_rapheson import newton_rapheson, newton_rapheson_iteration, vector_function, jacobin_matrix
from pprint import pprint

class NR_Integration_Test(unittest.TestCase):

    def setup(self, chi, N):
        fcn = partial(vector_function, chi, N)
        jcb = partial(jacobin_matrix, chi, N)
        nr_iter = partial(newton_rapheson_iteration, fcn, jcb)
        return nr_iter, fcn

    def test_correct_result_is_returned(self):
        chi = np.array([[0, 2, 0], [2, 0, 1], [0, 1, 0]])
        N = np.array([1,1,1])
        nr_iter, fcn = self.setup(chi, N)
        x_n = np.array([0.5, 0.5, 0.5])
        output = newton_rapheson(nr_iter, x_n, 0.00001)
        fx= fcn(output)
        self.assertTrue(np.allclose(fx, np.array([0, 0, 0])))
    
    def test_correct_result_is_returned_2(self):
        chi = np.array([[0, 2, 1, 0], [2, 0, 3, 4], [1, 3, 0, 5], [0, 4, 5, 0]])
        N = np.array([1,1,1,1])
        nr_iter, fcn = self.setup(chi, N)
        x_n = np.array([0.5, 0.5, 0.5, 0.5])
        output = newton_rapheson(nr_iter, x_n, 0.00001)
        fx= fcn(output)
        self.assertTrue(np.allclose(fx, np.array([0, 0, 0, 0])))

    def test_correct_result_is_returned_3(self):
        chi = np.array([[0, 1, 2], [1, 0, 0], [2, 0, 0]])
        N = np.array([2, 1, 2])
        nr_iter, fcn = self.setup(chi, N)
        x_n = np.array([0.5, 0.5, 0.5])
        output = newton_rapheson(nr_iter, x_n, 0.00000001)
        fx= fcn(output)
        self.assertTrue(np.allclose(fx, np.array([0, 0, 0])))
        self.assertTrue(np.allclose(output, np.array([0.28533, 0.63668, 0.467]), rtol=1e-2))

if __name__ == '__main__':
    unittest.main()
