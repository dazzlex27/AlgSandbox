#include <iostream>
#include <string>
#include <stack>
#include <map>

#define PRINT_SEQ_STATUS(seq)                                                  \
  std::cout << std::boolalpha << "is " << #seq                                 \
            << " correct: " << is_right_seq(seq) << std::endl;

bool is_right_seq(const std::string& seq) {

	std::stack<char> bracket_stack;

	std::map<char, char> br_map;
	br_map.emplace('(', ')');
	br_map.emplace('[', ']');
	br_map.emplace('{', '}');

	for (int i = 0; i < seq.size(); i++)
	{
		const char current_element = seq[i];

		if (br_map.count(current_element) == 0)
		{
			// found a closing bracket
			if (bracket_stack.empty())
			{
				// no more opening brackets left
				return false;
			}

			const char last_opening_bracket = bracket_stack.top();
			if (br_map[last_opening_bracket] != current_element)
			{
				// wrong closing bracket
				return false;
			}
			else
			{
				// removing last opening bracket, all good
				bracket_stack.pop();
			}
		}
		else
		{
			// adding a new opening bracket to the stack
			bracket_stack.push(current_element);
		}
	}

	if (bracket_stack.size() != 0)
		return false;

	return true;
}

int main() {
	std::string seq0 = "";
	std::string seq1 = "[[{([]))]]";
	std::string seq2 = "[[()[{}]()]]";
	std::string seq3 = "()[[()[{}]()]])";

	PRINT_SEQ_STATUS(seq0);
	PRINT_SEQ_STATUS(seq1);
	PRINT_SEQ_STATUS(seq2);
	PRINT_SEQ_STATUS(seq3);

	return 0;
}