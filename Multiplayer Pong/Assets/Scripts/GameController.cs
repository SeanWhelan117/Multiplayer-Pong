using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject ball;
    public TextMeshProUGUI playerOneScoreText;
    public TextMeshProUGUI playerTwoScoreText;

    public int scorePlayer1;
    public int scorePlayer2;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(ball, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity); 
    }

    // Update is called once per frame
    void Update()
    {
        GameObject ballClone = GameObject.FindGameObjectWithTag("Ball");

        if (ballClone.transform.position.x < -13)
        {
            scorePlayer2 += 1;
            playerTwoScoreText.text = scorePlayer2.ToString();
        }
        else if (ballClone.transform.position.x > 13)
        {
            scorePlayer1 += 1;
            playerOneScoreText.text = scorePlayer1.ToString();
        }
    }
}
