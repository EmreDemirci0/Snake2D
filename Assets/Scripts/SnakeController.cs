using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class SnakeController : MonoBehaviour
{
    [SerializeField] Transform EatRotationPrefab;
    [SerializeField] public static bool isGameOver = false;
    [SerializeField] TextMeshProUGUI GameOverText;
    [SerializeField] public static List<Transform> EatRotation;
    private void Start()
    {
        isGameOver = false;
    
        EatRotation = new List<Transform>();
        EatRotation.Add(this.transform);
        GameOverText = GameObject.FindGameObjectWithTag("gameovertext").GetComponent<TextMeshProUGUI>();

    }
    void Update()
    {
        #region Walls
        if (this.transform.position.x > 10f)
            this.transform.position = new Vector2(-10f, this.transform.position.y);
        if (this.transform.position.x < -10f)
            this.transform.position = new Vector2(10f, this.transform.position.y);
        if (this.transform.position.y > 5.6f)
            this.transform.position = new Vector2(this.transform.position.x, -5.6f);
        if (this.transform.position.y < -5.6f)
            this.transform.position = new Vector2(this.transform.position.x, 5.6f);
        #endregion
    }

    void FixedUpdate()
    {
        #region Tail     
        for (int i = EatRotation.Count - 1; i > 0; i--)
        {
            EatRotation[i].position = EatRotation[i - 1].position;
        }
        float xEks = Mathf.Clamp(this.transform.position.x + MobilEntegration.movements.x, -12f, 12f);
        float yEks = Mathf.Clamp(this.transform.position.y + MobilEntegration.movements.y, -7, 7f);
        this.transform.position = new Vector2(xEks, yEks);
        #endregion
    }
    void Expand()
    {
        Transform temp = Instantiate(this.EatRotationPrefab);
        temp.position = EatRotation[EatRotation.Count - 1].position;
        EatRotation.Add(temp);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "apple")
            Expand();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "playertail")
        {   
            GameOverText.text = "Oyun Bitti...";
            Time.timeScale = 0;//Oyun Bitti
        }
    }

}
