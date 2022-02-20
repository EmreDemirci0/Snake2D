using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    //up:0 1 |down:0 -1|right:1 0 |left:-1 0
    Vector2 movements;
    
    [SerializeField] Transform EatRotationPrefab;
    [SerializeField] Sprite[] SnakeSprites;
    SpriteRenderer SnakeSpriteRenderer;
   
   
    /*[SerializeField]*/public static List<Transform> EatRotation;
    private void Start()
    {
        movements = new Vector2(1, 0);
        EatRotation = new List<Transform>();
        EatRotation.Add(this.transform);
        SnakeSpriteRenderer = GetComponent<SpriteRenderer>();
       
    }
    void Update()
    {
        #region Movement

        if (EatRotation.Count == 1)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                movements = new Vector2(1, 0);
                SnakeSpriteRenderer.sprite = SnakeSprites[3];

            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                movements = new Vector2(0, -1);
                SnakeSpriteRenderer.sprite = SnakeSprites[2];

            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                movements = new Vector2(0, 1);
                SnakeSpriteRenderer.sprite = SnakeSprites[0];
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                movements = new Vector2(-1, 0);
                SnakeSpriteRenderer.sprite = SnakeSprites[1];

            }
        }
        else
        {
            if (!(movements == new Vector2(-1, 0)))
            {
                if (Input.GetKeyDown(KeyCode.D))
                {
                    movements = new Vector2(1, 0);
                    SnakeSpriteRenderer.sprite = SnakeSprites[3];

                }
            }
            if (!(movements == new Vector2(0, 1)))
            {
                if (Input.GetKeyDown(KeyCode.S))
                {
                    movements = new Vector2(0, -1);
                    SnakeSpriteRenderer.sprite = SnakeSprites[2];

                }
            }
            if (!(movements == new Vector2(0, -1)))
            {
                if (Input.GetKeyDown(KeyCode.W))
                {
                    movements = new Vector2(0, 1);
                    SnakeSpriteRenderer.sprite = SnakeSprites[0];

                }
            }
            if (!(movements == new Vector2(1, 0)))
            {
                if (Input.GetKeyDown(KeyCode.A))
                {
                    movements = new Vector2(-1, 0);
                    SnakeSpriteRenderer.sprite = SnakeSprites[1];

                }
            }
        }


        #endregion
        #region Walls
       
        if (this.transform.position.x > 12f)
            this.transform.position = new Vector2(-12f, this.transform.position.y);
        if (this.transform.position.x < -12f)
            this.transform.position = new Vector2(12f, this.transform.position.y);
        if (this.transform.position.y > 6.6f)
            this.transform.position = new Vector2(this.transform.position.x, -6.6f);
        if (this.transform.position.y < -6.6f)
            this.transform.position = new Vector2(this.transform.position.x, 6.6f);

        #endregion



    }

    void FixedUpdate()
    {
        #region Tail     
        for (int i = EatRotation.Count - 1; i > 0; i--)
        {
            EatRotation[i].position = EatRotation[i - 1].position;
        }
        float xEks = Mathf.Clamp(this.transform.position.x + movements.x, -12.01f, 12.01f);
        float yEks = Mathf.Clamp(this.transform.position.y + movements.y, -6.61f, 6.62f);
        this.transform.position = new Vector2(xEks , yEks);
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
        {
            Expand();
        }   
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "playertail")
        {
            Time.timeScale = 0;//Oyun Bitti
        }
    }

}
