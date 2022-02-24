using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class AppleController : MonoBehaviour
{
    TextMeshProUGUI ApplePointsText;
    public static TextMeshProUGUI GameOverText;
    [SerializeField]public static AudioSource[] pointsSource;

   
    public static bool isThereApple;

    private void Start()
    {
        Time.fixedDeltaTime = 0.15f;
        isThereApple = true;
        ApplePointsText = GameObject.FindGameObjectWithTag("scoretext").GetComponent<TextMeshProUGUI>();
        pointsSource = GameObject.FindGameObjectWithTag("MainCamera").GetComponents<AudioSource>();
       

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

           //if (SnakeController.EatRotation.Count!=1)
           //{
           //     sp = SnakeController.EatRotation[SnakeController.EatRotation.Count-1].GetComponent<SpriteRenderer>();
           //     sp.sprite = bacak;

           //     sp2 = SnakeController.EatRotation[SnakeController.EatRotation.Count - 2].GetComponent<SpriteRenderer>();
           //    sp2.transform.rotation=(Quaternion.Euler(new Vector3(0,0,0)));
           //     sp2.sprite = govde;
           //   //  EatRotation[EatRotation.Count - 1].transform.rotation = Quaternion.Euler(new Vector3(0, 0, -90));
           // }


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
