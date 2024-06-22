using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    Transform hedeftransform;
    float tempy;
    [SerializeField]
    float miny, maxy;
    Vector2 sonPos;
    [SerializeField]
    Transform altZemin, ortaZemin;

    private void Start()
    {
        sonPos = transform.position;
    }

    private void Update()
    {
        KamerayiSinirla();
        zeminleriHaraketEt();
    }
    void KamerayiSinirla()
    {
        tempy = Mathf.Clamp(hedeftransform.position.y, miny, maxy);
        transform.position = new Vector3(hedeftransform.position.x, tempy, transform.position.z);

    }
    void zeminleriHaraketEt()
    {
        Vector2 aradakiMiktar = new Vector2(transform.position.x - sonPos.x, transform.position.y - sonPos.y);
        altZemin.position += new Vector3(aradakiMiktar.x, aradakiMiktar.y, 0f);
        ortaZemin.position += new Vector3(aradakiMiktar.x, aradakiMiktar.y, 0f)*.5f;

        sonPos = transform.position;
    }

    
}
