using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;
    public float startHealth = 100;
    public float worth = 10;

    [HideInInspector]
    public float originalWorth;
    private float health;

    [HideInInspector]
    public float speed;

    public GameObject deathEffect;

    [Header("Unity Stuff")]
    public Image healthBar;

    private bool isDead = false;

    void Start()
    {
        speed = startSpeed;
        originalWorth = worth;
        health = startHealth;
    }

    public void takeDamage(float amount)
    {
        health -= amount;

        healthBar.fillAmount = health / startHealth;

        if (health <= 0 && !isDead)  
        {
            die();
        }
    }

    void die()
    {
        isDead = true;

        PlayerStats.Money += worth;
        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        WaveSpawner.enemiesAlive--;

        Destroy(gameObject);
    }

    public void slow(float pct)
    {
        speed = speed * pct;
    }

    public void takePrcDamage(float prcDmg)
    {

        health -= (startHealth * prcDmg) * Time.deltaTime;

        healthBar.fillAmount = health / startHealth;

        if (health <= 0 && !isDead)
        {
            die();
        }
    }

}
