# GAP-analyse Tijn
# Beoordelaar: Sed

## Huidige staat op de 4 hoofdlijnen van de GAP-analyse
### Kwantiteit
- Minimaal 4 dagen per week aan het werk                                                ~ +
- 4 user stories per week afgerond                                                      ~ +
- Levert een goede bijdrage aan de functionaliteiten in het project (marge 20-30%)      ~ +

### Kwaliteit
- Gebruikt de 4 pilaren van OOP                         ~ +
- Maakt gebruik van de C# code conventies               ~ +
- Schrijft comments waar nodig                          ~ +                         
- Gebruikt generics voor herbruikbare code (minimaal 2) ~ -
- Maakt gebruik van interfaces                          ~ -
- Maakt gebruik van composition over inheritance        ~ -

### Complexiteit
- Gebruikt generics voor herbruikbare code (minimaal 2) ~ -
- Maakt gebruik van loose coupling                      ~ +
- Maakt gebruik van encapsulation                       ~ +
- Maakt gebruik van het open/closed principle           ~ +
- Maakt gebruik van genormaliseerde vectoren (beweging) ~ -

### Documentatie
- Maakt gebruik van de C# code conventions              ~ +
- Gebruikt comments waar nodig                          ~ +
- Gebruikt beschrijvende namen                          ~ +
- Volgt een logische structuur in de documentatie       ~ +
- laat stukken code zien                                ~ -

### Kwantiteit - score: 100%
Tijn is elke fysieke schooldag aanwezig en werkend aan het project. Ook is in de commit geschiedenis te zien dat Tijn door werkt op woensdag en/of vrijdag. Tijn heeft zich bezig gehouden met de speler en alles daarom heen zoals:
- Movement
- HitPoints
- Invincibilty

Tijn draagt hierdoor meer dan voldoende mee aan het project en heeft hij tot nu toe 5 á 6 user stories gemiddeld per week afgerond.

### Kwaliteit - score: 50%
Tijn heeft laten zien in zijn code dat hij alle 4 pillaren van OOP gebruikt. Zo gebruikt hij voor abstraction een private methode voor het dashen van de speler. Voor Inheritance en Polymorphisme is te zien dat de Player class overneemt van de Character class en de HandleInput methode wordt geoverride om player movement toe te voegen. Als laatste heeft hij duidelijk gebruik gemaakt van access modifiers zoals te zien met de vorige genoemde dash methode en de privat variabelen die hij alleen nodig heeft in de class zelf.  De coding conventions gebruikt Tijn uigebreid in zijn code. Hij noemt variabelen en methods duidelijk te begrijpen namen en schrijft hij korte comments waar meer uitleg nodig is.  Tijn gebruikt in zijn deel van de code geen Generics. Wel gebruikt Tijn de loose coupling principle,  In de Player class kunnen er dingen verandert worden zonder dat er in de gamestate of Enemy class errors komen. In de Player class bundelt hij ook relevante code samen tot methodes en maakt degende die niet belangrijk zijn voor buiten de code private. Tijn heeft voor het project nog geen gebruik van interfaces, alles staat direct in de classes zelf. Ook heeft Tijn nog niet de design principle Composition over inheritance gebruikt.

### Complexiteit - score: 60%
Tijn gebruikt in zijn deel van de code geen Generics. Wel gebruikt Tijn de loose coupling principle, In de Player class kunnen er dingen verandert worden zonder dat er in de gamestate of Enemy class errors komen. In de Player class bundelt hij ook relevante code samen tot methodes en maakt degende die niet belangrijk zijn voor buiten de code private. Er word in dezelfde class ook al redelijk gebruik gemaakt van de Open/close principle doordat er veel gescheiden is met methodes. Tijn maakt nog geen gebruik van een genormalizeerde vector voor de beweging van de speler.


### Documentatie - score: 80%
De coding conventions word uigebreidt gebruikt. Hij noemt variabelen en methods duidelijk te begrijpen namen en schrijft hij korte comments waar meer uitleg nodig is. Tijn gebruikt in zijn documentatie de basissyntax van Markdown bv. Kopjes, Titels en Lijsten waardoor er een snel beeld is waar de documentatie ongeveer over gaat. Tijn laat alleen nog niet in zijn documentatie stukken code zien.


## GAPS
### Kwantiteit - 0%
Tijn voldoet aan de opgestelde eisen van de Kwantiteit.

### Kwaliteit - 50%
Om de Kwaliteit gap te verkleinen zal Tijn meer moeten gaan werken met Generics en interfaces en gaan beginnen met composition meer te gebruiken. 

### Complexiteit - 40%
Tijn is goed onderweg maar zal zich nog moeten focusen op het gebruiken van Generics en genormalizeerde vectoren.

### Documentatie - 20%
Het enige wat Tijn nog mist om aan alle opgestelde eisen te voldoen is code snippets toe voegen aan zijn documentatie.

## Actieplan
### Kwantiteit
Lekker bezig.

### Kwaliteit
Terwijl je bezig bent met coderen hou in je achterhoofd dat je voor een aantal stukken misschien beter een interface kan gebruiken ipv meerdere keren over nieuw te typen. Het gebruik van interfaces hier zorgt er ook voor dat je code een stuk minder gecompliceerd is en je een stuk minder erdoor heen hoeft te zoeken als je iets verander. Begin ook met het gebruiken van Generics(List, Dictionary), je hebt hier nog geen gebruik van gemaakt en er wordt van je verwacht dat je dr minstens 2 in je code hebt verwerkt. 

### Complexiteit
Ga vooral zo door op het gebied van encapsulation. Maak een aantal interfaces, generics en maak je classes gesloten voor veranderingen.
Ook hier zal je moeten beginnen met het gebruiken van Generics. Voor de genormalizeerde vectoren zou ik nog eens kijken naar hoe je de movement doet van de speler. Deze wordt nu nog gedaan op een manier waarop de speler diagonaal sneller loopt dan normaal.

### Documentatie
Voeg meer code snippets toe in je documentatie. Deze helpen met het verduidelijken van waar je het over hebt door de lezer context te geven.