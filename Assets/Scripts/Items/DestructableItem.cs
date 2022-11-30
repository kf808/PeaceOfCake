using UnityEngine;

public class DestructableItem : MonoBehaviour, IDamageable
{
    [field: SerializeField]
    public int Health { get; set; }
    Transform childItem;

    private void Awake()
    {
        childItem = transform.GetChild(0);
    }

    public void TakeDamage(int amount)
    {
        Health = Health - amount;

        if (Health <= 0)
        {
            childItem.gameObject.SetActive(true);
            transform.DetachChildren();
            Destroy(gameObject);
        }
    }
}
