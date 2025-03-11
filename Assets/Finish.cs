using UnityEngine;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{
    [SerializeField] private Text yourText; // Insert your text object inside unity inspector

    void Start()
    {
        yourText.enabled = false; // You may need to use .SetActive(false);
    }


// Assuming you're using a 2D platform
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Collision");
// This is where you make your text object appear on screen
            yourText.enabled = true; // May need to use .SetActive(true);
            Time.timeScale = 0;
        }
    }
}
