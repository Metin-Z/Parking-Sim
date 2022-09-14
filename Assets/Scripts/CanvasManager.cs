using UnityEngine;
using TMPro;

public class CanvasManager : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI highScoreText;
    public int ScoreInt;
    public int highScore;

    private void Start()
    {
        highScoreText.text = PlayerPrefs.GetInt("High").ToString();
    }

    private void Update()
    {
        ScoreText.text = ScoreInt.ToString();
        if (ScoreInt>=highScore)
        {
            highScore = ScoreInt;
            PlayerPrefs.SetInt("High", highScore);     
        }
        
    }
}
