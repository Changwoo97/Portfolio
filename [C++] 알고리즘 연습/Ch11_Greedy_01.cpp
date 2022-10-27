#include <iostream>
#include <algorithm>
using namespace std;

int n;
int d[100000];

int main() {
	cin >> n;
	for (int i = 0; i < n; i++) {
		int a;
		cin >> a;
		d[i] = -a;
	}

	sort(d, d + 100000);

	int result = 0;
	for (int i = 0; i < n;) {
		if (n - i >= -d[i])
			result++;
		i += -d[i];
	}

	cout << result << '\n';

	return 0;
}