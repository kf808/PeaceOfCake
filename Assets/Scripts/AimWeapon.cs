using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimWeapon : MonoBehaviour
{
    public void AimWeaponToCursor(Vector3 mousePosition)
    {
        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;

        Debug.Log(angle);

        if (Mathf.Abs(angle) < 100f && Mathf.Abs(angle) > 50f)
        {
            //transform.position = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
            
        }
        else if (Mathf.Abs(angle) > 90f)
        {
            //transform.eulerAngles = new Vector3(0, 90, 0);
            
        }
    }
}
