//#include <iostream>
//using namespace std;
//
//int main() {
//	int N, M, K, result;
//	int* num = nullptr;
//
//	cin >> N >> M >> K;
//
//	if (N < 2)
//	{
//		return -1;
//	}
//
//	num = new int[N];
//
//	for (int i = 0; i < N; i++) {
//		cin >> num[i];
//	}
//
//	for (int i = 0; i < 2; i++) {
//		for (int j = i + 1; j < N; j++) {
//			if (num[i] < num[j]) {
//				int temp = num[i];
//				num[i] = num[j];
//				num[j] = temp;
//			}
//		}
//	}
//
//	result = ((M / (K + 1)) * K + (M % (K + 1))) * num[0] + (M / (K + 1)) * num[1];
//	cout << result << endl;
//
//	delete[] num;
//	return 0;
//}