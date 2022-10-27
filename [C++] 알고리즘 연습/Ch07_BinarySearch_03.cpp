//#include <iostream>
//#include <vector>
//using namespace std;
//
//int Max(const vector<int>& v) {
//	int max = 0;
//	for (int i = 0; i < v.size(); i++) {
//		if (max < v[i]) max = v[i];
//	}
//	return max;
//}
//
//int binary_search(const vector<int>& v, int start, int end, int M) {
//	int result = -1;
//	while (start <= end) {
//		int mid = (start + end) / 2;
//		int totalLength = 0;
//		for (int i = 0; i < v.size(); i++) {
//			if (mid < v[i]) {
//				totalLength += v[i] - mid;
//			}
//		}
//		if (totalLength == M) {
//			return mid;
//		} else if (totalLength < M) {
//			end = mid - 1;
//		} else {
//			result = mid;
//			start = mid + 1;
//		}
//	}
//	return result;
//}
//
//int main() {
//	int N, M;
//	cin >> N >> M;
//
//	vector<int> dducks;
//	for (int i = 0; i < N; i++) {
//		int temp;
//		cin >> temp;
//		dducks.push_back(temp);
//	}
//
//	int max = Max(dducks);
//	
//	int H = binary_search(dducks, 0, max, M);
//	if (H >= 0) {
//		cout << H << '\n';
//	} else {
//		cout << "Error" << '\n';
//	}
//
//	return 0;
//}