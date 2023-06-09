using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    [SerializeField] private HealthBar healthBar;

    [SerializeField] private int maxHealth = 5;
    public int currentHealth;

    private int life = 5;

    // [SerializeField] private AudioSource deathSoundEffect;

    private void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            currentHealth--;
            healthBar.SetHealth(currentHealth);
            if (currentHealth <= 0)
            {
                Die();
            }
            else
            {
                Damage();
            }
        }

        if (collision.gameObject.CompareTag("Flag"))
        {
            SceneManager.LoadScene(2);
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
        SceneManager.LoadScene(2);
    }
}