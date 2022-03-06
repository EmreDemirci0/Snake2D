using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class SpeedController : MonoBehaviour
{
   public static bool isThereSpeed = true;
    private void Start()
    {
        AppleController.pointsSource = GameObject.FindGameObjectWithTag("MainCamera2").GetComponents<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && isThereSpeed)
        {
            AppleController.pointsSource[1].Play();
            Destroy(gameObject);
            levelmanager.Health += 5;
            isThereSpeed = false;
        }
        if (collision.tag == "playertail")
        {  
            Destroy(gameObject);
            isThereSpeed = false;
        }
    }
  
}
