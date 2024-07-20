using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameOverText : MonoBehaviour
{
    public void OnGameOverEvent()
    {
        GetComponent<TextMeshProUGUI>().text = $"Game Over";
    }
    

    // Start is called before the first frame update
    void Start()
    {

    }

    public void OnEnable()
    {
        EventManager.GameOverEvent += OnGameOverEvent;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
