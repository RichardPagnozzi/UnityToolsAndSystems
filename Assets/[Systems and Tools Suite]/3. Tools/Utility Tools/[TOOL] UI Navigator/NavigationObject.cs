using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace UTS
{
    public class NavigationObject : MonoBehaviour
    {
        public UnityEvent OnEnableEvent;
        public UnityEvent OnDisableEvent;

        [SerializeField]
        private GameObject GUI;

        [SerializeField]
        private bool isActive;

        private void Start()
        {
            if (GUI == null)            
               GUI = this.gameObject;          
        }
        private void Update()
        {
            isActive = GUI.gameObject.activeInHierarchy;
        }
        public void DisableGUIObject()
        {
                OnDisableEvent?.Invoke();         
                GUI.SetActive(false);    
        }

        public void EnableGUIObject()
        {
            OnEnableEvent?.Invoke();        
                GUI.SetActive(true);          
        }

        public void ToggleGUIObject()
        {
            GUI.SetActive(!isActive);
        }

    }
}