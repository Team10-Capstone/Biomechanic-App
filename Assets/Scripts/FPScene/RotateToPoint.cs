using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class RotateToPoint : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed;
    [SerializeField] 
    private Vector3 rotationDirection;

    [SerializeField]
    private Quaternion goal;
    [SerializeField]
    private Transform current;
    // Update is called once per frame
    void Update()
    {
        while(current.rotation != goal)
        {
            transform.Rotate(rotationDirection * rotationSpeed * Time.deltaTime);
        }
    }
}
