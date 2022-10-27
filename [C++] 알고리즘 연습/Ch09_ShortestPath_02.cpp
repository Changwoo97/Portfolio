#include <iostream>
#include <vector>
#include <queue>
using namespace std;

int n, m;
vector<int> graph[101];
int x, k;

int d[101];

int dijsktra(int start, int end) {
	fill(d, d + 101, -1);
	d[start] = 0;

	priority_queue<pair<int, int>> pq;
	pq.push({ -d[start], start });

	while (!(pq.empty())) {
		int time = -(pq.top().first);
		int node = pq.top().second;
		pq.pop();

		for (int i = 0; i < graph[node].size(); i++) {
			int newTime = time + 1;
			if (d[graph[node][i]] < 0 || newTime < d[graph[node][i]]) {
				d[graph[node][i]] = newTime;
				pq.push({ -d[graph[node][i]], graph[node][i] });
			}
		}
	}

	return d[end];
}

int main() {
	cin >> n >> m;

	for (int i = 0; i < m; i++) {
		int a, b;
		cin >> a >> b;
		graph[a].push_back(b);
		graph[b].push_back(a);
	}

	cin >> x >> k;

	int first = dijsktra(1, k);
	int second = dijsktra(k, x);

	if (first < 0 || second < 0)
		cout << -1;
	else
		cout << first + second;
	cout << '\n';

	return 0;
}