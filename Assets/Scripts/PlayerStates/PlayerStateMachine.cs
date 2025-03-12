using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStateMachine : MonoBehaviour {
    public bool airControl = true;
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public float jumpDeceleration = 5f;
    public float rotationSpeed = 1f;
    public float knockbackResistance = 5f;
    
    private IdleState _idleState = new IdleState();
    private MoveState _moveState = new MoveState();
    private JumpState _jumpState = new JumpState();
    private FallState _fallState = new FallState();
    private GroundPoundState _groudPoundState = new GroundPoundState();
    private State _currentState;

    public bool IsGrounded { get; private set; }
    public Vector2 MoveDirection { get; private set; }
    public Rigidbody2D Rb { get; private set; }
    public float JumpVelocity { get; private set; }
    
    private void Awake() {
        _currentState = _idleState;
    }
    
    private void MovePressed(InputAction.CallbackContext context) {
        MoveDirection = context.ReadValue<Vector2>(); 
    }
    
    private void JumpPressed(InputAction.CallbackContext context) {
        if (context.started) {
            if (_currentState != _groudPoundState) {
                SwitchState(_groudPoundState);
                return;
            }

            if (_currentState != _jumpState) {
                SwitchState(_jumpState);
            }
        }
    }
    
    private void FixedUpdate() {
        _currentState.Update();
    }
    
    private void SwitchState(State newState) {
        _currentState.Exit();
        _currentState = newState;
        _currentState.Entry(this);
    }
}
