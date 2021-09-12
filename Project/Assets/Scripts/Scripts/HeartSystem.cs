using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartSystem : MonoBehaviour
{
    //public GameObject[] hearts;
    private bool dead;

    public int max = 3;
    public int current = 0;

    

    private void Start()
    {
        current = max;
    }

    void Update()
    {
        if(dead == true)
        {
            Debug.Log("dead");
        }
    }

    public void TakeDamage(int td)
    {
        if (current >= 1)
        {
            current -= td;
            //Destroy(hearts[life].gameObject);
            if (current <= 0)
            {
                dead = true;
            }
        }
        
    }
}
