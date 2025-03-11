using UnityEngine;
using TMPro;

public class Points : MonoBehaviour
{
    private int _points = 0;

    public void AddPoints(int _amount) {
        _points += _amount;
        UpdatePoints();
    }

    public void UpdatePoints()
    {
        this.GetComponent<TMP_Text>().text = _points.ToString();
    }
}
