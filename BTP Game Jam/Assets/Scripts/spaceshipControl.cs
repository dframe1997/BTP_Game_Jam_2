using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class spaceshipControl : MonoBehaviour
{
    public GameObject bullet;
    public GameObject arrowPivot;
    public List<Planet> collectedPlanets;
    public GameObject gameOver;
    public GameObject UIContainer;
    float bulletTime = 0;
    public List<GameObject> arrowContainer;

    // Start is called before the first frame update
    void Start()
    {
        //MakeArrows();
    }

    // Update is called once per frame
    void Update()
    {
        //UpdateArrows();

        transform.Translate(Vector2.up * Time.deltaTime * (GameManager.gameManager.speed + GameManager.gameManager.speedAugment));
        if (Input.GetKey(KeyCode.W) && (GameManager.gameManager.speedAugment + 0.1f) < 4)
        {
            GameManager.gameManager.speedAugment += 0.1f;
        }
        else if (Input.GetKey(KeyCode.S) && (GameManager.gameManager.speedAugment - 0.1f) > -2)
        {
            GameManager.gameManager.speedAugment -= 0.1f;
        }
        else
        {
            if(GameManager.gameManager.speedAugment < 0)
            {
                GameManager.gameManager.speedAugment += 0.1f;
            }
            else if (GameManager.gameManager.speedAugment > 0)
            {
                GameManager.gameManager.speedAugment -= 0.1f;
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * 200 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.back * 200 * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.Space) && bulletTime <= 0)
        {
            Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
            bulletTime = 2;
        }

        if(bulletTime > 0)
        {
            bulletTime -= 0.1f;
        }
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Player collided with something.");
        if (col.gameObject.tag == "Planet")
        {
            Planet bestruckObject = col.gameObject.GetComponent<Planet>();
            if(bestruckObject.hp <= 0)
            {
                Planet newPlanet = bestruckObject;
                collectedPlanets.Add(newPlanet);
                Debug.Log("Destroying planet");
                Destroy(col.gameObject);
                GameManager.gameManager.addScore(bestruckObject.initialHP * 10);
                GameManager.gameManager.speedIncrease(1);
            }
            else
            {
                GameManager.gameManager.speed = 0;
                GameManager.gameManager.speedAugment = 0f;
                GameManager.gameManager.gameOver = true;
                gameOver.SetActive(true);
                UIContainer.SetActive(false);
            }
        }
        else if(col.gameObject.tag == "Wall")
        {
            GameManager.gameManager.speed = 0;
            GameManager.gameManager.speedAugment = 0f;
            GameManager.gameManager.gameOver = true;
            gameOver.SetActive(true);
            UIContainer.SetActive(false);
        }
    }

    public void MakeArrows()
    {
        GameObject[] planets;
        planets = GameObject.FindGameObjectsWithTag("Planet");
        Vector3 position = transform.position;
        foreach (GameObject planet in planets)
        {
            GameObject newArrow = Instantiate(arrowPivot, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
            newArrow.transform.parent = transform;
            pointAtPlanet(planet, newArrow);
            arrowContainer.Add(newArrow);
        }
    }

    public void UpdateArrows()
    {
        GameObject[] planets;
        planets = GameObject.FindGameObjectsWithTag("Planet");

        if (arrowContainer.Count > planets.Length)
        {
            //Too many arrows, delete some
             int toRemove = arrowContainer.Count - planets.Length;
             for(int i = 0; i < toRemove; i++)
             {
                 arrowContainer.Remove(arrowContainer[i]);
             }

            //Move the arrows to point at the planets

            
        }

        for (int i = 0; i < arrowContainer.Count; i++)
        {
            pointAtPlanet(planets[i], arrowContainer[i]);
        }

    }

    public void pointAtPlanet(GameObject planet, GameObject arrowPivot)
    {
        /*
        Vector3 vectorToTarget = planet.transform.position - arrowPivot.transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        arrowPivot.transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * GameManager.gameManager.speed);
        */

        /*
        Quaternion rotation = Quaternion.LookRotation(planet.transform.position - arrowPivot.transform.position, transform.TransformDirection(Vector3.up));
        arrowPivot.transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
        */

        /*
        Vector3 targ = planet.transform.position;
        targ.z = 0f;

        Vector3 objectPos = arrowPivot.transform.position;
        targ.x = targ.x - objectPos.x;
        targ.y = targ.y - objectPos.y;

        float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;
        arrowPivot.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        */

        //arrowPivot.transform.LookAt(planet.transform, Vector3.down);

    }
}
