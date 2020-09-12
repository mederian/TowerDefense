using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveDisplay : MonoBehaviour
{
    private int waveCount;
    private string waveText;
    private WaitForSeconds ws = new WaitForSeconds(0.1f);
    //[SerializeField] private TextMeshProUGUI UIText;
    [SerializeField] private GameObject waveDisplay;

    private void Start()
    {
        waveCount = 0;
        waveText = "Wave " + waveCount.ToString();
    }


    public void ShowWave()
    {
        IncrementWave();
        waveDisplay.GetComponent<CanvasGroup>().alpha = 1;
        waveDisplay.GetComponent<TextMeshProUGUI>().text = waveText;
    }
    public void IncrementWave()
    {
        waveCount++;
        waveText = "Wave " + waveCount.ToString();
    }
    public void InitNewWave()
    {
        ShowWave();
        StartCoroutine(Fade());
    }

    IEnumerator Fade()
    {
        while(waveDisplay.GetComponent<CanvasGroup>().alpha > 0)
        {
            waveDisplay.GetComponent<CanvasGroup>().alpha -= 0.03f;
            yield return ws;
        }
        Debug.Log("Corout fade wavedisplay ended");
    }
}
