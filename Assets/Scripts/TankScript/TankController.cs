using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TankController : MonoBehaviour
{
    //Rigidbody2D rb;
    [SerializeField]
    Transform tankObje;
    public Transform solHedef, sagHedef;

    public float speed,targetDistance;    
    bool yonSagmi,hedefSagmi;
    float playerLoc;
    bool checkDistance =true,moveTank;

    public GameObject mermi;
    public Transform mermiMerkezi;
    public float mermiAtmaSuresi;
    float mermiAtmaSayac;
    public float DarbeSuresi;
    float DarbeSayaci;

    public float beklemeSuresi, haraketSuresi;
    float beklemeSayaci, haraketSayaci;

    PlayerController playerController;
    PlayerHealthController playerHealthController;
    public Animator anim;

    private void Awake()
    {
        //rb = GetComponent<Rigidbody2D>();

        solHedef.parent = null;
        sagHedef.parent = null;        
        playerController = Object.FindObjectOfType<PlayerController>();
        playerHealthController = Object.FindObjectOfType<PlayerHealthController>();
        mermiAtmaSayac = mermiAtmaSuresi;
       
    }    
    
    private void Update()
    {
        MoveObject();        
    }


    public void MoveObject()
    {
        //rb.velocity = new Vector2(speed, rb.velocity.y);
        //rb.AddForce(Vector2.up * speed);

        /*float movex = Input.GetAxis("Vertical") * speed;
        rb.velocity = new Vector2(movex, rb.velocity.y);*/

        /*float h = Input.GetAxis("Vertical");
        transform.Translate(Vector2.right * h * Time.deltaTime * speed);*/

        //transform.position = new Vector3(3f, 5f, 7f);
        //transform.position += new Vector3(1f, 1f, 1f);
        //transform.position = Vector3.Lerp(transform.position, sagHedef.position, speed* Time.deltaTime); // the last one is time.
        //transform.position = Vector3.MoveTowards(transform.position, sagHedef.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, playerController.transform.position)<targetDistance && checkDistance == true)
        {
            moveTank = true;
            checkDistance = false;
        }
        if(moveTank == true)
        {
            if (haraketSayaci > 0)
            {
                haraketSayaci -= Time.deltaTime;
                playerLoc = transform.position.x - playerController.transform.position.x;
                if (playerLoc < 0)
                {
                    yonSagmi = true;
                    YonuDegistir(yonSagmi);
                }
                else
                {
                    yonSagmi = false;
                    YonuDegistir(yonSagmi);
                }

                anim.SetTrigger("Shoot");
                anim.ResetTrigger("StopMove");
                mermiAtmaSayac -= Time.deltaTime;
                if (mermiAtmaSayac <= 0)
                {
                    //Vector3 temp = new Vector3(0f, 0f, 0f);
                    if (yonSagmi)
                    {
                        mermi.transform.localScale = new Vector3(-1f, 1f, 1f);
                    }
                    else
                        mermi.transform.localScale = new Vector3(1f, 1f, 1f);
                    Instantiate(mermi, mermiMerkezi.position, mermiMerkezi.rotation);
                    mermiAtmaSayac = mermiAtmaSuresi;
                }
                if (hedefSagmi)
                {

                    transform.position = Vector3.MoveTowards(transform.position, sagHedef.position, speed * Time.deltaTime);
                    if (Vector3.Distance(transform.position, sagHedef.position) < 0.1f)
                    {
                        hedefSagmi = false;
                    }
                }
                else
                {
                    transform.position = Vector3.MoveTowards(transform.position, solHedef.position, speed * Time.deltaTime);
                    if (Vector3.Distance(transform.position, solHedef.position) < 0.1f)
                    {
                        hedefSagmi = true;
                    }
                }
                if (haraketSayaci <= 0)
                {
                    //beklemeSayaci = Random.Range(2, 5);
                    beklemeSayaci = beklemeSuresi;
                }

            }
            else
            {
                anim.ResetTrigger("Shoot");
                anim.SetTrigger("StopMove");
                beklemeSayaci -= Time.deltaTime;
                if (beklemeSayaci < 0)
                {
                    //haraketSayaci = Random.Range(2, 5);
                    haraketSayaci = 10f;
                    
                }
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
        if (collision.CompareTag("Player"))
        {
            playerHealthController.takeDamage();
           
        }
    }

    
}
