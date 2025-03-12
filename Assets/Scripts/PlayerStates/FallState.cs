using UnityEngine;

public class FallState : State {
    
    private PlayerStateMachine _stateMachine;
    
    override public void Entry(PlayerStateMachine stateMachine) {
        Debug.Log("Fall_Entry");

        _stateMachine = stateMachine;
  
    }

    override public void Update()
    {
        //_stateMachine.rb.linearVelocity = new Vector2(_stateMachine.moveDirection.x * _stateMachine.moveSpeed, 0);
        //_stateMachine.transform.Rotate(0, 0, _stateMachine._moveDirection.y * _stateMachine.rotationSpeed, _stateMachine.Space.Self);
    }

    override public void Exit() {
        Debug.Log("Fall_Exit");
    }
}