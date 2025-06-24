using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;
using Unity.VisualScripting;


public class Character2 : MonoBehaviour
{
    // below the are the varibles which are being used for multiple reasons

    // To set the speed of the characters.
    public float speed = 1f;

    // Referencing the enemy character for attack hit and damage hit box
    public Character1 enemy;

    // Varibles that have the keybinds of default keys and if modified thent these are the modified keys
    public KeyCode move_left_2, move_right_2, light_attack2, Attack2;

    // For health system.
    public int maxhealth = 100;
    public int currenthealth;
    public Health_bar2 health_Bar;

    // for movement and hitbox colliders.
    public Rigidbody2D rb;
    public BoxCollider2D hitbox;
    public EdgeCollider2D attackhitbox, smallattackhitbox;

    // To make animation be controllable through the scripts.
    public Animator animator;

    // using and modifieing values of SpriteRenderer component for flipping of characters when moving in different directions.
    public SpriteRenderer spriteRenderer;
    // a variable for checking death.
    private bool dead = false;

    // basically importing the winui Controls when a player wins and loses.
    public WinUI winUI;

    // for setting the horizontall movement.
    public float movement = 0f;

    // enabling the attack hitbox for colliding theattackhitbox and the hitbox of the other character
    public void enable_attack_hitbox()
    {
        attackhitbox.enabled = true;
        Audio.instance.PlayAttack();
    }

    // disabling the above attack hitbox
    public void disable_attack_hitbox()
    {
        attackhitbox.enabled = false;
    }

    // same the as the attack box but slightly different hot box size for a completely different attack
    public void enable_quick_attack()
    {
        smallattackhitbox.enabled = true;
        Audio.instance.PlayLightAttack();
    }
    // disabling the above attackhitbox
    public void disable_quick_attack()
    {
        smallattackhitbox.enabled = false;
    }

    // Start of the game
    private void Start()
    {
        // importing the keybinds from Player Prefs
        move_left_2 = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Moveleft2", "A"));
        move_right_2 = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Moveright2", "D"));
        light_attack2 = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Light_attack_2", "F"));
        Attack2 = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Attack2", "G"));

        // setting the correct health.
        currenthealth = maxhealth;
        health_Bar.setmaxhealth(maxhealth);
    }

    // Update is called once per frame
    void Update()
    {
        /*  setting the movement to 0 every frame and then check if key is held down the movement will go to 1 or -1 depending
       on the key which is pressed */
        movement = 0f;

        if (Input.GetKey(move_right_2))
        {
            movement = 1f;
        }
        else if (Input.GetKey(move_left_2))
        {
            movement = -1f;
        }


        // setting off the animation triggers according to keys pressed for attacks
        if (Input.GetKeyDown(light_attack2))
        {
            animator.SetTrigger("attack1");
        }
        else if (Input.GetKeyDown(Attack2))
        {
            animator.SetTrigger("attack2");
        }

        // checking if the players is dead or not and if yes then enabling the win logic
        if (!dead && currenthealth <= 0)
        {
            Debug.Log("player dead");
            dead = true;
            animator.SetTrigger("death");
            winUI.winplayer(1);
            Audio.instance.Play_win();
        }

        // setting the bool condition for idle animation
        animator.SetFloat("speed", Mathf.Abs(movement));

        // the sprite direction changer 
        if (movement == 1)
        {
            spriteRenderer.flipX = false;
        }
        if (movement == -1)
        {
            spriteRenderer.flipX = true;
        }
    }


    // basically the movement system
    void FixedUpdate()
    {
        // this how the players moves the characters. Helped by chatgpt by figuring out which method to use as i did not know
        rb.linearVelocity = new Vector2(movement * speed, rb.linearVelocity.y);
    }

    // damage function to decrease the healthbar
    public void damage(int damage)
    {
        if (dead) return;

        currenthealth -= damage;
        health_Bar.sethealth(currenthealth);

        if (currenthealth > 0)
        {
            animator.SetTrigger("hit");
            Audio.instance.Playhit();
            Debug.Log("sound worked, hit");
        }
    }

    // Checking if colliders have collided and doing damage accordingly
    // the compare tag was known by source of chatgpt
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (attackhitbox.enabled && other.CompareTag("Player1"))
        {
            other.GetComponent<Character1>().damage(20);
            Debug.Log("Hit Player 1!");
        }
        else if (smallattackhitbox.enabled && other.CompareTag("Player1"))
        {
            other.GetComponent<Character1>().damage(5);
            Debug.Log("Quick Attack Hit Player 1!");
        }
    }

}


