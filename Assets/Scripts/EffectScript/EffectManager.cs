using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    [SerializeField]
    float yasamaSuresi;

    private void Start()
    {
        startEffect();
        
    }
    public void startEffect()
    {
        Destroy(gameObject, yasamaSuresi);
    }
}
