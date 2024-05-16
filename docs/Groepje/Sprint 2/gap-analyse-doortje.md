# GAP-analyse voor Doortje, van Tijn

## Introductie

Deze documentatie dient als hulpmiddel tijdens de peer code review. Beoordeel Kwantiteit, Kwaliteit, Complexiteit en Toelichting & documentatie van elk teamgenoot. Noteer concrete verbeterpunten en bereken een compliance score. Hoe lager de score, hoe concreter het actieplan.

## Weight

| **Feature**                                    | **Weight** | **Commit/Link**                     |
|------------------------------------------------|------------|--------------------------------------|
| `PlayerBullet wordt gespawnt`                       | `2`    | [PlayerBullet wordt gespawnt](https://gitlab.fdmci.hva.nl/propedeuse-hbo-ict/onderwijs/2023-2024/out-d-se-gd/blok-4/suuleewooyaa34/-/commit/9ebe3b9f99015e6b3f110ca64508cdd880c3b14d)           |
| `Bullets schieten naar muis`                       | `4`    | [Bullets schieten naar muis](https://gitlab.fdmci.hva.nl/propedeuse-hbo-ict/onderwijs/2023-2024/out-d-se-gd/blok-4/suuleewooyaa34/-/commit/3d0f603a58e2366c4a4e960398816cd47c4ddba8) PS: Deze staat onder Seds naam maar heeft Doortje geschreven           |
| **Totaal Weight:**                             | `6`    |                                      |

---

## Kwantiteit

| **Meetbare doelen**                             | **Evaluatie**                         |
|-------------------------------------------------|--------------------------------------|
| Ten minste 1 programmeer-commit per werkdag, minstens 5 per week. | `nee` |
| Je pakt minstens een weight van 6 per week aan features, waarbij 1 een hele kleine feature is en 5 een hele grote. | `nee` |

**Concrete Verbeterpunten:**
1. `De activiteit rondom het project gaat meestal naar documentatie of theorie toe. Hierdoor wordt er vanuit Doortje onvoldoende bijgedragen aan de game zelf (bijdrage ligt rond de 10-15%).`
2. `Er is in sprint 1 gewerkt aan een user story weight van ongeveer , verspreid over 2 weken. Dit voldoet niet aan de gestelde eis van een weight van 6 per week.`

**Compliance Score:** `25`%

**Actieplan:**
- `Zoek tijd thuis om user stories te vinden die jij niet alleen leuk vindt om te doen, maar die je ook binnen een dag zou kunnen afronden. Als dit niet mogelijk is, probeer dan de user story op te splitten of meldt het bij de rest van het team, zodat deze user story zwaarder wordt meegeteld. Als thuis werken lastig gaat doordeweeks, dan is het weekend altijd een mogelijkheid om op je eigen tempo naar de code te kijken, en nog te zien of je iets extra's kan bijdragen.`

---

## Kwaliteit

| **Meetbare doelen**                             | **Evaluatie**                             |
|-------------------------------------------------|------------------------------------------|
| **Minstens 1x per sprint**                         |                                          |
| - OOP toegepast                                 | `deels` |
| - Minstens 1 stukje logica geschreven           | `ja` |
| **Code Conventies**                                |                                          |
| - Duidelijke variabele en functienamen & de naam beschrijft duidelijk wat het doet | `ja` |
| - Gebruik van indentatie zoals afgesproken met je groep | `ja` |
| - C# algemene code conventies toegepast         | `ja` |
| - Ingewikkelde code is gecomment                | `nee` |
| - Alleen public wanneer nodig                   | `ja` |
| - Magic numbers vermeden                        | `ja` |
| **Onderhoudbaarheid/Bruikbaarheid**                |  |
| - Je kan makkelijk iets aanpassen zonder dat het breekt | `ja` |
| - Geen dubbele code                             | `ja` |
| - Weinig of geen bugs                           | `ja` |
| - Nagedacht over toekomstig gebruik             | `ja` |
| - Weinig directe referenties                    | `ja` |

**Concrete Verbeterpunten:**
1. `Er is geen ingewikkelde code om te commenten, dus er zijn geen comments`
2. `OOP is deels toegepast; polymorphism en abstraction zijn niet/nauwelijks aanwezig`

**Compliance Score:** `85`%

**Actieplan:**
- `Zoek naar opties om polymorphism te gebruiken, zoals bij het gebruik van interfaces (wat ook handig is). Kijk eventueel naar of de bullet class niet naar een interface veranderd kan worden`
- `Probeer voor volgende sprint een user story te kiezen waarbij ingewikkelde code aan te pas komt, zodat deze ook gecomment kan worden.`

---

## Complexiteit

| **Meetbare doelen**                            | **Evaluatie**                                    |
|------------------------------------------------|-------------------------------------------------|
| Op basis van je actieplan (toets, code review) | `n.v.t` |
| Technische uitdagingen overwonnen              | `ja` |
| Gebruik van effectieve algoritmen en datastructuren | `nee` |
| Samenwerking met andere delen van het systeem  | `ja` |

**Concrete Verbeterpunten:**
1. `Gebruik van generics zoals List<> helpen bij kennis over datastructuren`

**Compliance Score:** `50`%

**Actieplan:**
- `Zoek voor volgende sprint naar user stories waar ingewikkelde algoritmen van pas komen, en probeer hier ook generics in te gebruiken`

---

## Toelichting & documentatie

| **Meetbare doelen**                             | **Evaluatie**                          |
|-------------------------------------------------|---------------------------------------|
| Elke feature is binnen een week voorzien van context en documentatie. | `nee` |
| Gebruik van code fragmenten en andere relevante documentatiemiddelen (diagrammen, etc.). | `ja` |
| Voor elke feature van weight > 2 is er documentatie inclusief gebruiksinstructies (denk aan gifs, screenshots). | `nee` |
| Minstens 1 feature gedocumenteerd & uitgelegd.  | `nee` |

**Concrete Verbeterpunten:**
1. `Features documenteren wanneer ze af zijn`

**Compliance Score:** `25`%

**Actieplan:**
- `Features direct commenten en documenteren wanneer ze af zijn, zodat hiernaar gerefereerd kan worden bij een expert`

---