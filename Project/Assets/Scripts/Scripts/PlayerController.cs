using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float timer;

    public Transform SpawnPoint;
    public GameObject Prefab;

    private Rigidbody rigid;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame

    private void Update()
    {
        //timer += Time.deltaTime;
        //Debug.Log(timer);

        BombDrop();
    }
    void FixedUpdate()
    {
        float xDirection = Input.GetAxis("Horizontal");
        float zDirection = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(xDirection, 0.0f, zDirection);

        rigid.AddForce(moveDirection * speed);
     
    }

    private void BombDrop()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(Prefab, SpawnPoint.position, SpawnPoint.rotation);
        }
    }
}
