using UnityEngine;

public class FallState : State {
    
    private PlayerStateMachine _stateMachine;
    
    public override void Entry(PlayerStateMachine stateMachine) {
        _stateMachine = stateMachine;
    }

    public override void Update() {
        _stateMachine.Rb.linearVelocity = new Vector2(_stateMachine.MoveDirection.x * _stateMachine.moveSpeed, _stateMachine.JumpVelocity);
        _stateMachine.transform.Rotate(0, 0, _stateMachine.MoveDirection.y * _stateMachine.rotationSpeed, Space.Self);

        _stateMachine.JumpVelocity -= _stateMachine.gravity;
    }

    public override void Exit() { }
}