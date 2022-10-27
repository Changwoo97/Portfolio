//#include <iostream>
//using namespace std;
//
//int main() {
//	int* num = nullptr;
//	int N = 0, M = 0, K = 0;
//	int max1 = 0, max2 = 0, result = 0;
//
//	try {
//		cin >> N >> M >> K;
//
//		if (N < 2 || 10000 < N) {
//			throw 1;
//		}
//		if (M < 1 || 10000 < M) {
//			throw 2;
//		}
//		if (K < 1 || 10000 < K) {
//			throw 3;
//		}
//		if (K > M) {
//			throw 4;
//		}
//
//		num = new int[N];
//
//		for (int i = 0; i < N; i++) {
//			cin >> num[i];
//			if (num[i] < 1 || 10000 < num[i]) {
//				throw 5;
//			}
//		}
//
//		for (int i = 0; i < 2; i++) {
//			for (int j = i + 1; j < N; j++) {
//				if (num[i] < num[j]) {
//					int temp = num[i];
//					num[i] = num[j];
//					num[j] = temp;
//				}
//			}
//		}
//
//		for (int i = 0, j = 0; i < M; i++, j++) {
//			if(j < K) { 
//				result += num[0];
//			}
//			else {
//				result += num[1];
//				j = -1;
//			}
//		}
//
//		cout << result << endl;
//	}
//	catch (int expn) {
//		cout << "Error: " << expn << endl;
//	}
//	catch (...) {
//		cout << "Error!" << endl;
//	}
//
//	if (num != nullptr) {
//		delete[] num;
//	}
//	return 0;
//}