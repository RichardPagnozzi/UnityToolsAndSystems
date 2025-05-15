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

    /// <summary>
    /// Represents a private reference to a saveFileObject instance used for managing save data operations in the application.
    /// This variable is initialized during the Awake method where it seeks the component tagged as "SaveFileObject."
    /// It is used internally by the saveFileWriter class to interact with save data, such as updating player level,
    /// play time, god mode state, and player name, as well as clearing or writing save data to a JSON file.
    /// </summary>
    [SerializeField] private  saveFileObject m_SaveFileObject;

    /// <summary>
    /// Represents the file path where the save file is stored. This variable is initialized
    /// during the Awake method to point to a persistent storage location specific to the
    /// application. The save file path is used for reading from and writing to the JSON file
    /// containing the save data.
    /// </summary>
    private string m_path;
    
    #endregion

    #region Factory Methods

    /// <summary>
    /// This method is called when the script instance is being loaded.
    /// It initializes the saveFileObject reference by finding it in the scene using the tag "SaveFileObject".
    /// Additionally, it sets the file path where the save file will be stored or retrieved.
    /// </summary>
    private void Awake()
    {
        m_SaveFileObject = GameObject.FindGameObjectWithTag("SaveFileObject").GetComponent<saveFileObject>();
        m_path = Application.persistentDataPath + "/UTS_SaveFileFolder/UTS_SaveFile.json";
    }
   
    #endregion

    #region Local Save Variables Methods

    /// <summary>
    /// Updates the player's level in the save file object.
    /// </summary>
    /// <param name="level">The level value to be saved for the player.</param>
    public  void SetSaveObject_PlayerLevel(int level)    
    {
        m_SaveFileObject.SetLocalSave_PlayerLevel(level);
    }

    /// <summary>
    /// Sets the playtime value in the save object.
    /// </summary>
    /// <param name="time">The float value of playtime to set in the save object.</param>
    public  void SetSaveObject_PlayTime(float time)    
    {
        m_SaveFileObject.SetLocalSave_PlayTime(time);
    }

    /// <summary>
    /// Updates the save file with the specified God Mode status.
    /// </summary>
    /// <param name="toggle">A boolean value indicating whether God Mode should be enabled (true) or disabled (false).</param>
    public  void SetSaveObject_GodMode(bool toggle)    
    {
        m_SaveFileObject.SetLocalSave_GodMode(toggle);
    }

    /// <summary>
    /// Sets the player's name in the save file object.
    /// </summary>
    /// <param name="name">The name of the player to be saved.</param>
    public  void SetSaveObject_PlayerName(string name)    
    {
        m_SaveFileObject.SetLocalSave_PlayerName(name);
    }

    /// <summary>
    /// Clears all variables in the save file object by resetting them to their default values.
    /// This method utilizes the `ClearLocalSaveVariables` method of the underlying `saveFileObject`
    /// to erase saved data such as player name, player level, playtime, and god mode status.
    /// </summary>
    public  void ClearSaveObjectVariables()   
    {
        m_SaveFileObject.ClearLocalSaveVariables();
    }
   
    #endregion

    #region Write To JSON Method

    /// <summary>
    /// Serializes the save file object to JSON format and writes it to a file at the specified path.
    /// The path is determined by the internal field <c>m_path</c>.
    /// This method uses platform-specific implementations for writing the data:
    /// - On Android, it uses <c>File.WriteAllText</c>.
    /// - On other platforms, it uses a <c>TextWriter</c> with <c>File.CreateText</c>.
    /// </summary>
    public void WriteToJSON()
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
