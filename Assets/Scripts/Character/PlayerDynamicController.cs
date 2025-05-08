using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public enum PlayerBaseStateType
{
    Stand,  // 0
    Crouch, // 1
    Crawl,  // 2
}

public enum PlayerStateType
{
    Idle,   // 0
    Walk,   // 1
    Run,    // 2
    Jump,   // 3
    Fall,   // 4
    Attack, // 5
    Hit,    // 6
    Dead,   // 7
    Strafe, // 8
}

public enum PlayerPreviousStateType
{
    Idle,   // 0
    Walk,   // 1
    Run,    // 2
    Jump,   // 3
    Fall,   // 4
    Attack, // 5
    Hit,    // 6
    Dead,   // 7
    Strafe, // 8
}

public class PlayerDynamicController : MonoBehaviour
{
    #region Variables // 변수 그룹

    public StateMachine stateMachine = new StateMachine();

    public PlayerBaseStateType playerBaseStateType = PlayerBaseStateType.Stand;
    public PlayerStateType playerStateType = PlayerStateType.Idle;
    public PlayerPreviousStateType playerPreviousStateType = PlayerPreviousStateType.Idle;

    public Animator anim;

    public float CurrentStateTime { get; private set; }

    private Transform capsuleCollider_Group => transform.Find("Collider_Group");
    public CapsuleCollider[] CapsuleColliders => capsuleCollider_Group.GetComponentsInChildren<CapsuleCollider>();// Stand, Crouch, Crawl CapsuleCollider 배열

    #endregion

    private void Start()
    {
        InitSettings();
    }

    private void InitSettings()
    {
        // Initialize the state machine with the Idle state
        stateMachine.ChangeState(new IdleState(), this);

        // References
        anim = GetComponent<Animator>();

        // Set up the animator
        if (anim == null) { Debug.LogError("Animator component not found in children."); return; }
            
        playerBaseStateType = PlayerBaseStateType.Stand;
        playerStateType = PlayerStateType.Idle;
        playerPreviousStateType = PlayerPreviousStateType.Idle;

        InputReader.Instance.OnPerformJump += OnJump;
        InputReader.Instance.OnActivateRun += OnActivateRun;
        InputReader.Instance.OnDeactivateRun += OnDeactivateRun;
    }

    private void Update()
    {
        stateMachine.Update(this);

        if (stateMachine?.CurrentState != null)
        {
            CurrentStateTime += Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        stateMachine.FixedUpdate(this);
    }

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
