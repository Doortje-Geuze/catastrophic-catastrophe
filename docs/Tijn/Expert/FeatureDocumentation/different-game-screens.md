# Different game screens

## Probleem
Aan het begin van dit project wordt alles van de game laten zien op 1 scherm van de game. Dit wordt in deze repository, de gamestate genoemd.

```C#
namespace Blok3Game.GameStates
{
    public class GameState : MenuItem
    {
        //all lists, objects and variables at the start of the game for the gamestate are created in the code here
        public GameState() : base()
        {
            //all lists, objects and variables at the start of the game for the gamestate are instantiated here, meaning they will show up when the gamestate is loaded in
        }
    }
}
```

Dit ziet er dan als volgt uit in de Game.cs:

```C#
public class Game : GameEnvironment
{
    protected override void LoadContent()
    {
        //extra code for loading the game

        GameStateManager.AddGameState("GAME_STATE", new GameState());
        GameStateManager.SwitchToState("GAME_STATE");
    }
}
```

Hier start de game direct in de gamestate. Dit is een probleem voor meerdere redenen: De speler heeft geen tijd om settings en andere zaken in een menu aan te passen voordat de game start en de speler kan niet zelf kiezen wanneer de game start als deze is opgestart, zoals met een 'start game' knop op een hoofdmenu bijvoorbeeld.

Het gebruik van alleen de gamestate voor de hele game kan maar voor een korte tijd goed gaan, omdat alle code die te maken heeft met interactie tussen objecten, in de gamestate moet staan. Het gebruik van alleen de gamestate voor langere tijd zorgt voor veel clutter, als je bijvoorbeeld objecten hebt die je maar 1x in 10 minuten gebruikt tijdens een andere schermdisplay.

## Oplossing
De oplossing hiervoor is op papier vrij simpel; het gebruik van meerdere states voor bepaalde schermdisplays in de game. Hiervoor moeten allereerst nieuwe game states gedefinieerd worden. Voor dit voorbeeld wordt gekeken naar de losescreen- en upgrade state. Hieronder de code ervoor.

=== "UpgradeState"
    ```C#
    public class UpgradeState : MenuItem
    {
        TextGameObject CurrencyCount;
        public UpgradeState() : base()
        {
            CreateButtons();
            CreateTexts();
        }

        //updating and resetting of this state goes here

        private void CreateTexts()
        {
            //creation of the updateable currency text goes here
        }

        private void CreateButtons()
        {
            //creation of all the upgrade buttons and buttons to go back to the main shop
        }

        private void OnButtonShopClicked(UIElement element)
        {
            GameEnvironment.AssetManager.AudioManager.PlaySoundEffect("button_agree");
            nextScreenName = "SHOP_STATE";
            ButtonClicked();
        }

        //functionality of different upgrade buttons goes here, not shown because the code itself is not important for this documentation

        private void UpgradeButtonClicked(int value, string type, int currencyRequirement)
        {
            if (GameState.Instance.player.currencyCounter < currencyRequirement) return;
            GameEnvironment.AssetManager.AudioManager.PlaySoundEffect("button_agree");
            GameState.Instance.player.UpdateValue(value, type);
            GameState.Instance.player.currencyCounter -= currencyRequirement;
            nextScreenName = "UPGRADE_STATE";
            ButtonClicked();
        }
    }
    ```

=== "ShopState"
    ```C#
    public class ShopState : MenuItem
    {
        public ShopState() : base()
        {
            CreateButtons();
        }

        //updating and resetting of this state goes here

        private void CreateButtons()
        {
            //creation of all the buttons goes here
        }

        //code for buttons to go to main menu, upgrade state and restart the level would be here
    }
    ```

Wanneer de speler in de gamestate doodgaat (dit betekent de hitpoints van de speler zijn 0), dan komt de speler direct in de shopstate. Hierin kan de speler naar de main menu gaan, het spel opnieuw proberen of nog belangrijker, naar de upgrade state gaan.

In de upgradestate kan de speler upgrades kopen op verschillende aspecten, aan de hand van verzamelde currency. Ook kan de speler terug naar de shop, waarin hij/zij dus weer naar main menu kan gaan of het spel opnieuw kan proberen.

In de upgradestate wordt gebruik gemaakt van de functie UpgradeButtonClicked (zie code block). Deze gebruikt verschillende meegegeven parameters om verschillende upgrades uit te voeren op de player. Dit wordt gedaan aan de hand van de volgende switch-case statement in de Player.cs.

```C#
public void UpdateValue(int value, string type)
{
    switch (type)
    {
        case "HitPoints":
            HitPoints += value;
            GameState.Instance.playerHealth.Text = $"{HitPoints}";
            break;
        case "MoveSpeed":
            BaseMoveSpeed += value;
            MoveSpeed += value;
            break;
        case "InvulnerabilityCooldown":
            BaseInvulnerabilityCooldown += value;
            break;
        case "DashCooldown":
            BaseDashCooldown -= value;
            break;
    }
}
```

Door deze functie kunnen 4 verschillende attributen van de speler aangepast worden door het gebruik van 1 functie. 

Als al deze functionaliteit in alleen de gamestate zou staan, dan zou dit bestand overvol raken (ongeveer 1000+ regels). Dit zou het werken steeds en steeds minder overzichtelijk maken, wat voor enorme tijdsverlies kan zorgen. Door elke losstaande toestand binnen een game op een ander scherm te laten zien, bespaart dit enorm veel clutter in de code.

Het is gelukkig alsnog mogelijk om variablen uit andere states aan te passen in een state. Dit kan gedaan worden door een static instance te maken van de state waarvan een variable moet worden aangepast. Deze kan vervolgens gerefereerd worden door elke andere state. Hieronder een voorbeeld:

```C#
public static GameState Instance { get; private set;}
//extra variable assignment
public GameState() : base()
{
    if (Instance != null)
    {
        throw new Exception("Only one instance of GameState is allowed");
    }

    Instance = this;
}
```

Deze code maakt een static variable aan genaamd GameState, die vervolgens bij creatie van de GameState meekrijgt dat het ook een GameState is (door gebruik van 'this'). Vervolgens kan elke public variable worden aangeroepen in een andere state. De [UpgradeButtonClicked](https://suuleewooyaa34-propedeuse-hbo-ict-onderwijs-2023-379a4339aa11c7.dev.hihva.nl/Tijn/Expert/FeatureDocumentation/different-game-screens/#oplossing) functie maakt hier effectief gebruik van.

Ik heb binnen de code nog meer gebruik gemaakt van verschillende schermen, maar dit was mijn meest nuttige invulling van deze feature.