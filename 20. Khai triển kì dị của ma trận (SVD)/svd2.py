import numpy as np
from numpy import linalg as LA
from scipy.linalg import *

# input Ma trận A cỡ m.n
A = np.loadtxt('input.txt', delimiter=' ')

# m hàng, n cột
(m, n) = np.shape(A)
print('m = ', m)
print('n = ', n)


# -------------------------------------------------------------------------------------------------------------------------
# Hàm tìm ma trận U, S, V  t/m: A = U.S.V^(t)
def SVD(A):
    # gán ma trận Sigma bằng ma trận 0 cỡ m.n
    sigma = np.zeros((m, n))
    v = np.eye(n)

    # r = Rank(A)
    r = np.linalg.matrix_rank(A)
    print('rank(A) = ', r)

    # ---------------------------------------------------------------------------------------------------------------------
    # TH1: m >= n
    # Tìm U trước -> V để ko dùng EIG 2 lần
    if m >= n:

        # dùng hàm EIG tìm trị riêng w_i của A.AT và vector riêng tương ứng là u_i
        # w = [w1 w2 ...] là hàng ngang
        # u = [u1 u2 ...] nhìn theo cột sẽ ra vector riêng tương ứng, ma trận này đã trực giao
        w, u = LA.eig(A @ A.T)
        # print('Các trị riêng của A.AT: \n',w)
        # print('Các vector riêng tương ứng:\n',u)

        # sắp xếp trị riêng và vetor riêng theo trị riêng giảm dần từ trái qua phải
        for i in range(m - 1):
            for j in range(i + 1, m):
                if (w[j - 1] < w[j]):
                    w[j], w[j - 1] = w[j - 1], w[j]
                    u[:, [j - 1, j]] = u[:, [j, j - 1]]
        U = u

        # TÌM V ------------------------------------------
        # ta tìm r vector riêng đầu tiên ứng với V
        # nếu A ko full rank thì sẽ tìm ker(A) và ker(A.T)
        if r != n:
            ns = null_space(A)
            ns = ns.T
            nd = null_space(A.T)
            nd = nd.T

        # A.AT . U     = lamda. U
        # (A.AT)^T . UT = lamda. UT --> từ U tính ra V vì các v_i là vector riêng của AT.A
        V = np.zeros((r, n))
        for i in range(r):
            V[i, :n] = (u.T[i, :m] @ A) / (np.sqrt(w[i]))

        # Sau đó tìm (n - r) vector còn lại
        if r != n:
            V = np.concatenate((V, ns), axis=0)

        # Chuyển vector ngang sang vector dọc
        V = V.T

        # TÌM SIGMA --------------------------------
        # giá trị kỳ dị của A = sqrt(trị riêng ATA)
        # chèn vào đường chéo của sigma
        np.fill_diagonal(sigma, np.sqrt(w))


    # ---------------------------------------------------------------------------------------------------------------------
    # TH2: m < n ta tính V trước U
    # Làm tương tự như TH1, chỉ đổi vai trò của U và V
    else:
        w, v = LA.eig(A.T @ A)
        for i in range(n - 1):
            for j in range(i + 1, n):
                if (w[j - 1] < w[j]):
                    w[j], w[j - 1] = w[j - 1], w[j]
                    v[:, [j - 1, j]] = v[:, [j, j - 1]]

        V = v

        # TÌM U -------------------------------------------------
        # ta tìm r vector riêng đầu tiên ứng với U
        # nếu A ko full rank thì sẽ tìm ker(A) và ker(A.T)
        if r != m:
            ns = null_space(A)
            ns = ns.T
            nd = null_space(A.T)
            nd = nd.T

        U = np.zeros((r, m))
        for i in range(r):
            U[i, :m] = (v.T[i, :n] @ A.T) / (np.sqrt(w[i]))

        # Sau đó tìm (m - r) vector còn lại
        if r != m:
            U = np.concatenate((U, nd), axis=0)

        # Chuyển vector ngang sang vector dọc
        U = U.T

        # TÌM SIGMA ----------------------------------------------
        # giá trị kỳ dị của A = sqrt(trị riêng AAT)
        np.fill_diagonal(sigma, np.sqrt(w))

    return U, sigma, V


# ---------------------------------------------------------------------------------------------------
U, sigma, V = SVD(A)
print("\nA = ")
print(A)
print("\nU = ")
print(U)
print("\nS = ")
print(sigma)
print("\nV = ")
print(V)
print("\nTest")
print('A - U.S.V^(t) = 0')
print(A - U @ sigma @ (V.T))