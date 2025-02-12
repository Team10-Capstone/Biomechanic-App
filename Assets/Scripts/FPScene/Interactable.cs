using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableButton : MonoBehaviour
{
    public Button changeButton;

    public void InteractButtonOn()
    {
        changeButton.interactable = true;
    }
    public void InteractButtonOff()
    {
        changeButton.interactable = false;
    }
}
