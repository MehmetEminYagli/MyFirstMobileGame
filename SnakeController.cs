using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    private Vector2 Yon = Vector2.right;
    //vector2 2 Boyutlu X ve Y yi ister
    //vector3 ise 3 Boyutlu Yani X,Y,Z verilerini ister

    //x,y,z
    //yýlanýmýzýn konumunu her zaman tam sayý olarak hareket ettirirsek iþimiz daha kolay olur bu yüzden mathf.round komutu ile ondalýklý sayýlarý tam sayýya çeviririz
    public float x ,y;
    private List<Transform> segments;

    public Transform segmentPrefab;

    //yýlanýn oyun baþlangýcýndaki boyutu
    public int DefaultSize = 3;
   

    private void Start()
    {
        segments = new List<Transform>();
        segments.Add(this.transform);
    }

  
    private void Update()
    {
       

     
        if (Input.GetKeyDown(KeyCode.W))
        {
            Yon = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            Yon = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            Yon = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Yon = Vector2.right;
        }

    }
    public void Right()
    {
        Yon = Vector2.right;
    }
    public void Left()
    {
        Yon = Vector2.left;
    }
    public void Up()
    {
        Yon = Vector2.up;
    }
    public void Down()
    {
        Yon = Vector2.down;
    }

    private void FixedUpdate()
    {
        for (int i = segments.Count - 1; i > 0; i--)
        {
            segments[i].position = segments[i - 1].position;
        }

        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x) + Yon.x,
            Mathf.Round(this.transform.position.y) + Yon.y,
            0.0f
            );
    }

    private void Grow()
    {
        Transform kuyruk = Instantiate(this.segmentPrefab);
        kuyruk.position = segments[segments.Count - 1].position;
        segments.Add(kuyruk);
    }
    private void ResetGame()
    {
        for (int i = 1; i < segments.Count; i++)
        {
            //eðer i yi 1 yerine 0 yaparsak yýlanýn baþýnýda destroy ederiz bu yüzden 1 den baþlayarak geri kalan kuyruklarý sil
            Destroy(segments[i].gameObject);
        }
            segments.Clear();
            segments.Add(this.transform);
            //segmentleri sildik ve geri ekledik
/*
        for (int i=1; i < this.DefaultSize; i++)
        {
            segments.Add(Instantiate(this.segmentPrefab));
        }
*/
            //þimdi yýlanýn yerini baþladýðý konuma getirelim
            this.transform.position = Vector3.zero;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Food")
        {
            Grow();
        } else if (collision.tag == "Engel")
        {
            ResetGame();
        }
    }

}
