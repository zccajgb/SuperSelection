import numpy as np
import sys
from decimal import Decimal
sys.path.append('C:\\Users\\josep\\Dropbox\\PhD\\Source\\SuperSelection\\Calculator\\infrastructure')
from tail_recursion import tail_recursive, recurse

def newton_rapheson_iteration(function, jacobin_matrix, x_n):
    inverse_jacobin_at_xn = np.linalg.inv(jacobin_matrix(x_n))
    delta_x = (inverse_jacobin_at_xn).dot(function(x_n))
    x2 = x_n - delta_x.T
    return x2

@tail_recursive
def newton_rapheson(newton_rapheson_iter, x_n, threshold):
    x_n1 = newton_rapheson_iter(x_n)
    diff = np.linalg.norm(x_n1 - x_n)
    if (diff <= threshold):
        return x_n1
    else:
        return recurse(newton_rapheson_iter, x_n1, threshold)

def vector_function(chi, N, x):
    check_chi_valid(chi)
    gamma = N*chi
    return (x - 1) + x*np.einsum('j,ij -> i', x, gamma)

def jacobin_matrix(chi, N, x):
    check_chi_valid(chi)
    gamma = N*chi
    diag = np.diag(1 + np.einsum('j,ij -> i', x, gamma))
    off_diag = (x*chi).T
    return diag + off_diag

def check_chi_valid(chi):
    if (np.trace(np.absolute(chi)) != 0):
        raise ValueError("Diagonal Elements of Chi should be zero")
    if (np.all(np.abs(chi-chi.T)) != 0):
        raise ValueError("Chi must be symmetric")
    