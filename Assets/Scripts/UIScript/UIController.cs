using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField]
    Image kalp1_Img, kalp2_Img, kalp3_Img;
    [SerializeField]
    Sprite doluKalp, yarimKalp, bosKalp;
    [SerializeField]
    TMP_Text kalp_Txt;
    PlayerHealthController playerHealthController;

    LevelManager levelManager;
    [SerializeField]
    TMP_Text mucevher_txt;


    private void Awake()
    {
        playerHealthController = Object.FindObjectOfType<PlayerHealthController>();
        levelManager = Object.FindObjectOfType<LevelManager>();
        
    }

    public void HealthUpdate()
    {
        
        switch (playerHealthController.totalhealth)
        {
           
            case 8:               
                kalp_Txt.text = "+2";
                break;

            case 7:                
                kalp_Txt.text ="+1";
                break;

            case 6:
                kalp_Txt.text = " ";
                kalp1_Img.sprite = doluKalp;
                kalp2_Img.sprite = doluKalp;
                kalp3_Img.sprite = doluKalp;
                break;
            case 5:
                kalp1_Img.sprite = doluKalp;
                kalp2_Img.sprite = doluKalp;
                kalp3_Img.sprite = yarimKalp;
                break;
            case 4:
                kalp1_Img.sprite = doluKalp;
                kalp2_Img.sprite = doluKalp;
                kalp3_Img.sprite = bosKalp;
                break;
            case 3:
                kalp1_Img.sprite = doluKalp;
                kalp2_Img.sprite = yarimKalp;
                kalp3_Img.sprite = bosKalp;
                break;
            case 2:
                kalp1_Img.sprite = doluKalp;
                kalp2_Img.sprite = bosKalp;
                kalp3_Img.sprite = bosKalp;
                break;
            case 1:
                kalp1_Img.sprite = yarimKalp;
                kalp2_Img.sprite = bosKalp;
                kalp3_Img.sprite = bosKalp;
                break;
            case 0:
                kalp1_Img.sprite = bosKalp;
                kalp2_Img.sprite = bosKalp;
                kalp3_Img.sprite = bosKalp;
                break;
        }
    }
    public void gemUpdate()
    {
        mucevher_txt.text = levelManager.toplananMucevherSayisi.ToString();

    }

}
