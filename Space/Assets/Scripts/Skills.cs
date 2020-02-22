using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skills : MonoBehaviour
{
    private PlayerMovement playerMovement;

    [Header("Lumiére")]
    private Light playerLight;
    public float maxIntesity = 2;
    public float maxRange = 2;

    public int level = 0;
    // Start is called before the first frame update
    void Start()
    {
        playerLight = GetComponentInChildren<Light>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            Grow();

        if (Input.GetKeyDown(KeyCode.Z))
            Shrink();

        if (Input.GetKey(KeyCode.E))
            Enlighten();
        else
        {
            playerLight.intensity = 0;
            playerLight.range = 0;
        }
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

    private void Enlighten()
    {
        playerLight.intensity = maxIntesity;
        playerLight.range = maxRange;
    }
}
