#include <iostream>
#include <vector>
#include <queue>
using namespace std;

const int INF = 1001;

int N, M, C;
vector<pair<int, int>> graph[30001];

int d[30001];

int main() {
	cin >> N >> M >> C;

	for (int i = 0; i < M; i++) {
		int X, Y, Z;
		cin >> X >> Y >> Z;
		graph[X].push_back({ Y, Z });
	}

	fill(d, d + 30001, INF);
	d[C] = 0;

	priority_queue<pair<int, int>> pq;
	pq.push({ -d[C], C });

	while (!(pq.empty())) {
		int time = -(pq.top().first);
		int node = pq.top().second;
		pq.pop();

		if (d[node] < time) continue;

		for (int i = 0; i < graph[node].size(); i++) {
			int newTime = time + graph[node][i].second;
			if (newTime < d[graph[node][i].first])
			{
				d[graph[node][i].first] = newTime;
				pq.push({ -d[graph[node][i].first], graph[node][i].first });
			}
		}
	}

	int count = 0, time = 0;
	for (int i = 1; i <= N; i++) {
		if (0 < d[i] && d[i] < INF) count++;
		if (time < d[i]) time = d[i];
	}

	cout << count << ' ' << time << '\n';

	return 0;
}