using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public BoxCollider2D OyunAlani;
    void Start()
    {
        RandomPosition();
  
    }
    private void RandomPosition()
    {
        Bounds sinir = this.OyunAlani.bounds;

        float x = Random.Range(sinir.min.x, sinir.max.x);
        float y = Random.Range(sinir.min.y, sinir.max.y);

        //tam sayýya çeviriyoruz
        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            RandomPosition();
        }
    }
}
