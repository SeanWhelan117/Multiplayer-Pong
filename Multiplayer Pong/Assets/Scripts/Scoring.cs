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
