using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStateMachine : MonoBehaviour {
    private PlayerStates _currentState = PlayerStates.Idle;
    private IdleState _idleState = new IdleState();
    private MoveState _moveState = new MoveState();
    private JumpState _jumpState = new JumpState();
    private FallState _fallState = new FallState();
    private GroundPoundState _groudPoundState = new GroundPoundState();

    public bool IsGrounded { get; private set; }
    
    private void MovePressed(InputAction.CallbackContext context) {
        
    }
    
    private void JumpPressed(InputAction.CallbackContext context) {
        
    }
    
    private void FixedUpdate() {
        
    }
    
    private void SwitchState(PlayerStates newState) {
        
        _currentState = newState;
    }
}
