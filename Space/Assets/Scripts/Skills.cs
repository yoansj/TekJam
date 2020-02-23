using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Experimental.Rendering.LWRP;
using TMPro;

public class Skills : MonoBehaviour
{
    private Movement playerMovement;

    public bool invicibility;
    public int levelMax;
    public int currentLevel;
    public bool canDoubleJump = true;

    private Light2D playerLight;
    private Color basicColor;
    private bool canGrow = true;
    private Animator animator;
    private float basicIntensity;

    public TextMeshProUGUI TextMeshPro;

    private Camera mainCamera;
    private float cameraOriginSize;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = FindObjectOfType<Camera>();
        cameraOriginSize = mainCamera.orthographicSize;

        animator = GetComponent<Animator>();

        playerLight = GetComponentInChildren<Light2D>();
        basicColor = playerLight.color;
        basicIntensity = playerLight.intensity;

        playerMovement = GetComponentInParent<Movement>();
        levelMax = 1;
        currentLevel = 1;
        invicibility = false;
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
    }

    private void Grow()
    {
        if (playerMovement.rb.transform.localScale.x <= levelMax && canGrow == true)
        {
            playerMovement.rb.transform.localScale += new Vector3(1, 1, 0);
            playerMovement.controller.m_JumpForce += 100;
            currentLevel += 1;
            mainCamera.orthographicSize += 1;
        }
    }

    private void Shrink()
    {
        if (playerMovement.rb.transform.localScale.x != 2)
        {
            playerMovement.rb.transform.localScale += new Vector3(-1, -1, 0);
            playerMovement.controller.m_JumpForce -= 100;
            currentLevel -= 1;
            mainCamera.orthographicSize -= 1;
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

    IEnumerator InvicibilityFrame()
     {
        playerLight.intensity = 0.2f;
        playerLight.color = Color.red;
        animator.SetBool("inv", true);
        invicibility = true;
        yield return new WaitForSeconds(2.0f);
        invicibility = false;
        animator.SetBool("inv", false);
    }

    IEnumerator GrowCooldown()
    {
        canGrow = false;
        yield return new WaitForSeconds(5.0f);
        canGrow = true;
        playerLight.color = basicColor;
        playerLight.intensity = basicIntensity;
        animator.SetBool("inv", false);
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) {
            if (
                collision.gameObject.GetComponentInParent<EnemyMovement>().isDead
                || collision.gameObject.GetComponentInParent<EnemyMovement>().isInvicible
                || invicibility
            )
                return;
            playerMovement.controller.soundPlayer.PlaySound(1);
            if (currentLevel == 1)
                SceneManager.LoadScene(2);
            StartCoroutine("InvicibilityFrame");
            StartCoroutine("GrowCooldown");
            Shrink();
        }
    }
}
