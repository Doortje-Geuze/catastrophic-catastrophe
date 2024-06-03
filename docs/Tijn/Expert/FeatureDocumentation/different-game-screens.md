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

=== "LoseScreenState"

```C#
public class LoseScreenState : MenuItem
{
    public LoseScreenState() : base()
    {
        CreateButtons();
        CreateTitle();
    }

    //updating and resetting code here

    private void CreateButtons()
    {
        //different button creations
    }

    private void OnButtonReviveClicked(UIElement element)
    {
        GameEnvironment.AssetManager.AudioManager.PlaySoundEffect("button_agree");
        nextScreenName = "GAME_STATE";
        ButtonClicked();
    }

    private void OnButtonMainMenuClicked(UIElement element)
    {
        GameEnvironment.AssetManager.AudioManager.PlaySoundEffect("button_agree");
        nextScreenName = "MAIN_MENU_STATE";
        ButtonClicked();
    }

    //create the losing text here
}