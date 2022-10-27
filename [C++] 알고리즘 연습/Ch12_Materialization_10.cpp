#include <string>
#include <vector>
using namespace std;

void rotate(vector<vector<int>>* v) {
    vector<vector<int>> result(v->size(), vector<int>(v->size()));
    for (int i = 0; i < v->size(); i++) {
        for (int j = 0; j < v->size(); j++) {
            result[j][v->size() - i - 1] = (*v)[i][j];
        }
    }
    *v = result;
}

bool check(vector<vector<int>>* v) {
    int count = v->size() / 3 * 2;
    for (int i = v->size() / 3; i < count; i++) {
        for (int j = v->size() / 3; j < count; j++) {
            if ((*v)[i][j] != 1) return false;
        }
    }
    return true;
}

bool solution(vector<vector<int>> key, vector<vector<int>> lock) {
    vector<vector<int>> v(lock.size() * 3, vector<int>(lock.size() * 3));
    for (int i = 0; i < lock.size(); i++) {
        for (int j = 0; j < lock.size(); j++) {
            v[lock.size() + i][lock.size() + j] = lock[i][j];
        }
    }

    for (int rot = 0; rot < 4; rot++) {
        for (int x = 0; x < lock.size() * 2; x++) {
            for (int y = 0; y < lock.size() * 2; y++) {
                for (int i = 0; i < key.size(); i++) {
                    for (int j = 0; j < key.size(); j++) {
                        v[x + i][y + j] += key[i][j];
                    }
                }
                if (check(&v)) return true;
                for (int i = 0; i < key.size(); i++) {
                    for (int j = 0; j < key.size(); j++) {
                        v[x + i][y + j] -= key[i][j];
                    }
                }
            }
        }
        rotate(&key);
    }
    return false;
}