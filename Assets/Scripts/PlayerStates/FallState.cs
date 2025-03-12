using UnityEngine;

public class FallState : State {
    
    private PlayerStateMachine _stateMachine;
    
    override public void Entry(PlayerStateMachine stateMachine) {
        Debug.Log("Fall_Entry");

        _stateMachine = stateMachine;
  
    }

    override public void Update()
    {
        _stateMachine.Rb.linearVelocity = new Vector2(_stateMachine.MoveDirection.x * _stateMachine.moveSpeed, 0);
        _stateMachine.transform.Rotate(0, 0, _stateMachine.MoveDirection.y * _stateMachine.rotationSpeed, Space.Self);
    }

    override public void Exit() {
        Debug.Log("Fall_Exit");
    }
}