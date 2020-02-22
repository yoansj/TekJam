using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skills : MonoBehaviour
{
    private PlayerMovement playerMovement;

    public int level = 0;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponentInParent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            Grow();

        if (Input.GetKeyDown(KeyCode.Z))
            Shrink();
    }

    private void Grow()
    {
        playerMovement.rb.transform.localScale += new Vector3(1, 1, 0);
    }
    private void Shrink()
    {
        if (playerMovement.rb.transform.localScale.x != 1)
        {
            playerMovement.rb.transform.localScale += new Vector3(-1, -1, 0);
        }
    }
}
