using UnityEngine;

public class WalkingSimulator : MonoBehaviour
{
    // Start is called before the first frame update
    public float MovementSpeed = 5;
    public float JumpForce = 7;
    public bool facingRight = true;
    public Animator anim;
    public int maxJumps = 2;
    
    private int jumpsRemaining;
    
    


    /*public Animator animator;*/
    
    
    // RIGIDBODY 2D
    public Rigidbody2D _rigidbody;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        jumpsRemaining = maxJumps;
    }
    // Update is called once per frame
    private void Update()
    {
        
        // KODE MOVEMENT
        var movement = Input.GetAxis("Horizontal");
        _rigidbody.velocity = new Vector2(Input.GetAxis("Horizontal") * MovementSpeed, _rigidbody.velocity.y);
        anim.SetFloat("moveSpeed", Mathf.Abs(_rigidbody.velocity.x));
        // KODE FLIP MOVEMENT
        if (movement < 0 && facingRight) Flip();
        if (movement > 0 && !facingRight) Flip();
        // KODE LOMPAT
        if (Input.GetButtonDown("Jump") && jumpsRemaining > 0)
        {
            _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            jumpsRemaining--;
        }
    }
    // KODE FLIP MOVEMENT
    private void Flip()
    {
        facingRight = !facingRight;
       
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            jumpsRemaining = maxJumps;
        }
    }
    
  
}