using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public enum PlayerBaseStateType
{
    Stand = 0,// 0
    Crouch = 1, // 1
    Crawl = 2,  // 2
}
public enum PlayerSubStateType
{
    Idle = 0,   // 0
    Walk = 1,   // 1
    Run = 2,    // 2
    Jump = 3,   // 3
    Fall = 4,   // 4
    Attack = 5, // 5
    Hit = 6,    // 6
    Dead = 7,   // 7
    Strafe = 8, // 8
}

public enum PlayerPreviousBaseStateType
{
    Stand = 0,  // 0
    Crouch = 1, // 1
    Crawl = 2,  // 2
}
public enum PlayerPreviousSubStateType
{
    Idle = 0,   // 0
    Walk = 1,   // 1
    Run = 2,    // 2
    Jump = 3,   // 3
    Fall = 4,   // 4
    Attack = 5, // 5
    Hit = 6,    // 6
    Dead = 7,   // 7
    Strafe = 8, // 8
}

public class PlayerDynamicController : MonoBehaviour
{
    #region Variables // 변수 그룹

    public StateMachine stateMachine = new StateMachine();

    public PlayerBaseStateType playerBaseStateType = PlayerBaseStateType.Stand;
    public PlayerSubStateType playerSubStateType = PlayerSubStateType.Idle;
    public PlayerPreviousBaseStateType playerPreviousBaseStateType = PlayerPreviousBaseStateType.Stand;
    public PlayerPreviousSubStateType playerPreviousSubStateType = PlayerPreviousSubStateType.Idle;

    public Animator anim;

    public float CurrentBaseStateTime { get; private set; }
    public float CurrentSubStateTime { get; private set; }
    

    private Transform capsuleCollider_Group => transform.Find("Collider_Group");
    public CapsuleCollider[] CapsuleColliders => capsuleCollider_Group.GetComponentsInChildren<CapsuleCollider>();// Stand, Crouch, Crawl CapsuleCollider 배열

    public Camera playerCamera => Camera.main;
    public float cameraOffset;

    #endregion

    private void InitSettings()
    {
        // References
        anim = GetComponentInChildren<Animator>();

        // Set up the animator
        if (anim == null) { Debug.LogError("Animator component not found in children."); return; }
            
        playerBaseStateType = PlayerBaseStateType.Stand;
        playerSubStateType = PlayerSubStateType.Idle;
        playerPreviousSubStateType = PlayerPreviousSubStateType.Idle;

        stateMachine.ChangeBaseState(new StandState(), this);
        stateMachine.ChangeSubState(new IdleState(), this);

        InputReader.Instance.OnPerformJump += OnJump;
    }

    private void Awake()
    {
        InitSettings();
        stateMachine.AwakeBaseState(this);
        stateMachine.AwakeSubState(this);
    }

    private void Update()
    {
        CameraOffset();

        stateMachine.UpdateBaseState(this);
        stateMachine.UpdateSubState(this);

        if (stateMachine?.CurrentBaseState != null) CurrentBaseStateTime += Time.deltaTime;

        if (stateMachine?.CurrentSubState != null) CurrentSubStateTime += Time.deltaTime;

        anim.SetFloat(AnimatorHash.Float.PLAYER_MOVE_DIRECTION_X, InputReader.Instance.moveDirection.x);
        anim.SetFloat(AnimatorHash.Float.PLAYER_MOVE_DIRECTION_Z, InputReader.Instance.moveDirection.y);
    }

    private void CameraOffset()
    {
        float cameraOffset = Vector3.SignedAngle(new Vector3(transform.forward.x, 0, transform.forward.z), new Vector3(playerCamera.transform.forward.x, 0, playerCamera.transform.forward.z), Vector3.up);
        
        this.cameraOffset = cameraOffset;

        // 구현 필요 
    }

    private void FixedUpdate()
    {
        stateMachine.FixedUpdateBaseState(this);
        stateMachine.FixedUpdateSubState(this);
    }

    private void OnAnimatorMove()
    {
        transform.position += anim.deltaPosition;
        transform.rotation *= anim.deltaRotation;
    }

    private void OnJump()
    {
        Debug.Log("Jump action triggered.");
    }
}
