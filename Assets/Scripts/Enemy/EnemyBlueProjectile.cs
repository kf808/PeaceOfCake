using UnityEngine;

public class EnemyBlueProjectile : EnemyProjectile
{
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == Tags.Player)
        {
            var playerWeight = collision.gameObject.GetComponent<Weight>();
            if (playerWeight != null)
                playerWeight.IncreaseWeight(5f);

            Destroy(gameObject);
        }
    }
}
