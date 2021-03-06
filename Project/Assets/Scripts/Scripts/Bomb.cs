using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public HeartSystem health;

    public float delay = 3f;
    public float radius = 5f;
    public float force = 700f;

    public MeshRenderer mesh;

    public GameObject explosionEffect;

    public int damage = 1;

    float countdown;
    bool hasExploded = false;

    AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        countdown = delay;
        //health = GameObject.FindGameObjectWithTag("Player").GetComponent<HeartSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if(countdown <= 0f && !hasExploded)
        {
            Expode();
            hasExploded = true;
        }
        //if(health.current <= 0)
        //{
        //    Debug.Log("dead");
        //}
     
    }

    void Expode()
    {
        mesh.enabled = false;
        source.Play();

        Instantiate(explosionEffect, transform.position, transform.rotation);

        Collider[] colliders =  Physics.OverlapSphere(transform.position, radius);

        foreach(Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if(rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }

            Destructable dest = nearbyObject.GetComponent<Destructable>();
            if (dest != null) 
            {
                dest.Destroy();
            }
        }
        Destroy(gameObject, 3);
    }

   
}
