using UnityEngine;

public class JumpState : State
{
    private PlayerStateMachine _stateMachine;
    
    override public void Entry(PlayerStateMachine stateMachine)
    {
        Debug.Log("Jump Entry");
        _stateMachine = stateMachine;
        _stateMachine.JumpVelocity = _stateMachine.jumpForce;
    }
    override public void Update()
    {
        _stateMachine.Rb.linearVelocity = new Vector2(_stateMachine.MoveDirection.x 
                                                       * _stateMachine.moveSpeed, _stateMachine.JumpVelocity);
        _stateMachine.JumpVelocity -= _stateMachine.jumpDeceleration;
        if (_stateMachine.JumpVelocity < 0)
        {
            _stateMachine.JumpVelocity = 0;
        }
    }
    override public void Exit()
    {
        Debug.Log("Jump Exit");
    }
}
