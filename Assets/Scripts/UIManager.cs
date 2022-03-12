using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text textScore;
    public GameObject panelGameOver;

    public void SetTextScore(string textscore)
    {
        textScore.text = textscore;
    }

    public void showPanelGameOver(bool panel)
    {
        panelGameOver.SetActive(panel);
    }

}
