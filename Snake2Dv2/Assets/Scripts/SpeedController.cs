using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class SpeedController : MonoBehaviour
{
   public static bool isThereSpeed = true;
 


    
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player" && isThereSpeed)
        {   
            Time.fixedDeltaTime = Time.fixedDeltaTime-0.005f;//k���ltt�k�e h�zlanur
            if (Time.fixedDeltaTime<0.01f)
            {
              //Oyun Bitti
            }
            Destroy(gameObject);
            isThereSpeed = false;
        }
        if (collision.tag == "playertail")//Buras� BUG'lu
        {   //burada e�er karakterin �zerine yem gelirse yok olmas�nm� sa�l�yoruz
            Destroy(gameObject);
            isThereSpeed = false;
        }
    }
  
}
