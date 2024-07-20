using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public void OnEnable()
    {
        EventManager.PlayerDamagedEvent += OnPlayerDamaged;
    }

    public void OnPlayerDamaged(int damage)
    {
        if (transform.childCount == 0) {
            EventManager.GameOver();
        }
        if (transform.childCount == 1)
        {
            Destroy(transform.GetChild(0).gameObject);
            EventManager.GameOver();
        }
        else
        {
            Destroy(transform.GetChild(0).gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
