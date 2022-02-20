using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
This class implemented when Players collect the cherry.
The purpose of this class is to print out and counting the number of cherry that player got on the screen (to users)
*/
public class ItemCollector : MonoBehaviour
{
    //private field for cherry number
    private int cherries = 0;

    //text field for user to modify in Unity IDE
    [SerializeField] private Text cherriesText;

    //function to be called when player collide on the Cherry Object.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if Cherry tag recognized by the player, it destroy the Cherry from screen and increment the number of cherry and print to screen
        if (collision.gameObject.CompareTag("Cherry"))
        {
            Destroy(collision.gameObject);
            cherries++;
            cherriesText.text = "Cherries: " + cherries;
        }
    }

    
}
