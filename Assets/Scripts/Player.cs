using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Animation thisAnimation;
    public Rigidbody rb;

    public float score;
    public Text txtscore;

    void Start()
    {
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 pos = transform.position;
        pos.y = Mathf.Clamp(pos.y, -5.25f, 3.38f);
        transform.position = pos;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
            thisAnimation.Play();
        }

        if (this.transform.position.y <= -4.64)
        {
            SceneManager.LoadScene("GameOver");
        }

    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ScoreWall")
        {
            score++;
            txtscore.text = "SCORE: " + score;
        }
    }
}
