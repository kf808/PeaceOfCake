using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private Transform attackPointArms;
    [SerializeField]
    private Transform attackPointHead;
    [SerializeField]
    private Transform attackPointLegs;
    [SerializeField]
    private float attackRange = 0.5f;
    [SerializeField]
    private LayerMask enemyLayer;

    private int damageAmount = 50;
    private Transform attackPoint;

    public void Attack(Vector3 mousePosition)
    {
        SetAttackPointDirection(mousePosition);

        Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
        
        foreach(Collider2D enemy in enemiesHit)
        {
            var damageable = enemy.GetComponent<IDamageable>();
            if (damageable != null)
                damageable.TakeDamage(damageAmount);
        }
    }

    private void SetAttackPointDirection(Vector3 mousePosition)
    {
        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;

        if (angle < 100f && angle > 50f)
            attackPoint = attackPointHead;
        else if (angle > -100f && angle < -50f)
            attackPoint = attackPointLegs;
        else
            attackPoint = attackPointArms;
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
