using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Say : MonoBehaviour
{
	
	public string defaultText = "Default Text";
	TextMeshProUGUI currentText;
    TextMeshProUGUI GameOverText;
    void Start()
    {
        currentText = GetComponent<TextMeshProUGUI>();
        GameOverText = GetComponent<TextMeshProUGUI>();
    }
    void Update() 
    {
        currentText.text = GameLanguage.gl.Say(defaultText);
        if (SnakeController.isGameOver)
        {
            GameOverText.text = GameLanguage.gl.Say(defaultText);
        }
    }
	
}
