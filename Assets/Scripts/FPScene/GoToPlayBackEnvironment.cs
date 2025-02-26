using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Cinemachine;

public class GoToPlayBackEnvironment : MonoBehaviour
{
    [SerializeField] private CinemachineSplineDolly splineDolly;
    //[SerializeField] private CinemachineSplineDolly splineDolly2; //not needed

    public void GoToPlayBack()
    {
       var dollySpeed = splineDolly.AutomaticDolly.Method as SplineAutoDolly.FixedSpeed;
       //var dollySpeed2 = splineDolly2.AutomaticDolly.Method as SplineAutoDolly.FixedSpeed;

        dollySpeed.Speed = 3f;
        //dollySpeed2.Speed = 3.0f;
    }

    public void GoBackToMenu()
    {
        var dollySpeed = splineDolly.AutomaticDolly.Method as SplineAutoDolly.FixedSpeed;
        //var dollySpeed2 = splineDolly2.AutomaticDolly.Method as SplineAutoDolly.FixedSpeed;

        dollySpeed.Speed = -2.4f;
        //dollySpeed2.Speed = -3.0f;
    }
}
