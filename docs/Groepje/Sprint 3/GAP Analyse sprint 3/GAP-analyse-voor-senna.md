# GAP-analyse voor Senna, van Sed

## Weight

| **Feature**                                    | **Weight** | **Commit/Link**                     |
|------------------------------------------------|------------|--------------------------------------|
| `Player Position Manager`                      | `2`    | [Position manager](https://gitlab.fdmci.hva.nl/propedeuse-hbo-ict/onderwijs/2023-2024/out-d-se-gd/blok-4/suuleewooyaa34/-/commit/92ccdc580c470d1dd3de7aed26338a1f0ac564bb)           |
| `Camera`                                       | `4`    | [Camera](https://gitlab.fdmci.hva.nl/propedeuse-hbo-ict/onderwijs/2023-2024/out-d-se-gd/blok-4/suuleewooyaa34/-/commit/68de2bfa2b72f7e9c1b25f3f3227370ebf7a1a77)          |
| `Database gemaakt (EER)`                       | `3`    | [Connectie in C#](https://gitlab.fdmci.hva.nl/propedeuse-hbo-ict/onderwijs/2023-2024/out-d-se-gd/blok-4/suuleewooyaa34/-/commit/982d2e7ca8b58f2af6932689b4fd090f91b4d75b)            |
| `Game op Itch.io`                              | `2`    | [Itch.io Pagina]()            |
| **Totaal Weight:**                             | `11`   |                                      |

---

## Kwantiteit

| **Meetbare doelen**                             | **Evaluatie**                         |
|-------------------------------------------------|--------------------------------------|
| Ten minste 1 programmeer-commit per werkdag, minstens 5 per week. | `ja` |
| Je pakt minstens een weight van 6 per week aan features, waarbij 1 een hele kleine feature is en 5 een hele grote. | `nee` |

**Concrete Verbeterpunten:**
1. `Je hebt gewerkt aan te weinig features deze sprint`

**Compliance Score:** `50`%

**Actieplan:**
- `Je blijft te lang hangen op een feature als het niet lukt om te maken. Dit zorgt ervoor dat je weinig tijd over hebt om aan andere features te werken. Hak sneller die knoop door.`

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
1. `Gebruik meer datastructuren behalve Lists`

**Compliance Score:** `60`%

**Actieplan:**
- `Gebruik meer datastructuren behalve Lists`

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