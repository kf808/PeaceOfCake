using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDetector
{
    private float radius;
    public bool targetDetected { get; set; }

    private int playerLayer = LayerMask.NameToLayer(Tags.Player);

    public AIDetector(float radius)
    {
        this.radius = radius;
    }

    public void TargetDetectionCircle(Vector2 point)
    {
        int playerLayerMask = 1 << playerLayer;
        Collider2D collider = Physics2D.OverlapCircle(point, radius, playerLayerMask);
        if (collider != null && collider.tag == Tags.Player)
            targetDetected = true;
        else
            targetDetected = false;
    }
}
