using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/*
This class is to implement the life cycle of player. Living -> Death(game over), or Death -> Life(ReStart)
*/
public class PlayerLife : MonoBehaviour
{   
    //Private fields
    private static int death = 0; //how many times player have died. 
                                // It is static field because it implemented until (death < 5)
    private Rigidbody2D rb;
    private Animator anim;
    //These variables can be modified in Unity IDE
    [SerializeField] private Text lifeText;
    [SerializeField] private Text go_text;

    /*
    Start is called before the first frame update
    And it shows the initial remaining life in the text. This needs inside of start() because it needs to be updated 
    everytime player die or restart the game. 
    */
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        lifeText.text = "Lives: " + getLife();
        
    }

    /* Update the game to Game Over scene if the player used up 5 attempts*/
    void Update() {
        if (getLife() == 0) {
            Time.timeScale = 0;
            SceneManager.LoadScene("GameOver");
            Application.Quit();
        }
        
    }
    /*
    This method is recognizing player on trap and increment the number of death
    If player eats cherry 
    */
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            death++;
            Die();
        }
    }
    /*
    This method is implemented when player hit trap (obstacle)
    */
    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static; 
        anim.SetTrigger("death");
    }
    
    /*
    This game is implemented to restart the game with new scene
    */
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /* calculate the attempt the player has left*/
    private int getLife() {
        return (5-death);
    }
}
