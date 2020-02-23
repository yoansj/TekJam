using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Skills : MonoBehaviour
{
    private Movement playerMovement;

    public int levelMax;
    public int currentLevel;
    public bool canDoubleJump = true;
    private Light playerLight;

    [Header("Lumiére")]
    public float maxIntesity = 2;
    public float maxRange = 2;

    public TextMeshProUGUI TextMeshPro;

    // Start is called before the first frame update
    void Start()
    {
        playerLight = GetComponentInChildren<Light>();
        playerMovement = GetComponentInParent<Movement>();
        levelMax = 1;
        currentLevel = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Grow();

        if (Input.GetKeyDown(KeyCode.X))
            Shrink();

        if (Input.GetKeyDown(KeyCode.UpArrow))
            DoubleJump();

        if (Input.GetKeyDown(KeyCode.D))
            Dash();

        if (playerMovement.controller.m_Grounded == true)
            canDoubleJump = true;

        TextMeshPro.text = "Level: " + currentLevel.ToString() + "/" + levelMax.ToString();
    }

    public void LevelUp()
    {
        levelMax += 1;
        currentLevel += 1;
    }

    private void Grow()
    {
        if (playerMovement.rb.transform.localScale.x <= currentLevel)
        {
            playerMovement.rb.transform.localScale += new Vector3(1, 1, 0);
            playerMovement.controller.m_JumpForce += 100;
        }
    }

    private void Shrink()
    {
        if (playerMovement.rb.transform.localScale.x != 2)
        {
            playerMovement.rb.transform.localScale += new Vector3(-1, -1, 0);
            playerMovement.controller.m_JumpForce -= 100;
        }
    }

    private void DoubleJump()
    {
        if (currentLevel >= 4 && playerMovement.controller.m_Grounded == false && canDoubleJump)
        {
            if (playerMovement.rb.velocity.y < 0)
            {
                playerMovement.rb.AddForce(new Vector2(0f, (-(playerMovement.rb.velocity.y) + playerMovement.controller.m_JumpForce)));
            }
            playerMovement.rb.AddForce(new Vector2(0f, playerMovement.controller.m_JumpForce));
            canDoubleJump = false;
            playerMovement.controller.soundPlayer.PlaySound(0);
        }
    }

    private void Dash()
    {
        playerMovement.rb.AddForce(new Vector2(100f, 0f));
    }

    private void Enlighten()
    {
        playerLight.intensity = maxIntesity;
        playerLight.range = maxRange;
    }
}