# C# Generics and interfaces summary

## C# Interfaces and generics

### Inleiding
Deze samenvatting gaat over de [linkedIn-course Interfaces & Generics](https://www.linkedin.com/learning/c-sharp-interfaces-and-generics/). Hierin wordt de theorie rondom Interfaces en Generics in het kort verteld.

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
Voor onze game is het gebruik van Lists extreem belangrijk. Lists worden voornamelijk gebruikt in de gamestate class, om objecten toe te voegen aan de GameObjectList (dit is een soort List, die uniek is aan deze codebase). De GameObjectList loopt door alle elementen in de list heen om functies uit te voeren als de Update en HandleInput. Voor het toevoegen van elementen aan de lijst wordt Add() gebruikt, en Remove() om elementen weg te halen. Elementen die in de lijst staan worden gedisplayed in de gamestate. Naast de GameobjectList voor de gamestate, gebruiken we ook reguliere Lists.

```C#
private List<PlayerBullet> playerBulletList;
private List<PlayerBullet> playerBulletsToRemove;
private List<EnemyBullet> enemyBulletList;
private List<ShootingEnemy> shootingEnemyList;
private List<GameObject> toRemoveList;
```

Deze lijsten zijn vrij vanzelfsprekend; playerBulletList is een lijst voor alle playerbullets, etc. De toRemoveList is een lijst voor alle objecten van het type GameObject. Deze wordt gebruikt om objects te verwijderen na een foreach loop over de lijst heen. Dit hebben wij zo gecodeerd, aangezien het verwijderen van elementen uit een lijst tijdens een loop zorgt voor een crash.

```C#
foreach (var playerBullet in playerBulletList)
{
    if (playerBullet.CheckForEnemyCollision(Enemy))
    {
        toRemoveList.Add(Enemy);
        toRemoveList.Add(playerBullet);
    }
}
```

De code hierboven laat een collision check plaatsvinden tussen enemies en playerBullets. Omdat er een foreach over de playerBulletList wordt uitgevoerd, kunnen hier niet direct elementen uit verwijderd worden. Daarom worden deze later verwijderd.

```C#
foreach (var gameObject in toRemoveList)
{
    if (gameObject is PlayerBullet playerBullet)
    {
        playerBulletList.Remove(playerBullet);
    }
    if (gameObject is ShootingEnemy shootingEnemy)
    {
        shootingEnemyList.Remove(shootingEnemy);
    }
    Remove(gameObject);
}
```

Interfaces en abstracte classes zijn enorm handig met het herbruikbaar maken van code, als er veel soortgelijke objecten gebruikt worden. Een interface geeft methods en variablen mee die een overervende class MOET overnemen op zijn eigen manier (met het 'override' keyword). Een abstract class heeft gelijke functionaliteit, maar er verschillen ook wat dingen. Zo kan er maar 1 class worden overgeerfd, en meerdere interfaces. Ook kan een abstracte class van tevoren al methods definieeren, wat een interface niet kan. Er kunnen van beide soorten geen instanties gemaakt worden, wat de kans op fouten verkleint.

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

### Resultaten LinkedIn Learning cursus
[Bewijs van LinkedIn-course voltooiing](https://www.linkedin.com/learning/me/my-library/completed?u=2132228)

### Resultaten quiz op DLO
![Bewijs van DLO quiz over K1](../LinkedInSummaries/DLOQuizBlok4.png)

### Vragen voor expert review
Is het gebruik van een abstrace class of interface beter als je nog niet weet wat er later met de class gebeurt? Is het dan beter om te beginnen op interface en eventueel te veranderen naar abstracte class of is het niet te bepalen?