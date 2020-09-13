#include <memory>

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
};
