using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public Transform min;
    public Transform max;

    AudioSource audio;
    public float inc;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    void move()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x + inc, min.position.x, max.position.x), transform.position.y, transform.position.z);
        }
       else if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x - inc, min.position.x, max.position.x), transform.position.y, transform.position.z);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            //Restart
           Invoke("Restart", 1f);
            //play audio
            PlayAudio();
        }
    }
    void Restart()
    {
        SceneManager.LoadScene(0);
    }
    void PlayAudio()
    {
        audio.Play();
    }
}
