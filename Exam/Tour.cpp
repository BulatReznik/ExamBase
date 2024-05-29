#include <iostream>
#include <string>
#include <string.h>

class Tour {
public:
	int id;
	std::string name;
	std::string country;
	std::string responsiblePerson;

	Tour(int _id, const std::string& _name, const std::string& _country, const std::string& _responsiblePerson)
		: id(_id), name(_name), country(_country), responsiblePerson(_responsiblePerson) {}
};

struct Node {
	Tour* data;
	Node* prevNode;
	Node* nextNode;

	Node(Tour* _tour)
		: data(_tour), prevNode(nullptr), nextNode(nullptr) {}
};

struct List {
	Node* first;
	Node* last;

	List() : first(nullptr), last(nullptr) {}

	bool is_empty() const {
		return first == nullptr;
	}

	void add(Tour* newTour) {
		Node* newNode = new Node(newTour);

		if (is_empty()) {
			first = newNode;
			last = newNode;
		}
		else {
			Node* current = first;
			Node* previous = nullptr;

			// Поиск позиции для вставки
			while (current != nullptr && current->data->id < newTour->id) {
				previous = current;
				current = current->nextNode;
			}

			//Вставка в начало
			if (previous == nullptr) {
				newNode->nextNode = first;
				first->prevNode = newNode;
				first = newNode;
			}
			// Вставка в конец
			else if (current == nullptr)
			{
				previous->nextNode = newNode;
				newNode->prevNode = previous;
				last = newNode;
			}
			// Вставка в середину
			else
			{
				previous->nextNode = newNode;
				newNode->prevNode = previous;
				newNode->nextNode = current;
				current->prevNode = newNode;
			}
		}
	}

	void print_list() {
		Node* current = first;
		while (current != nullptr)
		{
			std::cout << "ID: " << current->data->id
				<< "\nName: " << current->data->name
				<< "\nCountry: " << current->data->country
				<< "\nResponsible Person: " << current->data->responsiblePerson << "\n"
				<< std::endl;

			current = current->nextNode;
		}
	}
};

/*
int main() {
	List tourList;

	Tour* tour1 = new Tour(1, "123", "123", "123");
	Tour* tour2 = new Tour(2, "123", "123", "123");
	Tour* tour3 = new Tour(3, "123", "123", "123");
	Tour* tour4 = new Tour(4, "123", "123", "123");
	Tour* tour5 = new Tour(5, "123", "123", "123");

	tourList.add(tour4);
	tourList.add(tour3);
	tourList.add(tour2);
	tourList.add(tour1);
	tourList.add(tour5);

	tourList.print_list();

	return 0;
}
*/