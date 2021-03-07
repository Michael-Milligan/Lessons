#include <iostream>

class MyArray
{
    private:
    int* data;
    int count; // number of our elements
    int capacity; // number of all cells

    public:
    MyArray(int capacity = 5)
    {
        this->capacity = capacity;
        data = new int[capacity];
    }

    void push_back(int number)
    {
        if (count < capacity) data[count++] = number;
        else
        {
            int* temp = new int[capacity + 1];
            for(int i = 0; i < capacity; ++i) temp[i] = data[i];
            temp[count++] = number;
            ++capacity;
            data = temp;
        }
    }

    int element_at(int index) { return data[index]; }
    int set_element_at(int index, int number) { data[index] = number; }
};

int main(int argc, char *argv[])
{
    MyArray a;
    
}