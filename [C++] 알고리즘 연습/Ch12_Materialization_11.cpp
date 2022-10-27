#include <iostream>
#include <vector>
#include <queue>
#include <deque>
using namespace std;

enum { Left = 'L', Right = 'D' };
const vector<pair<int, int>> Directions = { { 0, 1 }, { -1, 0 }, { 0, -1 }, { 1, 0 } };
int dir = 0;

int n, k, l;
vector<pair<int, int>> apples;
queue<pair<int, char>> directions;
deque<pair<int, int>> snake;

int timer = 0;

pair<int, int> operator+ (const pair<int, int>& lhs, const pair<int, int>& rhs) {
	return { lhs.first + rhs.first, lhs.second + rhs.second };
}

bool touch() {
	bool outOfRow = snake.back().first < 1 || n < snake.back().first;
	bool outOfColumn = snake.back().second < 1 || n < snake.back().second;
	if (outOfRow || outOfColumn) return true;

	for (int i = 0; i < snake.size() - 1; i++) {
		if (snake.back() == snake[i]) {
			return true;
		}
	}
	return false;
}

bool apple() {
	for (vector<pair<int, int>>::iterator iter = apples.begin(); iter != apples.end(); ++iter) {
		if (snake.back() == *iter) {
			apples.erase(iter);
			return true;
		}
	}
	return false;
}

void renewDir() {
	if (!directions.empty() && timer == directions.front().first) {
		switch (directions.front().second) {
		case Left:
			if (Directions.size() <= ++dir) dir = 0;
			break;
		case Right:
			if (--dir < 0) dir = Directions.size() - 1;
			break;
		}
		directions.pop();
	}
}

int main() {
	cin >> n >> k;
	for (int i = 0; i < k; i++) {
		int row, column;
		cin >> row >> column;
		apples.push_back({ row, column });
	}
	cin >> l;
	for (int i = 0; i < l; i++) {
		int x;
		char c;
		cin >> x >> c;
		directions.push({ x, c });
	}

	snake.push_back({ 1, 1 });
	while (true) {
		timer++;
		snake.push_back(snake.back() + Directions[dir]);
		if (touch()) {
			break;
		}
		if (!apple()) {
			snake.pop_front();
		}
		renewDir();
	}

	cout << timer << endl;

	return 0;
}