using UnityEngine;

public class DashState : State {
    private PlayerStateMachine _stateMachine;

    private int _dashTimer;

    public override void Entry(PlayerStateMachine stateMachine) {
        _stateMachine = stateMachine;

        _dashTimer = _stateMachine.dashTime;
        
        if (_stateMachine.MoveDirection.x < 0) {
            _stateMachine.Rb.linearVelocity = new Vector2(-_stateMachine.dashSpeed, 0);
            _stateMachine.IsDash = true;
        } else if (_stateMachine.MoveDirection.x > 0) {
            _stateMachine.Rb.linearVelocity = new Vector2(_stateMachine.dashSpeed, 0);
            _stateMachine.IsDash = true;
        }
    }

    public override void Update()
    {
        if (_dashTimer <= 0) {
            _stateMachine.IsDash = false;
        } else {
            _dashTimer--;
        }
    }

    public override void Exit() { }
}