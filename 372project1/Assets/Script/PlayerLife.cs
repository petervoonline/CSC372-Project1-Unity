using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{   
    private static int death = 0;
    private Rigidbody2D rb;
    private Animator anim;

    [SerializeField] private Text lifeText;
    [SerializeField] private Text go_text;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        lifeText.text = "Lives: " + getLife();
        
    }

    // Update the game to Game Over scene if the player used up 5 attempts
    void Update() {
        if (getLife() == 0) {
            Time.timeScale = 0;
            SceneManager.LoadScene("GameOver");
            Application.Quit();
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Trap"))
        {
            death++;
            Die();

        } else if (collision.gameObject.CompareTag("Cherry"))
        {
            addLife();
            lifeText.text = "Lives: " + getLife();
        }
    }
    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static; 
        anim.SetTrigger("death");
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // calculate the attempt the player has left
    private int getLife() {
        return (5-death);
    }
}
