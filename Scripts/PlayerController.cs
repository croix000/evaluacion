using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float jumpforce;
    Rigidbody2D rigidbody2D;
    Vector2 movement;
    [SerializeField] float speed = 2f;
    SpriteRenderer spriteRenderer;
    Animator animator;
    public int life = 3;
    public int power = 50;


    Vector3 startPosition;
    public delegate void LifeStoneCollected();
    public event LifeStoneCollected onLifeStoneCollected;



    public delegate void PowerUpdated();
    public event PowerUpdated onPowerUpdated;


    public delegate void RockJumped();
    public event RockJumped onRockJumped;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Store the current horizontal input in the float moveHorizontal.
        float horizontal = Input.GetAxis("Horizontal");

        //Store the current vertical input in the float moveVertical.
        float vertical = Input.GetAxis("Vertical");

        //Use the two store floats to create a new Vector2 variable movement.
        Vector2 movement = new Vector2(horizontal, vertical);

        transform.position += new Vector3(movement.x, movement.y, 0) * Time.deltaTime * speed;

        if (Input.GetKeyDown("space") && Mathf.Abs(rigidbody2D.velocity.y)<0.001f)
        {
            rigidbody2D.AddForce(new Vector2(0, jumpforce), ForceMode2D.Impulse);
        }

        if (horizontal > 0)
        {
            spriteRenderer.flipX = true;
            animator.SetFloat("speed", 1);
        }
        else if (horizontal < 0)
        {

            spriteRenderer.flipX = false;

            animator.SetFloat("speed", 1);
        }
        else if (horizontal == 0) {

            animator.SetFloat("speed", 0);
        }

        if (Mathf.Abs(rigidbody2D.velocity.y) < 0.001f)
            animator.SetBool("grounded", true);
        else
            animator.SetBool("grounded", false);


    }



    public void LifeStoneCollision()
    {
        onLifeStoneCollected();
    }

    public void GiveLife() {
        life++;
    }


    public void ModifyPower(int modifier) {

        this.power += modifier;

        if (power > 100)
            power = 100;
        else if (power < 0)
            Die();

        onPowerUpdated();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Cat") {

            ModifyPower(20);
        }
        else if (collision.gameObject.tag == "Enemy")
        {

            Die();

        }
        else if (collision.gameObject.tag == "Rock")
        {

            RockLogic();

        }
    }
    void Die() {

        life--;
        if (life < 0)
            life = 0;
        transform.position = startPosition;
        rigidbody2D.velocity = Vector3.zero;
        power = 50;
        onPowerUpdated();
    }

    public void RockLogic()
    {

        onRockJumped();


    }
}
