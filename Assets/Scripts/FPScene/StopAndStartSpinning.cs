using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class StopAndStartSpinning : MonoBehaviour
{
    [SerializeField]
    private GameObject Model;

    [SerializeField]
    private Vector3 setPosition;
    [SerializeField]
    private quaternion setRotation;

    public void StartSpin()
    {
        Model.GetComponent<RotateConstantly>().enabled = true;
    }
    public void StopSpin()
    {
        Model.GetComponent<RotateConstantly>().enabled = false;
        Model.GetComponent<Transform>().SetPositionAndRotation(setPosition, setRotation);
    }
}
