# LinkedIn course summary

## C# Design principles

### Inleiding

Deze documentatie dient als leidraad om theoretische concepten in onder meer object georiënteerd programmeren, databases en infrastructuur te begrijpen en toe te passen. Het benadrukt de relevantie van theoretische kennis voor praktische toepassingen in je project en biedt een gestructureerde aanpak voor het documenteren van je voortgang.

### Samenvatting van de cursus in ongeveer 300 woorden
- Encapsulate what varies: when a certain block of code changes constantly, it is best to encapsulate that block of code to another class or method so there is less risk of the base code getting influenced by the changes, which would result in crashes.
- Favour composition over inheritance: inheritance is very useful to get classes to inherit from each other, but it can also cause some issues when changing the code in the class. In scenarios like these, and also some others, it is better to use composition, which follows the "HAS-A" principle instead of the "IS-A" that inheritance uses. "HAS-A" can be useful to give classes methods without having to inherit them from other classes.
- Loose coupling: makes sure that two different classes aren't dependent on one another, which prevents code breaks when changes are made on one of the classes.
- Program to interfaces, not implementations: encourages the use of abstract classes, not concrete classes. This helps with exploiting polymorphism, and prevents unnecessary work when the concrete class that is used is changed.
- Single responsibility principle: limit the impact of change, by giving every class a single responsibility that can be changed. And change only matters when change actually happens, not hypothetical.
- Open/closed principle: allow new additions without allowing changes to the concrete class. This works best with composition over inheritance, since you can give the concrete class behaviour with the HAS-A statement.
- Liskov substitution: subclasses should always be substitutable with their super class.
- Interface segregation: classes should never be reliant on methods that they don't use, separate interface classes that serve different functions, so that the interface does not get polluted with methods that don't get used.
- Dependency inversion: high-level modules should not depend on low-level modules, they should both depend on abstractions. Abstractions should not depend on details, but the other way around.

### Relevantie tot je project en praktische toepassing
[Leg uit hoe de theoretische concepten die in deze cursus worden behandeld direct of indirect verband houden met jouw project. Benadruk specifieke gebieden waar kennis die is opgedaan uit de cursus is toegepast of zal worden toegepast in het ontwikkelingsproces. Geef hier voorbeelden van en benoem hoe deze relevant zijn.]

### Resultaten LinkedIn Learning cursus
[Plak hier een screenshot of link naar het certificaat]

### Resultaten quiz op DLO
[Plak hier een screenshot van je quizresultaat]

### Vragen voor expert review
[Stel drie concrete vragen op die je tijdens de expert review wil behandelen. Deze vragen zijn gericht op het verkrijgen van feedback en inzichten van de beoordelaar.]

## C# Interfaces and generics

### Inleiding
Deze documentatie dient als leidraad om theoretische concepten in onder meer object georiënteerd programmeren, databases en infrastructuur te begrijpen en toe te passen. Het benadrukt de relevantie van theoretische kennis voor praktische toepassingen in je project en biedt een gestructureerde aanpak voor het documenteren van je voortgang.

### Samenvatting van de cursus in ongeveer 300 woorden
- Interfaces: determines behaviour instead of objects that other classes can inherit from. They contain no code themselves. Interfaces can be used multiple times, and one class can use multiple interfaces as well
- The "is" keyword is used to check whether an object is an instance of, or is derived from a certain class
- The "as" keyword makes sure a new object is created from another object, as another class which the object has inherited from
- When using the same method name multiple times, an interface reference is required in front of the method to implement the method.
- When calling the methods, the instance of the class has to be casted as the interface to correctly follow the desired method
- .NET has several built-in interfaces that can be used to give classes certain useful functions, such as a notifier when a property is changed
- Generics: restricts data structures (such as arrays) to accept certain types of variables
- List is a unique type of array, where the inserted data has to follow a predetermined rule which type the data is of. It also dynamically updates it's capacity with each item added
- List has many different functions that are useful to have access to, such as Count, Find, Add and Remove
- Stack is a type of list that uses the last in, first out principle to store and remove data
- Queue is a type of list that uses the first in, first out principle to store and remove data
- They both have overlapping functions, such as Contains and Count, and differing functions, such as Pop and Push for stack, and Enqueue and Dequeue for queue
- Dictionary gives a way to associate keys with individual values. There can be multiple keys with the same value, but not the other way around
- Dictionary has the Count method, as well as a few different ones like ContainsKey, ContainsValue, Add and Remove

