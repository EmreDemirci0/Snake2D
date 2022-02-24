using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class MainMenuController : MonoBehaviour
{
    [SerializeField] GameObject startButton,exitButton,HowToPlayButton,HowToPlayScenes;
  

    
    private void Start()
    {
        //SnakeController.isGameOver = false;
        Time.timeScale = 1;
        levelmanager.count = 0;
        //startButton = GameObject.FindWithTag("startbutton").GetComponent<GameObject>();
        //exitButton = GameObject.FindWithTag("exitbutton").GetComponent<GameObject>();
        //HowToPlayButton = GameObject.FindWithTag("howtoplaybutton").GetComponent<GameObject>();
        //HowToPlayScenes = GameObject.FindWithTag("howtoplay").GetComponent<GameObject>();

        startButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);
        HowToPlayButton.gameObject.SetActive(true);
        HowToPlayScenes.gameObject.SetActive(false);

    }
    public void backButton()
    {
        startButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);
        HowToPlayButton.gameObject.SetActive(true);
        HowToPlayScenes.gameObject.SetActive(false);

    }
    public void startGame()
    {
        //levelmanager.GameOverText.text = "";
        //SnakeController.isGameOver = false;

        SceneManager.LoadScene("SampleScene");
        
    }
    public void howToPlay()
    {     
        startButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);
        HowToPlayButton.gameObject.SetActive(false);
        HowToPlayScenes.gameObject.SetActive(true);
    }
    public void quitGame()
    {
        Application.Quit();
    }
}
