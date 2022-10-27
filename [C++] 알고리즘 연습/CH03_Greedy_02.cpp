#include <iostream>
using namespace std;

int main() {
	const int coin[] = { 500, 100, 50, 10 };
	int N = 0, count = 0, temp = 0;

	try {
		cin >> N;
		if (N < 0) throw N;
		N /= 10; N *= 10;

		temp = sizeof(coin) / sizeof(int);
		for (int i = 0; i < temp; i++) {
			for (; N >= coin[i]; N -= coin[i]) {
				count++;
			}
		}
		cout << count << endl;
	}
	catch (int expn) {
		cout << "Error: " << expn << endl;
	}
	catch (...) {
		cout << "Error: " << endl;
	}

	return 0;
}