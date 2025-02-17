using System.Collections;
using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

public class ResetCamera : MonoBehaviour
{
    [SerializeField] private CinemachineOrbitalFollow CameraSet;

    public void ResetCameraPosition()
    {
        CameraSet.HorizontalAxis.Value = 0f;
        CameraSet.VerticalAxis.Value = 17.5f;

    }
}
