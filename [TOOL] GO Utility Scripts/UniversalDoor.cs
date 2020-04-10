using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(BoxCollider))]
public class UniversalDoor : MonoBehaviour
{
    #region Variables
    [Header("Should the door only open for the play?")]
    [Tooltip("If toggled on, the door will only open for the player. It will remain shut" +
        "when enemies try to walk through.")]
    public bool playerLocked = false;

    [Header("Should the doors automatically open when in trigger range? Or should " +
        "they open on player 'use' toggle? ")]
    public bool automaticDoors = false;
    public Animator animController;

    [Space(3)]

    [SerializeField]
    [Header("Reflects whether or not the door is currently open")]
    private bool isOpen = false;

    [SerializeField]
    [Header("Shows the speed at which the door is delayed before closing")]
    private float closeDelay = 2f;
    private float closeDelayTimer = 0;
    #endregion Variables


    void Start()
    {
        isOpen = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(Input.GetButton("Use"))
            {
                OpenDoor();
                isOpen = true;
            }
        }
    }

    private void Update()
    {
        if(isOpen)
        {
            closeDelayTimer += Time.deltaTime;
            if(closeDelayTimer >= closeDelay)
            {
                CloseDoor();
                closeDelayTimer = 0;
                isOpen = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(automaticDoors)
        OpenDoor();
    }
    private void OnTriggerExit(Collider other)
    {
        if(automaticDoors)
        CloseDoor();
    }

    void OpenDoor()
    {
        animController.SetBool("Open", true);
    }

    void CloseDoor()
    {
        animController.SetBool("Open", false);
    }
}
