using UnityEngine;

public class PlayerHealth : MonoBehaviour {
   [SerializeField] private healthBar healthBar;
   
   private PlayerController _playerController;
   
   private void Start() {
      _playerController = GetComponent<PlayerController>();
   }
   
   private void OnCollisionEnter2D(Collision2D collision) {
      if (collision.gameObject.CompareTag("Obstacle")) {
         obstacle obstacle = collision.gameObject.GetComponent<obstacle>();
         //gameController.ApplyDamage(obstacle.damageAmount);
         healthBar.TakeDamage(obstacle.damageAmount);
      }
   }
}
