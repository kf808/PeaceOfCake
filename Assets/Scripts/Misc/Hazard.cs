using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == Tags.Player)
        {
            var playerHealth = collision.gameObject.GetComponent<Health>();
            if (playerHealth != null)
                playerHealth.TakeDamage(playerHealth.GetMaxHealth());
        }
    }
}
