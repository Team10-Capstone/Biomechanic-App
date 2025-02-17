using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Cinemachine;
using System;
public class SwitchCamera : MonoBehaviour
{

    [SerializeField] private CinemachineCamera cam;

    [SerializeField] private Vector3 target;
    [SerializeField] private Transform objectToCheck;
    [SerializeField] private float threshold = 0.1f;

    void Update()
    {
        if (cam == null)
        {
            Debug.LogError("ugh");
        }

        if (Vector3.Distance(objectToCheck.position, target) < threshold) //
        {
            cam.Priority.Value = 2;
        }
        else
        {
            cam.Priority.Value = 0;
        }

    }

}