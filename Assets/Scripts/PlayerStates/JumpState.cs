using UnityEngine;

public class JumpState : State
{
    private PlayerStateMachine _stateMachine;
    public float jumpVelocity;
    
    override public void Entry(PlayerStateMachine stateMachine)
    {
        Debug.Log("Jump Entry");
        _stateMachine = stateMachine;
        jumpVelocity = _stateMachine.jumpForce;
    }
    override public void Update()
    {
        _stateMachine.Rb.linearVelocity = new Vector2(_stateMachine.MoveDirection.x 
                                                       * _stateMachine.moveSpeed, jumpVelocity);
        jumpVelocity -= _stateMachine.jumpDeceleration;
        if (jumpVelocity < 0)
        {
            jumpVelocity = 0;
        }
    }
    override public void Exit()
    {
        Debug.Log("Jump Exit");
    }
}
