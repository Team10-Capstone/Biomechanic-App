using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Camera_0;
    public GameObject Camera_1;
    public Canvas Canvas;
    public Camera camera0;
    public Camera camera1;


    public void SwitchTo() {
        Camera_1.SetActive(true);
        Camera_0.SetActive(false);
        Canvas.worldCamera = camera1;
    }

    public void SwitchBack(){
        Camera_0.SetActive(true);
        Camera_1.SetActive(false);
        Canvas.worldCamera = camera0;
    }

}
