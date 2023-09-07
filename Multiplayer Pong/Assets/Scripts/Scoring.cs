using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Beamable.Common.Leaderboards;
using Beamable;

public class Scoring : MonoBehaviour
{
    [SerializeField] private LeaderboardRef _leaderboardRef = null;
    [SerializeField] private double _score = 100;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log($"Start()");
        LeaderboardServiceSetScore(_leaderboardRef.Id, _score);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space presesd");
            double score = _score + 15; 
            LeaderboardServiceSetScore(_leaderboardRef.Id, score);
        }

        GameObject ball = GameObject.Find("Ball");

        if(ball.transform.position.x > 1000 || ball.transform.position.x < -1000)
        {
            LeaderboardServiceSetScore(_leaderboardRef.Id, 50);
        }
    }

    //  Methods  --------------------------------------
    private async void LeaderboardServiceSetScore(string id, double score)
    {
        var beamContext = BeamContext.Default;
        await beamContext.OnReady;

        Debug.Log($"beamContext.PlayerId = {beamContext.PlayerId}");

        await beamContext.Api.LeaderboardService.SetScore(id, score);

        Debug.Log($"LeaderboardService.SetScore({id},{score})");
    }
}
