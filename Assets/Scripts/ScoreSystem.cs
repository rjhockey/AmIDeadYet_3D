using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    static TMP_Text _text;
    static int _points;

    public static void Add(int points)
    {
        //_points is current points, points is being added
        _points += points;
        _text.SetText(_points.ToString());
    }

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
    }
}