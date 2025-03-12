﻿using UnityEngine;

public class MoveState : State
{

    private PlayerStateMachine _stateMachine;
    
    override public void Entry(PlayerStateMachine stateMachine) {
        Debug.Log("Move_Entry");

        _stateMachine = stateMachine;
  
    }

    override public void Update()
    {
        //_stateMachine.rb.linearVelocity = new Vector2(_stateMachine.moveDirection.x * _stateMachine.moveSpeed, 0);
    }

    override public void Exit() {
        Debug.Log("Move_Exit");
    }
}
