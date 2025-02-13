using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
//TODO: FIX THIS SHIT
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
        Model.GetComponent<RotateToPoint>().enabled = false;
        Model.GetComponent<RotateConstantly>().enabled = true;
    }
    public void StopSpin()
    {
        Model.GetComponent<RotateConstantly>().enabled = false;
        Model.GetComponent<RotateToPoint>().enabled = true;
        //Model.GetComponent<Transform>().SetPositionAndRotation(setPosition, setRotation);
    }
}
