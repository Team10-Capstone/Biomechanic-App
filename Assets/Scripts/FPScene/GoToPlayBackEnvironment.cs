using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Cinemachine;

public class GoToPlayBackEnvironment : MonoBehaviour
{
    [SerializeField] private CinemachineSplineDolly splineDolly;

    public void GoToPlayBack()
    {
       var dollySpeed = splineDolly.AutomaticDolly.Method as SplineAutoDolly.FixedSpeed;

        dollySpeed.Speed = 3.0f;
    }

    public void GoBackToMenu()
    {
        var dollySpeed = splineDolly.AutomaticDolly.Method as SplineAutoDolly.FixedSpeed;
        dollySpeed.Speed = -3.0f;
    }
}
