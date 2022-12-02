using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D playerrigidbody;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private SpriteRenderer rend;
    [SerializeField]
    private float speed_x = 5f;
    [SerializeField]
    private float jumpadd = 330f;

    public Transform punch;
    public Wall wall;


    Vector3 MousePosition;




    bool isdead = false;
    bool isGrounded = true;
    RaycastHit2D rayHit;

    // Start is called before the first frame update
    void Start()
    {
        playerrigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        rend = GetComponent<SpriteRenderer>();
      
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(MousePosition, 0.2f);
    }
    void Update()
    {
        Jump();

    }
    private void FixedUpdate()
    {
        
        Move();
        
       // Debug.DrawRay(playerrigidbody.position, Vector3.down, new Color(0, 1, 0));

        


    
    }

    void Move()
    {
        float input_x = Input.GetAxis("Horizontal");
        float Input_x = input_x * speed_x; 
        Vector3 newvlocity = new Vector3(Input_x, playerrigidbody.velocity.y);

        if (Input.GetKey(KeyCode.RightArrow))
        {
            playerrigidbody.velocity = newvlocity;
            animator.SetTrigger("run");
            rend.flipX = false;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            playerrigidbody.velocity = newvlocity;
            animator.SetTrigger("run");
            rend.flipX = true;
        }

        if (!Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
        {
            if (isGrounded == true)
            {
                animator.SetTrigger("face");
            }
        }
    }
    
    void Jump()
    {
        animator.SetBool("jump", isGrounded);

        
        rayHit = Physics2D.Raycast(playerrigidbody.position, Vector3.down, 0.5f, LayerMask.GetMask("Platform"));
        

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            
            playerrigidbody.AddForce(Vector2.up * jumpadd);
            
            
        }

        if (rayHit.collider != null)
        {
            if (rayHit.distance < 0.5f)
            {
             
                isGrounded = true;
            }        
        }
        else if (rayHit.collider == null)
        {
            if (rayHit.distance < 0.5f)
            {
                
                isGrounded = false;
            }
        }
        
    }
     
    void Dig()
    {

        Vector3 punch1 = new (punch.position.x * 2, punch.position.y * 2,0);

        Collider2D overCollider2d = Physics2D.OverlapCircle(punch1, 0.5f, LayerMask.GetMask("Platform"));


        




        //MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (overCollider2d != null)
        {
            
            //Debug.Log(" ±úÁü ");
            overCollider2d.transform.GetComponent<Wall>().MakeDot(punch1);
            Debug.Log(overCollider2d);
            Debug.Log(punch.position);
        }
        
    }

    void Die()
    {

        isdead = true;
        animator.SetBool("dead", isdead);
        




    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Dead")
        {
            Die();
        }
    }



}
