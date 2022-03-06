using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobilEntegration : MonoBehaviour
{
    public static Vector2 movements;
    SpriteRenderer SnakeSpriteRenderer;
    [SerializeField] Sprite[] SnakeSprites;

    private void Start()
    {
        movements = new Vector2(1, 0);
        SnakeSpriteRenderer = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();
    }
    public void UpButton()
    {
        if (SnakeController.EatRotation.Count == 1)
        {
            if (!(SnakeController.isGameOver))
            {
                movements = new Vector2(0, 1);
                SnakeSpriteRenderer.sprite = SnakeSprites[0];
            }
        }
        else
        {
            if (!(movements == new Vector2(0, -1)))
            {
                movements = new Vector2(0, 1);
                SnakeSpriteRenderer.sprite = SnakeSprites[0];
            }
        }
    }
    public void DownButton()
    {
        if (SnakeController.EatRotation.Count == 1)
        {
            if (!(SnakeController.isGameOver))
            {
                movements = new Vector2(0, -1);
                SnakeSpriteRenderer.sprite = SnakeSprites[2];
            }
        }
        else
        {
            if (!(movements == new Vector2(0, 1)))
            {
                movements = new Vector2(0, -1);
                SnakeSpriteRenderer.sprite = SnakeSprites[2];
            }
        }
    }
    public void LeftButton()
    {
        if (SnakeController.EatRotation.Count == 1)
        {
            if (!(SnakeController.isGameOver))
            {
                movements = new Vector2(-1, 0);
                SnakeSpriteRenderer.sprite = SnakeSprites[1];
            }
        }
        else
        {
            if (!(movements == new Vector2(1, 0)))
            {
                movements = new Vector2(-1, 0);
                SnakeSpriteRenderer.sprite = SnakeSprites[1];
            }
        }
    }
    public void RightButton()
    {
        if (SnakeController.EatRotation.Count == 1)
        {
            if (!(SnakeController.isGameOver))
            {
                movements = new Vector2(1, 0);
                SnakeSpriteRenderer.sprite = SnakeSprites[3];
            }
        }
        else
        {
            if (!(movements == new Vector2(-1, 0)))
            {
                    movements = new Vector2(1, 0);
                    SnakeSpriteRenderer.sprite = SnakeSprites[3];
            }
        }
    }
   




}

