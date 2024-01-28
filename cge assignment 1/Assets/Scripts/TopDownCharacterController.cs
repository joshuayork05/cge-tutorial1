using System.Collections;
using System.Collections.Generic;
using UnityEditor.MPE;
using UnityEngine;

public class TopDownCharacterController : MonoBehaviour
{
    [SerializeField] GameObject m_projectilePreFab;
    [SerializeField] Transform m_firepoint;
    [SerializeField] float m_projectileSpeed;
    [SerializeField] ShieldSystem Sheild_functions;
    [SerializeField] SpeedSystem speed_functions;
    [SerializeField] private float m_cooldownLength = 1f;
    [SerializeField] private float m_maxAmmo = 10;
    [SerializeField] private float m_ammo;
    [SerializeField] private float projectile_damage = 1;

    private float m_timer;

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
    private void Awake()
    {
        //Get the attached components so we can use them later
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    /// <summary>
    /// Called after Awake(), and is used to initialize variables e.g. set values on the player
    /// </summary>
    private void Start()
    {
        m_ammo = m_maxAmmo;
    }

    /// <summary>
    /// When a fixed update loop is called, it runs at a constant rate, regardless of pc perfornamce so physics can be calculated properly
    /// </summary>
    private void FixedUpdate()
    {
        //Set the velocity to the direction they're moving in, multiplied
        //by the speed they're moving
        rb.velocity = playerDirection.normalized * (playerSpeed * playerMaxSpeed) * Time.fixedDeltaTime;
        m_timer -= Time.deltaTime;

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
        }
        else
        {
            //Was the input just cancelled (released)? If so, set
            //speed to 0
            playerSpeed = 0f;

            //Update the animator too, and return
            animator.SetFloat("Speed", 0);
        }

        // Was the fire button pressed (mapped to Left mouse button or gamepad trigger)
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
        /*
        if (Input.GetButtonDown("Fire2"))
        {
            //Shoot (well debug for now)
            block.transform.parent = transform;
        }
        if (Input.GetButtonUp("Fire2"))
        {
            //Shoot (well debug for now)
            block.transform.parent = null;
        }*/
    }

    void Fire()
    {
        if (m_timer <= 0)
        {
            GameObject projectileToSpawn = Instantiate(m_projectilePreFab, transform.position, Quaternion.identity); //thing being spawned, location, rotation

            //ensures the projectile fired has a consistent speed
            projectileToSpawn.GetComponent<Rigidbody2D>().AddForce(playerDirection.normalized * m_projectileSpeed, ForceMode2D.Impulse);

            m_ammo -= 1;
            m_timer = m_cooldownLength;

            if (m_ammo == 0)
            {
                m_timer += 3;
                m_ammo = m_maxAmmo;
            }
        }
        else
        {
            //used mainly for debugging but I doubt it will be used.
            Debug.Log($"In cooldown!");
        } 
    }

    public void UpdatePlayerSpeed(float speed)
    {
        playerMaxSpeed = speed;
    }

    public void UpdateFireRate(float amount)
    {
        m_cooldownLength -= amount;
    }

    public void updateProjectileDamage(float amount)
    {
        Debug.Log($"Current Damage Output: {projectile_damage}");
        projectile_damage += amount;
        Debug.Log($"Current Damage Output: {projectile_damage}");
    }
}
