# Feature: Box

## Doel
Het doel is om een box te hebben die je kan aanrakken.

## Wat is er voor nodig

- Box class
- Box moet geplaatst worden op het sherm
- Collisioncheck met de box en de speler


## Proces

### Box aanmaken
omdat er meerdere boxen moeten komen die vaak dezelfde atributen hebben heb ik een abstracte class gemaakt.

```c#
    public abstract class Box : SpriteGameObject
    {
        public Box(Vector2 position, string assetName, int layer = 0, string id = "", int sheetIndex = 0) : base(assetName)
        {
            Position = position;
        }
    }
```

deze abstracte class box wordt geinherit door de class yellowbox en purplebox 

```C#

    public class YellowBox : Box
    {
        public YellowBox(Vector2 position) : base(position, "Images/Tiles/SquareYellow", 0, " ", 0)
        {
        }
    }

 public class PurpleBox : Box
    {
        public PurpleBox(Vector2 position) : base(position, "Images/Tiles/PurpleSquare", 0, " ", 0)
        {

        }
    }

```

### Box moet geplaatst worden op het scherm
 In de gamstate word de box in een list geplaatst

 alle lists, objects and variables aan de start van de game voor de gamestate worden aan het begin van de class gecreert
 
 ```c#
 private List<Box> boxlist;
 ```

 daarna bij `GameStat` wordt de list aan gemaakt:

```c#
 boxlist = new List<Box>();
 ```
In het spel kom je vershillende waves tegen. Na wave 2 heb je de kans om een box op te pakken. op het scherm krijg je 2 boxxen te zien met de tekst: "Choose your upgrade!"

![Foto choose your upgrade!]()

```C#
 case 1: //Wave 2
                    if (EnemyList.Count == 0)
                    {
                        if (boxlist.Count == 0 && (!pickedUpPurple || !pickedUpYellow))
                        {
                            
                            yellowBox = new YellowBox(new Vector2((GameEnvironment.Screen.X / 2) - 100, 150));
                            boxlist.Add(yellowBox);

                            Add(yellowBox);

                            
                            purpleBox = new PurpleBox(new Vector2((GameEnvironment.Screen.X / 2) + 100, 150));
                            boxlist.Add(purpleBox);

                            Add(purpleBox);

                            chooseUpgrade = new TextGameObject("Fonts/SpriteFont@20px", 1);
                            Add(chooseUpgrade);
                            chooseUpgrade.Text = $"Choose your upgrade!";
                            chooseUpgrade.Color = new(255, 255, 255);
                            chooseUpgrade.Position = new Vector2((GameEnvironment.Screen.X / 2 - chooseUpgrade.Size.X / 2) + 20, 200);
                        }
                        else if (pickedUpPurple || pickedUpYellow)
                        {
                            WaveCounter++;
                            NewWave = true;
                            WaveIndicatorShowTime = 0;
                            ResetBullets();
                            SpawnFastEnemies();
                        }
```

### Collisioncheck met de box en de speler

De methode BoxCollision checked voor clossion met de box en de player. hij loopt door de boxList met een `foreach` loop en dan cheked hij voor collion met de player via `Player.CheckFotPlayerCollision`. Al is er een collion met de purplebox of yellowbox dan is `pickedUp` true. als is het true dan wordt de bo toegevoegd aan de removed list zodat het niet meer op het scherm staat.


```C#
private void BoxCollision()
        {
            foreach (Box box in boxlist)
            {
                if (player.CheckForPlayerCollision(box))
                {
                    if (box is YellowBox)
                    {
                        pickedUpYellow = true;
                    }

                    if (box is PurpleBox)
                    {
                        pickedUpPurple = true;
                    }
                }

                if (pickedUpPurple || pickedUpYellow)
                {
                    toRemoveList.Add(box);
                    toRemoveList.Add(chooseUpgrade);
                }
            }
        }
```