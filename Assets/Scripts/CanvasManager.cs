using UnityEngine;
using TMPro;

public class CanvasManager : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI highScoreText;
    public GameObject RestartPanel;
    public int ScoreInt;
    public int highScore;

    private void Start()
    {
        highScore = PlayerPrefs.GetInt("High");      
    }

    private void Update()
    {
        highScoreText.text = PlayerPrefs.GetInt("High").ToString();
        ScoreText.text = ScoreInt.ToString();
        if (ScoreInt>=highScore)
        {
            highScore = ScoreInt;
            PlayerPrefs.SetInt("High", highScore);     
        }    
    }
    public void Fail()
    {
        RestartPanel.SetActive(true);
    }
}
