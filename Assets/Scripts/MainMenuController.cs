using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class MainMenuController : MonoBehaviour
{
    [SerializeField] GameObject startButton,exitButton,HowToPlayButton,HowToPlayScenes,
        soundEffectsButton,MusicButton,turkishButton,EnglishButton;
    Image muteAudio, openAudio;
    
    private void Start()
    {
        Time.timeScale = 1;
        levelmanager.count = 0;
        
        startButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);
        HowToPlayButton.gameObject.SetActive(true);
        HowToPlayScenes.gameObject.SetActive(false);
        soundEffectsButton.gameObject.SetActive(true);
        MusicButton.gameObject.SetActive(true);
        turkishButton.gameObject.SetActive(true);
        EnglishButton.gameObject.SetActive(true);
    }
    
    public void backButton()
    {
        startButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);
        HowToPlayButton.gameObject.SetActive(true);
        HowToPlayScenes.gameObject.SetActive(false);
        soundEffectsButton.gameObject.SetActive(true);
        MusicButton.gameObject.SetActive(true);
        turkishButton.gameObject.SetActive(true);
        EnglishButton.gameObject.SetActive(true);
    }
    public void startGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void howToPlay()
    {     
        startButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);
        HowToPlayButton.gameObject.SetActive(false);
        HowToPlayScenes.gameObject.SetActive(true);
        soundEffectsButton.gameObject.SetActive(false);
        MusicButton.gameObject.SetActive(false);
        turkishButton.gameObject.SetActive(false);
        EnglishButton.gameObject.SetActive(false);
    }
    public void quitGame()
    {
        Application.Quit();
    }
}
