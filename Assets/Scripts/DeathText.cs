using TMPro;
using UnityEngine;

public class DeathText : MonoBehaviour {
    private PlayerHealth _playerHealth;
    private TextMeshProUGUI _text;
    private int _deaths;
    
    private void Start() {
        _playerHealth = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
        _playerHealth.playerDeathEvent.AddListener(IncrementDeaths);
        
        _text = GetComponent<TextMeshProUGUI>();
        
        _deaths = PlayerPrefs.GetInt("deaths", 0);
        UpdateDeathText();
    }
    
    private void IncrementDeaths() {
        if (Time.timeScale == 0) {
            return;
        }

        _deaths++;
        UpdateDeathText();
    }
    
    private void UpdateDeathText() {
        PlayerPrefs.SetInt("deaths", _deaths);
        _text.text = _deaths.ToString();
    }
}
