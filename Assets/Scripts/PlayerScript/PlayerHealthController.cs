using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public int totalhealth;
    public int maxhealth;
    UIController uIController;
    public float yenilmezlikSuresi;
    float yenilmezlikSayaci;
    SpriteRenderer spriteRenderer;
    PlayerController playerController;
    [SerializeField]
    GameObject deathEffect;

    private void Start()
    {
        
    }
    private void Awake()
    {
        playerController = Object.FindObjectOfType<PlayerController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        uIController = Object.FindObjectOfType<UIController>();
        
       
    }
    private void Update()
    {
        yenilmezlikSayaci -= Time.deltaTime;
        if (yenilmezlikSayaci <= 0)
        {
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1f);
        }
        if (totalhealth >= maxhealth)
        {
            totalhealth = maxhealth;

        }

    }

    public void takeDamage()
    {
        if (yenilmezlikSayaci <= 0)
        {
            totalhealth--;
            if (totalhealth <= 0)
            {
                totalhealth = 0;
                gameObject.SetActive(false);
                Instantiate(deathEffect, transform.position, transform.rotation);
            }
            else
            {
                spriteRenderer.color = new Color(spriteRenderer.color.r,spriteRenderer.color.g,spriteRenderer.color.b,.4f);
                yenilmezlikSayaci = yenilmezlikSuresi;
                playerController.geriTepmeFNC();
            }
        }        
        uIController.HealthUpdate();
    }
}
