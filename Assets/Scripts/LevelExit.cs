using UnityEngine;

public class LevelExit : MonoBehaviour
{
    private LevelManager levelManager;

    private void Awake()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == Tags.Player)
            levelManager.LoadNextLevel();
    }
}
