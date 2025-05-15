using UnityEngine;
using System.IO;

[RequireComponent(typeof(saveFileReader))]
[RequireComponent(typeof(saveFileWriter))]
public class saveFileManager : MonoBehaviour
{
    #region Members
    /// <summary>
    /// Represents an instance of the <c>saveFileObject</c> class which handles save file data and related operations.
    /// This variable is used to manage, update, and retrieve save file data within the <c>saveFileManager</c>.
    /// </summary>
    /// <remarks>
    /// The <c>m_SaveFileObject</c> is either assigned via a GameObject with the appropriate tag
    /// or instantiated dynamically if not found in the scene. It provides an interface to set and retrieve
    /// player-related data, such as level, playtime, god-mode status, and player name.
    /// It also ensures the existence of a directory for save files, initializing it when necessary.
    /// </remarks>
    [SerializeField] private saveFileObject m_SaveFileObject;

    /// <summary>
    /// Reference to an instance of <see cref="saveFileReader"/>.
    /// Used for reading save file data from JSON and initializing the save system.
    /// This component should be attached to the same GameObject as the <see cref="saveFileManager"/>.
    /// </summary>
    [Header("Drag and Drop")]
    public saveFileReader m_SaveFileReader;

    /// <summary>
    /// Represents an instance of the saveFileWriter class, used for managing saving operations
    /// including writing save data to a JSON file or updating individual save parameters.
    /// </summary>
    public saveFileWriter m_SaveFileWriter;

    /// <summary>
    /// The file path to the JSON save file used for game data storage and retrieval.
    /// </summary>
    /// <remarks>
    /// This variable is initialized during the Awake method and serves as the path pointing
    /// to the persistent directory where the save file is located or will be created. The
    /// path is constructed by combining <see cref="Application.persistentDataPath"/> with
    /// a predefined subdirectory and file name.
    /// </remarks>
    private string m_path;
    #endregion 
    
    #region Methods
    private void Awake()
    {
        m_path = Application.persistentDataPath + "/UTS_SaveFileFolder/UTS_SaveFile.json";
        Set_SaveFileObjectInstance();
    }

    /// <summary>
    /// Initializes or assigns the instance of <see cref="saveFileObject"/> within the scene.
    /// - If a GameObject with the tag "SaveFileObject" exists, the method locates it and assigns its <see cref="saveFileObject"/> component.
    /// - If no such GameObject is found, a new GameObject with the "SaveFileObject" tag is created and an instance of <see cref="saveFileObject"/> is attached to it.
    /// Further, the method ensures that a specific save directory exists. If the directory does not exist:
    /// 1. It creates the directory.
    /// 2. Initializes a new save file using <see cref="saveFile"/>.
    /// If the directory already exists, the save data is read from a JSON file specified in the persistent path.
    /// </summary>
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

    /// <summary>
    /// Retrieves the saveFileObject instance associated with the saveFileManager.
    /// </summary>
    /// <returns>
    /// Returns the saveFileObject instance currently managed by the saveFileManager.
    /// </returns>
    public saveFileObject GetSaveFileObject()
    {
        return m_SaveFileObject;
    }
    #endregion
}