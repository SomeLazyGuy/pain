using UnityEngine;
using UnityEngine.UI;

public class gameOver : MonoBehaviour
{
   [SerializeField] private Text yourText;
   
   void Start()
   {
      yourText.enabled = false; 
   }
   
   public void gameOverScreen()
   {
      yourText.enabled = true;
      Time.timeScale = 0;
   }
}
