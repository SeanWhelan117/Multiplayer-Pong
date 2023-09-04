using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

namespace Mirror
{
    [AddComponentMenu("")]
    public class NetworkManagerPong : NetworkManager
    {
        public Transform paddleSpawnLeft;
        public Transform paddleSpawnRight;

        GameObject ball;

        public override void OnServerAddPlayer(NetworkConnectionToClient conn)
        {
            // add player at correct spawn position
            Transform start = numPlayers == 0 ? paddleSpawnLeft : paddleSpawnRight;
            GameObject player = Instantiate(playerPrefab, start.position, start.rotation);
            NetworkServer.AddPlayerForConnection(conn, player);

            // spawn ball if two players
            if (numPlayers == 2)
            {
                ball = Instantiate(spawnPrefabs.Find(prefab => prefab.name == "Ball"));
                NetworkServer.Spawn(ball);
            }
        }

        public override void OnServerDisconnect(NetworkConnectionToClient conn)
        {
            // destroy ball
            if (ball != null)
                NetworkServer.Destroy(ball);

            //destroys the player
            base.OnServerDisconnect(conn);
        }
    }
}
