# LinkedIn course summary

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
[Bewijs van LinkedIn-course voltooiing](https://www.linkedin.com/learning/me/my-library/completed?u=2132228)

### Resultaten quiz op DLO
![Bewijs van DLO quiz over K1](../LinkedInSummaries/DLOQuizBlok4.png)

### Vragen voor expert review
[Stel drie concrete vragen op die je tijdens de expert review wil behandelen. Deze vragen zijn gericht op het verkrijgen van feedback en inzichten van de beoordelaar.]