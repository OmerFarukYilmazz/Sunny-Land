using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToplamaScript : MonoBehaviour
{
    LevelManager levelmanager;
    UIController uIController;
    PlayerHealthController playerHealthController;
    //EffectManager effectManager;
    [SerializeField]
    bool mucevhermi,kirazmi;

    [SerializeField]
    GameObject toplamaEffect;

    bool toplandimi;
    private void Awake()
    {
        levelmanager = Object.FindObjectOfType<LevelManager>();
        uIController = Object.FindObjectOfType<UIController>();
        playerHealthController = Object.FindObjectOfType<PlayerHealthController>();
        
    }
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.CompareTag("Player") && !toplandimi)
        {
            if (mucevhermi)
            {                   
                levelmanager.toplananMucevherSayisi++;
                uIController.gemUpdate();
                toplandimi = true;
                Destroy(gameObject);
                Instantiate(toplamaEffect, transform.position, transform.rotation);
            }
            else if (kirazmi)
            {
                if(playerHealthController.totalhealth != playerHealthController.maxhealth)
                {
                    playerHealthController.totalhealth++;
                    levelmanager.toplananKirazSayisi++;
                    uIController.HealthUpdate();
                    toplandimi = true;                    
                    Destroy(gameObject);
                    Instantiate(toplamaEffect, transform.position, transform.rotation);
                }                
            }      
        }
    }

}
