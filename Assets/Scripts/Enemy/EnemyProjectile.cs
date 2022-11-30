using UnityEngine;

public abstract class EnemyProjectile : MonoBehaviour, IDamageable
{
    [field: SerializeField]
    public int Health { get; set; }

    public void TakeDamage(int amount)
    {
        Health = Health - amount;
        if (Health <= 0)
            Destroy(gameObject);
    }

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == Tags.Player)
        {
            var playerHealth = collision.gameObject.GetComponent<Health>();
            if (playerHealth != null)
                playerHealth.TakeDamage(5);

            Destroy(gameObject);
        }
    }
}
