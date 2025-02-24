using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{
    public GameObject duck;
    public Text winText;
    public Text savedDucks;
    public int numSaved = 0;

    // Start is called before the first frame update
    void Start()
    {
        //winText.text = " ";
        //savedDucks.text = "Ducks Saved: " + numSaved.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (numSaved == 3)
        {
            winText.text = "You Win!";
        }
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
            //numSaved++;
            //savedDucks.text = "Ducks Saved: " + numSaved.ToString();

            RubberDuck rubberduck = collision.GetComponent<RubberDuck>();
            rubberduck.Respawn();           
            
        }
        

    }
}
