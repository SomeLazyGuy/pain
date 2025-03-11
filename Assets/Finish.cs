using UnityEngine;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{
    [SerializeField] private Text yourText; 

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
        }
    }
}
