# Linked in cursus C#: Applied Data Structures

## Overview of data structures

- Datastructuren worden gebruikt om applicatiegegevens bij te houden en erop te werken.
- verschillende structure types voorzien voor verschillende scenario's
- .NET biet genaric en non-genaric colecties waar je mee can werken:(class)
    - List
    - LinkedList
    - Stack
    - Queue
    - Dictionary
  
- .Net specialized collectie:
    - ListDictionary
    - HybridDictionary
    - OrderedDictionary
    - StringCollection
    - StringBuilder
  
### Wanner genaric of non-genaric gebruiken?

  - Wat voor data wordt er gebruikt in de situatie?
      - individual values, key-value pairs en keys voor meerderen values
  - Hoe zal data toegankelijk zijn en worden verwerkt?
      - Moet je vaak bij data keer op keer?
      - tijdelijke toegang tot data die daarna weer wordt weggegooid?
      - zijn de data toegangelijk in een bepaalde order?(last in, first out/first in, first out)
  - Waar wordt er nadrukop gelegd?
      - wordt de data structure gebouwd met content? of word er gezocht/toegang gemaakt er na?
  

![](/docs/Doortje/LinkenIn-Cursus/genaric-non-genaric.png)

## Basic data structures
- List operations
- List contains:
  
  
  ```cs
  Console.WriteLine(...List.Contains(" "));

  Bool found = ...List.Exist(" ");

  String item = " ";
  item = ..List.Find(" "):

  List<String> itemList = ...List.FindAll(" ");
  ```

- LinkedList 

```cs
LinkedList<String> mylist = new LinkedList<string>(NumberArray);

mylist.AddFirst("1");

mylist.AddLast("7");

```
### List vs Linked List


    |------|-----------|
    | List | LinkedList|
    | Snel om items op te zoeken | Items opzoeken is lastig  |
    |Snel items toevoegen(aan het einde) | Snel items voor aan of achteraan toevoegen   |
    |Resizing is lastig | eerste of laatste item verwijderen is snel  |
    |Items in de lijst zetten is lastig | items in de lijst zetten is lastig   |
    |Items verwijderen is lastig| items in de lijst verwijderen is lastig |

## Advanced Data Structure

- Stack: zie 'Linked In cursus C#: Interfaces and Generics'
- Queue: zie 'Linked In cursus C#: Interfaces and Generics'
- Dictionary:
```cs

//Dictionaries map key to values
Dictionary< string, string > fileType = new Dictionary< string, string >();

```

## Relevantie tot je project en praktische toepassing


## Resultaten LinkedIn Learning cursus


## Resultaten quiz op DLO
[Plak hier een screenshot van je quizresultaat]

## Vragen voor expert review
- 