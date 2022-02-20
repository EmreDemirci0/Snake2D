using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PoisonController : MonoBehaviour
{
   
    public static bool isTherePoison;
    
    Image HP1, HP2, HP3;
  

    private void Start()
    {   
        isTherePoison = true;
        HP1 = GameObject.FindGameObjectWithTag("HP1").GetComponent<Image>();
        HP2 = GameObject.FindGameObjectWithTag("HP2").GetComponent<Image>();
        HP3 = GameObject.FindGameObjectWithTag("HP3").GetComponent<Image>();
      
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player" && isTherePoison)
        {

            int random = Random.Range(0, 2);//0:yavaþla  1:küçül
            if (random == 0 || /**/random == 1/**/)
            {   /**Yavaþla*/
                Time.fixedDeltaTime = Time.fixedDeltaTime + 0.005f;
            }
            else /*if(random==1)*/
            {  //küçülmede sýkýntý çýktý :/
               //if (SnakeController.EatRotation.Count==1)
               //{

                //}
                //else
                //{
                //    SnakeController.EatRotation.RemoveAt(SnakeController.EatRotation.Count-1);

                //}
            }
            levelmanager.count++;
           
            if (levelmanager.count == 1)
            {
                HP3.color = Color.black;
                HP2.color = Color.white;
                HP1.color = Color.white;

            }
            if (levelmanager.count == 2)
            {
                HP3.color = Color.black;
                HP2.color = Color.black;
                HP1.color = Color.white;


            }
            if (levelmanager.count==3)
            {
                HP3.color = Color.black;
                HP2.color = Color.black;
                HP1.color = Color.black;
                //Oyun Bitti
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
