# Expert review sprint 2
## OOP
### Abstraction

### Encapsulation

### inheritance

### Polymorphism

## UML diagrammen
### Class diagram
Gedurende het project heb ik meerdere  classes aangemaakt voor objecten en methods in de game. In onderstaand diagram is te zien hoe de classes zijn verbonden en samenwerken. Allereerst heb ik een Enemy class aangemaakt. Van deze Enemy class inheriten 2 child classes genaamd ShootingEnemy en StandardEnemy. De Enemy class inherit weer van een Character class die weer inherit van SpriteGameObject. Een andere class die ik heb aangemaakt is de Camera class. Dit object gaat de speler volgen in het level waardoor de speler vrij rond kan lopen zonder dat hij steeds tegen een border aanloopt. De Camera inherit van GameObject. De Camera is nog een work in progress. Ook heb ik een EnemyBullet class aangemaakt die inherit van een algemene Bullet class die weer inherit van RotatingSpriteGameObject. In alle classes in het diagram is te zien van welke variabelen en methods er gebruik wordt gemaakt en of ze private, protected of public zijn.  

![Class diagram](<../Groepje/Images/Class-diagram-blok-4 jaar-1-Senna-de-Vries.png>)  

### Sequence diagram
Ik heb gekozon voor een Sequence diagram zodat ik één structuurdiagram en één gedragsdiagram heb gebruikt. Dit geeft een breder inzicht in de game. De sequence diagram geeft de flow van de game goed weer. Er is te zien dat de speler het spel kan starten waarna er een level wordt ingeladen met een wave aan enemies en een boss. De enemies schieten op de player en de player kan terugschieten naar de enemies. Als de speler de boss verslaat laat hij zijn wapen vallen en kan de speler het wapen oppakken en gebruiken. Als de speler alle enemies heeft verslagen spawnt er een nieuwe wave. Als de speler al zijn levens kwijt is of als alle waves met enemies zijn verslagen is het spel voorbij.  

![Sequence diagram](../Groepje/Images/Sequence-diagram-blok-4-jaar-1-Senna-de-Vries.png)

## Database