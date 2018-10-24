using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

public class Game_Controller : MonoBehaviour
{
    private Animator anim;
    private float dirX;
    public float speed = 5f, jumpForce = 700f;
    private Vector2 bullet_position;
    public GameObject fireball;
    public int health;
    private bool canMove = true;
    private bool canJump = true;
    Rigidbody2D rb;
    public bool red, blue, green, yellow = false;
    public bool redKey, blueKey, greenKey, yellowKey= false;
    private bool atRed, atBlue, atGreen, atYellow = false;
    private GameObject keyButton;
    private Vector2 respawnPoint;
    private bool nextLevel = false;
    private GameObject gameOverMenu, levelCompleteMenu;
    private GameObject GUI;
    private Audio_Manager audioManager;
    void Start()
    {
        //Almacena la ubicacion inicial del personaje.
        respawnPoint = transform.position;

        //Obtiene los componentes necesarios.
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        GUI = GameObject.Find("GUI");

        //Obtiene los componentes de los diferentes menus y los desactiva.
        gameOverMenu = GameObject.Find("GameOver");
        gameOverMenu.SetActive(false);
        levelCompleteMenu = GameObject.Find("LevelComplete");
        levelCompleteMenu.SetActive(false);

        //Obtiene los componentes del boton Key y lo desactiva.
        keyButton = GameObject.Find("KeyButton");
        keyButton.SetActive(false);

        //Controla el AudioManager.
        audioManager = Audio_Manager.instance;

    }
    
    void Update()
    {
        
        //Gestiona las animaciones necesarias.
        anim.SetBool("walk", false);
        anim.SetBool("fire", false);
        if(rb.velocity.y == 0)
        {
            anim.SetBool("jump", false);
        }

        //Gestiona los controles del personaje en funcion del boton que se pulse.

        dirX = CrossPlatformInputManager.GetAxisRaw("Horizontal");

        if (CrossPlatformInputManager.GetButtonDown("Jump")) 
        {
            doJump();
        }

        if (CrossPlatformInputManager.GetButtonDown("Fire"))
        {
            Fire();
        }

        if (CrossPlatformInputManager.GetButtonDown("Key"))
        {
            Key();
        }

        //Rota el sprite del personaje en funcion de la direccion en la que camine.
        if (dirX > 0)
        {
           transform.eulerAngles = new Vector2(0, 0);
           anim.SetBool("walk", true);
        }
        if (dirX < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
            anim.SetBool("walk", true);
        }


        NextLevel();
        GameOverMenu();
    }

    void FixedUpdate()
    {
        //Aplica el movimiento al personaje.
        if (canMove)
        {
            rb.velocity = new Vector2(dirX * speed, rb.velocity.y);
        }
    }

    //Salto
    public void doJump()
    {
        if(canJump)
        {
            rb.velocity = new Vector3(0, 0, 0);
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Force);
            anim.SetBool("jump", true);
            audioManager.PlaySound("Jump");
        }
    }

    //Disparo
    public void Fire()
    {
        bullet_position = transform.position + new Vector3(0.3f, -0.3f, 0);
        Instantiate(fireball, bullet_position, transform.rotation);
        anim.SetBool("fire", true);
        audioManager.PlaySound("Fire");
    }

    //Si se tiene la llave correcta, activa la bandera.
    public void Key()
    {
        if (redKey && atRed)
        {
            red = true;
            audioManager.PlaySound("Key");
        }
        if (blueKey && atBlue)
        {
            blue = true;
            audioManager.PlaySound("Key");
        }
        if (greenKey && atGreen)
        {
            green = true;
            audioManager.PlaySound("Key");
        }
        if (yellowKey && atYellow)
        {
            yellow = true;
            audioManager.PlaySound("Key");
        }
    }

    //Eventos para cuando un enemigo daña al personaje.
    public void CanMove()
    {
        canMove = true;
    }
    public void CantMove()
    {
        canMove = false;
    }

    //Si se han activado todas las banderas y se llega al final, avanza al siguiente nivel.
    public void NextLevel()
    {
        if(red && blue && green && yellow)
        {
            nextLevel = true;
        }
    }

    //Activa el menu de GameOver cuando no quedan vidas.
    void GameOverMenu()
    {
        if (health <= 0)
        {   
            gameOverMenu.SetActive(true);
            GUI.SetActive(false);
            audioManager.PlaySound("Loose");
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Al chocar con enemigos pierde vida.
        if (collision.tag.Equals("Enemy"))
        {
            health --;
            anim.Play("Player_damaged");
            audioManager.PlaySound("Damaged");
        }

        if (collision.tag.Equals("Killer"))
        {
            health--;
            anim.Play("Player_damaged");
            audioManager.PlaySound("Respawn");
            transform.position = respawnPoint;
        }


        //Marca el siguiente punto de respawn.
        if (collision.tag.Equals("Respawn"))
        {
            respawnPoint = collision.transform.position + new Vector3(0, 1);
        }

        //Si se cumplen los requisitos activa el menu de nivel superado.
        if (collision.tag.Equals("Finish"))
        {
            if (nextLevel)
            {
                levelCompleteMenu.SetActive(true);
                GUI.SetActive(false);
                audioManager.PlaySound("Win");
            }
        }


        //Recoge la llave correspondiente.
        if (collision.tag.Equals("Key_Red"))
        {
            Destroy(collision.gameObject);
            redKey = true;
            audioManager.PlaySound("Key");
        }
        if (collision.tag.Equals("Key_Blue"))
        {
            Destroy(collision.gameObject);
            blueKey = true;
            audioManager.PlaySound("Key");
        }
        if (collision.tag.Equals("Key_Green"))
        {
            Destroy(collision.gameObject);
            greenKey = true;
            audioManager.PlaySound("Key");
        }
        if (collision.tag.Equals("Key_Yellow"))
        {
            Destroy(collision.gameObject);
            yellowKey = true;
            audioManager.PlaySound("Key");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        //Activa el boton Key y marca en que Lock te encuentras.
        if (collision.tag.Equals("Lock_Red"))
        {
            keyButton.SetActive(true);
            atRed = true;
        }
        if (collision.tag.Equals("Lock_Blue"))
        {
            keyButton.SetActive(true);
            atBlue = true;
        }
        if (collision.tag.Equals("Lock_Green"))
        {
            keyButton.SetActive(true);
            atGreen = true;
        }
        if (collision.tag.Equals("Lock_Yellow"))
        {
            keyButton.SetActive(true);
            atYellow = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Desactiva el boton Key.
        if (collision.tag.Equals("Lock_Red"))
        {
            keyButton.SetActive(false);
            atRed = false;
        }
        if (collision.tag.Equals("Lock_Blue"))
        {
            keyButton.SetActive(false);
            atBlue = false;
        }
        if (collision.tag.Equals("Lock_Green"))
        {
            keyButton.SetActive(false);
            atGreen = false;
        }
        if (collision.tag.Equals("Lock_Yellow"))
        {
            keyButton.SetActive(false);
            atYellow = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag.Equals("Platform"))
        {
            gameObject.transform.parent = collision.transform;
            canJump = true;
        }

        //Permite saltar cuando se entra en contacto con el suelo.
        if (collision.gameObject.tag.Equals("Ground"))
        {
            canJump = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        //Hace parent a la plataforma para moverse con ella.
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //La plataforma deja de ser parent.
        if (collision.gameObject.tag.Equals("Platform"))
        {
            gameObject.transform.parent = null;
            canJump = false;
        }

        //Impide saltar cuando se separa del suelo.
        if (collision.gameObject.tag.Equals("Ground"))
        {
            canJump = false;
        }
    }
}
