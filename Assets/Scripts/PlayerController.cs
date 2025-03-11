using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {
    [SerializeField] private bool airControl = true;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float jumpDeceleration = 5f;
    [SerializeField] private float rotationSpeed = 1f;
    [SerializeField] private float knockbackResistance = 5f;
    [SerializeField] private GameObject canvas;

    private Rigidbody2D _rb;
    private Vector2 _moveDirection = Vector2.zero;
    private float _jumpVelocity;
    private bool _isGrounded;
    private bool _isGroundPound = false;
    
    private void Start() {
        _rb = GetComponent<Rigidbody2D>();
    }
    
    public void Move(InputAction.CallbackContext context) {
        _moveDirection = context.ReadValue<Vector2>();
    }
    
    //public void Jump(InputAction.CallbackContext context) {
    //    if (!_isGrounded) {
    //        return;
    //    }
//
    //    Debug.Log(context);
    //    _jumpVelocity = jumpForce;
    //}

    public void Jump(InputAction.CallbackContext context)
    {
        Debug.Log("Test");
        if (context.started)
        {
            if (!_isGrounded)
            {
                GroundPound();
                return;
            }
            Debug.Log("Jump");
            _jumpVelocity = jumpForce;
        }
    }

    public void GroundPound() {
        _jumpVelocity = -jumpForce;
        _isGroundPound = true;
    }
    
    private void FixedUpdate() {
        if (!_isGrounded) {
            transform.Rotate(0, 0, _moveDirection.y * rotationSpeed, Space.Self);    
        }

        if (!airControl) {
            if (_isGrounded) {
                _rb.linearVelocity = new Vector2(_moveDirection.x * moveSpeed, _jumpVelocity);
            } else {
                _rb.linearVelocity = new Vector2(0, _jumpVelocity);
            } 
        } else {
            _rb.linearVelocity = new Vector2(_moveDirection.x * moveSpeed, _jumpVelocity); 
        }
        
        _jumpVelocity -= jumpDeceleration;
        if (!_isGroundPound)
        {
            if (_jumpVelocity < 0)
            {
                _jumpVelocity = 0;
            }
        }

        if (transform.position.y < -10) {
            canvas.GetComponent<gameOver>().gameOverScreen();
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Ground")) {
            _isGrounded = true;
            _isGroundPound = false;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Ground")) {
            _isGrounded = false; 
        }
    }
}