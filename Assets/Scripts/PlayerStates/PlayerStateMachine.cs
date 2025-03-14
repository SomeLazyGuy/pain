using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerStateMachine : MonoBehaviour {
    public bool airControl = true;
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public float rotationSpeed = 1f;
    public float gravity = 9.81f;
    public float groundPoundMultiplier = 2;
    public float sprintMultiplier = 2;
    public float dashSpeed = 20;
    public int dashTime = 10;

    [HideInInspector] public UnityEvent<String> switchStateEvent;
    
    private IdleState _idleState = new IdleState();
    private MoveState _moveState = new MoveState();
    private JumpState _jumpState = new JumpState();
    private FallState _fallState = new FallState();
    private GroundPoundState _groundPoundState = new GroundPoundState();
    private SprintState _sprintState = new SprintState();
    private DashState _dashState = new DashState();
    private State _currentState;
    private bool _isSprinting = false;

    public bool IsGrounded { get; private set; }
    public bool IsDash { get; set; }
    public Vector2 MoveDirection { get; private set; }
    public Rigidbody2D Rb { get; private set; }
    public float JumpVelocity { get; set; }
    public bool IsGroundPound { get; private set; }
    
    private void Awake() {
        SwitchState(_idleState);
    }
    
    private void Start() {
        Rb = GetComponent<Rigidbody2D>();
        switchStateEvent ??= new UnityEvent<String>();
    }
    
    public void MovePressed(InputAction.CallbackContext context) {
        MoveDirection = context.ReadValue<Vector2>(); 
        
        if (MoveDirection.x == 0 && (_currentState == _moveState || _currentState == _sprintState)) {
            SwitchState(_idleState);
        }
    }
    
    public void JumpPressed(InputAction.CallbackContext context) {
        if (context.started) {
            if (_currentState == _jumpState || _currentState == _fallState) {
                if (IsGrounded) {
                   SwitchState(_jumpState);
                   return;
                }
                SwitchState(_groundPoundState);
                IsGroundPound = true;
                return;
            }

            if (_currentState == _idleState || _currentState == _moveState || _currentState == _sprintState) {
                SwitchState(_jumpState);
            }
        }
    }
    
    public void SprintPressed(InputAction.CallbackContext context) {
        if (context.started) {
            if ((_currentState == _jumpState || _currentState == _fallState) && !IsDash) {
                SwitchState(_dashState);
            }
            else
            {
                _isSprinting = true;
            }
        } else if (context.canceled) {
            _isSprinting = false;
        }
    }
    
    private void FixedUpdate() {
        if (MoveDirection.x != 0 && _currentState == _idleState) {
            SwitchState(_moveState);
            return;
        }
        
        if (_currentState == _moveState && _isSprinting) {
            SwitchState(_sprintState);
            return;
        }
        
        if ((_currentState == _moveState || _currentState == _idleState) && !IsGrounded) {
            SwitchState(_fallState);
            return;
        }
        
        if (_currentState == _jumpState && JumpVelocity == 0) {
            SwitchState(_fallState);
            return;
        }
        
        if (_currentState == _dashState && !IsDash) {
            SwitchState(_fallState);
            return;
        }
        
        _currentState.Update();
    }
    
    private void SwitchState(State newState) {
        if (_currentState != null) {
            _currentState.Exit();
        }
        _currentState = newState;
        _currentState.Entry(this);
        switchStateEvent.Invoke(_currentState.GetType().Name);
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Ground")) {
            IsGrounded = true;
            
            if (_currentState == _groundPoundState || _currentState == _fallState) {
                SwitchState(_idleState);
                IsGroundPound = false;
            }
        } 
        
        if (other.CompareTag("Destructable")) {
            if (_currentState == _groundPoundState) {
                Destroy(other.gameObject);
            } else {
                IsGrounded = true;
                SwitchState(_idleState);
            }
        }
    }
    
    private void OnTriggerStay2D(Collider2D other) {
        if (other.CompareTag("Ground") || other.CompareTag("Destructable")) {
            IsGrounded = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Ground")) {
            IsGrounded = false; 
        }
        if (other.CompareTag("Destructable")) {
            IsGrounded = false;
        }
    }    
}
