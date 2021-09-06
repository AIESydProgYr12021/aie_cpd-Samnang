using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombButton : MonoBehaviour
{
    public Transform SpawnPoint;
    public GameObject Prefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BombDrop();
    }

    private void BombDrop()
    {
        Instantiate(Prefab, SpawnPoint.position, SpawnPoint.rotation);
    }

}
