# GAP-analyse voor Senna, van Sed

## Introductie

Deze documentatie dient als hulpmiddel tijdens de peer code review. Beoordeel Kwantiteit, Kwaliteit, Complexiteit en Toelichting & documentatie van elk teamgenoot. Noteer concrete verbeterpunten en bereken een compliance score. Hoe lager de score, hoe concreter het actieplan.

## Weight

| **Feature**                                    | **Weight** | **Commit/Link**                     |
|------------------------------------------------|------------|--------------------------------------|
| `Player Position Manager`                      | `0`    | [ ]()           |
| `Camera`                                       | `0`    | []()            |
| `Database gemaakt`                             | `0`    | []()            |
| `Game op Itch.io`                              | `0`    | []()            |
| **Totaal Weight:**                             | `0`    |                                      |

---

## Kwantiteit

| **Meetbare doelen**                             | **Evaluatie**                         |
|-------------------------------------------------|--------------------------------------|
| Ten minste 1 programmeer-commit per werkdag, minstens 5 per week. | `nee` |
| Je pakt minstens een weight van 6 per week aan features, waarbij 1 een hele kleine feature is en 5 een hele grote. | `nee/ja` |

**Concrete Verbeterpunten:**
1. `Je commit pas wanneer een feature af is of wanneer het werkend is. Commit minstens elke keer aan het einde van de dag ookal ben je nog niet klaar met de feature.`
2. `--`

**Compliance Score:** `00`%

**Actieplan:**
- `--`

---

## Kwaliteit

| **Meetbare doelen**                             | **Evaluatie**                             |
|-------------------------------------------------|------------------------------------------|
| **Minstens 1x per sprint**                         |                                          |
| - OOP toegepast                                 | `ja` |
| - Minstens 1 stukje logica geschreven           | `ja` |
| **Code Conventies**                                |                                          |
| - Duidelijke variabele en functienamen & de naam beschrijft duidelijk wat het doet | `ja` |
| - Gebruik van indentatie zoals afgesproken met je groep | `ja` |
| - C# algemene code conventies toegepast         | `ja` |
| - Ingewikkelde code is gecomment                | `nee` |
| - Alleen public wanneer nodig                   | `ja` |
| - Magic numbers vermeden                        | `nee` |
| **Onderhoudbaarheid/Bruikbaarheid**                |  |
| - Je kan makkelijk iets aanpassen zonder dat het breekt | `nee` |
| - Geen dubbele code                             | `ja` |
| - Weinig of geen bugs                           | `ja` |
| - Nagedacht over toekomstig gebruik             | `ja` |
| - Weinig directe referenties                    | `ja` |

**Concrete Verbeterpunten:**
1. `Zet bij je code comments neer zodat je mede-ontwikkelaars snappen wat een stuk code doet`
2. `In je enemy spawning code staan nog magic numbers verborgen die de code zouden breken als er iets verandert zou worden aan de groote van de game screen`

**Compliance Score:** `75`%

**Actieplan:**
- `Kijk nog eens door je oude code en kijk of je meteen snapt wat er staat. Zo niet, schrijf er dan een comment bij die de code uitlegt`
- `verander de magic numbers naar variabelen`

---

## Complexiteit

| **Meetbare doelen**                            | **Evaluatie**                                    |
|------------------------------------------------|-------------------------------------------------|
| Op basis van je actieplan (toets, code review) | `half` |
| Technische uitdagingen overwonnen              | `ja` |
| Gebruik van effectieve algoritmen en datastructuren | `nee` |
| Samenwerking met andere delen van het systeem  | `ja` |

**Concrete Verbeterpunten:**
1. `De vorige code review werdt je er op gewezen dat je meer onafgeronde features moet gaan committen omdat je dat nog te weinig deed. Dit heb je bijna niet verandert en is ook nu nog een probleem`
2. `Gebruik meer datastructuren behalve Lists`

**Compliance Score:** `60`%

**Actieplan:**
- `Commit je code aan het einde van de dag ookal is het nog niet af`

---

## Toelichting & documentatie

| **Meetbare doelen**                             | **Evaluatie**                          |
|-------------------------------------------------|---------------------------------------|
| Elke feature is binnen een week voorzien van context en documentatie. | `ja` |
| Gebruik van code fragmenten en andere relevante documentatiemiddelen (diagrammen, etc.). | `ja` |
| Voor elke feature van weight > 2 is er documentatie inclusief gebruiksinstructies (denk aan gifs, screenshots). | `nee` |
| Minstens 1 feature gedocumenteerd & uitgelegd.  | `ja` |

**Concrete Verbeterpunten:**
1. `Je maakt goed gebruik van code fragmenten maar je mist nog gifs en/of screenshots die laten zien wat de feature uiteindelijk doet`

**Compliance Score:** `75`%

**Actieplan:**
- `Voeg screenshots toe aan je documentatie voor context tot wat een feature doet`

---