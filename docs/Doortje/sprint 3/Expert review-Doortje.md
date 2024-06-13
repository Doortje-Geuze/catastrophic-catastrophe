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

Voor dit project heb ik een UML class diagram gemaakt om de 
relaties tussen alle classen te visualiseren. Er staan ook classes op die ik niet heb gemaakt, maar wel een relatie hebben met de classes die ik heb gemaakt en in gewerkt heb. Deze worden aangegeven met een leeg vak voor attributen en methodes. In alle classes in het diagram is te zien van welke variabelen en methods er gebruik wordt gemaakt en of ze private, protected of public zijn.


Allereerst is er een Enemy class, deze class inherit van de abstracte class character. Van deze Enemy class inheriten 3 child classes genaamd ShootingEnemy, StandardEnemy en FastEnemy. De Enemy class inherit weer van een Character class die weer inherit van SpriteGameObject. 

Ook heb ik een abstracte class Box gemaakt. Van deze class inheriten 2 child classes, deze zijn YellowBox en PurpleBox.

Verder heb ik een Bullet class gemaakt, deze inherit van RotatingSpriteGameObject. PlayerBullet en Enemybullet inheriten weer van de Bullet class

![UML-class-diagram](../sprint%203/uml-class-diagram-blok4.png)

### Sequence diagram

Voor deze expert review heb ik een Sequence diagram zodat ik één structuurdiagram en één gedragsdiagram heb gebruikt. Dit geeft een breder inzicht in de game. De sequence diagram geeft de flow van de game goed weer. Er is te zien dat de speler het spel kan starten waarna er een level wordt ingeladen met een wave aan enemies en een boss. De enemies schieten op de player en de player kan terugschieten naar de enemies. Als de speler de boss verslaat laat hij zijn wapen vallen en kan de speler het wapen oppakken en gebruiken. Als de speler alle enemies heeft verslagen spawnt er een nieuwe wave. Als de speler al zijn levens kwijt is of als alle waves met enemies zijn verslagen is het spel voorbij.

![Sequance-diagram](../sprint%203/Sequence-diagram-blok4.png)

## Database
Voor de database heb ik een EER gemaakt in mySQL, een connection opgezet met de HBO-ICT cloud, de database gerealiseerd door middel van forward engineeren en met SQL statements data toegevoegd aan de database.

![EER](../sprint%203/EER-blok4-sprint3.png)  
![Connection](../sprint%203/conectie-blok4.png) 

### Analytics systeem

Er wordt al een datapacket opgestuurd naar de database, voor nu is dat nog dummy data

```Csharp
if (player.HitPoints <= 0)
{
    Retry();
    GameEnvironment.GameStateManager.SwitchToState("LOSE_SCREEN_STATE");
    SocketClient.Instance.SendDataPacket(new MatchData{
        TotalWavesSurvived = 2,
        KilledBy = "rat",
        Kills = 4,
        HealthLeft = 0
    });
}
```

```Csharp
 #sendMatchData(socket) {
        socket.on("Example", (data) => {
            this._socketConnectionListener.executePreparedQuery("INSERT INTO `match` (TotalWavesSurvived, KilledBy, Kills, HealthLeft) VALUES (? , ?, ?, ?)", [data.totalWavesSurvived, data.killedBy, data.kills, data.healthLeft])
            console.log(data);
        });
    }

```
![](../sprint%203/ConcollDatabase.PNG)

![](../sprint%203/database.PNG)

## Principles

### Single responsibility principle
De single responsibility hebben we toegepast bij de Bullets. Wij hebben nu vershillende soorten enemies, namelijk: ShootingEnemy, StandardEnemy en FastEnemy. Hierbij wordt gelet op het juist overerven van de enemy classes. De enemies worden uitgebreid met schietende enemies en enemies met hogere snelheiden. Hierbij dienen de originele enemies niet aangepast te worden.

=== "Enemy"

    ```Csharp
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

=== "ShootingEnemy"

    ```Csharp
    public class ShootingEnemy : Enemy
    {
        public int EnemyHitPoints;
        public ShootingEnemy(int hitPoints, int moveSpeed, Vector2 position) : base(hitPoints, moveSpeed, position, "Images/Characters/rat", 0, " ", 0)
        {
            EnemyHitPoints = hitPoints;
        }
    }

    ```
=== "StandardEnemy"

    ```Csharp
    public class StandardEnemy : Enemy
    {
        public int EnemyHitPoints;
        public StandardEnemy(int hitPoints, int moveSpeed, Vector2 position) : base(hitPoints, moveSpeed, position, "Images/Enemies/standardEnemy", 0, " ", 0)
        {
            EnemyHitPoints = hitPoints;
        }
    }
    ```
=== "FastEnemy"

    ```Csharp
    public class FastEnemy : Enemy
    {
        
        public FastEnemy(int hitPoints, int moveSpeed, Vector2 position) : base(hitPoints, moveSpeed, position, "Images/Characters/fastEnemy", 0, " ", 0)
        {
            EnemyHitPoints = hitPoints;
            EnemyMoveSpeed = moveSpeed;
        }
    }
    ```



### Dependency inversion principle (decoupeling)

Voor onze game willen we dat de enemies en de player willen schieten. We hebben dus `playerbullet` en `enemybullet`.  Sinds in alle 2 de bullet classes op dezelfde manier bepaald moet worden wat de angle en de positie is vanaf waar hij geschoten wordt inheriten ze allebei van de abstract class Bullet. De player en enemy bullets kunnen alle 2 de snelheid en de hoeveelheid bullets veranderen



=== "Bullet.cs"
    ```c#
public abstract class Bullet : RotatingSpriteGameObject
    {
        protected int BulletMoveSpeed = 0;

        public Bullet(Vector2 position, double angle, int bulletMoveSpeed, string assetName) : base(assetName)
        {
            Position = position;
            Angle = (float)angle;
            BulletMoveSpeed = bulletMoveSpeed;
        }

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

=== "PlayerBullet.cs"
    ```c#
public class PlayerBullet : Bullet
{
    public int playerBulletCooldown = 2;
    public int damage = 1;

    public PlayerBullet(Vector2 position, double angle, int bulletMoveSpeed, string assetName = "Images/Characters/whiteCircle45") : base(position, angle, bulletMoveSpeed, assetName)
    {
    }

    public bool CheckForEnemyCollision(SpriteGameObject enemy)
    {
        if (CollidesWith(enemy))
        {
            return true;
        } return false;
    }
}
    ```

=== "EnemyBullet.cs"
    ```c#
    public class EnemyBullet : Bullet
    {
        public EnemyBullet(Vector2 position, double angle, int bulletMoveSpeed, string assetName = "Images/Bullets/enemyBullet") : base(position, angle, bulletMoveSpeed, assetName)
        {
        }

        public bool CheckForEnemyCollision(SpriteGameObject player)
        {
            if (CollidesWith(player))
            {
                return true;
            }
            return false;
        }
    }
    ```

 

