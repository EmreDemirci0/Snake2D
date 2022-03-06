using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class levelmanager : MonoBehaviour
{
    public static int count = 0;
    public static int applePoints = 0;//score
    [SerializeField] UnityEngine.UI.Slider HealthSlider;
    [SerializeField] public static int Health;//Can Kýsmý
    [SerializeField] public static TextMeshProUGUI GameOverText;
    float timer;
    AudioSource musicAudio;
    [SerializeField] public static AudioSource[] Eating;
    private void Start()
    {
        Eating = GameObject.FindGameObjectWithTag("MainCamera2").GetComponents<AudioSource>();
        musicAudio = this.GetComponent<AudioSource>();
        Health = 100;//Can Kýsmý
        timer = 0;
        HealthSlider.minValue = 0;
        HealthSlider.maxValue = 100;
        GameOverText = GameObject.FindGameObjectWithTag("gameovertext").GetComponent<TextMeshProUGUI>();
        GameOverText.gameObject.SetActive(false);
        if (musicMute.isMutedMusic == false)
            musicAudio.Stop();
        else
            musicAudio.Play();

        if (SoundEffectsMute.isMutedAudioEffect == true)
        {//müzik çalýyoriken
            for (int i = 0; i < 3; i++)
            {
                Eating[i].volume = 0;
            }
        }
        else if (SoundEffectsMute.isMutedAudioEffect == false)
        {   //müzik çalmýyoriken
            for (int i = 0; i < 3; i++)
            {
                Eating[i].volume = .1f;
            }
        }
        if (SoundEffectsMute.SoundOnIsOpen == false)
        {
            for (int i = 0; i < 3; i++)
            {
                Eating[i].volume = 0f;
            }
        }
        else
        {
            for (int i = 0; i < 3; i++)
            {
                Eating[i].volume = 0.1f;
            }
        }

    }
    private void Update()
    {

        HealthSlider.value = Health;
        timer -= Time.deltaTime;
        if (timer < -1)
        {
            Health--;
            timer = 0;
        }
        if (Health <= 0)
        {
            GameOverText.text = "Oyun Bitti...";
        }
        if (GameOverText.text == "Oyun Bitti...")
        {
            Time.timeScale = 0;
            StartCoroutine(waitForNewScene(0.701f));
            SnakeController.isGameOver = true;
        }
    }
    IEnumerator waitForNewScene(float sec)
    {
        yield return new WaitForSecondsRealtime(sec);
        SceneManager.LoadScene("MainMenu");
    }

}
