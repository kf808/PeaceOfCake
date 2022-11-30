using UnityEngine;

public class EnemyTower : MonoBehaviour, IDamageable
{
    [field: SerializeField]
    public int Health { get; set; }
    [SerializeField]
    private bool showDetectorCircle;
    [SerializeField]
    private float detectionRadius;

    private AIDetector aiDetector;
    private EnemyTowerShoot enemyTowerShoot;

    private void Awake()
    {
        aiDetector = new AIDetector(detectionRadius);
        enemyTowerShoot = GetComponent<EnemyTowerShoot>();
    }

    // Update is called once per frame
    private void Update()
    {
        aiDetector.TargetDetectionCircle(transform.position);

        if (aiDetector.targetDetected)
            enemyTowerShoot.PlayerDetected = true;
        else
            enemyTowerShoot.PlayerDetected = false;
    }

    private void OnDrawGizmos()
    {
        if (showDetectorCircle)
        {
            if (enemyTowerShoot != null && enemyTowerShoot.PlayerDetected)
                Gizmos.color = Color.red;
            else
                Gizmos.color = Color.green;

            Gizmos.DrawWireSphere(transform.position, detectionRadius);

        }
    }

    public void TakeDamage(int amount)
    {
        Health = Health - amount;
        if (Health <= 0)
            Destroy(gameObject);
    }
}
