using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SFB;
using System.Threading;
using System.IO;
using System;
using System.Windows.Forms;
using Button = UnityEngine.UI.Button;
using System.Threading.Tasks;
using TMPro;
using UnityEngine.InputSystem.Controls;
using UnityEditor;

public class FileManager : MonoBehaviour
{

    [SerializeField]
    private GameObject recordingButtonTemplate;
    [SerializeField]
    private Transform RecordingItems;
    [SerializeField]

    private GameObject SwitchCamera;
    [SerializeField]
    private Canvas PageControl;

    private Thread thread;
    private string mainPath = "E:\\Unity\\Projects\\Biomechanic-App\\Biomechanic-App\\Assets"; //Change this to whatever directory your recording CSV files are in

    public async void AsyncSelectFolder()
    {
        await FolderSelect();

        LoadSelectedFolderFiles(mainPath);
    }


    private async Task FolderSelect() //async in order to keep main program running
    {
        await Task.Run(() =>
        {
            var path = StandaloneFileBrowser.OpenFolderPanel("Open File", mainPath, false);
            Debug.Log(path[0]);
            mainPath = path[0];
        });
    }

    private void LoadSelectedFolderFiles(string mainPath)
    {
        DirectoryInfo dir = new DirectoryInfo(mainPath);
        FileInfo[] files = dir.GetFiles("*.csv");
        foreach (FileInfo file in files) //reads in files
        {
            GameObject fileButton = Instantiate(recordingButtonTemplate, RecordingItems, false) as GameObject;
            TMP_Text[] textComponents = fileButton.GetComponentsInChildren<TMP_Text>();
            string FileDate = File.GetCreationTime(file.Directory.ToString()).ToString();
            if (textComponents.Length >= 3)
            {
                textComponents[0].text = file.Name;
                textComponents[1].text = mainPath;
                textComponents[2].text = FileDate;
            }

            Button buttonComponent = fileButton.GetComponent<Button>();//used to initiate onClick

            GameObject buttonControllerObject = GameObject.Find("ButtonController");//buttoncontroller 
            DisableFocusToggle disableFocus = buttonControllerObject.GetComponent<DisableFocusToggle>();
            ResetCamera resetcamera = buttonControllerObject.GetComponent<ResetCamera>();
            FileLoader fileLoader = buttonControllerObject.GetComponent<FileLoader>();

            GameObject canvas = GameObject.Find("Canvas");//canvas
            MenuController menuController = canvas.GetComponent<MenuController>();

            //pops itself and any additional non-sepecial pages, pops the primary page (start), and resets the model for a new file.
            if (buttonComponent != null)
            {
                buttonComponent.onClick.AddListener(menuController.PopAllPages);
                buttonComponent.onClick.AddListener(menuController.PopPrimaryPage);
                buttonComponent.onClick.AddListener(resetcamera.ResetCameraPosition);
                buttonComponent.onClick.AddListener(disableFocus.EnableToggleJoints);
                buttonComponent.onClick.AddListener(() => fileLoader.LoadFile(mainPath, file.Name, file.FullName));
            }
        }
    }
}
