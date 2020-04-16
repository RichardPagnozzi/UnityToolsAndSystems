using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class should be used in 2 ways: 
/// 1.) Attached to a gameobject in scene; methods are fired via events
/// 2.) Instanced via unique controller scripts
/// </summary>
public class saveFileWriter : MonoBehaviour
{
    #region Variables
    [SerializeField]
    private saveFileObject m_SaveFileObject;
    #endregion


    #region Factory Methods
    private void Awake()
    {
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
    }
    #endregion

    #region Local Save Variables Methods
    public void SetSaveObject_PlayerLevel(int level)
    {
        m_SaveFileObject.SetLocalSave_PlayerLevel(level);
    }

    public void SetSaveObject_PlayTime(float time)
    {
        m_SaveFileObject.SetLocalSave_PlayTime(time);
    }

    public void SetSaveObject_GodMode(bool toggle)
    {
        m_SaveFileObject.SetLocalSave_GodMode(toggle);
    }

    public void SetSaveObject_PlayerName(string name)
    {
        m_SaveFileObject.SetLocalSave_PlayerName(name);
    }

    public void ClearSaveObjectVariables()
    {
        m_SaveFileObject.ClearSaveVariables();
    }
    #endregion

    #region Global Save Variables Methods
    public void SaveLocal_ToGlobal()
    {
        m_SaveFileObject.SaveLocal_ToGlobal();
    }

    public void SaveGlobal_toJSON()
    {
        m_SaveFileObject.SaveJSON();
    }
    #endregion 
}
