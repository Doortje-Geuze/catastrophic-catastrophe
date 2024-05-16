# Peer Code Review Template

## Introductie

Deze documentatie dient als hulpmiddel tijdens de peer code review. Beoordeel Kwantiteit, Kwaliteit, Complexiteit en Toelichting & documentatie van elk teamgenoot. Noteer concrete verbeterpunten en bereken een compliance score. Hoe lager de score, hoe concreter het actieplan.

## Weight

| **Feature**                                    | **Weight** | **Commit/Link**                     |
|------------------------------------------------|------------|--------------------------------------|
| `Player Movement       `                       | `3`    | `[Link naar commit]([URL](https://gitlab.fdmci.hva.nl/propedeuse-hbo-ict/onderwijs/2023-2024/out-d-se-gd/blok-4/suuleewooyaa34/-/commit/4d7e7373be7e832ea4d20733fa5c669827905658))`            |
| `Player Dash`                                  | `4`    | `[Link naar commit]([URL](https://gitlab.fdmci.hva.nl/propedeuse-hbo-ict/onderwijs/2023-2024/out-d-se-gd/blok-4/suuleewooyaa34/-/commit/34a75934b399c0a12a78ef18c157b0090d75b055))`            |
| `Win/lose`                                     | `1`    | `[Link naar commit]([URL](https://gitlab.fdmci.hva.nl/propedeuse-hbo-ict/onderwijs/2023-2024/out-d-se-gd/blok-4/suuleewooyaa34/-/commit/656647e8053c3985ec58685052f43a79d36fcfb9))`            |
| `Player HP`                                    | `2`    | `[Link naar commit]([URL](https://gitlab.fdmci.hva.nl/propedeuse-hbo-ict/onderwijs/2023-2024/out-d-se-gd/blok-4/suuleewooyaa34/-/commit/075f389a28faa151201925e8b4d9780f649ba967))`            |
| `Invulnerability`                              | `4`    | `[Link naar commit]([URL](https://gitlab.fdmci.hva.nl/propedeuse-hbo-ict/onderwijs/2023-2024/out-d-se-gd/blok-4/suuleewooyaa34/-/commit/b4c51e69952b294a8ff6b2c84cb3b0d3f9d27d3b))`            |
| **Totaal Weight:**                             | `14`    |                                      |

---

## Kwantiteit

| **Meetbare doelen**                             | **Evaluatie**                         |
|-------------------------------------------------|--------------------------------------|
| Ten minste 1 programmeer-commit per werkdag, minstens 5 per week. | `Ja` |
| Je pakt minstens een weight van 6 per week aan features, waarbij 1 een hele kleine feature is en 5 een hele grote. | `Ja` |

**Concrete Verbeterpunten:**
-

**Compliance Score:** `100`%

**Actieplan:**
- `Tijn is elke fysieke schooldag aanwezig en werkend aan het project. Ook is in de commit geschiedenis te zien dat Tijn door werkt op woensdag en/of vrijdag. Tijn heeft zich bezig gehouden met de speler en alles daarom heen zoals:
- Movement
- HitPoints
- Invincibilty

Tijn draagt hierdoor meer dan voldoende mee aan het project en heeft hij tot nu toe 5 á 6 user stories gemiddeld per week afgerond.`

---

## Kwaliteit

| **Meetbare doelen**                             | **Evaluatie**                             |
|-------------------------------------------------|------------------------------------------|
| **Minstens 1x per sprint**                         |                                          |
| - OOP toegepast                                 | `Ja` |
| - Minstens 1 stukje logica geschreven           | `Ja` |
| **Code Conventies**                                |                                          |
| - Duidelijke variabele en functienamen & de naam beschrijft duidelijk wat het doet | `Ja` |
| - Gebruik van indentatie zoals afgesproken met je groep | `Ja` |
| - C# algemene code conventies toegepast         | `Ja` |
| - Ingewikkelde code is gecomment                | `Ja` |
| - Alleen public wanneer nodig                   | `Ja` |
| - Magic numbers vermeden                        | `Nee` |
| **Onderhoudbaarheid/Bruikbaarheid**                |  |
| - Je kan makkelijk iets aanpassen zonder dat het breekt | `Soms` |
| - Geen dubbele code                             | `Ja` |
| - Weinig of geen bugs                           | `Ja` |
| - Nagedacht over toekomstig gebruik             | `Ja` |
| - Weinig directe referenties                    | `Ja` |

**Concrete Verbeterpunten:**
1. `Let op je magic numbers, je gebruikt bijvoorbeeld voor de player dash nog magic numbers om te bepalen waar een speler mag dashen. Dits vervelend als de spel wereld groter wordt`
2. `Door de magic numbers breekt je code als je daar iets verandert`

**Compliance Score:** `90`%

**Actieplan:**
- `Ga nog eens door je code en verander de magic numbers. De magic numbers zorgen ervoor dat je code breekt als je bijvoorbeeld player dashing verandert.`

---

## Complexiteit

| **Meetbare doelen**                            | **Evaluatie**                                    |
|------------------------------------------------|-------------------------------------------------|
| Op basis van je actieplan (toets, code review) | `-` |
| Technische uitdagingen overwonnen              | `Ja` |
| Gebruik van effectieve algoritmen en datastructuren | `Nee` |
| Samenwerking met andere delen van het systeem  | `Ja` |

**Concrete Verbeterpunten:**
1. `Gebruik Datastructuren zoals Lists en Dictionary`

**Compliance Score:** `66`%

**Actieplan:**
- `Begin ook met het gebruiken van Generics(List, Dictionary), je hebt hier nog geen gebruik van gemaakt en er wordt van je verwacht dat je die in je code hebt verwerkt. `

---

## Toelichting & documentatie

| **Meetbare doelen**                             | **Evaluatie**                          |
|-------------------------------------------------|---------------------------------------|
| Elke feature is binnen een week voorzien van context en documentatie. | `Nee` |
| Gebruik van code fragmenten en andere relevante documentatiemiddelen (diagrammen, etc.). | `Soms` |
| Voor elke feature van weight > 2 is er documentatie inclusief gebruiksinstructies (denk aan gifs, screenshots). | `Nee` |
| Minstens 1 feature gedocumenteerd & uitgelegd.  | `Nee` |

**Concrete Verbeterpunten:**
1. `Voeg meer code snippets toe in je documentatie`
2. `Je hebt nog geen documentatie over je code`

**Compliance Score:** `20`%

**Actieplan:**
- `Je hebt nog geen documentatie geschreven over je code, hierdoor heb je nog geen code snippets of gifs/screenshots van je features opgeschreven.`

---
