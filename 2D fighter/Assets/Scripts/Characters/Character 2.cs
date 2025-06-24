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
    // varibles duh ^_^
    public float speed = 1f;

    public Character1 enemy;

    public KeyCode move_left_2;

    public KeyCode move_right_2;

    public KeyCode light_attack2;

    public KeyCode Attack2;

    public int maxhealth = 100;

    public int currenthealth;

    public Health_bar2 health_Bar;

    public Rigidbody2D rb;

    public BoxCollider2D hitbox;

    public EdgeCollider2D attackhitbox;

    public EdgeCollider2D smallattackhitbox;
    
    public Animator animator;

    public SpriteRenderer spriteRenderer;

    public float movement = 0f;

    private bool dead = false;

    public WinUI winUI;


    //attack animation section
    public void enable_attack_hitbox()
    {
        attackhitbox.enabled = true;
        Audio.instance.PlayAttack();
        Debug.Log("sound worked, attack");
    }

    public void disable_attack_hitbox ()
    {
        attackhitbox.enabled = false;
    }

    public void enable_quick_attack()
    {
        smallattackhitbox.enabled = true;
        Audio.instance.PlayLightAttack();
        Debug.Log("sound worked, light attack");
    }
    public void disable_quick_attack()
    {
        smallattackhitbox.enabled = false;
    }

    // setting the health
    private void Start()
    {
        move_left_2 = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Moveleft2", "A"));
        move_right_2 = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Moveright2", "D"));
        light_attack2 = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Light_attack_2", "F"));
        Attack2 = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Attack2", "G"));

        currenthealth = maxhealth;
        health_Bar.setmaxhealth(maxhealth);
    }

    // Update is called once per frame
    void Update()
    {

        // basically needed for movement and keybinds for movements
        movement = 0f;

        if (Input.GetKey(move_right_2))
        {
            movement = 1f;
        }
        else if (Input.GetKey(move_left_2))
        {
            movement = -1f;
        }


        // key binds for attacking (not flexible)
        if (Input.GetKeyDown(light_attack2))
        {
            animator.SetTrigger("attack1");
        }
        else if (Input.GetKeyDown(Attack2))
        {
            animator.SetTrigger("attack2");
        }

        // death check
        if (!dead && currenthealth <= 0)
        {
            Debug.Log("player dead");
            dead = true;
            animator.SetTrigger("death");
            winUI.winplayer(1);
            Audio.instance.Play_win();
            Debug.Log("sound worked, win");
        }

        // the sprite direction changer (mint)
        animator.SetFloat("speed", Mathf.Abs(movement));

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


