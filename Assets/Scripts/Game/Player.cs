using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;

    public GameObject player;
    private Animator anim;
    private Animator bubbleFade;
    private Rigidbody2D myBody;
    private SpriteRenderer sr;
    public ParticleSystem Dust;
    public ParticleSystem Explosion;
    public ParticleSystem GodModePS;
    SpriteRenderer Bubble;

    public float PlayerSpeed = 7;
    float MaxSpeed = 22;

    private float knockBackForce = -5;
    private float jumpForce = 18f;
    private float jumpDownForce = -8f;
    private float jumpDownAndroid = -36f;
    float dashDistance = 6f;
    public float GodModeEffectTime = 5;
    public float ReviveEffectTime = 5f;

    private bool inAir; //New Bool for Jumping Down
    public bool isGrounded;
    public bool Die = false;
    public bool permission = false;
    private bool stopTouch = false;
    public bool isDashing = false;
    public bool isGodMode = false;
    public bool CatRevive = false;
    public bool GameOverPanel = false;

    private bool fingerDown;

    public int pixelDistToDetect = 5;

    

    private string GROUND_TAG = "Ground";
    private string DOG_TAG = "Dog";
    private string CANDY_TAG = "Candy";

    private Vector2 startTouchPos;
    private Vector2 currentTouchPos;
    private Vector2 endTouchPos;

    private void Awake()
    {
        Instance = this;


    }

    void Start()
    {
        StartCoroutine(StartMoving());
        //StartCoroutine(Timeline());

        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        Bubble = GameObject.FindGameObjectWithTag("Bubble").GetComponent<SpriteRenderer>();
        bubbleFade = GameObject.FindGameObjectWithTag("Bubble").GetComponent<Animator>();
        bubbleFade.SetBool("Fade", false);
    }

    void Update()
    {
        anim.SetBool("Waited", permission);
        anim.SetFloat("yVelocity", myBody.velocity.y);
    }

    private void FixedUpdate()
    {
        if (!Die && permission)
        {
            MovePlayer();
            if(PlayerSpeed < MaxSpeed)
            {
                PlayerSpeed += 0.2f * Time.deltaTime;
            }
            else if (PlayerSpeed >= MaxSpeed)
            {
                PlayerSpeed = MaxSpeed;
            }
        }
        else if (CatRevive)
        {
            if (!Die && permission)
            {
                MovePlayer();
                if (PlayerSpeed < MaxSpeed)
                {
                    PlayerSpeed += 0.2f * Time.deltaTime;
                }
                else if (PlayerSpeed >= MaxSpeed)
                {
                    PlayerSpeed = MaxSpeed;
                }
            }
        }

        Swipe();
        JumpUp();
        JumpDown();
        

        if (Input.GetKey(KeyCode.V) && !isDashing && !isGrounded && inAir)
        {
            StartCoroutine(Dash(1f));
        }
    }

    #region Physics
    private void MovePlayer()
    {
        player.transform.Translate(Vector2.right * PlayerSpeed * Time.deltaTime);
    }

    void JumpUp() 
    {
        if (Input.GetKey(KeyCode.X) && isGrounded && permission && !Die)
        {
            CreateDust();
            isGrounded = false;
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            inAir = true; //When Jump, cat will be in air state
            anim.SetBool("AirState", true);

            if (isGodMode == false)
            {
                FindObjectOfType<AudioManager>().Play("UpDown");
            }

            else
            {
                FindObjectOfType<AudioManager>().StopPlaying("UpDown");
            }
        }
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            isGrounded = true;
            inAir = false; //Touching the ground means, not in air
            anim.SetBool("AirState", false);
            CreateDust();
        }

        if (collision.gameObject.CompareTag(DOG_TAG))
        {
            if (isDashing || isGodMode)
            {
                Die = false;
                Explosion.Play();
            }
            else
            {
                Die = true;
                myBody.AddForce(new Vector2(knockBackForce, 1), ForceMode2D.Impulse); //effect for knockback
                FindObjectOfType<AudioManager>().Play("DogHit");
                FindObjectOfType<AudioManager>().Mute("BGM");
                StartCoroutine(CatDie());         //StartCoroutine(DieFunction()); //Functions to do after dying
            }

            if (Die && !CatRevive)
            {
                MechanicUIManager.instance.FD();
            }

            if (Die && CatRevive)
            {
                MechanicUIManager.instance.LD();
            }

            
        }

        if (collision.gameObject.CompareTag(CANDY_TAG))
        {
            if (isDashing || isGodMode)
            {
                Die = false;
                Explosion.Play();
            }
            else
            {
                Die = true;
                myBody.AddForce(new Vector2(knockBackForce, 1), ForceMode2D.Impulse); //effect for knockback
                FindObjectOfType<AudioManager>().Play("CandyHit");
                FindObjectOfType<AudioManager>().Mute("BGM");
                StartCoroutine(CatDie());         //StartCoroutine(DieFunction()); //Functions to do after dying
            }

            if (Die && !CatRevive)
            {
                MechanicUIManager.instance.FD();
            }

            if (Die && CatRevive)
            {
                MechanicUIManager.instance.LD();
            }
        }
    }

    void JumpDown()
    {
        if (Input.GetKey(KeyCode.C) && inAir && !Die)
        {
            myBody.AddForce(new Vector2(0, jumpDownForce), ForceMode2D.Impulse);
            
        }


        
    }

    

    public void DashButton()
    {
        if (!isDashing && !isGrounded && inAir && !isGodMode)
        {
            StartCoroutine(Dash(1f));
        }
    }

    public void GodModeButton()
    {
        if (!Die && permission)
        {
            StartCoroutine(GodMode());
        }
    }

    void Swipe()
    {
        if (fingerDown == false && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            startTouchPos = Input.touches[0].position;
            fingerDown = true;
        }

        if (fingerDown)
        {
            if (Input.touches[0].position.y >= startTouchPos.y + pixelDistToDetect && isGrounded && permission && !Die)
            {
                fingerDown = false;
                CreateDust();
                isGrounded = false;
                myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                inAir = true; //When Jump, cat will be in air state
                anim.SetBool("AirState", true);

            }

            if (Input.touches[0].position.y <= startTouchPos.y - pixelDistToDetect && inAir && !Die)
            {
                fingerDown = false;
                myBody.AddForce(new Vector2(0, jumpDownAndroid), ForceMode2D.Impulse);
            }

        }
        if (fingerDown && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended)
        {
            fingerDown = false;

        }

    }
    public void ReviveButton()
    {
        StartCoroutine(Revive());
    }

    void CreateDust()
    {
        Dust.Play();
    }
    #endregion

    #region Ienumarators
    IEnumerator StartMoving()
    {
        yield return new WaitForSeconds(3);
        permission = true;
    }

    //IEnumerator Timeline() //Timeline management for global scripts
    //{
    //    yield return new WaitForSeconds(5);
    //    PlayerSpeed = 13;
    //    Debug.Log("cam is now 11");

    //    yield return new WaitForSeconds(10);
    //    PlayerSpeed = 16;
    //    Debug.Log("cam is now 12");

    //    yield return new WaitForSeconds(15);
    //    PlayerSpeed = 19;
    //    Debug.Log("cam is now 13");

    //    yield return new WaitForSeconds(20);
    //    PlayerSpeed = 22;
    //    Debug.Log("cam is now 14");

    //    yield return new WaitForSeconds(25);
    //    PlayerSpeed = 25;
    //    Debug.Log("cam is now 15");

    //    yield return new WaitForSeconds(30);
    //    PlayerSpeed = 28;
    //    Debug.Log("cam is now 16");

    //    yield return new WaitForSeconds(40);
    //    PlayerSpeed = 31;
    //    Debug.Log("cam is now 17");
    //}

    IEnumerator Dash(float direction)
    {
        GodModePS.Play();
        FindObjectOfType<AudioManager>().Play("Dash");
        Ghosting.instance.makeGhost = true;
        isDashing = true;
        myBody.velocity = new Vector2(myBody.velocity.x, 0f);
        myBody.AddForce(new Vector2(dashDistance * direction, 0f), ForceMode2D.Impulse);
        float gravity = myBody.gravityScale;
        myBody.gravityScale = 0;
        yield return new WaitForSeconds(0.6f);
        GodModePS.Pause();
        Ghosting.instance.makeGhost = false;
        isDashing = false;
        myBody.gravityScale = gravity;
    }

    IEnumerator GodMode()
    {
        GodModePS.Play();

        FindObjectOfType<AudioManager>().Play("Bubble");

        PlayerSpeed = 31;
        isGodMode = true;
        jumpForce = 8.5f;
        float gravity = myBody.gravityScale;
        myBody.gravityScale = 0.7f;
        Bubble.GetComponent<SpriteRenderer>().enabled = true;

        yield return new WaitForSeconds(GodModeEffectTime + PointSystem.GodSecond);
        PlayerSpeed = 13;
        bubbleFade.SetBool("Fade", true);
        yield return new WaitForSeconds(2f);
        bubbleFade.SetBool("Fade", false);
        Bubble.GetComponent<SpriteRenderer>().enabled = false;
        GodModePS.Pause();
        isGodMode = false;
        jumpForce = 18f;
        myBody.gravityScale = gravity;
        FindObjectOfType<AudioManager>().Play("Bubble Bursts");
    }

    IEnumerator Revive()
    {
        GodModePS.Play();
        FindObjectOfType<AudioManager>().Play("Bubble");
        anim.SetBool("Die", false);
        PlayerSpeed = 31;
        Die = false;
        permission = true;
        isGodMode = true;
        jumpForce = 8.5f;
        CatRevive = true;
        FindObjectOfType<AudioManager>().Play("Revive");
        float gravity = myBody.gravityScale;
        myBody.gravityScale = 0.7f;
        Bubble.GetComponent<SpriteRenderer>().enabled = true;

        yield return new WaitForSeconds(ReviveEffectTime + PointSystem.ReviveSecond);
        PlayerSpeed = 15;
        bubbleFade.SetBool("Fade", true);
        yield return new WaitForSeconds(2f);
        bubbleFade.SetBool("Fade", false);
        GodModePS.Pause();
        isGodMode = false;
        Bubble.GetComponent<SpriteRenderer>().enabled = false;
        jumpForce = 18f;
        myBody.gravityScale = gravity;
        FindObjectOfType<AudioManager>().Play("Bubble Bursts");
    }

    IEnumerator CatDie()
    {
        
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("Die", true);
        yield return new WaitForSeconds(0.5f);
        GameOverPanel = true;
    }


    #endregion
}
