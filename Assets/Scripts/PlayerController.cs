
/*          [  Solo Designs  ]          */
//This script is used to manage the Player

using System;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    [Header("Local Components")]
    Rigidbody2D rb;
    SpriteRenderer rdr;

    [Header("Local Variables")]
    public float thrust = 5f;
    public float jumpThrust = 5f;
    [Header("Scripts Reference")]
    public CameraShake shake;
    public ScaleGameToScreenSize scale;
    [Header("Player Items")]
    public GameObject cam;
    public GameObject score;
    public GameObject Spawner;
    public ParticleSystem GOParticuleEffect;
    public GameObject trail;
    public AudioSource audio;
    public AudioClip loose;
    public AudioClip teleportationSound;
    [Header("Environment")]
    public BoxCollider2D startFloor;
    public SpriteRenderer BG1;
    public SpriteRenderer BG2;
    public Level level1;
    public Level level2;
    public Start start;
    [Header("Animator")]
    public Animator playButton;
    public Animator highScoreText;
    public Animator highScore;
    public Animator previousScoreText;
    public Animator previousScore;
    public Animator tapText;
    public Animator title;
    public Animator Coin;

    public Color32 defaultColor = new Color32(130, 143, 154, 255);

    //Initialize Player for the Main Menu
    private void Start()
    {
        rdr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

        thrust = 0;
        jumpThrust = 0;
        rb.gravityScale = 0f;
        scale.ResizeGame();
        transform.localPosition = new Vector3(0, Spawner.transform.position.y, 0);
    }

    [Obsolete]
    private void Update()
    {
        //Give player velociy horizontally
        Vector3 vx = rb.velocity;
        vx.x = thrust;
        rb.velocity = vx;
        //Give player velocity vertically if jumping
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 vy = rb.velocity;
            vy.y = jumpThrust;
            rb.velocity = vy;
        }

        //When Game Over particule is done, restart the game
        if (!GOParticuleEffect.gameObject.active)
        {
            RestartGame();
        }
    }

    public void GameStart()
    {
        //Lauch play and size proportionaly with the screen size
        gameObject.transform.position = new Vector3(0, Spawner.transform.position.y, -1);
        thrust = 4;
        jumpThrust = 9.5f;
        rb.gravityScale = 2.9f;
        MakePlayerProp();
        //Change the UI of the game (menu to score)
        playButton.SetBool("out", true);
        highScore.SetBool("out", true);
        highScoreText.SetBool("out", true);
        previousScoreText.SetBool("out", true);
        previousScore.SetBool("out", true);
        tapText.SetBool("out", true);
        title.SetBool("out", true);
        score.SetActive(true);
        Coin.SetBool("out", true);
    }

    public void MakePlayerProp()
    {
        float ratio = start.gameObject.transform.localScale.x;
        Vector3 tempScale = transform.localScale *  (ratio*1.0f);
        //Scale the player and values proportionaly to the scene
        transform.localScale = new Vector3(0.55f, 0.55f, 0.55f) - ((transform.localScale - tempScale) / 3);
        thrust = thrust * (ratio*1.0f);
        jumpThrust = jumpThrust * (ratio*1.0f);
        rb.gravityScale = rb.gravityScale * (ratio*1.0f);
    }

    //CHange the player direction when hit wall and kill him when hit obstacles 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            thrust = thrust * -1;
        }

        if(collision.gameObject.tag == "Obstacle")
        {
            GameOver();
        }
    }

    //Put the game in Game Over Mode
    public void GameOver()
    {
        GOParticuleEffect.Play();
        StartCoroutine(shake.Shake(0.4f, 0.08f));
        audio.PlayOneShot(loose);
        Handheld.Vibrate( );
        rb.bodyType = RigidbodyType2D.Static;
        rdr.enabled = false;
        trail.SetActive(false);
    }

    private void RestartGame()
    {
        //Reset the environnment
        start.gameObject.SetActive(true);
        level1.gameObject.transform.position = new Vector3(0, 15, 0);
        level2.gameObject.transform.position = new Vector3(0, 35, 0);
        scale.ResetPosition();
        scale.FixPosition();
        BG1.color = defaultColor;
        BG2.color = defaultColor;
        if (startFloor.isActiveAndEnabled)
            startFloor.enabled = false;
        //Reset the player settings
        gameObject.transform.position = new Vector3(0, Spawner.transform.position.y, -1);
        cam.transform.position = new Vector3(0, 0, -10);
        rb.bodyType = RigidbodyType2D.Dynamic;
        thrust = 0;
        jumpThrust = 0;
        rb.gravityScale = 0f;
        rdr.enabled = true;
        trail.SetActive(true);
        GOParticuleEffect.gameObject.SetActive(true);
        //Reset levels Conditions
        level1.gameOver = true;
        level2.gameOver = true;
        level1.isDead = false;
        level2.isDead = false;
        //Reset the UI
        score.SetActive(false);
        playButton.SetBool("out", false);
        highScore.SetBool("out", false);
        highScoreText.SetBool("out", false);
        previousScoreText.SetBool("out", false);
        previousScore.SetBool("out", false);
        tapText.SetBool("out", false);
        title.SetBool("out", false);
        Coin.SetBool("out", false);
    }

    public void Teleport()
    {
        audio.PlayOneShot(teleportationSound);
    }
}
