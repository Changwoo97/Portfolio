#include <iostream>
#include <vector>
#include <queue>
using namespace std;

int n;

vector<int> graph[501];
int times[501];
int indegrees[501];

int main() {
	cin >> n;
	for (int i = 1; i <= n; i++) {
		int time;
		cin >> time;
		times[i] = time;

		while (true) {
			int node;
			cin >> node;

			if (node == -1) break;

			graph[node].push_back(i);
			indegrees[i]++;
		}
	}

	vector<int> results(501);
	queue<int> q;

	for (int i = 1; i <= n; i++)
		results[i] = times[i];

	for (int i = 1; i <= n; i++)
		if (indegrees[i] == 0) q.push(i);

	while (!q.empty()) {
		int idx = q.front();
		q.pop();

		for (int i = 0; i < graph[idx].size(); i++) {
			results[graph[idx][i]] =
				max(results[graph[idx][i]], results[idx] + times[graph[idx][i]]);
			if (--indegrees[graph[idx][i]] == 0)
				q.push(graph[idx][i]);
		}
	}

	for (int i = 1; i <= n; i++)
		cout << results[i] << '\n';

	return 0;
}