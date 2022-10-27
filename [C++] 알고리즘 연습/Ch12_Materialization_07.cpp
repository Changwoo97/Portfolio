#include <iostream>
#include <string>
using namespace std;

string n;

int main() {
	cin >> n;

	int left = 0, right = 0;
	for (int i = 0; i < n.size() / 2; i++) {
		left += n[i];
	}
	for (int i = n.size() / 2; i < n.size(); i++) {
		right += n[i];
	}

	if (left == right) {
		cout << "LUCKY" << '\n';
	}
	else {
		cout << "READY" << '\n';
	}

	return 0;
}