using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            transform.rotation = Quaternion.Euler(-90f, -90f, 0f);
            Move(Vector3.left);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            transform.rotation = Quaternion.Euler(-90f, -90f, 180f);
            Move(Vector3.right);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(-90f, -90f, 90f);
            Move(Vector3.forward);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(-90f, -90f, -90f);
            Move(Vector3.back);
        }
    }


    private void Move(Vector3 direction)
    {
        transform.position += direction*4;
    }


}
