using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class RubberDuck : MonoBehaviour
{
    public Vector3 startPosition;
    public Quaternion startRotation;
    public Boolean falling = false;
    public Text lives;
    public int numLives = 5;
    public Text loseText;


    // Start is called before the first frame update
    void Start()
    {
        loseText.text = " ";

        numLives = 5;
        lives.text = "Lives: " + numLives.ToString();
        startPosition = transform.position;
        startRotation = transform.rotation;
        Respawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.rotation = Quaternion.Euler(-90f, 0f, 0f);
            Move(Vector3.forward);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            transform.rotation = Quaternion.Euler(-90f, 0f, 180f);
            Move(Vector3.back);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(-90f, 0f, 90f);
            Move(Vector3.right);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(-90f, 0f, -90f);
            Move(Vector3.left);
        }

        if (falling == true)
        {
            Death();
        }

        if (numLives == 0)
        {
            loseText.text = "You Lose!";
            enabled = false;
        }

    }

    private void Move(Vector3 direction)
    {
        transform.position += direction*4;
    }

    private void Death()
    {
        transform.position = startPosition;
        transform.rotation = startRotation;
        falling = false;
        enabled = false;

        Invoke(nameof(Respawn), 1f);

        numLives--;
        lives.text = "Lives: " + numLives.ToString();
    }

    public void Respawn()
    {
        transform.position = startPosition;
        transform.rotation = startRotation;
        enabled = true;
    }

    private void OnTriggerEnter(Collider collision)
    {

        // seperate barrier tags because i couldnt get one if statement to work for the different sides
        if (collision.gameObject.CompareTag("LeftBarrier"))
        {
            Move(Vector3.right);
        }
        else if (collision.gameObject.CompareTag("RightBarrier"))
        {
            Move(Vector3.left);
        }
        else if (collision.gameObject.CompareTag("BottomBarrier"))
        {
            Move(Vector3.forward);
        }
        
    }

    // the docks and all logs have a safe zone tag, this checks if its touching a log or dock
    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "SafeZone")
        {
            falling = false;
        }
    }

    // checks if it's no longer interacting with a dock or log, aka falling in the water
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "SafeZone")
        {
            falling = true;
        }
    }

}
