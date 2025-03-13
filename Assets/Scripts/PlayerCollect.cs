using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCollect : MonoBehaviour {
    [SerializeField] private Points points;

    public UnityEvent keyPickedUpEvent;
    public UnityEvent doorOpenedEvent;

    private int _keyCount;
    
    private void Start() {
        keyPickedUpEvent ??= new UnityEvent();
        doorOpenedEvent ??= new UnityEvent();    
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
            _keyCount++;
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Door")) {
            if (_keyCount > 0) {
                other.gameObject.GetComponent<Door>().OpenDoor();
                doorOpenedEvent.Invoke();
                _keyCount--;
            }
        }
    }
}
