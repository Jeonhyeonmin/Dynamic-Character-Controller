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
}

public class PlayerDynamicController : MonoBehaviour
{
    #region Variables // 변수 그룹

    public StateMachine stateMachine = new StateMachine();

    public PlayerBaseStateType playerBaseStateType = PlayerBaseStateType.Stand;
    public PlayerStateType playerStateType = PlayerStateType.Idle;

    public Animator anim;

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

        InputReader.Instance.OnPerformJump += OnJump;
    }

    private void Update()
    {
        stateMachine.Update(this);
    }

    private void FixedUpdate()
    {
        stateMachine.FixedUpdate(this);
    }

    private void OnJump()
    {
        Debug.Log("Jump action triggered.");
    }
}
