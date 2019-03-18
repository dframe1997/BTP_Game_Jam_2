using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * 16);
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Collision");
        if(col.gameObject.tag == "Planet")
        {
            Planet bestruckObject = col.gameObject.GetComponent<Planet>();
            Debug.Log(bestruckObject);
            bestruckObject.transform.localScale = new Vector3(0.9f * bestruckObject.transform.localScale.x, 0.9f * bestruckObject.transform.localScale.y, 1);
            bestruckObject.hp -= 1;
            GameManager.gameManager.addScore(bestruckObject.initialHP);
            
            Destroy(gameObject);
        }
        else if(col.gameObject.tag != "Player")
        {
            Destroy(gameObject);
        }        
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}


