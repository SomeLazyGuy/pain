﻿using UnityEngine;

public class IdleState : State {
    private PlayerStateMachine _stateMachine;
    
    public override void Entry(PlayerStateMachine stateMachine) {
        _stateMachine = stateMachine;
    }

    public override void Update() {
        _stateMachine.JumpVelocity = -_stateMachine.gravity;
        _stateMachine.Rb.linearVelocity = new Vector2(0, _stateMachine.JumpVelocity);
    }

    public override void Exit() { }
}