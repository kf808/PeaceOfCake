using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLevelExit : MonoBehaviour
{
    private GameObject child;

    private void Awake()
    {
        child = transform.GetChild(0).gameObject;
    }

    private void OnEnable()
    {
        EventHandler.OnLevelExitOpen += LevelExitOpen;
    }

    private void OnDisable()
    {
        EventHandler.OnLevelExitOpen -= LevelExitOpen;
    }

    private void LevelExitOpen()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        child.SetActive(true);
    }
}
