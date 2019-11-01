import numpy as np
import sys
import unittest
sys.path.append('C:\\Users\\josep\\Dropbox\\PhD\\Source\\SuperSelection\\Calculator\\calculators')
from newton_rapheson import newton_rapheson
from pprint import pprint


class NewtonRaphesonTest(unittest.TestCase):
    def test_x1_is_returned_if_within_threshold(self):
        threshold = 0.011
        mock_nr_iter = lambda x : x + 0.01
        p = 1
        expected = 1.01
        output = newton_rapheson(mock_nr_iter, p, threshold)
        self.assertEqual(expected, output)

    def test_x1_is_returned_if_within_threshold_2(self):
        threshold = 0.2
        mock_nr_iter = lambda x : x * x
        p = 0.5
        expected = 0.0625
        output = newton_rapheson(mock_nr_iter, p, threshold)
        self.assertEqual(expected, output)

    def test_x1_is_returned_if_within_threshold_3(self):
        threshold = 0.02
        mock_nr_iter = lambda x : x + 0.01
        p = np.array([1, 1])
        expected = np.array([1.01, 1.01])
        output = newton_rapheson(mock_nr_iter, p, threshold)
        self.assertTrue(np.array_equal(expected, output))

if __name__ == '__main__':
    unittest.main()