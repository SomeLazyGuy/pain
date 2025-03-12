using UnityEngine;

public class MoveState : State {
    private PlayerStateMachine _stateMachine;
    
    public override void Entry(PlayerStateMachine stateMachine) {
        _stateMachine = stateMachine;
    }

    public override void Update() {
        _stateMachine.Rb.linearVelocity = new Vector2(_stateMachine.MoveDirection.x * _stateMachine.moveSpeed, 0);
    }

    public override void Exit() { }
}
