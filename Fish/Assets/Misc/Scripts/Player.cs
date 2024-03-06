using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Rigidbody2D rigidbody2d;
   private CapsuleCollider2D cc;

   
    [SerializeField] 
    float jumpStrength;
    [SerializeField] 
    private float groundCheckRadius;
    [SerializeField]
    private float slopeCheckDistance;
    [SerializeField]
    private float movementSpeed;


    [SerializeField] 
    private Transform groundCheck;

    [SerializeField] 
    private LayerMask whatisGround; 



    private float xInput;  
    private float slopeAngleDown;
    private float slopeDownAngleOld;
    private float slopeSideAngle;


    int facingDirection = 1;


    private Vector2 CapsuleColliderSize;
    private Vector2 slopeNormalPerp;
    private Vector2 newVelocity;
    private Vector2 newForce;

    private bool isOnGround;
    private bool canJump;
    private bool isJumping;
    private bool isOnSlope;

    

    void Start()
    {
    rigidbody2d = GetComponent<Rigidbody2D>();
    cc = GetComponent<CapsuleCollider2D>();

   CapsuleColliderSize = cc.size;
    }

    // Update is called once per frame
    void Update()
    {
      
      checkInput();
    }

    void FixedUpdate()
    {
      checkGround();
      slopeCheck();
      applyMovement();
    }

    private void checkInput()
    {
      xInput = Input.GetAxisRaw("Horizontal");

      if(xInput == 1 && facingDirection == -1){
         Flip();
      }else if(xInput == -1 && facingDirection == 1)
      {
         Flip();
      }
      if(Input.GetKeyDown(KeyCode.W)){
        Jump();
      }
    }

      private void applyMovement()
      {
        newVelocity.Set(movementSpeed * xInput,rigidbody2d.velocity.y);
        rigidbody2d.velocity = newVelocity;

        if(isOnGround && !isOnSlope && !isJumping)
        {
          newVelocity.Set(movementSpeed * xInput, 0.0f);
          rigidbody2d.velocity = newVelocity;
        }else if(isOnGround && isOnSlope && !isJumping)
        {
          newVelocity.Set(movementSpeed * slopeNormalPerp.x * -xInput, movementSpeed * slopeNormalPerp.y * -xInput);
          rigidbody2d.velocity = newVelocity;
        }else if(!isOnGround)
        {
          newVelocity.Set(movementSpeed * xInput,rigidbody2d.velocity.y);
          rigidbody2d.velocity = newVelocity;
        }

      }

      private void Jump()
      {
        if(canJump)
        {
          canJump = false;
          isJumping = true;
          newVelocity.Set(0.0f,0.0f);
          rigidbody2d.velocity = newVelocity;
          newForce.Set(0.0f,jumpStrength);
          rigidbody2d.AddForce(newForce,ForceMode2D.Impulse);
        }
      }

    private void checkGround(){
      isOnGround = Physics2D.OverlapCircle(groundCheck.position,groundCheckRadius,whatisGround);
      if(rigidbody2d.velocity.y <= 0.0f){
        isJumping = false;
      }

      if(isOnGround && !isJumping)
      {
        canJump = true;
      }
    }

    private void slopeCheck()
    {
         Vector2 checkPos = transform.position - new Vector3(0.0f,CapsuleColliderSize.y / 2);

         slopeCheckHorizontal(checkPos);
         slopeCheckVertical(checkPos);
    }

    private void slopeCheckHorizontal(Vector2 checkPos)
    {
      RaycastHit2D slopeHitFront;
      RaycastHit2D slopeHitBack;

      slopeHitFront = Physics2D.Raycast(checkPos,transform.right,slopeCheckDistance,whatisGround);
      slopeHitBack = Physics2D.Raycast(checkPos,-transform.right,slopeCheckDistance,whatisGround);

      if(slopeHitFront)
      {
        isOnSlope = true;
        slopeSideAngle = Vector2.Angle(slopeHitFront.normal,Vector2.up);
      }else if(slopeHitBack)
      {
        isOnSlope = true;
        slopeSideAngle = Vector2.Angle(slopeHitBack.normal,Vector2.up);
      }else
      {
        slopeSideAngle = 0.0f;
        isOnSlope = false;
      }

    }

    private void slopeCheckVertical(Vector2 checkPos)
    { 
      RaycastHit2D hit = Physics2D.Raycast(checkPos,Vector2.down,slopeCheckDistance,whatisGround);

      

      if(hit)
      {
         
         rigidbody2d.gravityScale = 10;

        slopeNormalPerp =  Vector2.Perpendicular(hit.normal).normalized;

        slopeAngleDown = Vector2.Angle(hit.normal,Vector2.up);

        if(slopeAngleDown != slopeDownAngleOld)
        {
          isOnSlope = true;
        }

        slopeDownAngleOld = slopeAngleDown;

         Debug.DrawRay(hit.point,hit.normal,Color.green);
         Debug.DrawRay(hit.point,slopeNormalPerp,Color.red);
      }else
      {
        rigidbody2d.gravityScale = 3;
      }

    }

     private void Flip()
    {
        facingDirection *= -1;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }

}

