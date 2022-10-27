//#include <iostream>
//using namespace std;
//
//int N, arr[500];
//
//void swap(int* const left, int* const right) {
//	int temp = *left;
//	*left = *right;
//	*right = temp;
//}
//
//void quick_sort(int arr[], const int start, const int end) {
//	if (start >= end - 1) return;
//	
//	int pivot = start;
//	int left = start + 1;
//	int right = end - 1;
//
//	while (true) {
//		while (left < end && arr[pivot] <= arr[left]) left++;
//		while (start < right && arr[right] <= arr[pivot]) right--;
//
//		if(left <= right) swap(&arr[left], &arr[right]);
//		else { swap(&arr[pivot], &arr[right]); break; }
//	}
//
//	quick_sort(arr, start, right);
//	quick_sort(arr, right + 1, end);
//}
//
//int main() {
//	cin >> N;
//	for (int i = 0; i < N; i++) {
//		cin >> arr[i];
//	}
//
//	quick_sort(arr, 0, N);
//
//	for (int i = 0; i < N; i++) {
//		cout << arr[i] << ' ';
//	}
//	cout << '\n';
//
//	return 0;
//}