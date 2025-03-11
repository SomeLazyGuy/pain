using System;
using UnityEngine;

public class PlayerCollect : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Collectable")) {
            int value = other.GetComponent<Leaf>().value;
            
            Debug.Log(value);
            
            // send value
            
            Destroy(other.gameObject);
        }
    }
}
