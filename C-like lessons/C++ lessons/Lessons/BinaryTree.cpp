#include "BinaryTree.h"
#include <memory>

template <typename T>
void binary_tree<T>::push(T Data)
{
	auto current = this->root;
	bool is_not_pushed = false;
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
	}
}

template<typename T>
void binary_tree<T>::erase(T Data)
{
}