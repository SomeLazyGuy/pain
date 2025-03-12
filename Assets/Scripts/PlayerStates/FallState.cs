using UnityEngine;

public class FallState : State {
    
    private PlayerStateMachine _stateMachine;
    
    public override void Entry(PlayerStateMachine stateMachine) {
        Debug.Log("Fall_Entry");
        _stateMachine = stateMachine;
    }

    public override void Update() {
        _stateMachine.Rb.linearVelocity = new Vector2(_stateMachine.MoveDirection.x * _stateMachine.moveSpeed, 0);
        _stateMachine.transform.Rotate(0, 0, _stateMachine.MoveDirection.y * _stateMachine.rotationSpeed, Space.Self);
    }

    public override void Exit() {
        Debug.Log("Fall_Exit");
    }
}