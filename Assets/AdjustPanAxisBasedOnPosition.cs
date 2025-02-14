using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Cinemachine;
using UnityEngine.Splines;

public class AdjustPanAxisBasedOnPosition : MonoBehaviour
{
    [SerializeField] private CinemachineSplineDolly splineDolly;
    [SerializeField] private CinemachinePanTilt panAxis;
    // Update is called once per frame
    void Update()
    {
        var dollyPosition = splineDolly.CameraPosition;

        if (dollyPosition <= 0)
        {
            panAxis.PanAxis.Value = 0;
        }
        else if (dollyPosition >= 1)
        {
            panAxis.PanAxis.Value = -45f;
        }
        else if (dollyPosition >= .10f)
        {
            float currentVal = ((dollyPosition - .25f) / .75f * 45);
            //Debug.Log(currentVal);
            panAxis.PanAxis.Value = -currentVal;
        }
    }
}
