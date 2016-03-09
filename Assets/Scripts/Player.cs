using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public InventoryOperator carrying;

    public class PlayerStats
    {
        public int Health = 100;
    }

    public bool win = false;

    public PlayerStats playerStats = new PlayerStats();

    private Rigidbody2D myRigidBody;

    private Animator myAnimator;

    [SerializeField]
    private float movementSpeed;
    private float jumpHeight;

    private bool facingRight;

    public int size;

    // Use this for initialization
    void Start()
    {
        facingRight = true;
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();

        size = 3;
        checkSize();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        HandleMovement(horizontal);
        Flip(horizontal);

        if(Input.GetKeyDown(KeyCode.Space))
            Jump();
    }

    private void HandleMovement(float horizontal)
    {
        myRigidBody.velocity = new Vector2(horizontal * movementSpeed, myRigidBody.velocity.y);
        if (myAnimator)
            myAnimator.SetFloat("speed", Mathf.Abs(horizontal));
    }

    void Jump()
    {
        myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpHeight);


    }

    private void Flip(float horizontal)
    {
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;

            if(carrying)
            {
                theScale = carrying.transform.localScale;
                theScale.x *= -1;
                carrying.transform.localScale = theScale;
            }
        }
    }

    public void DamagePlayer(int damage)
    {
        playerStats.Health -= damage;
        if (playerStats.Health <= 0)
        {
            Debug.Log("PLAYER DEAD");

            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }

    public void checkSize()
    {
        if(size == 1)
        {
            movementSpeed = 15;
            myRigidBody.gravityScale = 1;
            jumpHeight = 10;

        }
        if(size == 2)
        {
            movementSpeed = 20;
            myRigidBody.gravityScale = 2;
            jumpHeight = 10;
        }
        if(size == 3)
        {
            movementSpeed = 30;
            myRigidBody.gravityScale = 4;
            jumpHeight = 15;


        }
    }
}
