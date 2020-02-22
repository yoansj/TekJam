﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skills : MonoBehaviour
{
    private PlayerMovement playerMovement;

    public int level;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponentInParent<PlayerMovement>();
        level = 1;
        LevelUp();
        LevelUp();
        LevelUp();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            Grow();

        if (Input.GetKeyDown(KeyCode.Z))
            Shrink();
    }

    private void LevelUp()
    {
        level += 1;
    }

    private void Grow()
    {
        if (playerMovement.rb.transform.localScale.x < level)
        {
            playerMovement.rb.transform.localScale += new Vector3(1, 1, 0);
        }
    }
    private void Shrink()
    {
        if (playerMovement.rb.transform.localScale.x != 1)
        {
            playerMovement.rb.transform.localScale += new Vector3(-1, -1, 0);
        }
    }
}