# LinkedIn course summary

## C# Design principles

Loose coupling: makes sure that two different classes aren't dependent on one another, which prevents code breaks when changes are made on one of the classes.
Program to interfaces, not implementations: encourages the use of abstract classes, not concrete classes. This helps with exploiting polymorphism, and prevents unneccesary work when the concrete class that is used, is changed.
Signle responsibility principle: limit the impact of change, by giving every class a single responsibility that can be changed. And change only matters when change actually happens, not hypothetical
Open/closed principle: allow new additions without allowing changes to the concrete class. This works best with composition over inheritance, since you can give the concrete class behaviour with the HAS-A statement
Liskov substitution: subclasses should always be substitutable with their super class
Interface segregation: classes should never be reliant on methods that they don't use, seperate interface classes that serve different functions, so that the interface does not get polluted with methods that don't get used
Dependency inversion: high-level modules should not depend on low-level modules, they should both depend on abstractions. Abstractions should not depend on details, but the other way around

## C# Interfaces and generics

Interfaces: determines behaviour instead of objects, that other classes can inherit from. They contain no code themselves. Interfaces can be used multiple times, and one class can use multiple interfaces as well
the "is" keyword is used to check wether an object is an instance of, or is derived from a certain class
the "as" keyword makes sure a new object is created from another object, as another class which the object has inherited from
When using the same method name multiple times, an interface reference is required in front of the method to implement the method. When calling the methods, the instance of the class has to be casted as the interface to correctly follow the desired method
.NET has several built-in interfaces that can be used to give classes certain useful functions, such as a notifier when a property is changed
Generics: restricts data structures (such as arrays) to accept certain types of variables
List is a unique type of array, where the inserted data has to follow a predetermined rule which type the data is of. It also dynamically updates it's capacity with each item added
List has many different functions that are useful to have access to, such as Count, Find, Add and Remove
Stack uses the last in, first out principle to store and remove data
Queue uses the first in, first out principle to store and remove data
They both have overlapping functions, such as Contains and Count, and differing functions, such as Pop and Push for stack, and Enqueue and Dequeue for queue
Dictionary gives a way to associate keys with individual values. There can be multiple keys with the same value, but not the other way around
Dictionary has the Count method, as well as a few different ones like ContainsKey, ContainsValue, Add and Remove

## C# Data structures

Strings cannot be modified once they are created; immutable
Arrays are contiguous storage in memory of the same variable type
Tuples are used to group together multiple data elements without having to define a class
Contains checks for presence of a certain value in a List, Exists does checking for conditions, like string length, to figure out whether or not something exists in the list that the user is looking for
Find and FindAll can be used to check a value of something in a list, instead of returning a boolean
TrueForAll returns true when every value in a list meets a certain requirement
LinkedList works in sequence, instead of with an index like List
LinkedListNodes are points in a linked list that are set by the user, and any value can be added, removed or checked before and after these nodes
Lists vs LinkedList: Lists are faster at looking up items, as well as adding items at the end of the list. LinkedList is best used when adding / removing items from the last and first positions of the list
Stack, queue and dictionary are already covered in [C# Interfaces and generics](https://suuleewooyaa34-propedeuse-hbo-ict-onderwijs-2023-379a4339aa11c7.dev.hihva.nl/Tijn/LinkedIn-summary/#c-interfaces-and-generics)
ListDictionary implements a dictionary as a linked list, which is faster up to about 100 elements
HybridDictionary starts out as a ListDictionary, until that is no longer faster, and then switches to a Dictionary
OrderedDictionary keeps entries in the dictionary in order of when they were added
StringCollection is used to modify and manipulate groups of string objects. It is also indexed like an array
StringBuilder is more efficient at modifying strings multiple times than string functions