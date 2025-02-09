using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateConstantly : MonoBehaviour
{
    
    void Update()
    {
        transform.Rotate(0, 0, 0.05f);
    }
}
