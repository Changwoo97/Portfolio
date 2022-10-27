#include <iostream>
#include <algorithm>
using namespace std;

int n, coins[1001];

int main() {
	cin >> n;
	for (int i = 0; i < n; i++) {
		cin >> coins[i];
	}
	sort(coins, coins + 1001);

	int result = 1;
	for (int i = 0; i < n; i++) {
		if (result < coins[i]) break;
		result += coins[i];
	}

	cout << result << '\n';

	return 0;
}