//#include <iostream>
//#include <vector>
//#include <algorithm>
//using namespace std;
//
//int N, K;
//vector<int> A, B;
//
//bool upper_compare(const int left, const int right) {
//	return left > right;
//}
//
//bool lower_compare(const int left, const int right) {
//	return left < right;
//}
//
//int main() {
//	cin >> N >> K;
//
//	for (int i = 0; i < N; i++) {
//		int temp;
//		cin >> temp;
//		A.push_back(temp);
//	}
//	for (int i = 0; i < N; i++) {
//		int temp;
//		cin >> temp;
//		B.push_back(temp);
//	}
//
//	sort(A.begin(), A.end(), lower_compare);
//	sort(B.begin(), B.end(), upper_compare);
//
//	for (int i = 0; i < K; i++) {
//		if (A[0] < B[0]) {
//			int temp = A[0];
//			A[0] = B[0];
//			B[0] = temp;
//
//			sort(A.begin(), A.end(), lower_compare);
//			sort(B.begin(), B.end(), upper_compare);
//		}
//	}
//
//	int sum = 0;
//	for (int i = 0; i < N; i++) {
//		sum += A[i];
//	}
//	cout << sum << '\n';
//
//	return 0;
//}