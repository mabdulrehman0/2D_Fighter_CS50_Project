using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class Character1 : MonoBehaviour
{
    public float speed = 1f;

    public Character2 enemy;

    public KeyCode move_left_1;
   
    public KeyCode move_right_1;

    public KeyCode light_attack1;

    public KeyCode Attack1;

    public int maxhealth = 100;

    public int currenthealth;

    public Health_bar health_Bar;

    public Rigidbody2D rb;

    public BoxCollider2D hitbox;

    public EdgeCollider2D attackhitbox;

    public EdgeCollider2D smallattackhitbox;

    public Animator animator;

    public SpriteRenderer spriteRenderer;

    private bool dead = false;

    public WinUI winUI;

    

    public float movement = 0f;

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




    // start of the game
    private void Start()
    {
        move_left_1 = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Moveleft1", "LeftArrow"));
        move_right_1 = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Moveright1", "RightArrow"));
        light_attack1 = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Light_attack_1", "K"));
        Attack1 = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Attack1", "L"));

        currenthealth = maxhealth;
        health_Bar.setmaxhealth(maxhealth);
    }

    // Update is called once per frame
    void Update()
    {
        

        movement = 0f;

        if (Input.GetKey(move_right_1))
        {
            movement = 1f;
        }
        else if (Input.GetKey(move_left_1))
        {
            movement = -1f;
        }


        if (Input.GetKeyDown(light_attack1))
        {
            animator.SetTrigger("attack1");
        }
        else if (Input.GetKeyDown(Attack1))
        {
            animator.SetTrigger("attack2");
        }

        if (!dead && currenthealth <= 0)
        {
            Debug.Log("player dead");
            dead = true;
            animator.SetTrigger("death");
            winUI.winplayer(2);
            Audio.instance.Play_win();
            Debug.Log("sound worked, win");
        }

        animator.SetFloat("speed", Mathf.Abs(movement));

        // the sprite direction changer 
        if (movement == -1)
        {
            spriteRenderer.flipX = true;
        }
        if (movement == 1)
        {
            spriteRenderer.flipX = false;
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(movement * speed, rb.linearVelocity.y);   
    }

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
        if (attackhitbox.enabled && other.CompareTag("Player2"))
        {
            other.GetComponent<Character2>().damage(20);
            Debug.Log("Hit Player 2!");
        }
        else if (smallattackhitbox.enabled && other.CompareTag("Player2"))
        {
            other.GetComponent<Character2>().damage(5);
            Debug.Log("Quick Attack Hit Player 2!");
        }
    }

}
