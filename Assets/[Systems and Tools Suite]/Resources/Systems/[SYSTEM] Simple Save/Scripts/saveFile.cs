using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// This class is a template of what the jSon will be printing.
/// You can modify the variables to save different chunks of data. 
/// For sake of simplicity, this save file will act as a Generic Save file 
/// with generic variables to save between sessions.
/// 
///  + Each saveFile class needs to have a respective saveFileObject which represents it
/// </summary> 

[System.Serializable]
public class saveFile
{
    public int m_playerLevel;
    public float m_playTime;
    public bool m_isGodModeEnabled;
    public string m_playerName;
}
