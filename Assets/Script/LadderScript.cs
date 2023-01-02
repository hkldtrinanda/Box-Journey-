using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderScript : MonoBehaviour
{
    private float vertical;
    public float speed;
    private bool isClimbing;

    private bool isLadder;
    
    public Vector2[] points;
    
    [Header("NonActive Collider")]
    public List<Collider2D> nonActiveCollider;
    
    public Animator anim;
    [SerializeField] private Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxis("Vertical");
        
        if (isLadder && Mathf.Abs(vertical) > 0f)
        {
            isClimbing = true;
            anim.SetBool("isClimbing", true);

            nonActiveCollider.ForEach(collider => collider.enabled = false);
            /*transform.Translate(Vector3.up * vertical * speed * Time.deltaTime);*/
        }
        else
        {
            isClimbing = false;
            anim.SetBool("isClimbing", false);
            nonActiveCollider.ForEach(collider => collider.enabled = true);
        }
    }

    private void FixedUpdate()
    {
        if (isClimbing)
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, vertical * speed);
        }
        else
        {
            rb.gravityScale = 3f;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Ladder"))
        {
            isLadder = true;
            
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Ladder"))
        {
            isLadder = false;
            isClimbing = false;
            nonActiveCollider.ForEach(collider => collider.enabled = true);
        }

    }
}