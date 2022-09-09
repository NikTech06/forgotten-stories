using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthHandler : MonoBehaviour
{
    public int waterSurface = 1;

    public float health = 20f;
    public float underwaterTime = 30f;
    public float underwaterRegenCoefficient = 1.25f;
    public float hunger = 20f;
    public float hungerPerSecond = 0.001f;
    private float defaultHealth;
    private float defaultUnderwaterTime;
    private float defaultHunger;

    public Transform player;

    public GameObject postProcessingUnderwater;
    public GameObject underwaterBar;
    public GameObject[] armor;

    public Slider underwaterBarValue;
    public Slider healthBarValue;
    public Slider hungerBarValue;

    void Start()
    {
        defaultHealth = health;
        defaultUnderwaterTime = underwaterTime;
        defaultHunger = hunger;
    }

    void Update()
    {
        CheckDrowning();
        DoHunger();

        //update bars
        UpdateUnderwaterBar();
        UpdateHealthBar();
        UpdateHungerBar();
    }

    //main health
    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    public void Heal(float heal)
    {
        health += heal;
        health = Mathf.Clamp(health, 0, defaultHealth);
    }

    public void Die()
    {
        //die
    }

    //other health related things
    void CheckDrowning()
    {
        
        if(player.transform.position.y < waterSurface)
        {
            postProcessingUnderwater.SetActive(true);

            underwaterTime -= Time.deltaTime;
            if(underwaterTime <= 0)
            {
                TakeDamage(Time.deltaTime);
            }
        } else
        {
            postProcessingUnderwater.SetActive(false);

            underwaterTime += Time.deltaTime * underwaterRegenCoefficient;
            underwaterTime = Mathf.Clamp(underwaterTime, 0, defaultUnderwaterTime);
        }
    }

    void DoHunger()
    {
        if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            hunger -= Time.deltaTime * hungerPerSecond;
        }

        if(Input.GetButton("Sprint"))
        {
            hunger -= Time.deltaTime * hungerPerSecond;
        }
    }

    //updating bars
    void UpdateUnderwaterBar()
    {
        if(underwaterTime < defaultUnderwaterTime)
        {
            underwaterBar.SetActive(true);

            underwaterBarValue.value = underwaterTime / defaultUnderwaterTime;
        } else
        {
            underwaterBar.SetActive(false);
        }
    }

    void UpdateHealthBar()
    {
        healthBarValue.value = health / defaultHealth;
    }

    void UpdateHungerBar()
    {
        hungerBarValue.value = hunger / defaultHunger;
    }
}