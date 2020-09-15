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
	class node;
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
			root = new node();
			root->data = Data;
			return;
		}
		while (is_not_pushed)
		{
			if (Data < current->data)
			{
				if (current->pLeft != nullptr)
					current = current->pLeft;
				else
				{
					current->pLeft = new node();
					current->pLeft->data = Data;
					is_not_pushed = false;
				}
			}
			else if (Data > current->data)
			{
				if (current->pRight != nullptr)
					current = current->pRight;
				else
				{
					current->pRight = new node();
					current->pRight->data = Data;
					is_not_pushed = false;
				}
			}
			else return;
		}
	}

	/// <summary>
	/// Tries to delete the given value, if the value isn't in tree function throws exception
	/// </summary>
	/// <param name="Data"></param>
	void erase(T Data)
	{
		auto to_delete = search(Data);
		if (to_delete == nullptr) throw exception("The element isn't in tree");

		if (to_delete->pRight == nullptr && to_delete->pLeft == nullptr) delete to_delete;

		if (to_delete->pRight == nullptr && to_delete->pLeft != nullptr || to_delete->pRight != nullptr && to_delete->pLeft == nullptr)
		{
			if (to_delete->pRight == nullptr)
			{
				to_delete->data = to_delete->pLeft->data;
				delete to_delete->pLeft;
				to_delete->pLeft = nullptr;
			}
			else
			{
				to_delete->data = to_delete->pRight->data;
				delete to_delete->pRight;
				to_delete->pRight = nullptr;
			}
		}

		else
		{
			auto current = root;
			auto previous = root;
			while (current->pLeft != nullptr)
			{
				previous = current;
				current = current->pLeft;
			}
			to_delete->data = current->data;
			delete current;
			previous->pLeft = nullptr;
		}
	}
	node* search(T Data)
	{
		node* current = root;
		while (current->data != Data && current != nullptr)
		{
			if (Data > current->data) current = current->pRight;
			else current = current->pLeft;
		}
		return current;
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
	class node
	{
	public:
		T data;
		node()
		{
			pLeft = nullptr;
			pRight = nullptr;
		}
		~node()
		{
			delete pLeft;
			delete pRight;
		}
		node* pLeft;
		node* pRight;
	};
	node* root;

	int getHeight(node* node) {
		if (!node) return 0;
		return 1 + max(getHeight(node->pLeft), getHeight(node->pRight));
	}
	void fill(node* node, vector<vector<T>>& ret, int lvl, int l, int r) {
		if (!node || node->data == 0)return;
		ret[lvl][(l + r) / 2] = node->data;
		fill(node->pLeft, ret, lvl + 1, l, (l + r) / 2);
		fill(node->pRight, ret, lvl + 1, (l + r + 1) / 2, r);
	}
public:
	vector<vector<T>> printTree() {
		node* root = this->root;
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
