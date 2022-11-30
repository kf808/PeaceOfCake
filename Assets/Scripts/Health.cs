using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int health = 100;
    [SerializeField]
    private int maxHealth = 200;
    [SerializeField]
    private Sprite deathSprite;

    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private LevelManager levelManager;

    public bool isDead { get; private set; }

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        levelManager = FindObjectOfType<LevelManager>();
    }

    public void TakeDamage(int amount)
    {
        health = health - amount;

        if (health <= 0)
            Die();
    }

    private void Die()
    {
        isDead = true;
        animator.enabled = false;
        spriteRenderer.sprite = deathSprite;

        levelManager.LoadGameOver();
    }

    public void Heal(int amount)
    {
        if (health < maxHealth)
            health = health + amount;
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }

    public int GetHealth()
    {
        return health;
    }
}
