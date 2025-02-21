using System.Collections;
using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardToggleJoint : MonoBehaviour
{
    [SerializeField] private CinemachineCamera cam; //so joints are only toggled in free look mode

    [SerializeField] private Toggle toggle1;
    [SerializeField] private Toggle toggle2;
    [SerializeField] private Toggle toggle3;
    [SerializeField] private Toggle toggle4;
    [SerializeField] private Toggle toggle5;
    [SerializeField] private Toggle toggle6;
    // Start is called before the first frame update
    private void OnOne()
    {
        if (cam.Priority > 1)
        {
            toggle1.isOn = !toggle1.isOn;
        }
    }
    private void OnTwo()
    {
        if (cam.Priority > 1)
        {
            toggle2.isOn = !toggle2.isOn;
        }
    }
    private void OnThree()
    {
        if (cam.Priority > 1)
        {
            toggle3.isOn = !toggle3.isOn;
        }
    }
    private void OnFour()
    {
        if (cam.Priority > 1)
        {
            toggle4.isOn = !toggle4.isOn;
        }
    }
    private void OnFive()
    {
        if (cam.Priority > 1)
        {
            toggle5.isOn = !toggle5.isOn;
        }
    }
    private void OnSix()
    {
        if (cam.Priority > 1)
        {
            toggle6.isOn = !toggle6.isOn;
        }
    }
}
