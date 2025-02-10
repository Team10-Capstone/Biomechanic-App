using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisableSelf : MonoBehaviour
{
    public Button buttonToChange;

    public void EnableButton()
    {
        buttonToChange.enabled = true;
    }
    public void DisableButton()
    {
        buttonToChange.enabled = false;
    }
}
