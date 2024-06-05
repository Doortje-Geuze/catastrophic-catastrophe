# Weapon upgrades

## Doel
Het doel is dat als je een box aanraakt je dan een weapon upgrade krijgt

## Wat is daar voor nodig
- er zijn vershillende boxxen die colision hebben
- 2 boxen geven vershillende upgrades

## Process

### er zijn vershillende boxxen die colision hebben
Kijk hiervoor bij de box-aanmaken.md

### updgrades
In de `PlayerShoot` methode:
```c#
//Shotgun Upgrade
            if (pickedUpPurple)
            {
                for (int i = -1; i < 2; i++)
                {
                    PlayerBullet playerBullet = new(new Vector2(ShootPositionX, ShootPositionY), bulletAngle - 0.3f * i, 18);
                    playerBulletList.Add(playerBullet);
                    Add(playerBullet);
                }
            }
            else
            {
                PlayerBullet playerBullet = new(new Vector2(ShootPositionX, ShootPositionY), bulletAngle, 18);
                playerBulletList.Add(playerBullet);
                Add(playerBullet);
            }
```
```c#
//Lower Cooldown Upgrade
            if (pickedUpYellow)
            {
                PlayerShootCooldown = 5;
            }
            else
            {
                PlayerShootCooldown = 8;
            }
```