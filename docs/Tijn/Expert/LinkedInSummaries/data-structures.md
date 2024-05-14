# LinkedIn course summary

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
[Bewijs van LinkedIn-course voltooiing](https://www.linkedin.com/learning/me/my-library/completed?u=2132228)

### Resultaten quiz op DLO
![Bewijs van DLO quiz over K1](../LinkedInSummaries/DLOQuizBlok4.png)

### Vragen voor expert review
[Stel drie concrete vragen op die je tijdens de expert review wil behandelen. Deze vragen zijn gericht op het verkrijgen van feedback en inzichten van de beoordelaar.]