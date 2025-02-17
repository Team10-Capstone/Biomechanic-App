using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class FileLoader : MonoBehaviour
{
    [SerializeField] private Slider progressBar;
    [SerializeField] private TMP_Text ProgressAt;
    [SerializeField] private TMP_Text fileName;

    private int rowCount;
    private string path = "";
    void Update()
    {
        if (rowCount != 0)
        {
            ProgressAt.text = progressBar.value.ToString() + "/" + rowCount;
        }
        else
        {
            ProgressAt.text = "";
        }
    }
    public void LoadFile(string mainPath, string fileToOpen, string fileFullname)
    {
        DirectoryInfo dir = new DirectoryInfo(mainPath);


        fileName.text = fileToOpen;
        rowCount = File.ReadAllLines(fileFullname).Length;

        progressBar.maxValue = rowCount;

        ProgressAt.text = progressBar.value.ToString() + "/" + rowCount;
    }
}
