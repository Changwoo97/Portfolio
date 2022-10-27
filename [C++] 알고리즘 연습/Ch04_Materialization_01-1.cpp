//#include <iostream>
//using namespace std;
//
//class Point {
//public:
//	int x, y;
//	Point() : x(1), y(1) {}
//};
//
//ostream& operator<< (ostream& os, const Point& ref) {
//	os << ref.x << ' ' << ref.y;
//	return os;
//}
//
//int main() {
//	Point point;
//	int N;
//	char ch;
//
//	cin >> N;
//	cin.ignore();
//
//	for (int i = 0; i < 100; i++) {
//		ch = getchar();
//
//		switch (ch) {
//		case 'U':
//			point.x = point.x - 1 < 1 ? 1 : point.x - 1;
//			break;
//		case 'D':
//			point.x = point.x + 1 > N ? N : point.x + 1;
//			break;
//		case 'L':
//			point.y = point.y - 1 < 1 ? 1 : point.y - 1;
//			break;
//		case 'R':
//			point.y = point.y + 1 > N ? N : point.y + 1;
//			break;
//		case ' ':
//			i--;
//			break;
//		default:
//			goto OUT;
//		}
//	}
//OUT:
//	cout << point << endl;
//	return 0;
//}