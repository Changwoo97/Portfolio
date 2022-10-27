#include <iostream>
#include <string>
using namespace std;

string str;

int main() {
	cin >> str;

	int result = str[0] - '0';
	for (int i = 1; i < str.size(); i++) {
		if (str[i - 1] == '0' || str[i - 1] == '1'
			|| str[i] == '0' || str[i] == '1')
			result += str[i] - '0';
		else
			result *= (str[i] - '0');
	}

	cout << result << '\n';

	return 0;
}