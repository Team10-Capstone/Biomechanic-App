using System.Collections;
using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardToggleFocus : MonoBehaviour
{

    [SerializeField] private CinemachineCamera cam; //so joints are only toggled in free look mode

    [SerializeField] private Toggle toggleHide;
    [SerializeField] private Toggle toggleFocus;
    private void OnFocus()
    {
        if (cam.Priority < 1) return;

        if (toggleHide.isOn)
        {
            toggleFocus.isOn = true;
        }
        else
        {
            toggleHide.isOn = true;
        }
    }
}
