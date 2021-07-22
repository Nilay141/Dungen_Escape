using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour, IDamageable
{
    //using  [SerializeField] so we can change value of variable from inspecter in unity

    [SerializeField] private float n_jumpForce = 5.0f;    //using jumpforce to jump
    private bool n_resetJump = false;                     //logic to reset the jump 
    [SerializeField] private float n_playerSpeed = 5.0f;  //to increases speed
    [SerializeField] private LayerMask n_groundLayer;     // layer of ground objects used for detection
    [SerializeField] private int n_health;

    private Rigidbody2D n_rigid;                  //get handle for rigidbody
    private PlayerAnimation n_playerAnim;         //handle to playeranimation
    private SpriteRenderer n_playerSprite;        //handle the spriterenderer for first  element 0 of player
    private SpriteRenderer n_swordArcSprite;      //handle the Spriterenderer for second element 1 of player
    
    private bool n_grounded = false;   //to check ground for jumping

    public int Health { get; set; }
    public int Diamonds;
    protected bool isDead = false;   //to check if player is dead or not
    protected bool isHit = false;    //to check if player got hit by enemy

    
    // Start is called before the first frame update
    void Start()
    {
        //assign handle of rigid body
        n_rigid = GetComponent<Rigidbody2D>();
        n_playerAnim = GetComponent<PlayerAnimation>();
        n_playerSprite = GetComponentInChildren<SpriteRenderer>();
        n_swordArcSprite = transform.GetChild(1).GetComponent<SpriteRenderer>();
        Health = 5;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Attack();
    }
   
    
    void Movement()
    {
        //horizontal input to move left/right
        //pn(personal notes): using GetAxisRaw to get more smooth transitions
        //pn: Horizontal we can use a or d or -> or <- keys for movement
        #if MOBILE_INPUT
        float move = CrossPlatformInputManager.GetAxisRaw("Horizontal");
        #endif
        #if !MOBILE_INPUT
		float move = Input.GetAxisRaw("Horizontal");
        #endif

        n_grounded = IsGrounded();
        // Flip Sprite in X if move is < 0
        if (move > 0)
        {
            FlipSprite(true);
        }
        else if (move < 0)
        {
            FlipSprite(false);
        }
               
        //for jump
        #if MOBILE_INPUT
		if (CrossPlatformInputManager.GetButtonDown("B_Button") && IsGrounded()) {
			
			n_rigid.velocity = new Vector2(n_rigid.velocity.x, n_jumpForce);
			n_playerAnim.Jump(true);
            StartCoroutine(ResetJumpneededRoutine());

        }

        #endif
        #if !MOBILE_INPUT
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded() == true)
        {
            n_rigid.velocity = new Vector2(n_rigid.velocity.x, n_jumpForce); 
            n_playerAnim.Jump(true);                    //for juming anim
            StartCoroutine(ResetJumpneededRoutine());   //calling coroutine
        }
       
        #endif

        #if MOBILE_INPUT
        if (CrossPlatformInputManager.GetButtonDown("S_Jump") && IsGrounded() == true)
        {
            n_rigid.velocity = new Vector2(n_rigid.velocity.x, n_jumpForce * 2);
            n_playerAnim.Jump(true);                    //for juming anim
            StartCoroutine(ResetJumpneededRoutine());   //calling coroutine
        }
        #endif

        #if !MOBILE_INPUT
		 if (Input.GetKeyDown(KeyCode.W) && IsGrounded() == true)
        {
            n_rigid.velocity = new Vector2(n_rigid.velocity.x, n_jumpForce * 2);
            n_playerAnim.Jump(true);                    //for juming anim
            StartCoroutine(ResetJumpneededRoutine());   //calling coroutine
        }

        #endif
        n_rigid.velocity = new Vector2(move * n_playerSpeed, n_rigid.velocity.y);
        //for animation 
        n_playerAnim.Move(move);

    }
    void Attack()
    {
        #if MOBILE_INPUT
        if (CrossPlatformInputManager.GetButtonDown("A_Button") && IsGrounded())
        {
            n_playerAnim.Attack();
        }
        #endif

        #if !MOBILE_INPUT
		if (Input.GetMouseButtonDown(0) && IsGrounded() == true)
        {
           n_playerAnim.Attack();
        }
        #endif
       
    }
    bool IsGrounded()
    {
        //2D Raycast hit to check if u are grounded again or not
        RaycastHit2D n_hitinfo = Physics2D.Raycast(transform.position, Vector2.down, 1f, n_groundLayer.value);
        Debug.DrawRay(transform.position, Vector2.down, Color.green);
        if (n_hitinfo.collider != null)
        {
            if (n_resetJump == false)
            {
                n_playerAnim.Jump(false);
                return true;
            }
        }
        return false;
    }
    void FlipSprite(bool faceRight)
    {
        if(n_playerSprite != null) {
            if (faceRight == true)
            {
                n_playerSprite.flipX = false;

                n_swordArcSprite.flipX = false;
                n_swordArcSprite.flipY = false;
                Vector3 newPos = n_swordArcSprite.transform.localPosition;
                newPos.x = 1.01f;
                n_swordArcSprite.transform.localPosition = newPos;

            }
            else if (faceRight == false)
            {
                n_playerSprite.flipX = true;

                n_swordArcSprite.flipX = true;
                n_swordArcSprite.flipY = true;
                Vector3 newPos = n_swordArcSprite.transform.localPosition;
                newPos.x = -1.01f;
                n_swordArcSprite.transform.localPosition = newPos;
            }
        } 
    }
    IEnumerator ResetJumpneededRoutine()
    {
        n_resetJump = true;
        yield return new WaitForSeconds(0.1f);
        n_resetJump = false;
    }
    //to add gem in HUD Panel
    public void AddGems(int amount)
    {
        Diamonds += amount; //add gems to Daimonds
        UIManager.Instance.UpdateGemCount(Diamonds);
    }
    public void Damage()
    {
        if (isDead == true)
        {
            return;
        }
        Debug.Log("Damage(in Player)");
        Health -= 1;
        n_playerAnim.Hit();
        isHit = true;
        UIManager.Instance.UpdateLives(Health);
       
        
        if (Health < 1)
        {
            isDead = true;
            n_playerAnim.Death();
            SceneManager.LoadScene("GameOver");
            //Instantiating to get diamond after enemy dies
           //GameObject n_diamond = Instantiate(n_diamondPrefab, transform.position, Quaternion.identity) as GameObject;
            //changing gems value using n_diamond to local gems value using base.gems
            //n_diamond.GetComponent<Diamond>().n_gems = base.gems;

        }
    }
    
}
