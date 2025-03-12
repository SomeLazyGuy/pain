using UnityEngine;

public class JumpState : State
{
    private PlayerStateMachine _stateMachine;
    private float _jumpVelocity;
    
    override public void Entry(PlayerStateMachine stateMachine)
    {
        Debug.Log("Jump Entry");
        _stateMachine = stateMachine;
        _jumpVelocity = _stateMachine._jumpForce;
    }
    override public void Update()
    {
        _stateMachine._rb.linearVelocity = new Vector2(_stateMachine._moveDirection.x 
                                                       * _stateMachine._moveSpeed, _jumpVelocity);
        _jumpVelocity -= _stateMachine._jumpDeceleration;
        if (_jumpVelocity < 0)
        {
            _jumpVelocity = 0;
            Exit();
        }
    }
    override public void Exit()
    {
        Debug.Log("Jump Exit");
    }
}
