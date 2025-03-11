using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 1;
    public int _health = 1;

    [SerializeField] private GameObject _heart;

    private float _spread = 20;

    private GameObject[] _hearts;

    void Awake()
    {
        _hearts = new GameObject[_maxHealth];

        for (int i = 0; i < _maxHealth; i++) {
            _hearts[i] = Instantiate(_heart, this.transform);
            _hearts[i].transform.position += new Vector3((i * (_spread + 60)), 0, 0);
        }

        _health = _maxHealth;

        TakeDamage(1);

    }

    public void TakeDamage(int damageAmount) {
        for (int i = _health - 1; i >= ((_health - damageAmount) >= 0 ? (_health - damageAmount) : 0); i--)
        {
            _hearts[i].GetComponent<Image>().color = Color.gray;
        }
    }
}
