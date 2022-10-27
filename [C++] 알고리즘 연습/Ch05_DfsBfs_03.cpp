//#include <iostream>
//#include <stack>
//using namespace std;
//
//int N, M;
//int (*ptr)[1001];
//int dir[4][2] = { {1, 0}, {0, 1}, {-1, 0}, {0, -1} };
//
//void DFS(int x, int y) {
//	ptr[x][y] = -1;
//
//	for (int i = 0; i < 4; i++) {
//		int dirX = x + dir[i][0];
//		int dirY = y + dir[i][1];
//		if (1 <= dirX && dirX <= N && 1 <= dirY && dirY <= M) {
//			if (ptr[dirX][dirY] == 0) {
//				ptr[dirX][dirY] = -1;
//				DFS(dirX, dirY);
//			}
//		}
//	}
//}
//
//int main() {
//	cin >> N >> M;
//	ptr = new int[1001][1001];
//	for (int i = 1; i <= N; i++) {
//		for (int j = 1; j <= M; j++) {
//			cin >> ptr[i][j];
//		}
//	}
//
//	int count = 0;
//	for (int i = 1; i <= N; i++) {
//		for (int j = 1; j <= M; j++) {
//			if (ptr[i][j] == 0) {
//				count++;
//				DFS(i, j);
//			}
//		}
//	}
//	
//	cout << count << '\n';
//
//	delete[] ptr;
//	return 0;
//}