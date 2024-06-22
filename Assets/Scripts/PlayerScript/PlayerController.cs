using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float speed;    
    [SerializeField]
    float jump;
    bool yerdemi;
    public Transform zeminControl;
    public LayerMask zeminLayer;
    bool ikikezzýpla;

    public float geriTepmeSuresi, geriTepmeGucu;
    float geriTepmeSayaci;
    bool yonSagmi;

    public Rigidbody2D rb;
    Animator anim;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        // 1.method

        /*float movex = Input.GetAxis("Horizontal");
        Vector2 move = rb.velocity;
        move.x = speed * movex;
        if (Input.GetButtonDown("Jump"))
        {
            print("a");
            rb.AddForce(Vector2.up * jump);
        }
        rb.velocity = move;*/

        // 2.method
        

        if (geriTepmeSayaci <= 0)
        {
            moveCharacter();
            jumpCharacter();
        }
        else
        {
            geriTepmeSayaci -= Time.deltaTime;
            if (yonSagmi)
            {
                rb.velocity = new Vector2(-geriTepmeGucu, rb.velocity.y);
            }
            else
                rb.velocity = new Vector2(geriTepmeGucu, rb.velocity.y);

        }

        anim.SetFloat("HaraketHizi", Mathf.Abs(rb.velocity.x));
        anim.SetBool("Yerdemi", yerdemi);
    }
    public void moveCharacter()
    {
        float movex = Input.GetAxis("Horizontal");
        float move = movex * speed;
        rb.velocity = new Vector2(move, rb.velocity.y);
        YonuDegistir();
    }
    public void jumpCharacter()
    {
        yerdemi = Physics2D.OverlapCircle(zeminControl.position, .2f, zeminLayer);
        if (yerdemi)
        {
            ikikezzýpla = true;
        }
        if (Input.GetButtonDown("Jump"))
        {
            if (yerdemi)
            {
                rb.AddForce(Vector2.up * jump);
            }
            else {
                if (ikikezzýpla)
                {
                    rb.AddForce(Vector2.up * jump);
                    ikikezzýpla = false;
                }
            }
        }
        
    }

    void YonuDegistir()
    {
        Vector2 tempScale = transform.localScale;
        if (rb.velocity.x > 0)
        {
            yonSagmi = true;
            tempScale.x = 1f;
        }
        else if(rb.velocity.x < 0)
        {
            yonSagmi = false;
            tempScale.x = -1f;
        }
        transform.localScale = tempScale;
    }
    public void geriTepmeFNC()
    {
        geriTepmeSayaci = geriTepmeSuresi;
        anim.SetTrigger("Hurt");
        rb.velocity = new Vector2(0, rb.velocity.y);
        
    }

}
