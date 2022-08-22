using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour

{
    Rigidbody rb;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(0f, 0f, speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);

        collision.gameObject.GetComponent<AudioSource>().Play();

    }

}
