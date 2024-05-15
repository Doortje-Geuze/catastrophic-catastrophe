# GAP-analyse voor Doortje, van Tijn

## Huidige staat op de 4 hoofdlijnen van de GAP-analyse
### Kwantiteit
- Minimaal 4 dagen per week aan het werk                                                ~ 75%
- Maakt 4 user stories per week                                                         ~ 20%
- Levert een goede bijdrage aan de functionaliteiten in het project (marge 20-30%)      ~ 50%

### Kwaliteit
- Gebruikt de 4 pilaren van OOP                         ~ 30%
- Maakt gebruik van de C# code conventies               ~ 75%
- Schrijft comments waar nodig                          ~ 40%                         
- Gebruikt generics voor herbruikbare code (minimaal 2) ~ 10%
- Maakt gebruik van loose coupling (interfaces)         ~ 0%
- Maakt gebruik van encapsulation                       ~ 65%
- Maakt gebruik van abstraction                         ~ 25%
- Maakt gebruik van composition over inheritance        ~ 0%

### Complexiteit
- Gebruikt generics voor herbruikbare code (minimaal 2) ~ 10%
- Maakt gebruik van loose coupling (interfaces)         ~ 0%
- Maakt gebruik van encapsulation                       ~ 70%
- Maakt gebruik van het open/closed principle           ~ 10%
- Maakt gebruik van genormaliseerde vectoren (beweging) ~ 0%

### Documentatie
- Maakt gebruik van de C# code conventions              ~ 75%
- Gebruikt comments waar nodig                          ~ 40%
- Gebruikt beschrijvende namen                          ~ 85%
- Volgt een logische structuur in de documentatie       ~ 90%
- laat stukken code zien                                ~ 0%

## Current state
### Kwantiteit - score: 45%
Het is aan de commitgeschiedenis te zien dat Doortje minimaal 3 dagen van de week iets aan het doen is wat betreft het project. De activiteit rondom het project gaat meestal naar documentatie of theorie toe. Hierdoor wordt er vanuit Doortje onvoldoende bijgedragen aan de game zelf (bijdrage ligt rond de 10-15%). Er is in sprint 1 gewerkt aan 1,5 user stories, verspreid over 2 weken. Dit voldoet niet aan de gestelde eis van 4 per week.

### Kwaliteit - score: 35%
Doortje gebruikt voornamelijk inheritance als het gaat om de 4 pillaren van OOP. Polymorphism en abstraction zijn niet/nauwelijks aanwezig, maar encapsulation is wel voor een meerendeel aanwezig. De coding conventions omtrent de duidelijke variablenamen, inlining en styling worden goed gevolgd, alleen er zijn nergens comments te vinden. De meeste code heeft geen comments nodig aangezien het prima te lezen is zonder, maar het laten zien dat er actief over wordt nagedacht kan altijd met een paar comments. Er wordt qua generics geen eigen Lists, Queues, etc. aangemaakt, maar er wordt wel gebruik gemaakt van de Add() en Remove() functie, ingebouwd in de List<>. Er is nog geen gebruik gemaakt van abstracte classes of interfaces in de code van Doortje. Composition over inheritance wordt niet gebruikt.

### Complexiteit - score: 15%
Er wordt qua generics geen eigen Lists, Queues, etc. aangemaakt, maar er wordt wel gebruik gemaakt van de Add() en Remove() functie, ingebouwd in de List<>. Er is nog geen gebruik gemaakt van abstracte classes of interfaces in de code van Doortje. Er is encapsulation aanwezig in de code, door gebruik te maken van 'protected' keyword. Het open/closed principle komt voor een heel klein deel terug in de playerBullet code. Er is nog geen gebruik gemaakt van genormaliseerde vectoren/steering behaviours.

### Documentatie - score: 70%
De coding conventions omtrent de duidelijke variablenamen, inlining en styling worden goed gevolgd, alleen er zijn nergens comments te vinden. De meeste code heeft geen comments nodig aangezien het prima te lezen is zonder, maar het laten zien dat er actief over wordt nagedacht kan altijd met een paar comments. De documentatie is heel goed geordend, waardoor het makkelijk is om bestanden te vinden waar iemand naar op zoek is, en er wordt gebruik gemaakt van de basissyntax van Markdown, zoals unordened lists en hyperlinks. Er is alleen nog geen code laten zien in de documentatie, omdat er nog geen expert review is geweest waarvoor de code gedocumenteerd moest worden.

## GAPS
### Kwantiteit - 55%
Doortje kan vooral meer kwantiteit vinden door te werken aan de game zelf, en dus ook meer user stories af te ronden. De kwantiteit in documentatie levering is prima.

### Kwaliteit - 65%
Doortje kan vooral meer kwaliteit vinden door gebruik te maken van interfaces (en hiermee loose coupling en composition over inheritance), generics en ook nog wat comments toevoegen als een functie niet voor zichzelf spreekt. Coding conventions kunnen naast de comments gewoon gedragen worden zoals nu.

### Complexiteit - 85%
Er valt veel te overbruggen omrent complexiteit. De prioriteit ligt hier op gebruik van interfaces, genormaliseerde vectoren als het gaat om ingewikkelde movement en nog wat extra aandacht aan het open/closed principle (als voorbeeld, houdt de bullet code uit de player code, en zet functies voor bullets in de bullet class ipv de player of gamestate).

### Documentatie - 30%
Doortje is goed op weg als het gaat om documentatie. Er valt nog winst te halen als het gaat om code snippets in de documentatie.

## Actieplan
### Kwantiteit
Zoek tijd thuis om user stories te vinden die jij niet alleen leuk vindt om te doen, maar die je ook binnen een dag zou kunnen afronden. Als dit niet mogelijk is, probeer dan de user story op te splitten of meldt het bij de rest van het team, zodat deze user story zwaarder wordt meegeteld. Als thuis werken lastig gaat doordeweeks, dan is het weekend altijd een mogelijkheid om op je eigen tempo naar de code te kijken, en nog te zien of je iets extra's kan bijdragen.

### Kwaliteit
Zoek naar stukken code waar je gedragingen over meerdere classes, meerdere keren definieerd. Hier kunnen interfaces enorm handig van pas komen, om dit van tevoren vast te stellen bij de classes. Ga ook kijken of je nog user stories kunt oppakken, waar je objecten aan de gamestate moet toevoegen. Dit kan helpen met de ontwikkeling wat betreft generics, met name de List<>. 

### Complexiteit
Naast de punten genomed bij kwaliteit, kan je je verdiepen in genormaliseerde vectors onder [Steering behaviours](https://code.tutsplus.com/series/understanding-steering-behaviors--gamedev-12732). Dit kan vervolgens worden toegepast op bullets met homing effect of nieuwe types van enemies. Kijk ook voor stukken code waar je de 'readonly' keyword kunt gebruiken. Dit is een simpele manier om voor open/closed principle te zorgen, sinds een waarde niet kan worden aangepast en alleen gelezen.

### Documentatie
Probeer functies die niet heel makkelijk te begrijpen zijn, direct te commenten met een kleine uitleg erboven. Documenteer ook eventuele code snippets voor toekomstige expert reviews.