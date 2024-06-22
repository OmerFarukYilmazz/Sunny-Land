using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KutuControl : MonoBehaviour
{
    PlayerController playerController;
    [SerializeField]
    GameObject DeathEffect;

    public float kirazUretchance;
    public GameObject kirazObje;
    float Chance;
    public float gemUretchance;
    public GameObject gemObje;
    

    Vector3 tempPos;
    

    private void Awake()
    {
        playerController = Object.FindObjectOfType<PlayerController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Frog"))
        {
            // 1.method
            JumpPlayer();
            // 2.method
            //playerController.rb.AddForce(Vector2.up * 500f); 

            collision.transform.parent.gameObject.SetActive(false);            
            Instantiate(DeathEffect,transform.position,transform.rotation);
            Chance = Random.Range(0f, 100f);
            
            if (0f<Chance && Chance<= kirazUretchance)
            {             
                tempPos = collision.transform.position;                
                Invoke("createKiraz", 0.1f);
                //Instantiate(kirazObje, collision.transform.position, collision.transform.rotation);
            }
            else if (kirazUretchance< Chance && Chance <= kirazUretchance + gemUretchance)
            {
                tempPos = collision.transform.position;
                Invoke("createGem", 0.1f);
            }
        }
    }
    public void createKiraz()
    {
        Instantiate(kirazObje, tempPos, transform.rotation);
    }
    public void createGem()
    {
        Instantiate(gemObje, tempPos, transform.rotation);
    }
    public void JumpPlayer()
    {
        playerController.rb.velocity = new Vector2(playerController.rb.velocity.x, 15f);
    }


}
