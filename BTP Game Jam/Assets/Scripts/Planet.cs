using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public int hp;
    public int initialHP;
    public Sprite deadPlanet;

    // Start is called before the first frame update
    void Start()
    {
        initialHP = hp;
    }

    // Update is called once per frame
    void Update()
    {
        if(hp <= 0)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = deadPlanet;
        }
    }
}
