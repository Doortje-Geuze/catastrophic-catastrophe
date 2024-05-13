# Design Principles C#

## Introductie

### Design Principles
Design Priciples zijn richtlijnen die helpen met het verbeteren van het objectgeoriënteerde ontwerp en het voorkomen van slecht objectgeoriënteerd ontwerp. Het zijn een extra reeks richtlijnen boven op de object-oriented concepts (zoals Inheritance).
Er is geen standaard catalogus voor deze principles. De principles verschillen per vakgebied in de ICT en met wie je praat.

### Design Patterns
Design patterns zijn een gevolg van Design Priciples te volgen. Over tijd heeft dit geresulteerd tot een reeks terug komende patronen. Deze patterns gebruiken we voor hoe we grotere objectgeoriënteerde ontwerp structereren.

### Symptonen van een slecht ontwerp
- Het is moeilijk te veranderen vanwege sommige afhankelijkheden
- Als iets in de code verandert breken er niet-gerelateerde delen
- Het kan niet hergebruikt worden op plaatsen waar het niet voor ontworpen was

### Fundamental Principles
- Encapsuleer wat varieert
- Een voorkeur aan samenstelling boven inheritance
- Programeer naar interfaces
- Losse Kopelingsprincipe, streef voor losjes gekoppelde ontwerpen tussen objecten die op elkaar inwerken
- S(ingle responsibilty) O(Open/Closed) L(iskov substitutie) I(nterfacescheidings) D(ependency inversion)