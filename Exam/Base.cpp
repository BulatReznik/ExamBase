#include <iostream>
#include <string>
#include <string.h>

struct Node {
	std::string data;
	Node* prevNode;
	Node* nextNode;

	Node(std::string _data) : data(_data), prevNode(nullptr), nextNode(nullptr) {}
};

struct List {
	Node* first;
	Node* last;

	List() : first(nullptr), last(nullptr) {}

	bool is_empty() {
		return first == nullptr;
	}

	void add(const std::string& dataue) {
		Node* newNode = new Node(dataue);

		// Если список пустой, добавляем первый элемент
		if (is_empty()) {
			first = newNode;
			last = newNode;
		}
		else {
			Node* current = first;
			Node* previous = nullptr;

			// Поиск позиции для вставки
			while (current != nullptr && current->data < dataue) {
				previous = current;
				current = current->nextNode;
			}

			// Вставка в начало списка
			if (previous == nullptr) {
				newNode->nextNode = first;
				first->prevNode = newNode;
				first = newNode;
			}
			// Вставка в конец списка
			else if (current == nullptr) {
				previous->nextNode = newNode;
				newNode->prevNode = previous;
				last = newNode;
			}
			// Вставка в середину списка
			else {
				previous->nextNode = newNode;
				newNode->prevNode = previous;
				newNode->nextNode = current;
				current->prevNode = newNode;
			}
		}
	}

	void print_list() {
		Node* current = first;
		while (current != nullptr) {
			std::cout << current->data << " ";
			current = current->nextNode;
		}
		std::cout << std::endl;
	}
};


int main() {
	List list;
	list.add("banana");
	list.add("apple");
	list.add("cherry");
	list.add("date");

	list.print_list(); 

	return 0;
}