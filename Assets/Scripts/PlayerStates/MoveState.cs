using UnityEngine;

public class MoveState : IState
{

    private PlayerStateMachine _stateMachine;
    
    public void Entry(PlayerStateMachine stateMachine) {
        Debug.Log("Move_Entry");

        _stateMachine = stateMachine;
  
    }

    public void Update()
    {
        //_stateMachine.rb.linearVelocity = new Vector2(_stateMachine.moveDirection.x * _stateMachine.moveSpeed, 0);
    }

    public void Exit() {
        Debug.Log("Move_Exit");
    }
}
