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

    public StateMachine baseStateMachine = new StateMachine();
    public StateMachine subStateMachine = new StateMachine();

    public PlayerBaseStateType playerBaseStateType = PlayerBaseStateType.Stand;
    public PlayerSubStateType playerSubStateType = PlayerSubStateType.Idle;
    public PlayerPreviousBaseStateType playerPreviousBaseStateType = PlayerPreviousBaseStateType.Stand;
    public PlayerPreviousSubStateType playerPreviousSubStateType = PlayerPreviousSubStateType.Idle;

    public Animator anim;

    public float CurrentBaseStateTime { get; private set; }
    public float CurrentSubStateTime { get; private set; }
    

    private Transform capsuleCollider_Group => transform.Find("Collider_Group");
    public CapsuleCollider[] CapsuleColliders => capsuleCollider_Group.GetComponentsInChildren<CapsuleCollider>();// Stand, Crouch, Crawl CapsuleCollider 배열

    #endregion

    private void Start()
    {
        InitSettings();
    }

    private void InitSettings()
    {
        baseStateMachine.ChangeBaseState(new StandState(), this);
        subStateMachine.ChangeSubState(new IdleState(), this);

        // References
        anim = GetComponent<Animator>();

        // Set up the animator
        if (anim == null) { Debug.LogError("Animator component not found in children."); return; }
            
        playerBaseStateType = PlayerBaseStateType.Stand;
        playerSubStateType = PlayerSubStateType.Idle;
        playerPreviousSubStateType = PlayerPreviousSubStateType.Idle;

        InputReader.Instance.OnPerformJump += OnJump;
        InputReader.Instance.OnActivateRun += OnActivateRun;
        InputReader.Instance.OnDeactivateRun += OnDeactivateRun;
    }

    private void Awake()
    {
        baseStateMachine.AwakeBaseState(this);
        subStateMachine.AwakeSubState(this);
    }

    private void Update()
    {
        baseStateMachine.UpdateSubState(this);
        subStateMachine.UpdateSubState(this);

        if (baseStateMachine?.CurrentSubState != null) CurrentBaseStateTime += Time.deltaTime;

        if (subStateMachine?.CurrentSubState != null) CurrentSubStateTime += Time.deltaTime;
    }

    private void FixedUpdate()
    {
        baseStateMachine.FixedUpdateSubState(this);
        subStateMachine.FixedUpdateSubState(this);
    }

    //protected void 

    private void OnJump()
    {
        Debug.Log("Jump action triggered.");
    }

    private void OnActivateRun()
    {
        Debug.Log("Run action activated.");
    }

    private void OnDeactivateRun()
    {
        Debug.Log("Run action deactivated.");
    }
}
