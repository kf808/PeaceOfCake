using System.Collections;
using UnityEngine;

public class Apple : MonoBehaviour
{
    private int healOverTimeInterval = 5;
    private bool hasTriggered;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == Tags.Player && !hasTriggered)
        {
            hasTriggered = true;
            var health = collision.gameObject.GetComponent<Health>();
            if (health != null)
                StartCoroutine(HealOverTime(health));

            var weight = collision.gameObject.GetComponent<Weight>();
            if (weight != null)
                weight.LoseWeight(20f);

        }
    }

    private IEnumerator HealOverTime(Health health)
    {
        for (int i = 0; i < healOverTimeInterval; i++)
        {
            health.Heal(10);
            yield return new WaitForSeconds(2f);
        }
        Destroy(gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == Tags.Player)
            Destroy(gameObject);
    }
}
