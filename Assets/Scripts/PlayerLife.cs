using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    private int life = 5;
    [SerializeField] private TextMeshProUGUI displayText;

    // [SerializeField] private AudioSource deathSoundEffect;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            life--;
            displayText.text = "Life: " + life;
            if(life <= 0)
            {
                Die();
            }
            else
            {
                Damage();
            }
        }
    }

    private void Die()
    {
        // deathSoundEffect.Play();
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
    }

        private void Damage()
    {
        // deathSoundEffect.Play();
        anim.SetTrigger("damage");
        rb.velocity = new Vector2(rb.velocity.x, 14f);
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}