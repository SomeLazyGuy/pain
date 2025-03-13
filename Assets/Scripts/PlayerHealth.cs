using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
   [SerializeField] private healthBar healthBar;
   [SerializeField] private float immunityTime;
   [SerializeField] private float deathPlane;
   [SerializeField] public int maxHealth;
   
   private PlayerStateMachine _playerStateMachine;
   private Animator _animator;
   private bool _isImmune;
   [HideInInspector] public int currentHealth;

   [HideInInspector] public UnityEvent playerDeathEvent;
   [HideInInspector] public UnityEvent updateHealthEvent;
   
   
   private void Start() {
      _playerStateMachine = GetComponent<PlayerStateMachine>();
      _animator = GetComponent<Animator>();

      playerDeathEvent ??= new UnityEvent();
      updateHealthEvent ??= new UnityEvent();
      currentHealth = maxHealth;
   }
   
   private void OnCollisionEnter2D(Collision2D collision) {
      if (_isImmune) {
         return;
      }
      
      if (collision.gameObject.CompareTag("Obstacle")) {
         obstacle obstacle = collision.gameObject.GetComponent<obstacle>();
         if (_playerStateMachine.IsGrounded)
         {
            currentHealth -= 2 * obstacle.damageAmount;
         } else {
            currentHealth -= obstacle.damageAmount;
         }
         updateHealthEvent.Invoke();
         if (currentHealth <= 0)
         {
            playerDeathEvent.Invoke();
         }
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
   
   private void OnTriggerEnter2D(Collider2D other) {
      if (other.CompareTag("Heart")) {
         currentHealth = Mathf.Clamp(currentHealth + other.GetComponent<Heart>().amount, 0, maxHealth);
         Destroy(other.gameObject);
         updateHealthEvent.Invoke();
      }
   }

   private void Update()
   {
      if (transform.position.y < deathPlane)
      {
         playerDeathEvent.Invoke();
      }
   }
   
}
