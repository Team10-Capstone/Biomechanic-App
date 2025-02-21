using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayPause : MonoBehaviour
{
    private void OnSpace()
    {
        GameObject buttonControllerObject = GameObject.Find("ButtonController");//buttoncontroller 
        FileLoader fileLoader = buttonControllerObject.GetComponent<FileLoader>();
        fileLoader.togglePlayButton();
    }
}
