using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class PaddleController : NetworkBehaviour
{
    public float paddleSpeed = 5.0f;
    public float boundaryY = 6.0f;

   // public int paddle = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
            return;

        // LOCAL LOCAL
        float moveInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(0, moveInput, 0) * paddleSpeed * Time.deltaTime;
        transform.Translate(movement);

        //Calmp for bounds
        Vector3 newPosition = transform.position;
        newPosition.y = Mathf.Clamp(newPosition.y, -boundaryY, boundaryY);
        transform.position = newPosition;

        CmdSyncPaddlePosition(transform.position);
    }

    [Command]
    void CmdSyncPaddlePosition(Vector3 position)
    {
        // Update the paddle's position on the server
        RpcUpdatePaddlePosition(position);
    }

    [ClientRpc]
    void RpcUpdatePaddlePosition(Vector3 position)
    {
        // Update the paddle's position on all clients
        transform.position = position;
    }
}

