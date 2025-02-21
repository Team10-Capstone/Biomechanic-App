using System.Collections;
using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class ToggleJointSection : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private CinemachineCamera cam; //so joints are only toggled in free look mode

    [SerializeField] private Toggle toggleSection1;
    [SerializeField] private Toggle toggleSection2;
    [SerializeField] private Toggle toggleSection3;

    private void OnToggleHipJoints()
    {
        if (cam.Priority > 1)
        {
            toggleSection1.isOn = !toggleSection1.isOn;
        }
    }

    private void OnToggleKneeJoints()
    {
        if (cam.Priority > 1)
        {
            toggleSection2.isOn = !toggleSection2.isOn;
        }
    }

    private void OnToggleAnkleJoints()
    {
        if (cam.Priority > 1)
        {
            toggleSection3.isOn = !toggleSection3.isOn;
        }
    }
}
