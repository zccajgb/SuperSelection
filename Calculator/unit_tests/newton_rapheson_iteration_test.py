import numpy as np
import sys
import unittest
sys.path.append('C:\\Users\\josep\\Dropbox\\PhD\\Source\\SuperSelection\\Calculator\\calculators')
from newton_rapheson import newton_rapheson_iteration, vector_function, jacobin_matrix
from pprint import pprint

class NR_Iter_Test(unittest.TestCase):
    def test_correct_result_is_returned(self):
        p = np.array([1,2,3])
        mock_jacobin = lambda x : np.eye(3)
        mock_function = lambda x : np.array([1,2,3])
        expected = np.array([0,0,0])
        
        output = newton_rapheson_iteration(mock_function, mock_jacobin, p)

        self.assertTrue(np.array_equal(expected, output))
    
    def test_correct_result_is_returned2(self):
        p = np.array([1,2,10])
        mock_function = lambda x : np.ones([3,1])
        mock_jacobin = lambda x : np.array([[0, -0.8, -0.6], [0.8, 0.36, 0.48], [0.6, 0.48, -0.64]])
        expected = np.array([-0.9287257, 2.91792657, 10.44276458])
        
        output = newton_rapheson_iteration(mock_function, mock_jacobin, p)

        self.assertTrue(np.allclose(expected, output))


        
if __name__ == '__main__':
    unittest.main()
