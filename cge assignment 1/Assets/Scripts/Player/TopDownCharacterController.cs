
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEditor.MPE;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TopDownCharacterController : MonoBehaviour
{
    [SerializeField] ShieldSystem Sheild_functions;
    [SerializeField] SpeedSystem speed_functions;
    [SerializeField] HealthSystem healthSystem;
    [SerializeField] EnemyAttack enemyAttack;
    [SerializeField] Camera cam;
    [SerializeField] MusicController music;

    #region Framework Stuff
    //Reference to attached animator
    private Animator animator;

    //Reference to attached rigidbody 2D
    private Rigidbody2D rb;

    //The direction the player is moving in
    private Vector2 playerDirection;

    [Header("Movement parameters")]
    //The maximum speed the player can move
    [SerializeField] private float playerMaxSpeed = 100f;
    [SerializeField] private float playerSpeed = 1f;
    #endregion


    GameObject block;

    /// <summary>
    /// When the script first initialises this gets called, use this for grabbing componenets
    /// </summary>
    /// 

    private void Awake()
    {
        //Get the attached components so we can use them later
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    /// <summary>
    /// When a fixed update loop is called, it runs at a constant rate, regardless of pc perfornamce so physics can be calculated properly
    /// </summary>
    private void FixedUpdate()
    {
        //Set the velocity to the direction they're moving in, multiplied
        //by the speed they're moving
        rb.velocity = playerDirection.normalized * (playerSpeed * playerMaxSpeed) * Time.fixedDeltaTime;

        if (Sheild_functions.IsShieldEnabled())
        {
            if (Sheild_functions.GetShieldTime() <= 0)
            {
                Sheild_functions.EndShield();
            }
        }

        if (speed_functions.IsSpeedEnabled())
        {
            if (speed_functions.GetSpeedTime() <= 0)
            {
                speed_functions.EndSpeedTimer();
            }
        }
    }

    /// <summary>
    /// When the update loop is called, it runs every frame, ca run more or less frequently depending on performance. Used to catch changes in variables or input.
    /// </summary>
    private void Update()
    {
        // read input from WASD keys
        playerDirection.x = Input.GetAxis("Horizontal");
        playerDirection.y = Input.GetAxis("Vertical");

        // check if there is some movement direction, if there is something, then set animator flags and make speed = 1
        if (playerDirection.magnitude != 0)
        {
            animator.SetFloat("Horizontal", playerDirection.x);
            animator.SetFloat("Vertical", playerDirection.y);
            animator.SetFloat("Speed", playerDirection.magnitude);

            //And set the speed to 1, so they move!
            playerSpeed = 1f;

            if (Input.GetKeyDown(KeyCode.R))
                animator.SetTrigger("Rolling");

            if (animator.GetCurrentAnimatorStateInfo(0).IsName("rollTree"))
                playerSpeed = 2f;
        }
        else
        {
            //Was the input just cancelled (released)? If so, set
            //speed to 0
            playerSpeed = 0f;

            //Update the animator too, and return
            animator.SetFloat("Speed", 0);
        }

    }

    public void UpdatePlayerSpeed(float speed)
    {
        playerSpeed = speed;
    }

    public float GetPlayerSpeed()
    {
        return playerSpeed;
    }

    public Vector2 GetPlayerDirection()
    {
        return playerDirection;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("hfrldProjectile"))
        {
            healthSystem.Collidedwith(collision.tag);
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("lfrhdProjectile"))
        {
            healthSystem.Collidedwith(collision.tag);
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("bossProjectile"))
        {
            healthSystem.Collidedwith(collision.tag);
            Destroy(collision.gameObject);
        }

        if (healthSystem.IsPlayerAlive() == false)
        {
            music.StopAllMusic();
            music.StartMusic("gameover");
            SceneManager.LoadScene(2);
        }
    }

    public void UpdateCameraSize(float size)
    {
        cam.orthographicSize = size;
    }

}