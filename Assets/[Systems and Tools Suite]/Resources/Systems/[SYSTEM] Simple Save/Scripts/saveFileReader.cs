using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using System.Windows;
using System;

public class saveFileReader : MonoBehaviour
{
    #region Variables
    [SerializeField]
    private saveFileObject m_SaveFileObject;
    private saveFile m_SaveFile;
    #endregion

    #region Factory Methods
    private void Awake()
    {
        Set_SaveFileObjectInstance();
    }

    private void Set_SaveFileObjectInstance()
    {
        if (GameObject.FindGameObjectWithTag("SaveFileObject") != null)
        {
            m_SaveFileObject = GameObject.FindGameObjectWithTag("SaveFileObject").GetComponent<saveFileObject>();
        }
        else
        {
            GameObject obj = new GameObject("SaveFileObject");
            obj.AddComponent<saveFileObject>();
            obj.gameObject.tag = "SaveFileObject";
            obj.gameObject.transform.SetParent(null);
            m_SaveFileObject = obj.GetComponent<saveFileObject>();
        }
    }
    #endregion

    #region Local Read Methods
    #endregion

    #region Global Read Methods
    #endregion 

    //private async void ReadSaveFileFromJSon(saveFile SaveFile)
    //{
    //    string filePath = Application.persistentDataPath + "/UTS_SaveFileFolder/UTS_SaveFile.json";

    //}
}


