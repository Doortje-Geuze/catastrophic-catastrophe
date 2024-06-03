# Different game screens

## Probleem
Aan het begin van dit project wordt alles van de game laten zien op 1 scherm van de game. Dit wordt in deze repository, de gamestate genoemd.

```C#
namespace Blok3Game.GameStates
{
    public class GameState : GameObjectList
    {
        //all lists, objects and variables at the start of the game for the gamestate are created in the code here
        public GameState() : base()
        {
            //all lists, objects and variables at the start of the game for the gamestate are instantiated here, meaning they will show up when the gamestate is loaded in
        }
    }
}
```

Dit ziet er dan als volgt uit in de game.cs:

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