using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SFB;
using System.Threading;
using System.IO;
using System;

public class FileManager : MonoBehaviour
{
    private Thread thread;
    private string mainPath = "E:\\Unity\\Projects\\Biomechanic-App\\Biomechanic-App";
    public void SelectFolder()
    {
        thread = new Thread(FolderSelect);
        thread.Start();
    }

    private void FolderSelect()
    {
        var path = StandaloneFileBrowser.OpenFolderPanel("Open File", mainPath, false);
        Debug.Log(path[0]);
        mainPath = path[0];
        LoadSelectedFolderFiles(mainPath);
        thread.Join();
    }

    private void LoadSelectedFolderFiles(string mainPath)
    {
        DirectoryInfo dir = new DirectoryInfo(mainPath);
        FileInfo[] files = dir.GetFiles("*.csv");
        foreach (FileInfo file in files)
        {
            Debug.Log(file.FullName);
        }
    }
}
