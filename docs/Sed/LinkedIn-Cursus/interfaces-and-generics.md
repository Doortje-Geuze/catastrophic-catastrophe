# Template van theorie naar praktijk

## Inleiding

Deze documentatie dient als leidraad om theoretische concepten in onder meer object georiënteerd programmeren, databases en infrastructuur te begrijpen en toe te passen. Het benadrukt de relevantie van theoretische kennis voor praktische toepassingen in je project en biedt een gestructureerde aanpak voor het documenteren van je voortgang.

## Samenvatting van de cursus

### Interfaces
- Classes kunnen meerdere interface implementeren
- Interfaces kunnen geimplementeerd worden in verschillende classes
- Interfaces bieden geen logica
- Interfaces beschrijven gedrag, geen individuele classes

#### Implementing a Interface
- Je defined een interface door `interface` voor de naam te zetten (`interface IStoreable`)
- Namen van interfaces beginnen met een I
- `Class Example : IStoreable`

#### Interface and Casting
- "is" keyword is een boolean en wordt gebruikt om te bepalen of een object een instantie is of is afgeleid van een specifieke class
- "as" keyword wordt gebruikt om een nieuw object te creëren van een ander object als een andere class waar het object van inherit

#### Implementing multiple interfaces
- Meerdere Interface kunnen worden geimplementeerd door een komma toe tevoegen (`Class Example : IStoreable, IExampleInter`)
- Als 2 methods dezelfde naam hebben is er een interface reference nodig voor de method (`void IInterface.SameMethod()`)
- Wanneer je de methodes called moeten deze worden gecast als de interface (`IInterface i1 = testclass as IInterface`, `i1.SameMethod()`)

#### Using .NET-defined interfaces
.NET heeft verschillende ingebouwde interface:
- IComparable, IComparer: Vergelijk verschillende objecten
- IDisposal: Veilige manier voor callers om jouw object weg te gooien
- IEquatable: Vergelijk de gelijkheid van 2 objecten van hetzelfde type
- INotifyPropertyChanged: Broadcast veranderingen tot property waardens om jouw object

### Generics
- Generics geven typeveiligheid, herbruikbaarheid en efficiëntie
- Meestal gebruikt met dataverzameling
- Beperk data structuren om alleen bepaalde type variabelen toe te laten

#### Generic List Collections
- List is een soort array waar de toegevoegde data dezelfde type moet volgen als dat vast gestelt is.
- List zijn dynamisch in groote en veranderen automatisch hun groote met elke toegevoegde/verwijderde stuk data 

#### Queue and Stack
- Queue: FiFo (First in, First out)
  - .Peek, .Pop, .Contains  
- Stack: FiLo (First in, Last out)
  - .Peel, .Enqueue/.Dequeue, .Contains, .Clear

#### Dictionary
- Geeft values een unieke key
- Meerdere keys kunnen dezelfde value hebben maar meerdere values kunnen niet dezelde key hebben
    - Count, Add/Remove, ContainsKey, ContainsValue

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
