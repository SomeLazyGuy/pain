using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameOver : MonoBehaviour
{
   [SerializeField] private Text yourText;
   [SerializeField] private Button restartButton;
   
   private PlayerHealth _playerHealth;

   
   void Start()
   {
      Time.timeScale = 1;
      
      yourText.enabled = false;
      
      _playerHealth = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
      _playerHealth.playerDeathEvent.AddListener(gameOverScreen);
   }
   
   //public void OnEnable()
   //{
   //   _playerHealth.updateHealthEvent.AddListener(gameOverScreen);
   //}

   public void OnDisable()
   {
      _playerHealth.playerDeathEvent.RemoveListener(gameOverScreen);
   }
   
   public void gameOverScreen()
   {
      yourText.enabled = true;
      Time.timeScale = 0;
      restartButton.gameObject.SetActive(true);

   }

   public void Restart()
   {
      
      SceneManager.LoadScene("Level2");
   }
}
