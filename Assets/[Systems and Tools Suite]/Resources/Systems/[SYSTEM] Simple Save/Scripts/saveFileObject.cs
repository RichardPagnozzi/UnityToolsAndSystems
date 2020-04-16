using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class saveFileObject : MonoBehaviour
{
    #region Variables

    private saveFile m_SaveFile; // saveFile template

    #region Save File Variables 
    [SerializeField] 
    private int m_playerLevel;  // variables that match the saveFile template 
    [SerializeField]
    private float m_playTime;
    [SerializeField]
    private bool m_isGodModeEnabled;
    [SerializeField]
    private string m_playerName;
    #endregion 

    private string SaveFolderName;

    #endregion


    #region Factory Methods
    private void Awake()
    {
        if (m_SaveFile == null)
            m_SaveFile = new saveFile();

        DontDestroyOnLoad(this.gameObject);

        SaveFolderName = Application.persistentDataPath + "/UTS_SaveFileFolder/";

        if (!Directory.Exists(SaveFolderName))
        {
            Directory.CreateDirectory(SaveFolderName);
        }
    }
    #endregion

    #region Local Save Variable Methods
    // Player Level (int)
    public void SetLocalSave_PlayerLevel(int level)
    {
        m_playerLevel = level;
    }
    public int GetLovalSave_PlayerLevel()
    {
        return m_playerLevel;
    }
    // Play Time (float)
    public void SetLocalSave_PlayTime(float time)
    {
        m_playTime = time;
    }
    public float GetLocalSave_PlayTime()
    {
        return m_playTime;
    }
    // God-Mode (bool)
    public void SetLocalSave_GodMode(bool toggle)
    {
        m_isGodModeEnabled = toggle;
    }
    public bool GetLocalSave_GodMode()
    {
        return m_isGodModeEnabled;
    }
    // Player Name (string)
    public void SetLocalSave_PlayerName(string name)
    {
        m_playerName = name;
    }
    public string GetLocalSave_PlayerName()
    {
        return m_playerName;
    }

    public void ClearSaveVariables()
    {
        m_playerLevel = 0;
        m_playTime = 0;
        m_isGodModeEnabled = false;
        m_playerName = null;
    }
    #endregion

    #region Global Save Variable Methods
    public void SaveLocal_ToGlobal() // Copy Local to Global
    {
        m_SaveFile.m_playerLevel = m_playerLevel;
        m_SaveFile.m_playTime = m_playTime;
        m_SaveFile.m_isGodModeEnabled = m_isGodModeEnabled;
        m_SaveFile.m_playerName = m_playerName;
    } 

    public void SaveJSON() // Save/Write jSon Utility File to jSon
    {
        string path = SaveFolderName + "UTS_SaveFile.json";
        string data = JsonUtility.ToJson(m_SaveFile);

#if UNITY_ANDROID
        File.WriteAllText(path, Data);                
#else
        using (TextWriter writer = File.CreateText(path))
        {
            writer.Write(data);
        }
#endif      
    }
    #endregion 
}
