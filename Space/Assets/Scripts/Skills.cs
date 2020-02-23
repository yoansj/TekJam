using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Skills : MonoBehaviour
{
    private Movement playerMovement;

    public bool invicibility;
    public int levelMax;
    public int currentLevel;
    public bool canDoubleJump = true;
    private Light playerLight;

    [Header("Lumiére")]
    public float maxIntesity = 2;
    public float maxRange = 2;

    public TextMeshProUGUI TextMeshPro;

    private Camera mainCamera;
    private float cameraOriginSize;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = FindObjectOfType<Camera>();
        cameraOriginSize = mainCamera.orthographicSize;

        playerLight = GetComponentInChildren<Light>();
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
        if (playerMovement.rb.transform.localScale.x <= levelMax)
        {
            playerMovement.rb.transform.localScale += new Vector3(1, 1, 0);
            playerMovement.controller.m_JumpForce += 100;
            currentLevel += 1;
            ResizeCamera(1);
        }
    }

    private void Shrink()
    {
        if (playerMovement.rb.transform.localScale.x != 2)
        {
            playerMovement.rb.transform.localScale += new Vector3(-1, -1, 0);
            playerMovement.controller.m_JumpForce -= 100;
            currentLevel -= 1;
            ResizeCamera(-1);
        }
    }

    void ResizeCamera(int value)
    {
        float newSize = mainCamera.orthographicSize;

        newSize += value;
        mainCamera.orthographicSize = newSize;
//        mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, newSize, Time.deltaTime * 5.0f);
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

     IEnumerator InvicibilityFrame()
     {
        invicibility = true;
        yield return new WaitForSeconds(2.0f);
        invicibility = false;
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
            if (currentLevel == 1)
                SceneManager.LoadScene(2);
            StartCoroutine("InvicibilityFrame");
            Shrink();
        }
    }
}
