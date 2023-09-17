using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{

    private Animator anim;
    private Rigidbody2D rb;

    //[SerializeField] private AudioSource deathSoundEffect; // sfx of death; must be serialized
 
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Debug.Log("you are dead");
            Die();
           
        }
    }

    private void Die()
    {
        //deathSoundEffect.Play();
        rb.bodyType = RigidbodyType2D.Static; // this sets player movement to static, preventing movement after death
        //anim.SetTrigger("death"); // this activates death trigger, starting the death state of the player
 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);// this will reload the current level
    }
}
