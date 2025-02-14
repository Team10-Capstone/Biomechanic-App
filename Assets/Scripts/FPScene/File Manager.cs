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
    private string mainPath = "E:\\Unity\\Projects\\Biomechanic-App\\Biomechanic-App"; //Change this to whatever directory your recording CSV files are in

    public async void AsyncSelectFolder()
    {
        await FolderSelect();

        LoadSelectedFolderFiles(mainPath);
    }


    private async Task FolderSelect()
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
        foreach (FileInfo file in files)
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

            Button buttonComponent = fileButton.GetComponent<Button>();

            GameObject buttonControllerObject = GameObject.Find("ButtonController");
            SwitchCamera switchCamera = buttonControllerObject.GetComponent<SwitchCamera>();

            GameObject canvas = GameObject.Find("Canvas");
            MenuController menuController = canvas.GetComponent<MenuController>();

            GameObject pageObject = GameObject.Find("PlaybackPanel");
            Page page = pageObject.GetComponent<Page>();

            if (buttonComponent != null)
            {
                //buttonComponent.onClick.AddListener(switchCamera.SwitchTo); //no longer needed
                buttonComponent.onClick.AddListener(menuController.PopAllPages);
                buttonComponent.onClick.AddListener(menuController.PopPrimaryPage);
                //buttonComponent.onClick.AddListener(menuController.PopSpecialPage); //unstable
                buttonComponent.onClick.AddListener(() => menuController.PushPage(page));
            }
        }
    }
}
