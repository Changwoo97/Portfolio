//#include <iostream>
//#include <utility>
//using namespace std;
//
//int X, d[30001];
//
//int main() {
//	cin >> X;
//
//	for (int i = 1; i < X; i++) {
//		d[i + 1] = d[i] + 1;
//		if (d[i + 1] % 5 == 0) 
//			d[i + 1] = min<int>(d[i + 1], d[(i + 1) / 5] + 1);
//		if (d[i + 1] % 3 == 0) 
//			d[i + 1] = min<int>(d[i + 1], d[(i + 1) / 3] + 1);		
//		if (d[i + 1] % 2 == 0) 
//			d[i + 1] = min<int>(d[i + 1], d[(i + 1) / 2] + 1);
//	}
//	cout << d[X] << '\n';
//
//	return 0;
//}