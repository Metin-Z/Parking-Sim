using UnityEngine;
using UnityEngine.UI;

public class LevelBar : MonoBehaviour
{
    public float progress;
    public Image progressBar;
    public float maxAmount;
    void Start()
    {
        progressBar =GetComponent<Image>();
        maxAmount = 6;
    }
    public void Fill()
    {
        if (progressBar.fillAmount < 1)
        {
            progress+=1;
            progressBar.fillAmount = progress/maxAmount;
        }
    }
}
