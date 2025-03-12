using UnityEngine;

public class JumpState : State {
    private PlayerStateMachine _stateMachine;
    
    public override void Entry(PlayerStateMachine stateMachine) {
        _stateMachine = stateMachine;
        _stateMachine.JumpVelocity = _stateMachine.jumpForce;
    }
    
    public override void Update() {
        _stateMachine.Rb.linearVelocity = new Vector2(_stateMachine.MoveDirection.x 
                                                       * _stateMachine.moveSpeed, _stateMachine.JumpVelocity);
        _stateMachine.transform.Rotate(0, 0, _stateMachine.MoveDirection.y * _stateMachine.rotationSpeed, Space.Self);
        _stateMachine.JumpVelocity -= _stateMachine.jumpDeceleration;
        if (_stateMachine.JumpVelocity < 0) {
            _stateMachine.JumpVelocity = 0;
        }
    }
    public override void Exit() { }
}
