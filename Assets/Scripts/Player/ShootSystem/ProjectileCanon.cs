using System.Collections;
using UnityEngine;

public class ProjectileCanon
{
    private Projectile Projectile;
    private CooldownTimer CooldownTimer;      

    public delegate void PlayerShotedDel(GameObject owner);
    public static event PlayerShotedDel PlayerShotedEve;

    public ProjectileCanon(Projectile projectile, float coolDown)
    {
        Projectile = projectile;
        
        CooldownTimer = new CooldownTimer(coolDown);
        CooldownTimer.Go();
    }

    public void Fire(GameObject owner, Vector3 direction, Vector3 startPosition)
    {
        if (CooldownTimer.Check)
        {
            Projectile p = UnityEngine.Object.Instantiate(Projectile);
            p.MoveAway(startPosition, direction);
            CooldownTimer.Go();
            PlayerShotedEve?.Invoke(owner);            
        }
    }
}
