using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{
    public GameObject duck;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    private void OnEnable()
    {
        duck.SetActive(true);
    }

    private void OnDisable()
    {
        duck.SetActive(false);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            enabled = true;
            
            RubberDuck rubberduck = collision.GetComponent<RubberDuck>();
            rubberduck.Respawn();
        }
        

    }
}
