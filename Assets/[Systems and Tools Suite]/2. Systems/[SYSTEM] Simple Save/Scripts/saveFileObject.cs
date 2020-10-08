using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class saveFileObject : MonoBehaviour
{
    #region Variables
    [SerializeField]
    private saveFile m_SaveFile;
    [SerializeField]
    private string SaveFolderName;
    #endregion

    #region Factory Methods
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        SaveFolderName = Application.persistentDataPath + "/UTS_SaveFileFolder/";
    }
    #endregion

    #region Local Save Variable Methods 
    // Player Level (int)
    public void SetLocalSave_PlayerLevel(int level)
    {
        m_SaveFile.m_playerLevel = level;
    }
    public int GetLovalSave_PlayerLevel()
    {
        return m_SaveFile.m_playerLevel;
    }
   
    // Play Time (float)
    public void SetLocalSave_PlayTime(float time)
    {
        m_SaveFile.m_playTime = time;
    }
    public float GetLocalSave_PlayTime()
    {
        return m_SaveFile.m_playTime;
    }
    
    // God-Mode (bool)
    public void SetLocalSave_GodMode(bool toggle)
    {
        m_SaveFile.m_isGodModeEnabled = toggle;
    }
    public bool GetLocalSave_GodMode()
    {
        return m_SaveFile.m_isGodModeEnabled;
    }
   
    // Player Name (string)
    public void SetLocalSave_PlayerName(string name)
    {
        m_SaveFile.m_playerName = name;
    }
    public string GetLocalSave_PlayerName()
    {
        return m_SaveFile.m_playerName;
    }
   // Clear All Variables
   public void ClearLocalSaveVariables()
    {
        m_SaveFile.m_playerName = null;
        m_SaveFile.m_playerLevel = 0;
        m_SaveFile.m_playTime = 0;
        m_SaveFile.m_isGodModeEnabled = false;
    }
    
    public string GetSaveFolderPath()
    {
        return SaveFolderName;
    }
    public void SetSaveFile(saveFile SF)
    {
        m_SaveFile = SF;
    }
    public saveFile GetSaveFile()
    {
        return m_SaveFile;
    }
    #endregion
}
