using System;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour {

    [SerializeField] private GameObject _heart;

    private float _spread = 20;

    private GameObject[] _hearts;

    private PlayerHealth _playerHealth;
    

    public void Start()
    {
        _playerHealth = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
        
        _hearts = new GameObject[_playerHealth.maxHealth];

        InstantiateHearts();
        
        UpdateHearts();
        
        _playerHealth.updateHealthEvent.AddListener(UpdateHearts);
    }

    //public void OnEnable()
    //{
    //    _playerHealth.updateHealthEvent.AddListener(UpdateHearts);
    //}

    public void OnDisable()
    {
        _playerHealth.updateHealthEvent.RemoveListener(UpdateHearts);
    }
    
    private void UpdateHearts()
    {
        
        for (int i = 0; i < _playerHealth.maxHealth; i++) {
            if (i < _playerHealth.currentHealth)
            {
                _hearts[i].GetComponent<Image>().color = Color.white;
            } else
            {
                _hearts[i].GetComponent<Image>().color = Color.gray;
            }
        }
    }

    private void InstantiateHearts() {
        for (int i = 0; i < _playerHealth.maxHealth; i++)
        {
            _hearts[i] = Instantiate(_heart, this.transform);
            _hearts[i].transform.position += new Vector3((i * (_spread + 60)), 0, 0);
        }
    }
}
