using UnityEngine;

public abstract class EnemyCake : MonoBehaviour, IDamageable
{
    private Rigidbody2D _rigidbody;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private Vector2 lastPosition;

    [field: SerializeField]
    public int Health { get; set; }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        lastPosition = transform.position;
    }

    private void Update()
    {
        SetAnimation();
        FlipSprite();
    }

    private void SetAnimation()
    {
        if (Mathf.Approximately(_rigidbody.velocity.magnitude, 0f))
            animator.SetBool("IsMoving", true);
        else
            animator.SetBool("IsMoving", false);
    }

    private void FlipSprite()
    {
        if (transform.position.x < lastPosition.x)
            spriteRenderer.flipX = true;
        else
            spriteRenderer.flipX = false;

        lastPosition = transform.position;
    }

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == Tags.Player)
        {
            var playerHealth = collision.gameObject.GetComponent<Health>();
            if (playerHealth != null)
                playerHealth.TakeDamage(10);
        }
    }

    public void TakeDamage(int amount)
    {
        Health = Health - amount;
        if (Health <= 0)
            Destroy(gameObject);
    }
}
