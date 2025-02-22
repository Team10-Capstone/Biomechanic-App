using System.Collections;
using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

public class ResetCamera : MonoBehaviour
{
    [SerializeField] private CinemachineOrbitalFollow CameraSet;

    public void ResetCameraPosition()
    {
        CameraSet.HorizontalAxis.Recentering.Enabled = true;
        CameraSet.VerticalAxis.Recentering.Enabled = true;

    }

    public void HardResetCamera()
    {
        CameraSet.HorizontalAxis.Value = 0;
        CameraSet.VerticalAxis.Value = 17.5f;

    }


    public void StopRecentering()
    {
        CameraSet.HorizontalAxis.Recentering.Enabled = false;
        CameraSet.VerticalAxis.Recentering.Enabled = false;
    }
}
