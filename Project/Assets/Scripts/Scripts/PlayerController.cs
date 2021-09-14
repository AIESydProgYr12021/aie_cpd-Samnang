using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;

    public GameObject prefab;

    float lerpTime = 0f;

    Vector3 currentPos;
    Vector3 targetPos;

    bool canMove = true;


    private void Start()
    {
        currentPos = transform.position;
        targetPos = currentPos;
    }

    void Update()
    {
        if (!canMove)
            lerpTime += Time.deltaTime * speed;

        transform.position = Vector3.Lerp(currentPos, targetPos, lerpTime);

        if(lerpTime >= 1.0f)
        {
            lerpTime = 0f;
            currentPos = transform.position;
            canMove = true;
        }

        if (canMove)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                MoveForwards();
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                MoveBackwards();
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                MoveRight();
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                MoveLeft();
            }
        }
        
        BombDrop();
    }

    public void MoveForwards()
    {
        if(!Physics.Raycast(transform.position, Vector3.forward, 1.0f, 1 << 3))
        {
            targetPos.z += 1;
            canMove = false;
        }
       
    }

    public void MoveBackwards()
    {
        if (!Physics.Raycast(transform.position, -Vector3.forward, 1.0f, 1 << 3))
        {
            targetPos.z -= 1;
            canMove = false;
        }
    }

    public void MoveRight()
    {
        if (!Physics.Raycast(transform.position, Vector3.right, 1.0f, 1 << 3))
        {
            targetPos.x += 1;
            canMove = false;
        }
    }

    public void MoveLeft()
    {
        if (!Physics.Raycast(transform.position, -Vector3.right, 1.0f, 1 << 3))
        {
            targetPos.x -= 1;
            canMove = false;
        }
    }

    private void BombDrop()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(prefab, transform.position, Quaternion.identity);
        }
    }

}
