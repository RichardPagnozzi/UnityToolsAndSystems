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
    private string m_jSonString;
    #endregion

    #region Factory Methods
    private void Awake()
    {
        m_SaveFileObject = GameObject.FindGameObjectWithTag("SaveFileObject").GetComponent<saveFileObject>();
    }
    #endregion

    #region Local Read Methods   
    private string GetJsonStringFromFile(string path) // Read File into Json String
    {
            return m_jSonString = File.ReadAllText(path);
    }
    
    private saveFile ConvertJsonToClass(string jSon) // Copy jSon string into a useable object
    {
        if (m_jSonString != null)
            return JsonUtility.FromJson<saveFile>(jSon);
        else
            return null;
    }
   
    public saveFile GetSaveFileFromJson(string path) // PUBLIC METHOD to access the referenced save file from jSon
    {
        return ConvertJsonToClass(GetJsonStringFromFile(path));
    }
    #endregion

}


