# Linked In cursus C# Design Principles

 
## Introductie 

 ### Wat zijn Design principles?:

- Guidelines (bedoeld als advies niet als een regel)
- Geconstateerd dat het tot een goed object oriented design
- Bieden hulp for de maker om geen slecht object georienteerd design te maken
- Er is geen standaard lijst van de principles
- Varieerd in welk gebeid je zit in de ICT

### Wat zijn Symthoms van bad design?

- Als iets moeilijk aan te passen is (stijfheid)
- Als het product kwedsbaar is ( 1 wijziging leit tot veele bugs)
- Als het moeilijk te herbruiken is
- Inflexible

### Fundemental principles

- Enacpsulate wat varieerd
- Voorkeur aan samentelling boven overerving
- progameer naar interfaces, niet naar implementaties
- losse koppelingspricipe
- SOLID (Single responsibly, Open/closed, Liskov substitution, Interface segregation, Dependency inversion)

### Design Patterns

- Beproefde ontwerpoplossingen die zijn gevonden om specifieke problemen op te lossen
  
  "Design patterns are solutions while design principles are guidelines"

## The principles

### Enacpsulate what varies

- Identificeer de aspecten van de apilcatie die variëren 
- Scheid ze van wat hetzelfde blijft
- Basis van bijna elk Design Pattern

### favor composition over inheritance

- IS-A, HAS-A
- IS-A: inharitance Relationship(Een hond is een dier)
- HAS-A: Relationship of composition (Een hoond heeft een baasje)
- In plaats van gedrag te erven, kunnen we onze objecten samenstellen met nieuw gedrag
- Composition geeft meer flexibiliteit.

### Loose Coupling

- Loose coupling reduces the dependency between components

### Program to interfaces, not implementations

- wanner mogelijk: componens moeten abstracte classes of interfaces gebruiken
- "Program to interface" = "Program to a super type"
- Kan je beter polymorphism exploiteren
- Verbetert de uitbreidbaarheid en onderhoudbaarheid
  
### SOLID

#### Single responsibly

- Een class kan elleen maar 1 reden hebben om te veranderen.
- Verandring is alleen belangrijk als er ook verandering optreed
  
#### Open/closed

- object oriented desing zouden open moeten zijn voor extensie maar gesloten voor wijzigingen
- maakt nieuw gedrag mogelijk zonder het risico te lopen veranderingen in bewezen code te riskeren
- Verbeter de onderhoudbaarheid en uitbreidbaarheid van een ontwerp

#### Liskov substitution

-  je zou altijd subtypes kunnen vervangen for hun baseclass
  
#### Interface segregation

- Let op de samenhang in de interfase classes
- grote samenhangende interfaces leiden tot meer onderhoudbare en meer flexibeler systemen
- gescheiden interfaces zo als nodig om ze focust en samenhangend te houden

#### Dependency inversion

- High-level modules zouden niet moeten leunen op low-level modules
- helped met het maken van software dat herbruiktbaar en betrouwbaar is 
- Alle relaties zouden abstract classes of interfases moeten gebruiken
- Abstraction zorgt ervoor dat details geisoleerd zijn voor elkaar.

## Relevantie tot je project en praktische toepassing

het design principle: encapsute what varies zouden wij kunnen toepassen op onze enemies. stel al maken we 3 vershillende enemies, die samen in 1 enemy class zitten en we moeten deze steeds aanpassen omdat we verschillnde enemies willen uit proberen. Dan zouden we het kennen toepassen net zoals het voorbeeld van de pancake factory in de cursus. zo kunnen we de enemies veranderen zonder dat het rest van de code beinvloed

## Resultaten LinkedIn Learning cursus

![](/docs/Doortje/LinkenIn-Cursus/C#%20Design%20Principles.png) 


## Vragen voor expert review

[Stel drie concrete vragen op die je tijdens de expert review wil behandelen. Deze vragen zijn gericht op het verkrijgen van feedback en inzichten van de beoordelaar.]