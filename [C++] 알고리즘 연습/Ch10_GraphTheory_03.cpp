#include <iostream>
#include <vector>
#include <queue>
using namespace std;

int n, m;
priority_queue<pair<int, pair<int, int>>> pq;
priority_queue<int> pq2;

int roots[100001];

int findRoot(int x) {
	if (x == roots[x]) return x;
	return roots[x] = findRoot(roots[x]);
}

void unionRoot(int a, int b) {
	a = findRoot(a);
	b = findRoot(b);
	if (a <= b) roots[b] = a;
	else roots[a] = b;
}

int main() {
	cin >> n >> m;
	for (int i = 0; i < m; i++) {
		int a, b, c;
		cin >> a >> b >> c;
		pq.push({ -c, {a, b} });
	}

	for (int i = 1; i <= n; i++) roots[i] = i;

	int result = 0;
	while (!(pq.empty())) {
		int cost = -(pq.top().first);
		int a = pq.top().second.first;
		int b = pq.top().second.second;
		pq.pop();

		if (findRoot(a) != findRoot(b)) {
			unionRoot(a, b);
			result += cost;
			pq2.push(cost);
		}
	}

	result -= pq2.top();
	cout << result << '\n';

	return 0;
}