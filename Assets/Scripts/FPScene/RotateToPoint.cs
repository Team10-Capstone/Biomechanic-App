using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class RotateToPoint : MonoBehaviour
{
    [SerializeField] private Transform current;
    [SerializeField] private float rotationSpeed = 90f; //desgrees per second
    [SerializeField] private Quaternion goal;
    private bool shouldRotate = false;


    // Update is called once per frame
    public void Update()
    {
        if (shouldRotate)
        {
            current.rotation = Quaternion.RotateTowards(current.rotation, goal, rotationSpeed * Time.deltaTime);

            //stops rotating
            if (Quaternion.Angle(current.rotation, goal) < 0.1f)
            {
                shouldRotate = false;
            }
        }
    }
    public void StartRotation()
    {
        shouldRotate = true;
    }
}
