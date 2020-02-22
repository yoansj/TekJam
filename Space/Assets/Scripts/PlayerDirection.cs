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

    // Start is called before the first frame update
    void Start()
    {
        playerDir = direction_e.UNDEFINED;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            setPlayerDir(direction_e.LEFT);
        if (Input.GetKeyDown(KeyCode.RightArrow))
            setPlayerDir(direction_e.RIGHT);
    }

    void setPlayerDir(direction_e dir)
    {
        playerDir = dir;
    }

    public direction_e getPlayerDir()
    {
        return (playerDir);
    }    
}
