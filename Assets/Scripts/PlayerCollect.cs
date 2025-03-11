using System;
using UnityEngine;

public class PlayerCollect : MonoBehaviour {
    [SerializeField] private Points points;
    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Collectable")) {
            int value = other.GetComponent<Leaf>().value;
            
            Debug.Log(value);
            
            points.AddPoints(value);
            Destroy(other.gameObject);
        }
    }
}
