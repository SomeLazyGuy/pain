using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {
   [SerializeField] private healthBar healthBar;
   [SerializeField] private float immunityTime;
   
   private PlayerController _playerController;
   private Animator _animator;
   private bool _isImmune;
   
   private void Start() {
      _playerController = GetComponent<PlayerController>();
      _animator = GetComponent<Animator>();
   }
   
   private void OnCollisionEnter2D(Collision2D collision) {
      if (_isImmune) {
         return;
      }
      
      if (collision.gameObject.CompareTag("Obstacle")) {
         obstacle obstacle = collision.gameObject.GetComponent<obstacle>();
         healthBar.TakeDamage(obstacle.damageAmount);
         StartCoroutine(Immunity());
      }
   }
   
   private IEnumerator Immunity() {
      _animator.SetBool("immune", true);
      _isImmune = true;
      yield return new WaitForSeconds(immunityTime);
      _isImmune = false;
      _animator.SetBool("immune", false);
   }
}
