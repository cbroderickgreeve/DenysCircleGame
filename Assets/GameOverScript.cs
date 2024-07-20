using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameOverScript : MonoBehaviour
{
    public void OnGameOverEvent()
    {
        transform.gameObject.SetActive(false);
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
