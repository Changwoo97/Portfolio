#include <iostream>
#include <vector>
using namespace std;

int n, m;
vector<int> k;

int main() {
	cin >> n >> m;
	for (int i = 0; i < n; i++) {
		int temp;
		cin >> temp;
		k.push_back(temp);
	}

	int result = 0;
	for (int i = 0; i < n - 1; i++) {
		for (int j = i + 1; j < n; j++) {
			if (k[i] != k[j]) result++;
		}
	}

	cout << result << '\n';

	return 0;
}