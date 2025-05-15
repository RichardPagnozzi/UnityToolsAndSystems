using UnityEngine;
using System.IO;


public class saveFileReader : MonoBehaviour
{
    /// <summary>
    /// A private field representing an instance of the saveFileObject class.
    /// This object is responsible for managing, storing, and retrieving save file data,
    /// allowing the interaction and manipulation of save file information.
    /// </summary>
    [SerializeField] private saveFileObject m_SaveFileObject;

    /// <summary>
    /// A private string variable used to store the JSON content read from a file.
    /// This variable acts as an intermediary for processing saved data, allowing it
    /// to be deserialized into the <see cref="saveFile"/> object.
    /// </summary>
    private string m_jSonString;

    /// <summary>
    /// Unity's Awake method, called when the script instance is being loaded.
    /// This method initializes the saveFileObject by finding the GameObject with the tag "SaveFileObject"
    /// and retrieving its saveFileObject component. This ensures that the script has a reference
    /// to the saveFileObject instance at the start of the game or scene.
    /// </summary>
    private void Awake()
    {
        m_SaveFileObject = GameObject.FindGameObjectWithTag("SaveFileObject").GetComponent<saveFileObject>();
    }

    /// <summary>
    /// Reads the content of a file at the specified path and returns it as a JSON string.
    /// </summary>
    /// <param name="path">The file path from which to read the JSON string.</param>
    /// <returns>A JSON string containing the file's content.</returns>
    private string GetJsonStringFromFile(string path) 
    {
            return m_jSonString = File.ReadAllText(path);
    }

    /// <summary>
    /// Converts a JSON string into a saveFile object.
    /// </summary>
    /// <param name="jSon">The JSON string to be converted into a saveFile object.</param>
    /// <returns>
    /// A saveFile object populated with data from the provided JSON string if conversion succeeds,
    /// or null if the JSON string is null or invalid.
    /// </returns>
    private saveFile ConvertJsonToClass(string jSon) 
    {
        if (m_jSonString != null)
            return JsonUtility.FromJson<saveFile>(jSon);
        
        return null;
    }

    /// <summary>
    /// Reads a JSON file from the specified file path and converts it into a <see cref="saveFile"/> object.
    /// </summary>
    /// <param name="path">The file path of the JSON file containing save data.</param>
    /// <returns>A <see cref="saveFile"/> object populated with data from the JSON file, or null if the JSON string is empty.</returns>
    public saveFile GetSaveFileFromJson(string path) 
    {
        return ConvertJsonToClass(GetJsonStringFromFile(path));
    }

}


