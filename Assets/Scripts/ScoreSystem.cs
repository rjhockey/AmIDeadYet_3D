using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    int _points;
    static int _highScore;
    static ScoreSystem _instance;

    void Awake() => _instance = this;

    [SerializeField] TMP_Text _text;
    [SerializeField] TMP_Text _highScoreText;

    private void OnEnable()
    {
        _highScore = PlayerPrefs.GetInt("HighScore");
        _text.SetText(_points.ToString());
        _highScoreText.SetText(_highScore.ToString());
    }

    public static void Add(int points)
    {
        _instance.AddPoints(points);
    }

    private void AddPoints(int points)
    {
        //_points is current points, points is being added
        _points += points;
        _text.SetText(_points.ToString());

        if (_points >= _highScore)
        {
            _highScore = _points;
            _highScoreText.SetText(_highScore.ToString());
            PlayerPrefs.SetInt("HighScore", _highScore);
        }
    }
}