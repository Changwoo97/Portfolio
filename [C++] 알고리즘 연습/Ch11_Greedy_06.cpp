#include <iostream>
#include <vector>
#include <queue>
#include <algorithm>
using namespace std;

bool compare(pair<int, int> a, pair<int, int> b) {
    return a.second < b.second;
}

int solution(vector<int> food_times, long long k) {
    long long sum = 0;
    for (int i = 0; i < food_times.size(); i++) {
        sum += food_times[i];
    }
    if (sum <= k) return -1;

    priority_queue<pair<int, int>> pq;
    for (int i = 0; i < food_times.size(); i++) {
        pq.push({ -food_times[i], i + 1 });
    }

    sum = 0;
    int previous = 0;
    while (true) {
        long long oper = sum + (-pq.top().first - previous) * pq.size();
        if (oper > k) break;

        previous = -pq.top().first;
        sum = oper;
        pq.pop();
    }

    vector<pair<int, int>> v;
    while (!pq.empty()) {
        v.push_back({ -pq.top().first, pq.top().second });
        pq.pop();
    }
    sort(v.begin(), v.end(), compare);

    return v[(k - sum) % v.size()].second;
}