### Relevantie tot je project en praktische toepassing
[Leg uit hoe de theoretische concepten die in deze cursus worden behandeld direct of indirect verband houden met jouw project. Benadruk specifieke gebieden waar kennis die is opgedaan uit de cursus is toegepast of zal worden toegepast in het ontwikkelingsproces. Geef hier voorbeelden van en benoem hoe deze relevant zijn.]

### Resultaten LinkedIn Learning cursus
[Plak hier een screenshot of link naar het certificaat]

### Resultaten quiz op DLO
[Plak hier een screenshot van je quizresultaat]

### Vragen voor expert review
[Stel drie concrete vragen op die je tijdens de expert review wil behandelen. Deze vragen zijn gericht op het verkrijgen van feedback en inzichten van de beoordelaar.]


## C# Data structures

### Inleiding

Deze documentatie dient als leidraad om theoretische concepten in onder meer object georiënteerd programmeren, databases en infrastructuur te begrijpen en toe te passen. Het benadrukt de relevantie van theoretische kennis voor praktische toepassingen in je project en biedt een gestructureerde aanpak voor het documenteren van je voortgang.

### Samenvatting van de cursus in ongeveer 300 woorden
- Strings cannot be modified once they are created; immutable
- Arrays are contiguous storage in memory of the same variable type
- Tuples are used to group together multiple data elements without having to define a class
- Contains checks for presence of a certain value in a List, Exists does checking for conditions, like string length, to figure out whether or not something exists in the list that the user is looking for
- Find and FindAll can be used to check a value of something in a list, instead of returning a boolean
- TrueForAll returns true when every value in a list meets a certain requirement
- LinkedList works in sequence, instead of with an index like List
- LinkedListNodes are points in a linked list that are set by the user, and any value can be added, removed or checked before and after these nodes
- Lists vs LinkedList: Lists are faster at looking up items, as well as adding items at the end of the list. LinkedList is best used when adding / removing items from the last and first positions of the list
- Stack is a type of list that uses the last in, first out principle to store and remove data
- Queue is a type of list that uses the first in, first out principle to store and remove data
- They both have overlapping functions, such as Contains and Count, and differing functions, such as Pop and Push for stack, and Enqueue and Dequeue for queue
- Dictionary gives a way to associate keys with individual values. There can be multiple keys with the same value, but not the other way around
- Dictionary has the Count method, as well as a few different ones like ContainsKey, ContainsValue, Add and Remove
- ListDictionary implements a dictionary as a linked list, which is faster up to about 100 elements
- HybridDictionary starts out as a ListDictionary, until that is no longer faster, and then switches to a Dictionary
- OrderedDictionary keeps entries in the dictionary in order of when they were added
- StringCollection is used to modify and manipulate groups of string objects. It is also indexed like an array
- StringBuilder is more efficient at modifying strings multiple times than string functions

### Relevantie tot je project en praktische toepassing
[Leg uit hoe de theoretische concepten die in deze cursus worden behandeld direct of indirect verband houden met jouw project. Benadruk specifieke gebieden waar kennis die is opgedaan uit de cursus is toegepast of zal worden toegepast in het ontwikkelingsproces. Geef hier voorbeelden van en benoem hoe deze relevant zijn.]

### Resultaten LinkedIn Learning cursus
[Plak hier een screenshot of link naar het certificaat]

### Resultaten quiz op DLO
[Plak hier een screenshot van je quizresultaat]

### Vragen voor expert review
[Stel drie concrete vragen op die je tijdens de expert review wil behandelen. Deze vragen zijn gericht op het verkrijgen van feedback en inzichten van de beoordelaar.]