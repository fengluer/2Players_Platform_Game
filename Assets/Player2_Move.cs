using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Player2_Move;

public class Player2_Move : MonoBehaviour
{
    // Start is called before the first frame update
    protected Rigidbody2D rb;
    private Animator anim;
    public bool x=true, y=true;
    private SpriteRenderer sprite;
    private BoxCollider2D coll;
    [SerializeField] private float maxSpeed=5f,acc=25f,dec=15f;
    private float moveSpeed;
    private float dirX = 0f,dirY=0f;
    void ChangeSpeed(float r)
    {
        moveSpeed += r * acc * Time.deltaTime;

        float d = dec * Time.deltaTime;
        if (moveSpeed > d)
            moveSpeed -= dec * Time.deltaTime;
        else if (moveSpeed < -d)
            moveSpeed += dec * Time.deltaTime;
        else
            moveSpeed = 0;

        moveSpeed = Mathf.Clamp(moveSpeed, -maxSpeed, maxSpeed);
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponentInChildren<Animator>();
    }
    private void Awake()
    {
        Player2_Manager.player2.Add(this);
    }
    public void OnDeselected()
    {
        //rb.velocity = Vector2.zero;
        if(rb!=null)
            rb.bodyType = RigidbodyType2D.Static;
    }
    public void OnSelected()
    {
        if (rb != null) 
            rb.bodyType = RigidbodyType2D.Dynamic;
    }
    // Update is called once per frame
    void MoveByInput()
    {
        if (x)
        {
            dirX = Input.GetAxisRaw("Player2Horizontal");
            ChangeSpeed(dirX);
            if(!y)
                rb.velocity = new Vector2(moveSpeed, 0);
            else
                rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
        if (y)
        {
            dirY = Input.GetAxisRaw("Player2Vertical");
            ChangeSpeed(dirY);
            rb.velocity = new Vector2(rb.velocity.x, moveSpeed);
        }
    }
    protected virtual void Update()
    {
        MoveByInput();
    }
}
