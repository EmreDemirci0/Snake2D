using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObject : MonoBehaviour
{
    [SerializeField] GameObject Apple;
    [SerializeField] GameObject Speed;
    [SerializeField] GameObject Poison;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float xPos = Random.Range(-12f, 12f);
        float yPos = Random.Range(-6.6f, 6.6f);
        if (SpeedController.isThereSpeed == false)
        {
            Instantiate(Speed, new Vector2(xPos, yPos), Quaternion.identity);
            SpeedController.isThereSpeed = true;
        }
        if (AppleController.isThereApple == false)
        {
            int random=Random.Range(0,2);
            Instantiate(Apple, new Vector2(xPos, yPos), Quaternion.identity);
            
            AppleController.isThereApple = true;

        }
        if (PoisonController.isTherePoison == false)
        {

            Instantiate(Poison, new Vector2(xPos, yPos), Quaternion.identity);
            PoisonController.isTherePoison = true;

        }
    }
}
