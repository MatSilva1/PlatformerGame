using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public Animator animator;
    public float maxHealth = 1f;
    public float currentHealth;
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private Rigidbody2D playerRb;
    private Vector2 direction;
    [SerializeField] private float attackForce = 100;

    void Start()
    {
        currentHealth = maxHealth;
    }

    private void Awake() 
    {
        playerRb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
       
    }

    public void TakeDamage(float damage)
    {
        direction = Vector2.up;

        currentHealth -= damage;
        healthBar.SetSize(currentHealth);
        animator.SetTrigger("TakeDamage");
        playerRb.AddForce(direction * attackForce);

        if(currentHealth <= 0)
        {
            animator.SetTrigger("isDead");
        }
    }

}
