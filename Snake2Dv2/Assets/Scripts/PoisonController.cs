using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PoisonController : MonoBehaviour
{

    public static bool isTherePoison;

    
    [SerializeField] TextMeshProUGUI GameOverText;
    


    private void Start()
    {
        isTherePoison = true;
        GameOverText = GameObject.FindGameObjectWithTag("gameovertext").GetComponent<TextMeshProUGUI>();
        
        AppleController.pointsSource = GameObject.FindGameObjectWithTag("MainCamera").GetComponents<AudioSource>();

    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        AppleController.pointsSource[2].Play();
        if (other.tag == "Player" && isTherePoison)
        {
            levelmanager.Health -= 10;
            if (levelmanager.applePoints>1)
            {
                levelmanager.applePoints -= 2;

            }
            int random = Random.Range(0, 1);//0:küçül  //1:yavaþla
            if (!(SnakeController.EatRotation.Count == 1))
            {
                if (random == 0)
                {  //küçül
                    if (SnakeController.EatRotation.Count != 1)
                    {
                        SnakeController.EatRotation[SnakeController.EatRotation.Count - 1].gameObject.SetActive(false);
                        SnakeController.EatRotation[SnakeController.EatRotation.Count - 1].tag = "Untagged";
                        SnakeController.EatRotation.RemoveAt(SnakeController.EatRotation.Count - 1);
                        //if (gameObject.tag=="playertail" && gameObject.tag="playertail".)
                        //{

                        //}
                    }
                }
                //else
                //{//yavaþla
                //    Time.fixedDeltaTime = Time.fixedDeltaTime + 0.005f;
                //}
            }

            levelmanager.count++;
          
           
            if (levelmanager.count == /*3*/10)
            {
                //Oyun Bitti
                GameOverText.text = "Oyun Bitti...";
                Time.timeScale = 0;
            }
            Destroy(gameObject);
            isTherePoison = false;
        }
        if (other.tag == "playertail")//Burasý BUG'lu
        {
            Destroy(gameObject);
            isTherePoison = false;
        }
    }



}
