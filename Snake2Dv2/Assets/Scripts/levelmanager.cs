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
    public static int Health=100;
    [SerializeField] public static TextMeshProUGUI GameOverText;
    float timer;
    private void Start()
    {
        Health = 100;
        timer = 0;
        HealthSlider.minValue = 0;
        HealthSlider.maxValue = 100;
        GameOverText = GameObject.FindGameObjectWithTag("gameovertext").GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
      // 
        HealthSlider.value = Health;
        timer -= Time.deltaTime;
        if (timer<-1)
        {
            Health--;
         //   print("health" + Health);
            timer = 0;
        }
        if (Health<=0)
        {
            GameOverText.text = "Oyun Bitti...";
          
        }
        if (GameOverText.text == "Oyun Bitti...")
        {
            Time.timeScale = 0;
            StartCoroutine(waitForNewScene(2.45f));
             SnakeController.isGameOver = true;
        }
    }
    IEnumerator waitForNewScene(float sec)
    {

        yield return new WaitForSecondsRealtime(sec);

        SceneManager.LoadScene("MainMenu");
    }

}
