#include <iostream>
using namespace std;

struct Polynom
{
    int pow;  
    int coef; 
    Polynom* pNext;  
};

void AddElement(Polynom*& head, int step,int coef, int position);

void RemoveElement(Polynom*& head, int position);

void Destroy(Polynom* head);

void Print(Polynom* head);

void Fill(Polynom*& head);

Polynom* Find(Polynom*& head, int pow);

Polynom* Sum(Polynom*& first, Polynom*& second);

int get_length(const Polynom* head)
{
    int count = 0;
    auto current = head;
    while(current != 0)
    {
        current = current->pNext;
        ++count;
    }
    return count;
}

Polynom* Multiplication(Polynom*& first, Polynom*& second)
{
    Polynom* result = new Polynom();
    auto i1 = first, i2 = second;
    int a = get_length(first);
    Polynom** terms = new Polynom*[get_length(first)];
    for(int j = 0; j < get_length(first); ++j) terms[j] = new Polynom();
    int i = 0;
    while(i1 != 0)
    {
        i2 = second;
        while(i2 != 0)
        {
            AddElement(terms[i], i2->coef, i2->pow, 0);
            i2 = i2->pNext;
        }
        RemoveElement(terms[i], get_length(terms[i]) - 1);
        i2 = terms[i];
        while(i2 != 0)
        {
            i2->coef *= i1->coef;
            i2->pow += i1->pow;
            i2 = i2->pNext;
        }
        i1 = i1->pNext;
        ++i;
    }
    for(i = 0; i < get_length(first) - 1; ++i)
    {
        //Sum(terms[i], result);
        Print(terms[i]);
    }
    return result;
}

int main(int argc, char *argv[])
{
    Polynom* head1 = NULL;
    Polynom* head2 = NULL;
    Polynom* head3 = NULL;
    Fill(head1);
    Print(head1);
    Fill(head2);
    Print(head2);
    //Fill(head3);
    //Print(head3);

    auto multi = Multiplication(head1, head2);
    Print(multi);

    Destroy(head1);
    Destroy(head2);
    //Destroy(head3);
    return 0;
}

void Destroy(Polynom* head)
{
    while (head != NULL)
    {
        Polynom* help = head;
        head = head->pNext;
        delete help;
    }
}

void Fill(Polynom*& head)
{
    cout << "Enter the number of terms" << endl;
    int n;
    cin >> n;
    for (int i = 0; i < n; i++)
    {
        Polynom* help = new Polynom;
        cout << "Enter the coefficient of term then the degree" << endl;
        int coef, pow;
        cin >> coef >> pow;
        Polynom* a = Find(head, pow);
        if (a != NULL)
        {
            a->coef += coef;
            help = help->pNext;
            continue;
        }
        help->coef = coef;
        help->pow = pow;
        help->pNext = head;
        head = help;
    }
}

Polynom* Sum(Polynom*& first, Polynom*& second)
{
    Polynom* result = NULL;
    Polynom* current = first;
    while (current != NULL)
    {
        AddElement(result, current->coef, current->pow, 0);
        current = current->pNext;
    }

    current = second;
    while(current != NULL)
    {
        auto temp = Find(result, current->pow);
        if(temp != 0)
        {
            temp->coef += current->coef;
            current = current->pNext;
            continue;
        }
        AddElement(result, current->coef, current->pow, 0);
        current = current->pNext;
    }
    delete current;
    return result;
}

Polynom* Find(Polynom*& head, int pow)
{
    if (head == NULL)
    {
        return NULL;
    }
    Polynom* current = head;
    do 
    {
        if (current->pow == pow)
        {
            return current;
        }
        current = current->pNext;
    } while (current != NULL);
    return NULL;
}


void AddElement(Polynom*& head, int coef, int pow, int position)
{
    if (position == 0)
    {
        Polynom* help = new Polynom;
        help->pow = pow;
        help->coef = coef;
        help->pNext = head;
        head = help;
        return;
    }
    
    Polynom* cur = head;
    int i = 0;
    while (cur != NULL && i != position - 1)
    {
        i++;
        cur = cur->pNext;
    }

    if (cur == NULL)
    {
        return;
    }
    Polynom* help = new Polynom;
    help->pow = pow;
    help->coef = coef;
    help->pNext = cur->pNext;
    cur->pNext = help;
}

void Print(Polynom* head)
{
    Polynom* cur;
    for (cur = head; cur->pNext != NULL; cur = cur->pNext)
    {
        cout << cur->coef << "x^" << cur->pow << " + ";
    }
    cout << cur->coef << "x^" << cur->pow << endl;
}

void RemoveElement(Polynom*& head, int p)
{
    if (p == 0)
    {
        Polynom* help = head;
        head = head->pNext;
        delete help;
        return;
    }

    Polynom* cur = head;
    int i = 0;
    while (cur != NULL && i != p - 1)
    {
        i++;
        cur = cur->pNext;
    }

    if (cur->pNext == NULL)
    {
        return;
    }
    Polynom* help = cur->pNext;
    cur->pNext = help->pNext;
    delete help;
}