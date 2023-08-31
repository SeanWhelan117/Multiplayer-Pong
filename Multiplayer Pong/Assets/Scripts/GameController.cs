using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(ball, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
