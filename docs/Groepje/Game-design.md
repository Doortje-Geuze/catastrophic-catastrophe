# Game design document voor Catastrophic Catastrophy

## Concept en mechanics
Het concept van ons spel is een competitie tussen verschillende huisdieren. De speler kiest, of krijgt, een huisdier toegewezen waarmee de speler het spel speelt. Dit huisdier zal in een top-down bullet hell game vechten tegen horden van enemies die proberen de speler aan te vallen. Na een aantal waves van deze enemies spawnt er een boss. Dit is een ander huisdier waartegen het huisdier van de speler moet vechten, om te bewijzen dat het huisdier van de speler superieur is. Als de speler een boss verslaat, dan krijgt hij/zij de kans om het wapen van deze boss op te pakken en te gebruiken in het vervolg van het spel. Ook verdient de speler na het verslaan van enemies/bosses in-game currency, die gebruikt kunnen worden voor stat/weapon upgrades.

## Formal elements
- Players: Single player vs enemies
- Objectives: Het verslaan van waves van enemies en bosses om verder te komen in het spel
- Procedures: Lopen, schieten, dashen
- Rules: Als de speler al zijn/haar levens verliest, dan stopt het spel (speler is dood)
- Resources: HP, schiet-cooldown, invulnerability-cooldown
- Conflict: Enemies proberen de speler te raken, met hun body of met hun kogels. De speler moet deze zien te ontwijken
- Outcome: De speler verslaat alle enemies en voltooid een wave/verslaat een boss. Hierna wordt de speler beloond met in-game currency of het wapen van een boss
- Boundaries: De speler kan niet van het scherm af lopen, en kan ook geen enemies raken buiten het scherm.

## Inspiratie analyse
### Vampire Survivors
Voor de mechanics van ons spel hebben wij ons laten inspireren door vampire survivors. Vampire survivors is een bullet hell game waarbij er waves aan enemies het beeld in lopen en de speler achtervolgen. Tevens spawnt er af en toe een boss in die (betere) loot dropt. In onze game wordt de speler achtervolgt door waves van 'normale' enemies. Eens in de zoveel tijd spawnt er een boss met een wapen die schiet op de speler. 

Als de speler de boss verslaat kan de speler het wapen van de boss oppakken en gebruiken om de enemies te verslaan.  
In vampire survivors krijg je na een bepaalde hoeveelheid xp te hebben verdiend de mogelijkheid om een wapen te upgraden. Wij willen dit concept in een iets andere vorm toepassen. Namelijk in de vorm van een shop.

### Stardew Valley
Voor het uiterlijk van de game hebben we inspiratie opgedaan van de populaire game Stardew Valley. In onze game willen wij gebruik maken van 'vrolijke' felle kleuren en pixel art. Deze aspecten zijn ook terug te zien in het design van Stardew Valley. 

In Stardew Valley is het ook mogelijk om allerlei verschillende soorten (huis)dieren te houden. Huisdieren is een belangrijk thema binnen onze game.

### Enter The Gungeon
Wij hebben inspriratie gehaald uit Enter The Gungeon. Dit spel is een bullet hell waar je in een dungeon verschilde enemies en bosses tegenkom. Verder is er ook een top-down point of view, deze sprak ons erg aan en willen wij deze ook implementeren in onze game


### Animal Restaurant

In Animal Restaurant run je een restaurant waar verschillende dieren komen. Deze dieren hebben allemaal hun eigen karakters. Zoals: een struisvogel die een papieren zak draagt omdat hij verlegen is, een stinkdier die niet te veel bonen mag eten omdat hij anders scheten laat en een flamingo die een influencer is. 

Al deze dieren hebben hun eigen originele persoonlijkheid, wij willen ook onze eigen karakters hun eigen persoonlijkheid geven.

## Game design theory
### Flow state
Flow state
Een speler bereikt flow state als er een balans is tussen de moeilijkheidsgraad van het spel en de stress die een speler ervaart.

![Flow state diagram](/docs/Groepje/Images/flowState.png)

Een game kan op 2 verschillende manieren flow state verstoren:

1. De moeilijkheid van de game is relatief te hoog ten opzichte van de vaardigheden van de speler. Dit zorgt voor stress/spanning, waardoor de speler een spel niet voor langere tijd kan spelen.

2. De moeilijkheid van de game is relatief te laag ten opzichte van de vaardigheden van de speler. Dit zorgt voor verveeldheid, waardoor de speler geen interesse heeft om een spel te spelen.

Flow state wordt in onze game veroorzaakt door de kracht van de enemies zo te laten scalen, dat deze op elk moment haalbaar zouden kunnen zijn, mits de speler de juiste upgrades kiest en de juiste wapens per wave/boss. Dit vereist kennis van de speler met betrekking tot de updates. Hierom geven we de speler een baseline skill niveau om vanaf verder te werken, door een tutorial/guides toe te voegen op bepaalde momenten waar nieuwe features worden geintroduceerd.

### Internal Economy
Een internal economy van een game is een economisch systeem wat zich enkel en alleen in de game bevindt (met uitzonderingen op micro-transactions). Een economie binnen een spel gaat over de flow van resources tussen entities/de game. Binnen het spel zijn er meestal 4 componenten die bepalend zijn voor de economische flow: bronnen, vernietigingen, omvormers en ruilmogelijkheden. Bronnen zorgen voor een toegankelijkheid aan een resource, vernietigingen zorgen ervoor dat de resource niet in overvloed aanwezig is door het te verwijderen van het spel (zorgt tot op zekere hoogte tot schaarste). Omvormers zorgen dat een bepaalde resource omgevormd kan worden tot een andere resource. Deze actie is meestal irreversibel. Ruilmogelijkheden zorgen dat de speler resources kan in ruilen voor (meestal) niet-ruilbare items/resources.

![In game currencies](/docs/Groepje/Images/inGameCurrency.png)

Wij gaan een internal economy in onze game voegen aan de hand van een in-game currency. Deze wordt verkregen door waves/bosses te verslaan. De speler kan ook (een deel van) deze currency verliezen door dood te gaan. Wij hebben nog geen plan om een omvormer specifiek toe te voegen, maar wel een ruilmogelijkheid die een belangrijke rol vervult; de shop. Deze zorgt er namelijk voor dat de in-game currency nuttig is voor de speler. Hier kan de speler zijn/haar karakter sterker maken door de currency in te ruilen voor stat/weapon upgrades.

## Bronnenlijst
[Internal economy how-to design](https://www.peachpit.com/articles/article.aspx?p=1925649)
