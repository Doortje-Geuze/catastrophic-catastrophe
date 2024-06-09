# C# Design principles summary

## C# Design principles

### Inleiding
Deze samenvatting gaat over de [linkedIn-course Design Principles](https://www.linkedin.com/learning/advanced-design-patterns-design-principles/). Hierin wordt de theorie rondom Design Principles in het kort verteld.

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
De Design Principles zijn algemene guidelines om aan te houden tijdens het coderen. Het gebruik van alle principles moet daarom altijd in acht genomen worden. Neem 'Program to interfaces, not implementations' als voorbeeld:

```C#
public abstract class Character : SpriteGameObject
{
    //all variables that a character needs
    public int HitPoints;
    protected int MoveSpeed;
    //rest of code
}
```

De character class is een abstracte class. Dit betekent dat hier geen instanties van kunnen worden gemaakt. Alle character-type objecten in onze game (zoals de speler of enemies) kunnen hier vervolgens van overerven om character-unique methods en/of variable te krijgen. Bij de creatie van een nieuwe player in de Player class, hoeft bijvoorbeeld geen extra variable aangemaakt te worden voor HitPoints, sinds die al bestaat door de Character class.

```C#
public class Player : Character
{
    //assignment of new variables
    public Player(int hitPoints, int moveSpeed, Vector2 position) : base(hitPoints, moveSpeed, position,"Images/Characters/playerCat@2x1", 0, " ", 0)
    {
        HitPoints = hitPoints;
    }
    //rest of code
}
```

Bij deze voorbeeld code komt ook 'Interface segregation' aan bod. Door nieuwe variables niet te verwerken in IGameLoopObject, maar in een nieuwe abstracte class, blijft de IGameLoopObject code schoon voor andere classes die alleen deze interface nodig hebben, en niet de Character.

### Resultaten LinkedIn Learning cursus
[Bewijs van LinkedIn-course voltooiing](https://www.linkedin.com/learning/me/my-library/completed?u=2132228)

### Resultaten quiz op DLO
![Bewijs van DLO quiz over K1](../LinkedInSummaries/DLOQuizBlok4.png)

### Vragen voor expert review
Hoe wordt composition aangeduid in C#? Hoe werkt de syntax hiervoor, of is het meer een concept dan een echte feature van C#?