using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class menuCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //MakeArrows();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * 5 * Time.deltaTime);
    }
}
