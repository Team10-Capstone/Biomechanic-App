using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateConstantly : MonoBehaviour
{
    [SerializeField] private Vector3 _rotation;

    private bool shouldRotate = true;

    public void StartRotation()
    {
        shouldRotate = true;
    }
    public void StopRotation()
    {
        shouldRotate = false;
    }
    void Update()
    {
        if (shouldRotate)
        {
            transform.Rotate(_rotation * Time.deltaTime);
        }

    }
}
