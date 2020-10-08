using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


[RequireComponent(typeof(saveFileReader))]
[RequireComponent(typeof(saveFileWriter))]
public class saveFileManager : MonoBehaviour
{
    #region Variables
    [SerializeField]
    private saveFileObject m_SaveFileObject;
    [Header("Drag and Drop")]
    public saveFileReader m_SaveFileReader;
    public saveFileWriter m_SaveFileWriter;

    private string m_path;

    #endregion
    private void Awake()
    {
        m_path = Application.persistentDataPath + "/UTS_SaveFileFolder/UTS_SaveFile.json";
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


        if (!Directory.Exists(m_SaveFileObject.GetSaveFolderPath()))
        {
            Directory.CreateDirectory(m_SaveFileObject.GetSaveFolderPath());
            m_SaveFileObject.SetSaveFile(new saveFile());
        }

        else
        {
            m_SaveFileObject.SetSaveFile(m_SaveFileReader.GetSaveFileFromJson(m_path));
        }
    }

    public saveFileObject GetSaveFileObject()
    {
        return m_SaveFileObject;
    }
}