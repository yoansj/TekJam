using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private GameObject player;
    private PlayerDirection playerDirection;
    private PlayerDirection.direction_e playerDir;
    private object playerPos;

    private Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerDirection = player.GetComponent<PlayerDirection>();
        playerDir = PlayerDirection.direction_e.UNDEFINED;
        velocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        cameraFollow();
    }

    void cameraFollow()
    {
        Vector3 playerPos = player.transform.position;

        playerPos.y += 1;
        playerPos.z = transform.position.z;
        playerPos.x += cameraChangeDirEffect();
        transform.position = Vector3.SmoothDamp(transform.position, playerPos, ref velocity, Time.deltaTime * 5);
    }

    int cameraChangeDirEffect()
    {
        playerDir = playerDirection.getPlayerDir();
        return ((int)playerDir);
    }
}
