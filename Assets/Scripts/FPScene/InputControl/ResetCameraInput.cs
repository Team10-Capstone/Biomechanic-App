using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Cinemachine;

public class ResetCameraInput : MonoBehaviour
{
    [SerializeField] private GameObject ButtonController;
    [SerializeField] private CinemachineCamera freeLookCam;

    private void OnResetCamera()
    {
        if (freeLookCam.Priority.Value > 1)
        {
            ResetCamera reset = ButtonController.GetComponent<ResetCamera>();
            reset.ResetCameraPosition();
        }
    }
}
