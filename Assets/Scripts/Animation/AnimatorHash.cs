using UnityEngine;

public static class AnimatorHash
{
    public static class Bool
    {
        public static readonly int ISTIRED_HASH = Animator.StringToHash("IsTired");
        public static readonly int ONGROUND_HASH = Animator.StringToHash("OnGround");
    }

    public static class Trigger
    {
        
    }

    public static class Float
    {
        public static readonly int PLAYER_FALL_TIME_HASH = Animator.StringToHash("PlayerFallTime");
        public static readonly int PLAYER_MOVE_DIRECTION_X = Animator.StringToHash("PlayerMoveDirectionX");
        public static readonly int PLAYER_MOVE_DIRECTION_Z = Animator.StringToHash("PlayerMoveDirectionZ");
        public static readonly int PLAYER_CAMERA_OFFSET = Animator.StringToHash("PlayerCameraOffset");
    }

    public static class Int
    {
        public static readonly int PLAYER_BASE_STATE_TYPE_HASH = Animator.StringToHash("PlayerBaseStateType");
        public static readonly int PLAYER_STATE_TYPE_HASH = Animator.StringToHash("PlayerStateType");
        public static readonly int PLAYER_PREVIOUS_STATE_TYPE_HASH = Animator.StringToHash("PlayerPreviousStateType");
    }
}
