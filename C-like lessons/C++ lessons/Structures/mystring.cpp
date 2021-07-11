#include <vector>
#include <string>
#include <stdexcept>
#include <iostream>
#define DEBUG

class mystring
{
    private:
    std::vector<char> data;

    public:
    mystring()
    {
        this->data = std::vector<char>();
    }
    mystring(char* string)
    {
        int i = 0;
        while(string[i] != '\0')
        {
            data.push_back(string[i]);
            ++i;
        }
    }
    mystring(const char* string)
    {
        int i = 0;
        while(string[i] != '\0')
        {
            data.push_back(string[i]);
            ++i;
        }
    }

    const char* toString()
    {
        char* result = new char[data.size() + 1];
        for (int i = 0; i < data.size(); ++i)
        {
            result[i] = data[i];
        }
        result[data.size()] = '\0';
        return result;
    }

    int size()
    {
        return data.size();
    }

    char operator[](int i)
    { 
        if(i < data.size() && i >= 0)
        {
            return data[i]; 
        }
        else
        {
            throw std::out_of_range("index was bigger than size of string");
        }
    }

    mystring operator +(mystring secondString)
    {
        char* result = new char[data.size() + secondString.size() + 1];
        for (int i = 0; i < data.size(); ++i)
        {
            result[i] = data[i];
        }
        
        for (int i = data.size(), j = 0; i < data.size() + secondString.size(); ++i, ++j)
        {
            result[i] = secondString[j];
        }
        result[data.size() + secondString.size()] = '\0';
        return mystring(result);
    }

    mystring operator*(int multiplier)
    {
        int size = data.size() * multiplier + 1;
        char* result = new char[size];

        for (int i = 0, j = 0; i < size - 1; ++i, ++j)
        {
            if (i % data.size() == 0 && i != 0) j = 0;
            result[i] = data[j];
        }
        result[size - 1] = '\0';
        return result;
    }
};