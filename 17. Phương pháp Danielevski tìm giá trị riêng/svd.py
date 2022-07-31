# SVD

import numpy as np
from numpy import linalg as la
from scipy.linalg import *

# Input: Ma trận A cỡ m x n
# Test1: TH m = 2 < n = 3
# Test2: TH m = 3 = n = 3
# Test3: TH m = 3 > n = 2
A = np.loadtxt('G:/visual/Veoquynhs/C/GTS/SVD/SVD_Test3.txt', delimiter = ' ')

# m hàng, n cột
(m, n) = np.shape(A)
print('Số hàng: ', m)
print('Số cột: ', n)

# Hàm tìm 3 ma trận U, S, V thỏa mãn A = U.S.V^{T}
def SVD(A):
    np.seterr(invalid = 'ignore')
    # Gán ma trận Sigma bằng ma trận 0 cỡ m x n
    sigma = np.zeros((m, n))
    v = np.eye(n)

    # r = Rank(A)
    r = np.linalg.matrix_rank(A)
    print('rank(A) = ', r)

    # TH1: m >= n
    if m >= n:
        # Tìm ma trận U
        # Tìm các giá trị riêng w_{i} của A.A^{T}
        # Tìm các vector riêng tương ứng là u_{i}
        w, u = la.eig(A @ A.T)
        print('\nCác trị riêng của A.A^{T}:')
        print(w)
        print('\nCác vector riêng tương ứng:')
        print(u)

        # Sắp xếp các giá trị riêng và các vetor riêng tương ứng theo giá trị riêng giảm dần từ trái qua phải
        for i in range(m - 1):
            for j in range(i + 1, m):
                if (w[j - 1] < w[j]):
                    w[j], w[j - 1] = w[j - 1], w[j]
                    u[:, [j - 1, j]] = u[:, [j, j - 1]]
        U = u

        # Tìm ma trận V 
        # Ta tìm r vector riêng đầu tiên ứng với V
        # Nếu ma trận A không đủ hạng thì sẽ tìm ker(A) và ker(A^{T})
        if r != n:
            ns = null_space(A)
            ns = ns.T
            nd = null_space(A.T)
            nd = nd.T

        # A.A^{T}.U = lamda.U
        # (A.A^{T})^{T}.U^{T} = lamda.U^{T}
        # Từ U tính ra V
        V = np.zeros((r, n))
        for i in range(r):
            V[i, :n] = (u.T[i, :m] @ A) / (np.sqrt(w[i]))

        # Tìm (n - r) vector còn lại
        if r != n:
            V = np.concatenate((V, ns), axis=0)

        # V = V^{T}
        V = V.T

        # Tìm ma trận Sigma
        np.fill_diagonal(sigma, np.sqrt(w))

    # TH2: m < n
    # Tương tự như TH1, chỉ đổi vai trò của U và V
    else:
        # Tìm ma trận V
        w, v = la.eig(A.T @ A)
        print('\nCác trị riêng của A^{T}.A:')
        print(w)
        print('\nCác vector riêng tương ứng:')
        print(v)
        
        # Sắp xếp
        for i in range(n - 1):
            for j in range(i + 1, n):
                if (w[j - 1] < w[j]):
                    w[j], w[j - 1] = w[j - 1], w[j]
                    v[:, [j - 1, j]] = v[:, [j, j - 1]]

        V = v

        # Tìm ma trận U
        # Ta tìm r vector riêng đầu tiên ứng với U
        # Nếu ma trận A không đủ hạng thì sẽ tìm ker(A) và ker(A^{T})
        if r != m:
            ns = null_space(A)
            ns = ns.T
            nd = null_space(A.T)
            nd = nd.T

        U = np.zeros((r, m))
        for i in range(r):
            U[i, :m] = (v.T[i, :n] @ A.T) / (np.sqrt(w[i]))

        # Tìm (m - r) vector còn lại
        if r != m:
            U = np.concatenate((U, nd), axis=0)