# Expert review Doortje Sprint 3

## LinkedIn certificaten + quiz resultaat
Relsutaat quiz 14-5-2024: Op niveau      
Resultaat quiz 4-6-2024: in ontwikkeling

Bewijs voor linkedin cursus:
[LinkedIn cursus documentatie](https://suuleewooyaa34-propedeuse-hbo-ict-onderwijs-2023-379a4339aa11c7.dev.hihva.nl/Doortje/LinkenIn-Cursus/)

## OOP

### Abstraction
Binnen OOP is abstraction het verbergen van complexe en onnodige informatie voor de gebruiker. Ik heb dit gedaan door middel van private methods en het keyword `abstract`

=== "Gamestate"
```Csharp
// Private methode SpawnFastEnemies
private void SpawnFastEnemies()
        {
            Random random = new Random();

            int swap = 0;
            //For-loop om meerdere enemies aan te maken
            for (int i = 0; i < 10 * WaveCounter; i++)
            {
                int XPosition, YPosition;

                //Willekeurige posities waar de enemies spawnen
                XPosition = random.Next(0 - 300, GameEnvironment.Screen.X + 700);
                YPosition = random.Next(0 - 300, GameEnvironment.Screen.Y + 700);


                //Do-While loop die ervoor zorgt dat de enemies aan de buiten randen spawnen 
                //De swap variabele zorgt ervoor dat de enemies evenredig worden verdeel aan alle kanten
                do
                {
                    if (swap % 2 == 0)
                    {
                        XPosition = random.Next(0 - 300, GameEnvironment.Screen.X + 700);
                        swap++;
                    }
                    else
                    {
                        YPosition = random.Next(0 - 300, GameEnvironment.Screen.Y + 700);
                        swap++;
                    }

                } while (XPosition >= 0 - 200 && XPosition <= GameEnvironment.Screen.X + 200 &&
                         YPosition >= 0 - 200 && YPosition <= GameEnvironment.Screen.Y + 200);

                //Aanmaken van de enemies
                fastEnemy = new FastEnemy(1, 3, new Vector2(XPosition, YPosition));

                EnemyList.Add(fastEnemy);
                Add(fastEnemy);
            }
        }
```
=== "Characters"
```Csharp
public abstract class Character : SpriteGameObject
{
    //all variables that a character needs
    public int HitPoints;
    protected int MoveSpeed;

    public Character(int hitPoints, int moveSpeed, Vector2 position, string assetName = " ", int layer = 0, string id = "", int sheetIndex = 0) : base(assetName)
    {
        HitPoints = hitPoints;
        MoveSpeed = moveSpeed;
        Position = position;
    }
}
```

### Encapsulation
Binnen ons project zijn veel classes public, dit is omdat de classes op meerdere plekken gebruikt moeten kunnen worden. Enkele methodes zijn private gamaakt.

=== "Enemy"
```Csharp
//Enemy class met public methodes en variabelen omdat deze weer op anderen pleken gebruikt moeten worden
public class Enemy : Character
    {
        public int EnemyMoveSpeed;
        public Vector2 steering;
        public Vector2 desired_velocity;
        public int EnemyShootCooldown = 120;

        public Enemy(int hitPoints, int moveSpeed, Vector2 position, string assetName, int layer = 0, string id = "", int sheetIndex = 0) : base(hitPoints, moveSpeed, position, assetName)
        {
            EnemyMoveSpeed = moveSpeed;
        }

        public void EnemySeeking(Vector2 PlayerPosition) // Made with the help of https://code.tutsplus.com/understanding-steering-behaviors-seek--gamedev-849t
        {
            desired_velocity = PlayerPosition - position;
            desired_velocity.Normalize();
            desired_velocity *= EnemyMoveSpeed;

            steering = desired_velocity - velocity;

            steering = steering / 5;
            velocity = velocity + steering;
            position += velocity;
        }
    }
```
=== "SpawnFastEnemy"
```Csharp
//private method SpawnfastEnemies() Deze method dient niet van buitenaf aangepast te kunnen worden.
private void SpawnFastEnemies()
        {
            Random random = new Random();

            int swap = 0;
            //For-loop om meerdere enemies aan te maken
            for (int i = 0; i < 10 * WaveCounter; i++)
            {
                int XPosition, YPosition;

                //Willekeurige posities waar de enemies spawnen
                XPosition = random.Next(0 - 300, GameEnvironment.Screen.X + 700);
                YPosition = random.Next(0 - 300, GameEnvironment.Screen.Y + 700);


                //Do-While loop die ervoor zorgt dat de enemies aan de buiten randen spawnen 
                //De swap variabele zorgt ervoor dat de enemies evenredig worden verdeel aan alle kanten
                do
                {
                    if (swap % 2 == 0)
                    {
                        XPosition = random.Next(0 - 300, GameEnvironment.Screen.X + 700);
                        swap++;
                    }
                    else
                    {
                        YPosition = random.Next(0 - 300, GameEnvironment.Screen.Y + 700);
                        swap++;
                    }

                } while (XPosition >= 0 - 200 && XPosition <= GameEnvironment.Screen.X + 200 &&
                         YPosition >= 0 - 200 && YPosition <= GameEnvironment.Screen.Y + 200);

                //Aanmaken van de enemies
                fastEnemy = new FastEnemy(1, 3, new Vector2(XPosition, YPosition));

                EnemyList.Add(fastEnemy);
                Add(fastEnemy);
            }
        }
```

### inheritance
Alle classes die ik heb gemaakt in dit blok inheriten van een andere class. Ze nemen de methods en variabelen van andere classes over. 

```Csharp
public abstract class Box : SpriteGameObject
{
}
public class YellowBox : Box
{
}
public class PurpleBox : Box
{
}
public class FastEnemy : Enemy
{
}
public class PlayerBullet : Bullet
{
}
```

### Polymorphism
Binnen het project worden verschillende classes herbruikt door middel van inheritance en override statements. Zo wordt de Update functie op meerdere plekken ge-override.

=== "Bullet"
```Csharp
 public class Bullet : RotatingSpriteGameObject
    {
        protected int BulletMoveSpeed = 0;

        public Bullet(Vector2 position, double angle, int bulletMoveSpeed, string assetName) : base(assetName)
        {
            Position = position;
            Angle = (float)angle;
            BulletMoveSpeed = bulletMoveSpeed;
        }

//Override voor Update()
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (Position.X > 0 - Width && Position.X < GameEnvironment.Screen.X + Width && Position.Y > 0 - Width && 
                Position.Y < GameEnvironment.Screen.Y + Width)
            {
                position += AngularDirection * BulletMoveSpeed;
            }
            else
            {
                velocity = new Vector2(0, 0);
            }
        }
    }
```
=== "GatGun"
```Csharp
//Override voor Update()
public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);

        if (Sprite.Mirror)
        {
            position = new Vector2(playerPos.Position.X - 28, playerPos.Position.Y + 40);
            if (CatArms)
            {
                LookAt(crossHair, 180);
            }
        }
        else
        {
            position = new Vector2(playerPos.Position.X + 28, playerPos.Position.Y + 40);
            if (CatArms)
            {
                LookAt(crossHair);
            }
        }
    }
```

## UML diagrammen

### Class diagram

![UML-class-diagram](../sprint%203/uml-class-diagram-blok4.png)

### Sequence diagram

![Sequance-diagram](../sprint%203/Sequence-diagram-blok4.png)

## Database

![EER](/docs/images/EERSprint2.png)  
![Connection](/docs/images/DatabaseConnection.png) 

### Analytics systeem

## Principles

### Single responsibility principle

### Dependency inversion principle

```Csharp

// Abstract class box
public abstract class Box : SpriteGameObject
    {
        public Box(Vector2 position, string assetName, int layer = 0, string id = "", int sheetIndex = 0) : base(assetName)
        {
            Position = position;
        }
    }

    // yelow box gives Lower Cooldown Upgrade
    public class YellowBox : Box
    {
        public YellowBox(Vector2 position) : base(position, "Images/Tiles/SquareYellow", 0, " ", 0)
        {
        }
    }

    // purple box gives Shotgun upgrade 
    public class PurpleBox : Box
    {
        public PurpleBox(Vector2 position) : base(position, "Images/Tiles/PurpleSquare", 0, " ", 0)
        {

        }
    }
````