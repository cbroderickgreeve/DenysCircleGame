using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int currentScore = 0;

    public void OnEnable()
    {
        EventManager.IncreaseScoreEvent += OnScoreIncrease;
    }
    public void Start()
    {
        Application.targetFrameRate = 60;
    }
    public void OnScoreIncrease(int scoreIncrease)
    {
        currentScore = currentScore + scoreIncrease;
        GetComponent<TextMeshProUGUI>().text = $"{currentScore}";
    }
}
