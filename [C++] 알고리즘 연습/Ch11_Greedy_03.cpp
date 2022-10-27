#include <iostream>
#include <string>
using namespace std;

string str;

int main() {
	cin >> str;

	int count = 1;
	for (int i = 1; i < str.size(); i++) {
		if (str[i - 1] != str[i]) count++;
	}

	cout << count / 2 << '\n';

	return 0;
}