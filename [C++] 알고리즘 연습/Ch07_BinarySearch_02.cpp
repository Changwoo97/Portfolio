//#include <iostream>
//#include <vector>
//#include <algorithm>
//#include <string>
//using namespace std;
//
//int N, M;
//vector<int> retainedParts, requiredParts;
//vector<string> result;
//
//void binarySearch() {
//	for (int i = 0; i < requiredParts.size(); i++) {
//		int start = 0;
//		int end = N - 1;
//		while (true) {
//			if (start > end) {
//				result.push_back("no");
//				break;
//			}
//
//			int mid = (start + end) / 2;
//			if (requiredParts[i] == retainedParts[mid]) {
//				result.push_back("yes"); break;
//			} else if (requiredParts[i] < retainedParts[mid]) {
//				end = mid - 1;
//			} else {
//				start = mid + 1;
//			}
//		}
//	}
//}
//
//int main() {
//	cin >> N;
//	for (int i = 0; i < N; i++) {
//		int temp;
//		cin >> temp;
//		retainedParts.push_back(temp);
//	}
//	cin >> M;
//	for (int i = 0; i < M; i++) {
//		int temp;
//		cin >> temp;
//		requiredParts.push_back(temp);
//	}
//
//	sort(retainedParts.begin(), retainedParts.end());
//	binarySearch();
//
//	for (int i = 0; i < result.size(); i++) {
//		cout << result[i] << ' ';
//	}
//	cout << '\n';
//
//	return 0;
//}