# Template van theorie naar praktijk

## Inleiding

Deze documentatie dient als leidraad om theoretische concepten in onder meer object georiënteerd programmeren, databases en infrastructuur te begrijpen en toe te passen. Het benadrukt de relevantie van theoretische kennis voor praktische toepassingen in je project en biedt een gestructureerde aanpak voor het documenteren van je voortgang.

## Samenvatting van de cursus

### Overview of Data Structures
- Verschillende data structuren worden voor verschillende scenario's gebruikt waar gegeven moeten worden bijgehouden
- .NET Generics en Non-Generics:
  - List
  - LinkedList
  - Queue
  - Stack
  - Dictionary

- .NET specialized collectie:
  - ListDictionary
  - HybridDictionary
  - OrderedDictionary
  - StringCollection
  - StringBuilder

### Generics vs. non-generic collections
- Ligt aan de scenario waar je het nodig voor hebt
  - Moet je vaak de data wijzigen?
  - Welke volgorde van de data?
  - Heb je tijdelijk de data nodig?
  - Zoek je content of voeg je toe?

## Basic Data Structures
### List
- Snel om items in op te zoeken
- Items worden aan het einde van de lijst toevoegt
- Groote wijzigen is moeilijk

List operators:
  - Contains
  - Find
  - FindAll
  - Exists

### LinkedList
- Items kunnen worden toegevoegt aan het begin en einde van de lijst
- Groote wijzigen is makkelijk

LinkedList operators:
  - AddFirst
  - AddLast

## Advanced Data Structures
### Queue and Stack
- Queue: FiFo (First in, First out)
  - .Peek, .Pop, .Contains  
- Stack: FiLo (First in, Last out)
  - .Peel, .Enqueue/.Dequeue, .Contains, .Clear

### Dictionary
- Geeft values een unieke key
- Meerdere keys kunnen dezelfde value hebben maar meerdere values kunnen niet dezelde key hebben
    - Count, Add/Remove, ContainsKey, ContainsValue

## Specialized Data Structures
### OrderedDictionary
- Houd toegevoegde data bij in de volgorde van wanneer het is toegevoegt
  
### ListDictionary
- Implementeerd een dictionary als een linked list
- Is sneller dan een linked list tot 100 values

### HybridDictionary
- Start als een ListDictionary
- Wanneer ListDictionary niet meer sneller is verandert het naar een normale Dictionary
  
### StringCollection
- Index zoals een Array
- Wordt gebruikt om een groep van Strings te manipuleren

### StringBuilder
- Efficenter in het meerdere keren wijzigen van strings

## Relevantie tot je project en praktische toepassing

In onze game zijn er meerdere van dezelfde enemies op het scherm die allemaal kogels schieten op de speler. WIj voegen daarom ook de Enemies en de kogels toe aan een list zodat er meerdere instansies van die objecten op het scherm kunnen zijn tegelijk.

```C#
EnemyList = new List<Enemy>();
enemyBulletList = new List<EnemyBullet>();
```

Wanneer een bullet van een enemy een player raakt wordt de bullet toegevoegd aan de ToRemoveList en worden deze objecten aan het einde van de game loop verwijdert uit beiden lijsten. Dit is zo gedaan omdat de game anders meteen weer door de lijst heen gaat voordat het zichzelf kan updaten en de game chrased.
```C#
foreach (var gameObject in toRemoveList)
{
    if (gameObject is EnemyBullet enemyBullet)
    {
       enemyBulletList.Remove(enemyBullet);
    }
    Remove(gameObject);
}
```

## Resultaten LinkedIn Learning cursus

[Plak hier een screenshot of link naar het certificaat]

## Resultaten quiz op DLO

![resultatentoets](../images/toetsresultatenSedK1.PNG)

## Vragen voor expert review

- Is er een mogelijkheid om ipv aan het einde van de gameloop al tijdens de loop gameobjecten te verwijderen?
- Kan de ToRemoveList anders worden geschreven zodat er niet zoveel if statements staan?
