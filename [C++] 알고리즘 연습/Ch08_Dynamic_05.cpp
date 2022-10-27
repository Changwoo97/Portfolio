//#include <iostream>
//#include <vector>
//#include <utility>
//using namespace std;
//
//int N, M, d[10001];
//vector<int> v;
//
//int main() {
//	cin >> N >> M;
//
//	for (int i = 1; i <= M; i++) {
//		d[i] = 10001;
//	}
//
//	for (int i = 0; i < N; i++) {
//		int temp;
//		cin >> temp;
//		v.push_back(temp);
//	}
//
//	for (int i = 0; i < N; i++) {
//		for (int j = v[i]; j <= M; j++) {
//			d[j] = min<int>(d[j], d[j - v[i]] + 1);
//		}
//	}
//
//	cout << ((d[M] <= 10000) ? d[M] : -1) << '\n';
//
//	return 0;
//}