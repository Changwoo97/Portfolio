//#include <iostream>
//using namespace std;
//
//int main() {
//	char h, v;
//	int dir[][2] = {
//		{2, 1}, {2, -1},
//		{1, 2}, {-1, 2},
//		{-2, 1}, {-2, -1},
//		{1, -2}, {-1, -2}
//	};
//	int count = 0;
//
//	cin >> v >> h;
//
//	int range = sizeof(dir) / sizeof(dir[0]);
//	for (int i = 0; i < range; i++) {
//		char hTemp = h + dir[i][0];
//		char vTemp = v + dir[i][1];
//
//		bool hCondition = ('1' <= hTemp) && (hTemp <= '8');
//		bool vCondition = ('a' <= vTemp) && (vTemp <= 'h');
//
//		if (hCondition && vCondition) count++;
//	}
//
//	cout << count << endl;
//
//	return 0;
//}