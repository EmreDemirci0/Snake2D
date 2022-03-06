using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameOver : MonoBehaviour
{
    TextMeshProUGUI gameoverText;
    void Start()
    {
        gameoverText = GetComponent<TextMeshProUGUI>();
        gameoverText.text = null;
    }
    void Update()
    {
        if (SnakeController.isGameOver)
        {
            gameoverText.text = "!!!!!!!";
        }
    }
}
