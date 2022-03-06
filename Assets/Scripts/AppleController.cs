using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class AppleController : MonoBehaviour
{
    TextMeshProUGUI ApplePointsText;
    public static TextMeshProUGUI GameOverText;
    [SerializeField] public static AudioSource[] pointsSource;
    public static bool isThereApple;

    private void Start()
    {
        Time.fixedDeltaTime = 0.15f;
        isThereApple = true;
        ApplePointsText = GameObject.FindGameObjectWithTag("scoretext").GetComponent<TextMeshProUGUI>();
        pointsSource = GameObject.FindGameObjectWithTag("MainCamera2").GetComponents<AudioSource>();
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && isThereApple)
        {
            pointsSource[0].Play();
            levelmanager.applePoints++;
            Time.fixedDeltaTime -= 0.004f;
            levelmanager.Health+=2;
            ApplePointsText.text = levelmanager.applePoints.ToString();
            Destroy(gameObject);
            isThereApple = false;
        }
        if (collision.tag=="playertail")
        {
            Destroy(gameObject);
            isThereApple = false;
        }
    }
}
