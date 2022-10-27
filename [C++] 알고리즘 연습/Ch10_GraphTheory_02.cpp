#include <iostream>
#include <vector>
using namespace std;

int n, m;
vector<pair<int, pair<int, int>>> opers;

int roots[100001];
bool results[100001];

int findRoot(int node) {
	if (node == roots[node]) return node;
	return roots[node] = findRoot(roots[node]);
}

void unionRoot(int nodeA, int nodeB) {
	nodeA = findRoot(nodeA);
	nodeB = findRoot(nodeB);

	if (nodeA <= nodeB) roots[nodeB] = nodeA;
	else roots[nodeA] = nodeB;
}

int main() {
	cin >> n >> m;
	for (int i = 0; i < m; i++) {
		int oper, nodeA, nodeB;
		cin >> oper >> nodeA >> nodeB;
		opers.push_back({ oper, {nodeA, nodeB} });
	}

	for (int i = 1; i <= n; i++) roots[i] = i;

	int count = 0;
	for (int i = 0; i < m; i++) {
		int oper = opers[i].first;
		int nodeA = opers[i].second.first;
		int nodeB = opers[i].second.second;

		if (oper == 0)
			unionRoot(nodeA, nodeB);
		else {
			if (findRoot(nodeA) == findRoot(nodeB))
				results[count++] = true;
			else
				results[count++] = false;
		}
	}

	for (int i = 0; i < count; i++)
		cout << (results[i] ? "Yes" : "No") << '\n';

	return 0;
}