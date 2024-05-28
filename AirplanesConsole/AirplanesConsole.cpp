// AirplanesConsole.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>
#include <vector> v
using namespace std;

enum Type
{
    Passanger = 0,
    Transport = 1,
};

struct Airplane
{
    int number;
    Type type;
    string model;
    double massUp;
    int pathToFlight;
    
    // Конструктор по умолчанию
    Airplane() : number(0), type(Passanger), model(""), massUp(0.0), pathToFlight(0) {}

    Airplane(int n, Type t, string m, double mass, int p) {
        number = n;
        type = t;
        model = m;
        massUp = mass;
        pathToFlight = p;
    }
};


struct Node
{
    Airplane value;
    Node* next;
    Node* prev;

    Node() : value(), next(nullptr), prev(nullptr) {}
};

struct List 
{
    Node* first;
    Node* last;
    
    List() {
        first = last = NULL;
    }

    Node* add(Airplane a) {
        Node* newNode = new Node();
        newNode->value = a;

        if (first == nullptr) {
            // Если список пустой
            first = last = newNode;
        }
        else if (a.number <= first->value.number) {
            // Вставка в начало списка
            newNode->next = first;
            first->prev = newNode;
            first = newNode;
        }
        else if (a.number >= last->value.number) {
            // Вставка в конец списка
            newNode->prev = last;
            last->next = newNode;
            last = newNode;
        }
        else {
            // Вставка в середину списка
            Node* current = first;
            while (current->next != nullptr && current->next->value.number < a.number) {
                current = current->next;
            }
            newNode->next = current->next;
            newNode->prev = current;
            if (current->next != nullptr) {
                current->next->prev = newNode;
            }
            current->next = newNode;
        }
        return newNode;
    }

    Node* push_back(Airplane a) {
        Node* newNode = new Node();
        newNode->value = a;

        newNode->prev = last;
        newNode->next = nullptr;

        if (last != NULL) {
            last->next = newNode;
        }

        if (first == NULL) {
            first = newNode;
        }

        last = newNode;
        return newNode;
    }
};

int main()
{
    List list;

    list.add(Airplane(123, Passanger, "airbus", 11.2, 14123));
    list.add(Airplane(4443, Transport, "boing", 222.2, 100));
    list.add(Airplane(349, Passanger, "zhopa", 0.2, 8));

    for(Node* ptr = list.first; ptr != NULL; ptr = ptr->next)
    {
        cout << ptr->value.number << " " << ptr->value.model << " " << ptr->value.massUp << " " << ptr->value.type << " " << ptr->value.pathToFlight << " ";
    }

    cout << endl;
}

// Запуск программы: CTRL+F5 или меню "Отладка" > "Запуск без отладки"
// Отладка программы: F5 или меню "Отладка" > "Запустить отладку"

// Советы по началу работы 
//   1. В окне обозревателя решений можно добавлять файлы и управлять ими.
//   2. В окне Team Explorer можно подключиться к системе управления версиями.
//   3. В окне "Выходные данные" можно просматривать выходные данные сборки и другие сообщения.
//   4. В окне "Список ошибок" можно просматривать ошибки.
//   5. Последовательно выберите пункты меню "Проект" > "Добавить новый элемент", чтобы создать файлы кода, или "Проект" > "Добавить существующий элемент", чтобы добавить в проект существующие файлы кода.
//   6. Чтобы снова открыть этот проект позже, выберите пункты меню "Файл" > "Открыть" > "Проект" и выберите SLN-файл.
