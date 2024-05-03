using System.Collections;
using System.Collections.Generic;
using System;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    private int scoreCounter;
    public Text scoreText;
    public GameObject lvl2, lvl3, WinPanel, LosePanel;
    public camera myCamera;
    public AudioClip picksound;
    private Rigidbody rb;
    public float jumpspeed=50;
    public float movementspeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3();
        movement.x = moveHorizontal;
        movement.z = moveVertical;
        rb.AddForce(movement * movementspeed * Time.deltaTime);
        System.DateTime dt = System.DateTime.Now;
        
        if (dt.Hour > 7)
        {
   
        }
        if (Input.GetKey(KeyCode.Space)&& rb.velocity.y==0)
        {
            Debug.Log("Jump");
            rb.AddForce(0, jumpspeed, 0);
        }

        if (this.transform.position.y < -80)
        {
            
            LosePanel.transform.GetChild(0).GetComponent<Text>().text = "YOULOSE...";
            LosePanel.SetActive(true);
            gameObject.SetActive(false);
        }



    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "pickup")
        {
            other.gameObject.SetActive(false);
            scoreCounter++;
            scoreText.text = "Score:" + scoreCounter;
            AudioSource s = myCamera.GetComponent<AudioSource>();
            s.PlayOneShot(picksound);

            if (scoreCounter == 6)
            {
                lvl2.gameObject.SetActive(true);
            }
            if (scoreCounter == 12)
            {
                lvl3.gameObject.SetActive(true);
            }
           
           if(scoreCounter == 18)
            {
                WinPanel.transform.GetChild(0).GetComponent<Text>().text = "YOUWIN!";
                WinPanel.SetActive(true);
                gameObject.SetActive(false);
            }

        }
    }
}
