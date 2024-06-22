using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MermiController : MonoBehaviour
{
    PlayerHealthController playerHealthController;
    public float mermiHizi;

    private void Awake()
    {
        playerHealthController = Object.FindObjectOfType<PlayerHealthController>();
    }
    private void Update()
    {
        transform.position += new Vector3(-mermiHizi * Time.deltaTime * transform.localScale.x, 0f, 0f);  // for try.
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")){
            playerHealthController.takeDamage();
            Destroy(gameObject);
        }
        //Destroy(gameObject);
    }
}
