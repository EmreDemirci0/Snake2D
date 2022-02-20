using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class AppleController : MonoBehaviour
{
   TextMeshProUGUI ApplePointsText;
    public static TextMeshProUGUI GameOverText;

    

    public static bool isThereApple;

    private void Start()
    {
        isThereApple = true;
        ApplePointsText = GameObject.FindGameObjectWithTag("scoretext").GetComponent<TextMeshProUGUI>();
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && isThereApple)
        {
            levelmanager.applePoints++;
            ApplePointsText.text = levelmanager.applePoints.ToString();
            Destroy(gameObject);
            isThereApple = false;
        }
        if (collision.tag=="playertail")//Burasý BUG'lu
        {
            Destroy(gameObject);
            isThereApple = false;
        }
    }
   

}
