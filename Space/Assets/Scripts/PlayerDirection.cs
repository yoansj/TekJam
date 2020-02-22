using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDirection : MonoBehaviour
{
    public enum direction_e {
        LEFT = -1,
        RIGHT = 1,
        UNDEFINED = 0,
    };

    private direction_e playerDir;
    private direction_e prevDir;

    // Start is called before the first frame update
    void Start()
    {
        playerDir = direction_e.UNDEFINED;
        prevDir = direction_e.UNDEFINED;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow))
            setPlayerDir(prevDir);
        else if (Input.GetKey(KeyCode.LeftArrow))
            setPlayerDir(direction_e.LEFT);
        else if (Input.GetKey(KeyCode.RightArrow))
            setPlayerDir(direction_e.RIGHT);
    }

    void setPlayerDir(direction_e dir)
    {
        prevDir = playerDir;
        playerDir = dir;
    }

    public direction_e getPlayerDir()
    {
        return (playerDir);
    }    
}
