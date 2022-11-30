using UnityEngine;

public class EnemyRedProjectile : EnemyProjectile
{
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }
}
