using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

/// <summary>
/// This class should be used in 2 ways: 
/// 1.) Attached to a gameobject in scene; methods are fired via events
/// 2.) Instanced via unique controller scripts
/// </summary>
public class saveFileWriter : MonoBehaviour
{
    #region Variables
    [SerializeField]
    private  saveFileObject m_SaveFileObject;
    private string m_path;
    #endregion

    #region Factory Methods
    private void Awake()
    {
        m_SaveFileObject = GameObject.FindGameObjectWithTag("SaveFileObject").GetComponent<saveFileObject>();
        m_path = Application.persistentDataPath + "/UTS_SaveFileFolder/UTS_SaveFile.json";
    }
    #endregion

    #region Local Save Variables Methods
    public  void SetSaveObject_PlayerLevel(int level)     // Save Int
    {
        m_SaveFileObject.SetLocalSave_PlayerLevel(level);
    }

    public  void SetSaveObject_PlayTime(float time)    // Save Float
    {
        m_SaveFileObject.SetLocalSave_PlayTime(time);
    }

    public  void SetSaveObject_GodMode(bool toggle)    // Save Boolean
    {
        m_SaveFileObject.SetLocalSave_GodMode(toggle);
    }

    public  void SetSaveObject_PlayerName(string name)    // Save String
    {
        m_SaveFileObject.SetLocalSave_PlayerName(name);
    }
 
    public  void ClearSaveObjectVariables()    // Clear Save
    {
        m_SaveFileObject.ClearLocalSaveVariables();
    }
    #endregion

    #region Write To JSON Method
    public void WriteToJSON()     // Save/Write jSon Utility File to jSon
    {
        string data = JsonUtility.ToJson(m_SaveFileObject.GetSaveFile());

#if UNITY_ANDROID
        File.WriteAllText(m_path, data);                
#else
        using (TextWriter writer = File.CreateText(m_path))
        {
            writer.Write(data);
        }
#endif      
    }
    #endregion 


}
