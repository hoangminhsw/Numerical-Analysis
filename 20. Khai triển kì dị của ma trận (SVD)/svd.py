# Đọc ma trận từ file các phần tử cách nhau bằng khoảng trắng
fileMaTran = open("input1.txt", mode="r", encoding="utf-8-sig")
MaTran=fileMaTran.readlines()
MaTranChuyen=[]
[MaTranChuyen.append([float(PhanTu) for PhanTu in MaTran[i].strip().split(" ")]) for i in range(len(MaTran))]
import numpy as np 
import numpy.matlib
import math

from numpy import linalg as la
# ma trận A
A=np.array(MaTranChuyen)
C=A@(A.T)
# m là  giá trị kì dị của A
# U là vector kì dì trái của A
m, U = la.eig(C)
rankA=np.linalg.matrix_rank(A)
print("Kích thước của ma trận A: ",np.shape(A))
print("Hạng của ma trận A: ",rankA)
s=np.shape(A)
M=np.matlib.zeros((np.shape(A)))
U=U.T
for k in range(0,len(m)-1):
	for l in range(k+1,len(m)):
		if m[k]<m[l]:
			tg=m[k]
			m[k]=m[l]
			m[l]=tg
			for ct in range(len(U.T)):
				tg=U[k,ct]
				U[k,ct]=U[l,ct]
				U[l,ct]=tg
U=U.T
i=len(m)-1
while i>=0:
	if m[i]<0.000000000001:
		m[i]=0
	i=i-1
B=(A.T)@A
# V là vector kì dị phải của A
n,V=la.eig(B)


V=V.T

for k in range(0,len(n)):
	for l in range(k+1,len(n)):
		if n[k]<n[l]:
			tg=n[k]
			n[k]=n[l]
			n[l]=tg
			for ct in range(len(V.T)):
				tg=V[k,ct]
				V[k,ct]=V[l,ct]
				V[l,ct]=tg

V=V.T
for dem in range(len(n)):
	if n[dem]<0.000000000001:
		n[dem]=0
#M la ma trận giá trị kì dị
for k in range(len(n)):
	M[k,k]=math.sqrt(n[k])


print("U=",U)
print("M=",M)
print("V=",V)
Atest=np.matlib.zeros((np.shape(A)))
print("A=")
for i in range(rankA):
	D=U.T[i]
	D=np.reshape(D,(len(U),1))
	print('+');print(M[i,i],D,V.T[i],sep='\nx')