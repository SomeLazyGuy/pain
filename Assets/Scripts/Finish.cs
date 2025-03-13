using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{
    [SerializeField] private Text yourText;

    [SerializeField] public Button restartButton;
    
    void Start()
    {
        yourText.enabled = false; 
    }

    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            yourText.enabled = true; 
            Time.timeScale = 0;

            restartButton.gameObject.SetActive(true);
        }
    }
}
