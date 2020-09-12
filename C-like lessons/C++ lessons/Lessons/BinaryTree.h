#pragma once

template <typename T>
class binary_tree
{
public:
	void push(T Data);
	
	void erase(T Data);
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

