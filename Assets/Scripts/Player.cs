using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] int speed;

    [SerializeField] Grid_Terrain grid;

    [SerializeField] SpriteRenderer spriteRenderer;

    Vector2Int tilepos=Vector2Int.zero;

    [EnumIndex(typeof(Direction))] [SerializeField] Sprite[] sprites;

    enum Direction {
        right,
        left,
        up,
        down
    }

    Vector2Int GetDirection(Direction direction)
    {
        switch (direction)
        {
            case Direction.right:
                return Vector2Int.right;
            case Direction.left:
                return Vector2Int.left;
            case Direction.up:
                return Vector2Int.up;
            case Direction.down:
                return Vector2Int.down;
            default:
                return Vector2Int.zero;
        }
    }


    bool hitCheck()
    {
        return false;

    }


    bool canMove = true;
    IEnumerator Move(Direction direction)
    {
        spriteRenderer.sprite = sprites[(int)direction];

        if (grid.isWall(tilepos + GetDirection(direction))){
            yield break;
        }

        canMove = false;



        Vector2 start =this.transform.position;
        Vector2 end = start+ GetDirection(direction) * 32;

        float MoveTime = 100f / speed;
        print(MoveTime);

        float timer = 0;

        while (MoveTime > timer)
        {
            timer += Time.deltaTime;

            timer = Mathf.Clamp(timer, 0, MoveTime);
            float progress = timer / MoveTime;

            this.transform.position = Vector2.Lerp(start, end, progress);

            yield return null;

        }
        this.transform.position=end;
        tilepos += GetDirection(direction);
        canMove = true;
    }



    // Update is called once per frame
    public void Updater()
    {
        if (GameManager.Game_Manager.Input.InputArrow() == Vector2.right)
        {
            if (canMove)
            {
                StartCoroutine(Move(Direction.right));
            }
        }
        else if (GameManager.Game_Manager.Input.InputArrow() == Vector2.left)
        {
            if (canMove)
            {
                StartCoroutine(Move(Direction.left));
            }
        }
        else if (GameManager.Game_Manager.Input.InputArrow() == Vector2.up)
        {
            if (canMove)
            {
                StartCoroutine(Move(Direction.up));
            }
        }
        else if (GameManager.Game_Manager.Input.InputArrow() == Vector2.down)
        {
            if (canMove)
            {
                StartCoroutine(Move(Direction.down));
            }
        }
        else
        {
        }

    }
}
