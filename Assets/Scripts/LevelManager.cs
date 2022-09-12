using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class LevelManager : MonoBehaviour
{
    CarSpawnList _carspawn;
    public GameObject NextLevelButton;
    public TextMeshProUGUI LevelText;
    public TextMeshProUGUI NextLevelText;
    void Start()
    {
        _carspawn = FindObjectOfType<CarSpawnList>();
    }
    void Update()
    {
        if (_carspawn.ParkPos.Count ==0)
        {
            NextLevelButton.SetActive(true);
        }
        LevelText.text = (PlayerPrefs.GetInt(CommonTypes.LEVEL_FAKE_DATA_KEY) + 1).ToString();
        NextLevelText.text = (PlayerPrefs.GetInt(CommonTypes.LEVEL_FAKE_DATA_KEY) + 2).ToString();
    }
    public void Next()
    {
        PlayerPrefs.SetInt(CommonTypes.LEVEL_FAKE_DATA_KEY, PlayerPrefs.GetInt(CommonTypes.LEVEL_FAKE_DATA_KEY) + 1);
        SceneManager.LoadScene(0);
    }
}
