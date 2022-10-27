//#include <iostream>
//#include <utility>
//using namespace std;
//
//int N, K[100], d[100];
//
//int main() {
//	cin >> N;
//	for (int i = 0; i < N; i++) {
//		cin >> K[i];
//	}
//
//	d[0] = K[0];
//	d[1] = max<int>(K[0], K[1]);
//
//	for (int i = 2; i < N; i++) {
//		d[i] = max<int>(d[i - 1], d[i - 2] + K[i]);
//	}
//
//	cout << d[N - 1] << '\n';
//
//	return 0;
//}