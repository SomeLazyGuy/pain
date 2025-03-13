using System;
using UnityEngine;
using UnityEngine.Serialization;

public class GumbaMov : MonoBehaviour
{

    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject pointA;
    [SerializeField] private GameObject pointB;
    private int _direction;
    private float _yPos;

    public void Start()
    {
        _yPos = transform.position.y;
        _direction = 1;
    }

    public void FixedUpdate() {
        if (pointA.transform.position.x >= transform.position.x || pointB.transform.position.x <= transform.position.x)
        {
            _direction *= -1;
            
        }
        transform.position = new Vector2(transform.position.x+_direction * moveSpeed, _yPos);
    }

    public void Update()
    {
        transform.rotation = Quaternion.Euler(Vector3.zero);
    }
}
