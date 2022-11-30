using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionsPanel : MonoBehaviour
{
    public void OpenInstructionsPanel()
    {
        gameObject.SetActive(true);
    }

    public void CloseInstructionsPanel()
    {
        gameObject.SetActive(false);
    }
}
