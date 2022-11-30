using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCakeBlue : EnemyCake
{
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == Tags.Player)
        {
            var playerWeight = collision.gameObject.GetComponent<Weight>();
            if (playerWeight != null)
                playerWeight.IncreaseWeight(5f);
        }
    }
}
