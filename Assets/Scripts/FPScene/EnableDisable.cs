using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisableSelf : MonoBehaviour
{
    public GameObject buttonToChange;

    public void EnableButton()
    {
        buttonToChange.SetActive(true);
    }
    public void DisableButton()
    {
        buttonToChange.SetActive(false);
    }
}
