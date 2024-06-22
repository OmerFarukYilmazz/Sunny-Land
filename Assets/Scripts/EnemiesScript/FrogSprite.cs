using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogSprite : MonoBehaviour
{
    public float speed;
    public Transform solHedef, sagHedef;
    bool yonSagmi;

    bool sagTaraf;
    Rigidbody2D rb;
    Animator anim;
    bool move,checkDistance =true;

    PlayerController playerController;
    PlayerHealthController playerHealthController;
    [SerializeField]
    float targetDistance;

    public float haraketSuresi, beklemeSuresi;
    float haraketSayaci, beklemeSayaci;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playerController = Object.FindObjectOfType<PlayerController>();
        playerHealthController = Object.FindObjectOfType<PlayerHealthController>();
        
    }
    private void Start()
    {
        solHedef.parent = null;
        sagHedef.parent = null;
        haraketSayaci = haraketSuresi;
        beklemeSayaci = beklemeSuresi;
        
    }
    private void Update()
    {
        
        frogMove(); // method 1
        //frogMovement(); // method 2
        
    }

    public void frogMove()
    {
        if (Vector3.Distance(playerController.transform.position, transform.position) < targetDistance && checkDistance == true)
        {
            move = true;
            
            checkDistance = false;
        }
        if (move == true)
        {
            if (haraketSayaci > 0 )
            {
                anim.SetBool("Run", move);
                haraketSayaci -= Time.deltaTime;
                if (yonSagmi)
                {
                    transform.position = Vector3.MoveTowards(transform.position, sagHedef.position, speed * Time.deltaTime);
                    if (Vector3.Distance(transform.position, sagHedef.position) < 0.1f)
                    {
                        yonSagmi = false;
                        YonuDegistir(yonSagmi);
                    }
                }
                else
                {
                    transform.position = Vector3.MoveTowards(transform.position, solHedef.position, speed * Time.deltaTime);
                    if (Vector3.Distance(transform.position, solHedef.position) < 0.1f)
                    {
                        yonSagmi = true;
                        YonuDegistir(yonSagmi);
                    }
                }
                if (haraketSayaci <= 0)
                {
                    beklemeSayaci = Random.Range(2,5);                    
                }
            }
            else
            {
                anim.SetBool("Run", false);
                //print(beklemeSayaci);                 
                beklemeSayaci -= Time.deltaTime;
                if (beklemeSayaci <= 0)
                {
                    haraketSayaci = Random.Range(2,5);
                    move = true;
                }
            }
        }
        
        
    }
    public void frogMovement()
    {
        if (yonSagmi)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            if (transform.position.x > sagHedef.position.x)
            {
                yonSagmi = false;
            }

        }
        else
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            if (transform.position.x < solHedef.position.x)
            {
                yonSagmi = true;
            }

        }
        
    }
    public void YonuDegistir(bool yonSagmi)
    {
        Vector2 tempScale = transform.localScale;
        if (this.yonSagmi)
        {            
            tempScale.x = -1f;            
        }
        else 
        {            
            tempScale.x = 1f;
        }
        transform.localScale = tempScale;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            playerHealthController.takeDamage();
        }
    }


}
