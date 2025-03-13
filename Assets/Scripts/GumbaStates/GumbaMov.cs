using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class GumbaMov : MonoBehaviour
{

    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject pointA;
    [SerializeField] private GameObject pointB;
    private int _direction;
    private float _yPos;
    [SerializeField] private int live;

    public void Start()
    {
        _yPos = transform.position.y;
        _direction = 1;
    }

    public void FixedUpdate()
    {
        if (pointA.transform.position.x >= transform.position.x || pointB.transform.position.x <= transform.position.x)
        {
            _direction *= -1;

        }

        transform.position = new Vector2(transform.position.x + _direction * moveSpeed, _yPos);
    }

    public void Update()
    {
        transform.rotation = Quaternion.Euler(Vector3.zero);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerStateMachine playerStateMachine = other.GetComponent<PlayerStateMachine>();
            if (playerStateMachine.IsGroundPound)
            {
                live -= 2;
            }
            else
            {
                live--;
            }

            if (live <= 0)
            {
                Destroy(gameObject);
            }

            playerStateMachine.Rb.linearVelocity = new Vector2(0,50);
        }
    }
}
