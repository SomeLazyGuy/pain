using UnityEngine;

public class SprintState : State {
    private PlayerStateMachine _stateMachine;
    
    public override void Entry(PlayerStateMachine stateMachine) {
        _stateMachine = stateMachine;
    }
    
    public override void Update() {
        int direction = _stateMachine.MoveDirection.x < 0 ? -1 : 1;
        _stateMachine.Rb.linearVelocity = new Vector2(direction * _stateMachine.moveSpeed * _stateMachine.sprintMultiplier, _stateMachine.JumpVelocity);
        _stateMachine.JumpVelocity = -_stateMachine.gravity;
    }
    
    public override void Exit() { }
}
