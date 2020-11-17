#include <iostream>
using namespace std;

int index_min(int* array, int length)
{
    int result = array[0], result_i = 0;
    for (int i = 0; i < length; ++i)
    {
        if (array[i] < result)
        {
            result = array[i];
            result_i = i;
        }
    }
    return result_i;
}

void selection_sort(int* array, const int size)
{
    for (int i = 0; i < size - 1; i++)
    {
        int index_of_min = i;
        index_of_min = index_min(array + i, size - i) + i;

        if (index_of_min != i)
        {
            swap(array[i], array[index_of_min]);
        }
    }
    return;
}

int main()
{
    int* array = new int[5]{5,7,2,9,1};
    selection_sort(array, 5);
    for (int i = 0; i < 5; ++i)
    {
        cout << array[i];
    }
    return 0;
}