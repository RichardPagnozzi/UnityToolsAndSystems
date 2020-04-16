using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saveFileManager : MonoBehaviour
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
}
