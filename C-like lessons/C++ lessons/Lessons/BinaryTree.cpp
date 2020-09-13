#include <memory>
#include <vector>
#include <string>
using namespace std;

/// <summary>
/// The binary tree with unique elements
/// </summary>
/// <typeparam name="T"></typeparam>
template <typename T>
class binary_tree
{
public:
	/// <summary>
	/// Tries to push the data through the tree, if not succeeded makes nothing
	/// </summary>
	/// <param name="Data: ">The data to add to the tree</param>
	void push(T Data)
	{
		auto current = this->root;
		bool is_not_pushed = true;
		if (root == nullptr)
		{
			root = new Node();
			root->data = Data;
			return;
		}
		while (is_not_pushed)
		{
			if (Data > current->data)
			{
				if (current->pLeft != nullptr)
					current = current->pLeft;
				else
				{
					current->pLeft = new Node();
					current->pLeft->data = Data;
					is_not_pushed = false;
				}
			}
			else if (Data < current->data)
			{
				if (current->pRight != nullptr)
					current = current->pRight;
				else
				{
					current->pRight = new Node();
					current->pRight->data = Data;
					is_not_pushed = false;
				}
			}
			else return;
		}
	}

	void erase(T Data)
	{

	}
	binary_tree()
	{
		root = nullptr;
	}
	~binary_tree()
	{

	}
private:
	/// <summary>
	/// The class of elements of the binary tree
	/// </summary>
	class Node
	{
	public:
		T data;
		Node()
		{
			pLeft = nullptr;
			pRight = nullptr;
		}
		~Node()
		{
			delete pLeft;
			delete pRight;
		}
		Node* pLeft;
		Node* pRight;
	};
	Node* root;

	int getHeight(Node* node) {
		if (!node) return 0;
		return 1 + max(getHeight(node->pLeft), getHeight(node->pRight));
	}
	void fill(Node* node, vector<vector<T>>& ret, int lvl, int l, int r) {
		if (!node || node->data == 0)return;
		ret[lvl][(l + r) / 2] = node->data;
		fill(node->pLeft, ret, lvl + 1, l, (l + r) / 2);
		fill(node->pRight, ret, lvl + 1, (l + r + 1) / 2, r);
	}
public:
	vector<vector<T>> printTree() {
		Node* root = this->root;
		int h = getHeight(root);
		int leaves = (1 << h) - 1;
		vector<vector<T>> ret (h, vector <T>(leaves));
		fill(root, ret, 0, 0, leaves);
		return ret;
	}
	int max(int first_number, int second_number)
	{
		return first_number > second_number ? first_number : second_number;
	}
};
