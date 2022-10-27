//#include <iostream>
//using namespace std;
//
//int main() {
//	int N, count = 0;
//	cin >> N;
//
//	for (int hour = 0; hour <= N; hour++) {
//		for (int min = 0; min < 60; min++) {
//			for (int sec = 0; sec < 60; sec++) {
//				if (hour / 10 == 3|| hour % 10 == 3 
//					|| min / 10 == 3 || min % 10 == 3 
//					|| sec / 10 == 3 || sec % 10 == 3) {
//					count++;
//				}
//			}
//		}
//	}
//
//	cout << count << endl;
//
//	return 0;
//}