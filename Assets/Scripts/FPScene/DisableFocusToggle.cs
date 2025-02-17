using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisableFocusToggle : MonoBehaviour //used to reset the recordings object 
{
    [SerializeField] private Toggle toggleJoints;

    public void EnableToggleJoints(){

            toggleJoints.isOn = true;

    }
}
