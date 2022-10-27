//#include <iostream>
//using namespace std;
//
//int N, d[1000];
//
//int main() {
//	cin >> N;
//
//	d[0] = 1;
//	d[1] = 3;
//	for (int i = 2; i < N; i++) {
//		d[i] = (d[i - 1] + d[i - 2] * 2) % 796796;
//	}
//
//	cout << d[N - 1] << '\n';
//
//	return 0;
//}