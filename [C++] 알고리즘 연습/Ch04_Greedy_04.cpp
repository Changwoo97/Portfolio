//#include <iostream>
//using namespace std;
//
//int main() {
//	int N = 0, M = 0, result = 0;
//	int* matrix;
//
//	cin >> N >> M;
//
//	if (N < 1 || 100 < N || M < 1 || 100 < M) {
//		return -1;
//	}
//
//	matrix = new int[N * (M + 1)];
//
//	for (int i = 0; i < N; i++) {
//		cin >> matrix[N * i];
//		matrix[N * i + M] = matrix[N * i];
//
//		for (int j = 1; j < M; j++) {
//			cin >> matrix[N * i + j];
//
//			if (matrix[N * i + j] < 1 || 10000 < matrix[N * i + j]) {
//				return -2;
//			}
//
//			if (matrix[N * i + M] > matrix[N * i + j]) {
//				matrix[N * i + M] = matrix[N * i + j];
//			}
//		}
//
//		if (result < matrix[N * i + M]) {
//			result = matrix[N * i + M];
//		}
//	}
//	
//	cout << result << endl;
//
//	delete[] matrix;
//	return 0;
//}