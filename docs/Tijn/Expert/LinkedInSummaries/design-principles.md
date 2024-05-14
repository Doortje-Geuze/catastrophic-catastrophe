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
[Bewijs van LinkedIn-course voltooiing](https://www.linkedin.com/learning/me/my-library/completed?u=2132228)

### Resultaten quiz op DLO
![Bewijs van DLO quiz over K1](../LinkedInSummaries/DLOQuizBlok4.png)

### Vragen voor expert review
[Stel drie concrete vragen op die je tijdens de expert review wil behandelen. Deze vragen zijn gericht op het verkrijgen van feedback en inzichten van de beoordelaar.]