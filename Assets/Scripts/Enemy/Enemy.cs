using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected int health;
    [SerializeField] protected float speed;
    [SerializeField] protected int gems;
    [SerializeField] protected Transform pointA, pointB;
    protected SpriteRenderer n_enemySprite;
    protected Vector3 n_currentTarget;
    protected Animator n_anim;
    protected bool isHit = false;  //use to check if the enemy is been hit or not 
    protected Player n_player;     //geting player.cs file class
    protected bool isDead = false; //to check if player is dead 
    public GameObject n_diamondPrefab;


    public virtual void Init()
    {
        n_anim = GetComponentInChildren<Animator>();
        n_enemySprite = GetComponentInChildren<SpriteRenderer>();
        n_player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>(); 
    }
    public void Start()
    {
        Init();
    }
    public virtual void Update()
    {
        if (n_anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            return;
        }
        //to stop movement after the enemy is dead we use => isdead
        if(isDead == false)
        {
            Movement();
        }
        
    }

   
    public virtual void Movement()
    {
        if (n_currentTarget == pointA.position)
        {
            n_enemySprite.flipX = true;
        }
        else if (n_currentTarget == pointB.position)
        {
            n_enemySprite.flipX = false;
        }
        float step = speed * Time.deltaTime; // calculate distance to move // Time.deltatime to move gameobject in y direction multiplying it with n(speed)
        if (transform.position == pointA.position)
        {
            n_currentTarget = pointB.position;
            n_anim.SetTrigger("Idle");
        }
        else if (transform.position == pointB.position)
        {
            n_currentTarget = pointA.position;
            n_anim.SetTrigger("Idle");
        }
        if(isHit == false) // enemy is allow to move cuz isHit is false
        {
            transform.position = Vector3.MoveTowards(transform.position, n_currentTarget, step);
        }
        
        //override in specific enemy to calculate diatance of specfic enemy only else it will calculate the duistance of all wnemy inherited classes  
        float n_distance = Vector3.Distance(transform.localPosition, n_player.transform.localPosition); //to check the distance between enemy and us(Player)
        
        if ( n_distance > 2.0f)
        {
            isHit = false;
            n_anim.SetBool("InCombat", false);
           
        }

        //checking direction of enemy 
        Vector3 direction = n_player.transform.localPosition - transform.localPosition;
        //Flip Enemy sprite when in combat with player
        if (direction.x > 0 && n_anim.GetBool("InCombat") == true)
        {
            n_enemySprite.flipX = false;
        }
        else if (direction.x < 0 && n_anim.GetBool("InCombat") == true)
        {
            n_enemySprite.flipX = true;
        }

    }

    


}
