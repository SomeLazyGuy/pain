using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour {
    [SerializeField] private gameOver gameOver;
    [SerializeField] private int _maxHealth = 1;
    public int _health = 1;

    [SerializeField] private GameObject _heart;

    private float _spread = 20;

    private GameObject[] _hearts;

    void Awake()
    {
        _hearts = new GameObject[_maxHealth];

        InstantiateHearts();

        _health = _maxHealth;

        UpdateHearts();

    }

    public void TakeDamage(int damageAmount) {

        _health -= damageAmount;

        UpdateHearts();


        if (_health <= 0) {
            gameOver.gameOverScreen();
        }
    }
    public void Heal(int healAmount)
    {
        _health = Mathf.Clamp(_health + healAmount, 0, _maxHealth);

        UpdateHearts();
    }

    public void UpdateHearts()
    {
        for (int i = 0; i < _maxHealth; i++) {
            if (i < _health) {
                _hearts[i].GetComponent<Image>().color = new Color(1f, 0.08f, 0.55f);
            } else
            {
                _hearts[i].GetComponent<Image>().color = Color.gray;
            }
        }
    }

    private void InstantiateHearts() {
        for (int i = 0; i < _maxHealth; i++)
        {
            _hearts[i] = Instantiate(_heart, this.transform);
            _hearts[i].transform.position += new Vector3((i * (_spread + 60)), 0, 0);
        }
    }
}
