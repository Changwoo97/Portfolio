#include <iostream>
#include <string>
#include <algorithm>
using namespace std;

string s;

int main() {
	cin >> s;

	string order;
	int sum = 0;
	for (int i = 0; i < s.size(); i++) {
		if ('A' <= s[i] && s[i] <= 'Z') order += s[i];
		else sum += s[i] - '0';
	}

	sort(order.begin(), order.end());
	cout << order << sum << '\n';

	return 0;
}