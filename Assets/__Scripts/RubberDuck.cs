using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class RubberDuck : MonoBehaviour
{
    
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
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
    }

    private void Move(Vector3 direction)
    {
        transform.position += direction*4;
    }

    private void OnTriggerEnter(Collider other)
    {
        // seperate barrier tags because i couldnt get one if statement to work for all of them
        if (other.gameObject.CompareTag("LeftBarrier"))
        {
            Move(Vector3.right);
        }
        else if (other.gameObject.CompareTag("RightBarrier"))
        {
            Move(Vector3.left);
        }
        else if (other.gameObject.CompareTag("BottomBarrier"))
        {
            Move(Vector3.forward);
        }
    }

}
