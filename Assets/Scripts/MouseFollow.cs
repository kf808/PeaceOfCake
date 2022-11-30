using UnityEngine;
using UnityEngine.InputSystem;

public class MouseFollow : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = false;
    }

    private void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        mousePosition.z = Camera.main.transform.position.z + Camera.main.farClipPlane;

        transform.position = mousePosition;
    }
}
