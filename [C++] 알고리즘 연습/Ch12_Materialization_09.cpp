#include <string>
#include <vector>
#include <algorithm>
using namespace std;

int solution(string s) {
    int result = s.size();

    for (int i = 1; i <= s.size() / 2; i++) {
        vector<string> v;
        for (int j = 0; j < s.size() / i; j++) {
            v.push_back(s.substr(i * j, i));
        }

        int press = s.size();
        int repeat = 1;
        int position = 1;
        for (int j = 0; j < v.size() - 1; j++) {
            if (v[j] == v[j + 1]) {
                press -= i;
                int position_num = to_string(++repeat).size();
                if (repeat == 2 || position_num > position) {
                    press++;
                    position = position_num;
                }
            }
            else {
                repeat = 1;
                position = 1;
            }
        }
        result = min(result, press);
    }

    return result;
}