using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Cinemachine;
using UnityEngine.Rendering;
using Unity.VisualScripting;
using UnityEngine.InputSystem;

public class FreeLookRightClickControl : MonoBehaviour
{
    [SerializeField]
    private CinemachineInputAxisController cineCam;
    [SerializeField]
    private CinemachineCamera cam;

    void Update()
    {

        if (Mouse.current.rightButton.isPressed && cam.Priority.Value > 1) //  && cam.Priority.Value > 1
        {
            cineCam.enabled = true;
        }
        else
        {
            cineCam.enabled = false;
        }
    }
}
