//#include <iostream>
//#include <string>
//using namespace std;
//
//class Student {
//public:
//	const string name;
//	const int score;
//	explicit Student(const string name, const int score)
//		: name(name), score(score) {}
//};
//
//void sort(Student* students[], const int size) {
//	for (int i = 0; i < size - 1; i++) {
//		for (int j = i + 1; j < size; j++) {
//			if (students[i]->score > students[j]->score) {
//				Student* temp = students[i];
//				students[i] = students[j];
//				students[j] = temp;
//			}
//		}
//	}
//}
//
//Student* students[100000];
//int N;
//
//int main()
//{
//	cin >> N;
//
//	for (int i = 0; i < N; i++) {
//		string name;
//		int score;
//		cin >> name >> score;
//		students[i] = new Student(name, score);
//	}
//
//	sort(students, N);
//
//	for (int i = 0; i < N; i++) {
//		cout << students[i]->name << ' ';
//		delete students[i];
//	}
//	cout << '\n';
//
//	return 0;
//}