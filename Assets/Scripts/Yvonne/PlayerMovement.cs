using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private Animator animator;

    private Rigidbody2D body;
    private Vector2 direction;
    private float moveX;
    private float moveY;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        ProcessInputs();
        //ProcessAnimation();
    }

    private void ProcessInputs()
    {
        moveX = Input.GetAxisRaw("Horizontal") * movementSpeed  ;
        moveY = Input.GetAxisRaw("Vertical") * movementSpeed;

        if (Mathf.Abs(moveX) > 0 && Mathf.Abs(moveY) > 0)
        {
            moveY /= 2.0f;
        }

        body.velocity = new Vector2(moveX, moveY);
    }

    //private void ProcessAnimation()
    //{
    //    if(moveX != 0)
    //    {
    //        animator.SetFloat("moveX", movementSpeed);
    //    }

    //    if(moveY != 0)
    //    {
    //        animator.SetFloat("moveY", movementSpeed);
    //    }
    //}
}
