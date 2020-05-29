
template <typename T>
class BinaryTree
{
public:
	BinaryTree()
	{
		Root = nullptr;
	}
	void Add(T Data)
	{
		if (Root == nullptr) Root = new Nod(Data);
	}
private:
	template <typename T>
	class Nod
	{
	public:
		T Data;
		Nod* pLeft;
		Nod* pRight;
		Nod(T Data)
		{
			this->Data = Data;
		}
	};
	Nod* Root;
};

