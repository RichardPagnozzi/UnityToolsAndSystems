using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WorldBuilder_GUI
{
    public class Navigator : MonoBehaviour
    {
        [SerializeField]
        private NavigationObject[] navObjects;
        

        private void DisableAllObjects()
        {
            foreach(NavigationObject no in navObjects)
            {
                no.DisableGUIObject();
            }
        }

        public void ToggleObjectAtIndex(int index)
        {
            if (index > navObjects.Length)
            {
                Debug.LogError("index out of range");
                return;
            }
            else if (navObjects[index] == null)
            {
                Debug.LogError("object at index is null");
                return;
            }
            else
            {
                DisableAllObjects();
                navObjects[index].ToggleGUIObject();
            }
        }

        public void EnableObjectAtIndex(int index)
        {
            if (index > navObjects.Length)
            {
                Debug.LogError("index out of range");
                return;
            }
            else if (navObjects[index] == null)
            {
                Debug.LogError("object at index is null");
                return;
            }
            else
            {
                DisableAllObjects();
                navObjects[index].EnableGUIObject();
            }
        }

        public void DisableObjectAtIndex(int index)
        {
            if (index > navObjects.Length)
            {
                Debug.LogError("index out of range");
                return;
            }
            else if (navObjects[index] == null)
            {
                Debug.LogError("object at index is null");
                return;
            }
            else
            {
                DisableAllObjects();
                navObjects[index].DisableGUIObject();
            }
        }

    }
}