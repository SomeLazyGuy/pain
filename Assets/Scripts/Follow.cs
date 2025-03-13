using System;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject Player;
    public float FollowSpeed = 1.5f;
    public float Radius = 2f;
    public Vector2 Direction = new Vector2(0,1);

    private float _xPos;
    private float _yPos;
    
    private Vector2 targetPos;
    
    private Vector2 targetDirection;

    private void Awake() {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update() {
        targetDirection = transform.rotation * Direction;
        targetPos = new Vector2(Player.transform.position.x, Player.transform.position.y) + targetDirection * Radius;
        
        _xPos = Mathf.Lerp(transform.position.x, targetPos.x, FollowSpeed * Time.deltaTime);
        _yPos = Mathf.Lerp(transform.position.y, targetPos.y, FollowSpeed * Time.deltaTime);
    
        transform.position = new Vector3(_xPos,_yPos, transform.position.z);
    }
}
