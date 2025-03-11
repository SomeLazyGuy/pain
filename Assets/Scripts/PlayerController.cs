using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpSpeed = 5f;
    [SerializeField] private float jumpTime = 1f;
    
    private Rigidbody2D _rb;
    private Vector2 _moveDirection = Vector2.zero;
    private bool _jumping;
    private bool _isGrounded;
    
    private void Start() {
        _rb = GetComponent<Rigidbody2D>();
    }
    
    public void Move(InputAction.CallbackContext context) {
        _moveDirection = context.ReadValue<Vector2>();
    }
    
    public void Jump(InputAction.CallbackContext context) {
        if (_jumping || !_isGrounded) {
            return;
        }
        
        StartCoroutine(Accelerate());
    }
    
    private void FixedUpdate() {
        if (_jumping) {
            _moveDirection.y = jumpSpeed;
        } else {
            _moveDirection.y = 0;
        }
        
        _rb.linearVelocity = _moveDirection * moveSpeed;
    }
    
    private IEnumerator Accelerate() {
        _jumping = true;
        
        yield return new WaitForSecondsRealtime(jumpTime);
        
        _jumping = false;
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Ground")) {
           _isGrounded = true; 
        }
    }
    
    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Ground")) {
            _isGrounded = false; 
        }
    }
}
