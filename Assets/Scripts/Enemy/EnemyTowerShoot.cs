using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTowerShoot : MonoBehaviour
{
    [SerializeField]
    private GameObject projectilePrefab;
    [SerializeField]
    private float speed = 5.0f;
    [SerializeField]
    private float lifeTime = 5.0f;
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float fireRate = 2.0f;
    public bool PlayerDetected { get; set; }
    Coroutine shootCoroutine;

    private void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        if (PlayerDetected && shootCoroutine == null)
        {
            shootCoroutine = StartCoroutine(ShootAtTarget());
        }
        else if (!PlayerDetected && shootCoroutine != null)
        {
            StopCoroutine(shootCoroutine);
            shootCoroutine = null;
        }
    }

    private IEnumerator ShootAtTarget()
    {
        while (true)
        {
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity, transform);
            var rb = projectile.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector3 direction = (target.position - transform.position).normalized;
                rb.velocity = direction * speed;
            }

            Destroy(projectile, lifeTime);
            yield return new WaitForSeconds(fireRate);
        }
    }
}
