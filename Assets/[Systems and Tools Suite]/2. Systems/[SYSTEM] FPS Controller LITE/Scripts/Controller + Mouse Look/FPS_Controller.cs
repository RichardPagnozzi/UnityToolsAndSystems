using UnityEngine;

[AddComponentMenu("Richs FPS Scripts/Controller")]
[RequireComponent(typeof(CharacterController))]
public class FPS_Controller : MonoBehaviour
{
    #region Members
    
    #region Scriptable Object Settings
    [SerializeField]
    public Player_Difficulty_Profile DifficultySettings;
    private int baseSpeed,
     curSpeed,
     sprintSpeed,
     jumpSpeed,
     gravity,
     fallingThreshold;
    #endregion Scriptable Object Settings
    #region Variables accessed by other scripts
    public bool isMoving = false;
    private bool isSprinting = false;
    #endregion Variables accessed by other scripts
    #region Local Variables
    private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;
    private float horizontal, vertical;
    private int standingHeight = 2, crouchingHeight = 1;
    private int jPadSpeed = 50;
    private bool isCrouching = false;
    private bool canJump = true;
    private bool PlayFoostep = false;
    private bool hitJumpPad = false;
    #endregion Local Variables
    
    #endregion Variables


    #region Start + Update
    
    void Start()
    {
        controller = GetComponent<CharacterController>();
        baseSpeed = DifficultySettings.baseSpeed;
        sprintSpeed = DifficultySettings.sprintSpeed;
        jumpSpeed = DifficultySettings.jumpSpeed;
        gravity = DifficultySettings.gravity;
        curSpeed = baseSpeed;
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        SprintHandler();

        if (controller.isGrounded)
        {
            moveDirection = new Vector3(horizontal, 0, vertical);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= curSpeed;
            CrouchHandler();
        }
        else
        {
            moveDirection.x = horizontal * (curSpeed * 0.8f);
            moveDirection.z = vertical * (curSpeed * 0.8f);
            moveDirection = transform.TransformDirection(moveDirection);
        }
        // FootStepHandler();
        JumpHandler();
        JumpPadHandler();
        DashHandler();

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }

    void FixedUpdate()
    {
        if (Mathf.Abs(controller.velocity.x) > 0.5f || Mathf.Abs(controller.velocity.z) > 0.5f)
            isMoving = true;
        else
            isMoving = false;
    }

    #endregion Start + Update 


    #region Movement Mechanic Methods
    void JumpHandler()
    {
        if ((Input.GetButtonDown("Jump")) && !isCrouching & controller.isGrounded)
        {
            moveDirection.y = jumpSpeed;
        }
    }

    void DashHandler()
    {
        if ((Input.GetButtonDown("Dash")) && !isCrouching && controller.isGrounded)
        {
            moveDirection *= 0.22f;
            controller.Move(moveDirection);
        }
    }

    void SprintHandler()
    {
        if (Input.GetButton("Sprint"))
        {
            if (controller.isGrounded && !isCrouching && isMoving)
                isSprinting = true;
        }
        if (Input.GetButtonUp("Sprint") || isCrouching || !isMoving || !controller.isGrounded)
        {
            isSprinting = false;
        }

        if (isSprinting)
        {
            curSpeed += 1;
            if (curSpeed > sprintSpeed)
                curSpeed = sprintSpeed;
        }
        else
        {
            curSpeed = baseSpeed;
        }
    }

    void CrouchHandler()
    {
        #region runs on Dash toggle
        if (Input.GetKeyDown(KeyCode.C) && Time.timeScale != 0)
        {
            isCrouching = !isCrouching;

            if (isCrouching)
                curSpeed = baseSpeed / 2;
            else
                curSpeed = baseSpeed;
        }
        #endregion runs on Dash toggle

        if (isCrouching)
        {
            if (controller.height > 1.2f)
            {
                controller.height = 1.2f;
                GetComponent<CapsuleCollider>().height = 1.2f;
            }
        }
        else
        {
            if (controller.height < 2)
            {
                GetComponent<CapsuleCollider>().height += Time.deltaTime * 10;
                controller.height += Time.deltaTime * 10;
            }
            if (controller.height > 2)
            {
                GetComponent<CapsuleCollider>().height = 2;
                controller.height = 2;
            }

        }
    }

    void FootStepHandler()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            PlayFoostep = true;
        else
            GetComponent<AudioSource>().Stop();

        if (PlayFoostep && GetComponent<AudioSource>().isPlaying != true)
        {
            GetComponent<AudioSource>().pitch = UnityEngine.Random.Range(0.75f, 1.5f);
            GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip, 0.5f);
            PlayFoostep = false;
        }
    }
    #endregion Movement Mechanic Methods

    
    private void JumpPadHandler()
    {
        if (hitJumpPad)
        {
            moveDirection.y = jPadSpeed;
            hitJumpPad = false;
        }

    }
    public void ToggleJumpPad(int jSpeed)
    {
        jPadSpeed = jSpeed;
        hitJumpPad = true;
    }
    public bool GetSprintStatus()
    {
        return isSprinting;
    }
    public void SetSprintStatus(bool status)
    {
        isSprinting = status;
    }
}