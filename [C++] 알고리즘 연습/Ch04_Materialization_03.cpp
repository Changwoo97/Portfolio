//#include <iostream>
//using namespace std;
//
//int main() {
//	int N, M;
//	cin >> N >> M;
//
//	int A, B, d;
//	cin >> A >> B >> d;
//
//	int map[50][50];
//	for (int i = 0; i < N; i++) {
//		for (int j = 0; j < M; j++) {
//			cin >> map[i][j];
//		}
//	}
//	map[A][B] = 2;
//
//	int move = 1, count = 0;
//	while (true) {
//		if (--d < 0) d = 3;
//
//		if (d == 0 && 0 < A - 1 && map[A - 1][B] == 0) {
//			A--; map[A][B] = 2; move++; count = 0; continue;
//		} else if (d == 1 && B + 1 < M && map[A][B + 1] == 0) {
//			B++; map[A][B] = 2; move++; count = 0; continue;
//		} else if (d == 2 && A + 1 < N && map[A + 1][B] == 0) {
//			A++; map[A][B] = 2; move++; count = 0; continue;
//		} else if (d == 3 && 0 < B - 1 && map[A][B - 1] == 0) {
//			B--; map[A][B] = 2; move++; count = 0; continue;
//		}
//
//		if (++count >= 4) {
//			if (d == 0 && A + 1 < N && map[A + 1][B] != 1) {
//				A++; 
//			} else if (d == 1 && 0 < B - 1 && map[A][B - 1] != 1) {
//				B--; 
//			} else if (d == 2 && 0 < A - 1 && map[A - 1][B] != 1) {
//				A--; 
//			} else if (d == 3 && B + 1 < M && map[A][B + 1] != 1) {
//				B++;
//			} else {
//				break;
//			}
//
//			if (map[A][B] != 2) {
//				map[A][B] = 2; move++;
//			}
//			count = 0;
//		}	
//	}
//
//	cout << move << endl;
//
//	return 0;
//}