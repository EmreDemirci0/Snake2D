using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class SnakeController : MonoBehaviour
{
    //up:0 1 |down:0 -1|right:1 0 |left:-1 0
    Vector2 movements;

    [SerializeField] Transform EatRotationPrefab;
    [SerializeField] Sprite[] SnakeSprites;
    [SerializeField]public static bool isGameOver = false;
    SpriteRenderer SnakeSpriteRenderer;
    [SerializeField] TextMeshProUGUI GameOverText;


    /*[SerializeField]*/
    [SerializeField] public static List<Transform> EatRotation;
    //  [SerializeField]Sprite bacak;
    //  [SerializeField]SpriteRenderer sp;
    private void Start()
    {
        isGameOver = false;
        movements = new Vector2(1, 0);
        EatRotation = new List<Transform>();
        EatRotation.Add(this.transform);
        SnakeSpriteRenderer = GetComponent<SpriteRenderer>();
        GameOverText = GameObject.FindGameObjectWithTag("gameovertext").GetComponent<TextMeshProUGUI>();

    }
    void Update()
    {//wa  wd  as ad//önce w sonra a'ya basýnca b ug oluyor


        #region Movement

        if (!((Input.GetKeyDown(KeyCode.W) && Input.GetKeyDown(KeyCode.A)) || (Input.GetKeyDown(KeyCode.W) && Input.GetKeyDown(KeyCode.D)) ||
            (Input.GetKeyDown(KeyCode.A) && Input.GetKeyDown(KeyCode.S)) || (Input.GetKeyDown(KeyCode.S) && Input.GetKeyDown(KeyCode.D))))
        {
            if (EatRotation.Count == 1)
            {
                if (!isGameOver)
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
            }
            else
            {
                if (!isGameOver)
                {


                    if (!(movements == new Vector2(-1, 0)))
                    {
                        if (Input.GetKeyDown(KeyCode.D))
                        {
                            movements = new Vector2(1, 0);
                            SnakeSpriteRenderer.sprite = SnakeSprites[3];
                            // EatRotation[EatRotation.Count - 1].transform.rotation = Quaternion.Euler(new Vector3(0, 0, -90));
                        }
                    }
                    if (!(movements == new Vector2(0, 1)))
                    {
                        if (Input.GetKeyDown(KeyCode.S))
                        {
                            movements = new Vector2(0, -1);
                            SnakeSpriteRenderer.sprite = SnakeSprites[2];
                            // EatRotation[EatRotation.Count - 1].transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0 + 180));
                        }
                    }
                    if (!(movements == new Vector2(0, -1)))
                    {
                        if (Input.GetKeyDown(KeyCode.W))
                        {
                            movements = new Vector2(0, 1);
                            SnakeSpriteRenderer.sprite = SnakeSprites[0];
                            //  EatRotation[EatRotation.Count - 1].transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                        }
                    }
                    if (!(movements == new Vector2(1, 0)))
                    {
                        if (Input.GetKeyDown(KeyCode.A))
                        {
                            movements = new Vector2(-1, 0);
                            SnakeSpriteRenderer.sprite = SnakeSprites[1];
                            //  EatRotation[EatRotation.Count - 1].transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
                        }
                    }
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
        float xEks = Mathf.Clamp(this.transform.position.x + movements.x, -13f, 13f);
        float yEks = Mathf.Clamp(this.transform.position.y + movements.y, -7.5f, 7.5f);
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
        {
            Expand();
        }
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
