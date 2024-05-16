# Peer Code Review Senna

## Introductie

Deze documentatie dient als hulpmiddel tijdens de peer code review. Beoordeel Kwantiteit, Kwaliteit, Complexiteit en Toelichting & documentatie van elk teamgenoot. Noteer concrete verbeterpunten en bereken een compliance score. Hoe lager de score, hoe concreter het actieplan.

## Weight

| **Feature**                                    | **Weight** | **Commit/Link**                     |
|------------------------------------------------|------------|--------------------------------------|
| `Feature  camera`                             | `3`    | [camera](https://gitlab.fdmci.hva.nl/propedeuse-hbo-ict/onderwijs/2023-2024/out-d-se-gd/blok-4/suuleewooyaa34/-/commit/cbb3fb4f1266014310221bccb184fe610dbed440)           |
| `Feature  shooting Enemy`                       | `3`    | link naar commit is niet meer te vinden omdat we sommige brances moesten verwijderen            |
| `Feature  standard Enemy`                       | `4`    | [Standard enemy](https://gitlab.fdmci.hva.nl/propedeuse-hbo-ict/onderwijs/2023-2024/out-d-se-gd/blok-4/suuleewooyaa34/-/commit/aa15f8b4dde02b68afc43dd6d975d83b319823ae)           |
| `Feature  Enemy movement`                       | `3`    | [Enemies bewegen](https://gitlab.fdmci.hva.nl/propedeuse-hbo-ict/onderwijs/2023-2024/out-d-se-gd/blok-4/suuleewooyaa34/-/commit/247420fc84825001f105fbfada13e36c54c33d9c)            |
 `Feature  enemy Spawning`                       | `4`    | [Enemies spawnen](https://gitlab.fdmci.hva.nl/propedeuse-hbo-ict/onderwijs/2023-2024/out-d-se-gd/blok-4/suuleewooyaa34/-/commit/246152927ed41c9ba39a324df21f8b29c8cc92a4)            |
| **Totaal Weight:**                             |    `17`    |                                      |



## Kwantiteit

| **Meetbare doelen**                             | **Evaluatie**                         |
|-------------------------------------------------|--------------------------------------|
| Ten minste 1 programmeer-commit per werkdag, minstens 5 per week. | `nee` |
| Je pakt minstens een weight van 6 per week aan features, waarbij 1 een hele kleine feature is en 5 een hele grote. | `ja` |

**Concrete Verbeterpunten:**
1. `Senna doet nu minder commits, hij commit nu waneer er iets af is. Dit kan verbeterd worden door elke dag kleine commita te doen.`


**Compliance Score:** `50`%

**Actieplan:**
- `Ga vanaf nu meer commits per dag doen, ookal is een feature nog niet af. Dit laat zien dat je elke dag bezig ben`

---

## Kwaliteit

| **Meetbare doelen**                             | **Evaluatie**                             |
|-------------------------------------------------|------------------------------------------|
| **Minstens 1x per sprint**                         |                                          |
| - OOP toegepast                                 | `half` |
| - Minstens 1 stukje logica geschreven           | `ja` |
| **Code Conventies**                                |                                          |
| - Duidelijke variabele en functienamen & de naam beschrijft duidelijk wat het doet | `nee` |
| - Gebruik van indentatie zoals afgesproken met je groep | `ja` |
| - C# algemene code conventies toegepast         | `ja` |
| - Ingewikkelde code is gecomment                | `ja` |
| - Alleen public wanneer nodig                   | `nee` |
| - Magic numbers vermeden                        | `ja` |
| **Onderhoudbaarheid/Bruikbaarheid**                |  |
| - Je kan makkelijk iets aanpassen zonder dat het breekt | `ja` |
| - Geen dubbele code                             | `ja` |
| - Weinig of geen bugs                           | `ja` |
| - Nagedacht over toekomstig gebruik             | `ja` |
| - Weinig directe referenties                    | `ja` |

**Concrete Verbeterpunten:**
1. `Er is nu nog veel gebruik gemaakt van public classes, hierdoor zijn de classes open voor verandering. Echter zijn senna zijn classes wel compact en logisch ingedeeld waardoor ze makkelijk te begrijpen zijn.`
2. `Gebruik duidelijke namen in je code (niet enemies maar enemy)`
3. `Let er op dat je OOP toepas`

**Compliance Score:** `88`%

**Actieplan:**
- `Let vanaf nu op het gebruiken van public classes, veel classes zijn prublic terwijl dat niet altijd nodig is. Gebruik duidelijke namen in je code en ga abstraction en polymorphism toepassen op je code `

---

## Complexiteit

| **Meetbare doelen**                            | **Evaluatie**                                    |
|------------------------------------------------|-------------------------------------------------|
| Op basis van je actieplan (toets, code review) | `__` |
| Technische uitdagingen overwonnen              | `ja` |
| Gebruik van effectieve algoritmen en datastructuren | `half` |
| Samenwerking met andere delen van het systeem  | `ja` |

**Concrete Verbeterpunten:**
1. `Meer datastruturen gebruiken`


**Compliance Score:** `62`%

**Actieplan:**
- `Ga je oude code reviewen en kijk of je aanpassiggen kan maken met nieuwe datastructuren , je gebruik nu List, ga nu verder met anderen datastructuren`

---

## Toelichting & documentatie

| **Meetbare doelen**                             | **Evaluatie**                          |
|-------------------------------------------------|---------------------------------------|
| Elke feature is binnen een week voorzien van context en documentatie. | `nee` |
| Gebruik van code fragmenten en andere relevante documentatiemiddelen (diagrammen, etc.). | `ja` |
| Voor elke feature van weight > 2 is er documentatie inclusief gebruiksinstructies (denk aan gifs, screenshots). | `nee` |
| Minstens 1 feature gedocumenteerd & uitgelegd.  | `nee` |

**Concrete Verbeterpunten:**
1. `Maak documentatie van code`


**Compliance Score:** `25`%

**Actieplan:**
- `Ga nu features die je maakt ook gelijk documenteren en vorzien van comments, voorzien je documentatie ook van code fragmenten`

---
