using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCollect : MonoBehaviour {
    [SerializeField] private Points points;

    public UnityEvent keyPickedUpEvent;

    private void Start() {
        if (keyPickedUpEvent == null) {
            keyPickedUpEvent = new UnityEvent();
        }
    }
    
    private void OnTriggerStay2D(Collider2D other) {
        if (other.CompareTag("Collectable")) {
            int value = other.GetComponent<Leaf>().value;
            Destroy(other.gameObject);
            points.AddPoints(value);
        }
        
        if (other.CompareTag("Key")) {
            Destroy(other.gameObject);
            keyPickedUpEvent.Invoke();
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Door")) {
            other.gameObject.GetComponent<Door>().OpenDoor();
        }
    }
}
