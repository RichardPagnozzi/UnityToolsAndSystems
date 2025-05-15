using UnityEngine;

/// <summary>
/// The saveFileObject class is responsible for managing the local save file of the game.
/// It provides methods to read, update, and manage save data for the player.
/// </summary>
public class saveFileObject : MonoBehaviour
{
    #region Variables

    /// <summary>
    /// Represents the current save file in use by the saveFileObject instance.
    /// It stores game-related data such as player level, playtime, god mode status, and player name.
    /// This variable is used for setting or retrieving saved data during gameplay and session management.
    /// </summary>
    [SerializeField]
    private saveFile m_SaveFile;

    /// <summary>
    /// Represents the folder path where save files are stored.
    /// By default, this value is initialized to a path within the persistent data storage directory
    /// specific to the application. This ensures save files are stored in a location that persists
    /// across sessions and is accessible only to the application.
    /// </summary>
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

    #region Save Methods

    /// <summary>
    /// Updates the player's level in the local save file.
    /// </summary>
    /// <param name="level">The new level to set for the player in the local save data.</param>
    public void SetLocalSave_PlayerLevel(int level)
    {
        m_SaveFile.m_playerLevel = level;
    }

    /// <summary>
    /// Retrieves the player's level stored in the local save file.
    /// </summary>
    /// <returns>The player's level as an integer.</returns>
    public int GetLovalSave_PlayerLevel()
    {
        return m_SaveFile.m_playerLevel;
    }

    /// <summary>
    /// Sets the local save playtime value in the save file.
    /// </summary>
    /// <param name="time">The playtime value to be saved.</param>
    public void SetLocalSave_PlayTime(float time)
    {
        m_SaveFile.m_playTime = time;
    }

    /// <summary>
    /// Retrieves the total play time stored in the local save file.
    /// </summary>
    /// <returns>
    /// The total play time as a float value.
    /// </returns>
    public float GetLocalSave_PlayTime()
    {
        return m_SaveFile.m_playTime;
    }

    /// <summary>
    /// Enables or disables God Mode in the save file by toggling the specified boolean value.
    /// </summary>
    /// <param name="toggle">A boolean value where true enables God Mode and false disables it.</param>
    public void SetLocalSave_GodMode(bool toggle)
    {
        m_SaveFile.m_isGodModeEnabled = toggle;
    }

    /// <summary>
    /// Retrieves the current status of the God Mode from the local save file.
    /// </summary>
    /// <returns>Returns true if God Mode is enabled, otherwise false.</returns>
    public bool GetLocalSave_GodMode()
    {
        return m_SaveFile.m_isGodModeEnabled;
    }

    /// <summary>
    /// Sets the player's name in the local save file.
    /// </summary>
    /// <param name="name">The player's name to be saved.</param>
    public void SetLocalSave_PlayerName(string name)
    {
        m_SaveFile.m_playerName = name;
    }

    /// <summary>
    /// Retrieves the player's name from the local save file.
    /// </summary>
    /// <returns>A string representing the player's name stored in the local save file.</returns>
    public string GetLocalSave_PlayerName()
    {
        return m_SaveFile.m_playerName;
    }

    /// <summary>
    /// Resets the local save file variables to their default values.
    /// This method clears all the currently saved data in the local save file,
    /// including player name, player level, playtime, and god mode status.
    /// </summary>
    public void ClearLocalSaveVariables()
    {
        m_SaveFile.m_playerName = null;
        m_SaveFile.m_playerLevel = 0;
        m_SaveFile.m_playTime = 0;
        m_SaveFile.m_isGodModeEnabled = false;
    }

    /// Retrieves the path to the folder where save files are stored.
    /// <returns>
    /// A string representing the path to the save file folder.
    /// </returns>
    public string GetSaveFolderPath()
    {
        return SaveFolderName;
    }

    /// <summary>
    /// Sets the specified save file instance within the saveFileObject.
    /// </summary>
    /// <param name="SF">The saveFile instance to assign to the saveFileObject.</param>
    public void SetSaveFile(saveFile SF)
    {
        m_SaveFile = SF;
    }

    /// <summary>
    /// Retrieves the current save file object associated with this saveFileObject instance.
    /// </summary>
    /// <returns>
    /// The saveFile instance representing the current save file data.
    /// </returns>
    public saveFile GetSaveFile()
    {
        return m_SaveFile;
    }
    #endregion
}
