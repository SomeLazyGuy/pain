using System;
using UnityEngine;

public class PlayerCollect : MonoBehaviour {
    [SerializeField] private Points points;
    
    private void OnTriggerStay2D(Collider2D other) {
        if (other.CompareTag("Collectable")) {
            int value = other.GetComponent<Leaf>().value;
            Destroy(other.gameObject);
            Debug.Log(value);
            
            points.AddPoints(value);
        }
    }
}
