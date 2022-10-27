//#define _CRT_SECURE_NO_WARNINGS
//#include <iostream>
//#include <queue>
//using namespace std;
//
//int N, M;
//int map[201][201];
//int dir[4][2] = { {1, 0}, {0, 1}, {-1, 0}, {0, -1} };
//
//int DFS(int x, int y) {
//	queue<pair<int, int>> q;
//	queue<int> qCount;
//	q.push({ x, y });
//	qCount.push(1);
//	map[x][y] = 0;
//
//	while (true) {
//		if (q.empty()) return 0;
//		pair<int, int> pair = q.front();
//		int count = qCount.front();
//		q.pop();
//		qCount.pop();
//
//		for (int i = 0; i < 4; i++) {
//			int _x = pair.first + dir[i][0];
//			int _y = pair.second + dir[i][1];
//
//			if ((1 <= _x && _x <= N) && (1 <= _y && _y <= M)) {
//				if (map[_x][_y] == 1) {
//					q.push({_x, _y});
//					qCount.push(count + 1);
//					map[_x][_y] = 0;
//				}
//			}
//			
//			if (_x == N && _y == M) return count + 1;
//		}
//	}
//}
//
//int main() {
//	cin >> N >> M;
//	for (int i = 1; i <= N; i++) {
//		for (int j = 1; j <= M; j++) {
//			scanf("%1d", &map[i][j]);
//		}
//	}
//
//	cout << DFS(1, 1) << '\n';
//
//	return 0;
//}