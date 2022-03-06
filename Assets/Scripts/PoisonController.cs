using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PoisonController : MonoBehaviour
{
    public static bool isTherePoison;

    private void Start()
    {
        isTherePoison = true;
        AppleController.pointsSource = GameObject.FindGameObjectWithTag("MainCamera2").GetComponents<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        AppleController.pointsSource[2].Play();
        if (other.tag == "Player" && isTherePoison)
        {
            levelmanager.Health -= 10;
            if (levelmanager.applePoints > 1)
            {
                levelmanager.applePoints -= 2;

            }
            if (!(SnakeController.EatRotation.Count == 1))
            {
                if (SnakeController.EatRotation.Count != 1)
                {
                    SnakeController.EatRotation[SnakeController.EatRotation.Count - 1].gameObject.SetActive(false);
                    SnakeController.EatRotation[SnakeController.EatRotation.Count - 1].tag = "Untagged";
                    SnakeController.EatRotation.RemoveAt(SnakeController.EatRotation.Count - 1);
                }
            }
            levelmanager.count++;

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
