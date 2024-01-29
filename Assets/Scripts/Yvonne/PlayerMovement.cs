using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;

    private Animator animator;
    private Rigidbody2D body;
    private float moveX;
    private float moveY;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        ProcessInputs();
        ProcessAnimations();
    }

    private void ProcessInputs()
    {
        moveX = Input.GetAxisRaw("Horizontal") * movementSpeed;
        moveY = Input.GetAxisRaw("Vertical") * movementSpeed;

        if (Mathf.Abs(moveX) > 0 && Mathf.Abs(moveY) > 0)
        {
            moveY /= 2.0f;
        }

        body.velocity = new Vector2(moveX, moveY);
    }
    private void ProcessAnimations()
    {
        animator.SetFloat("moveX", moveX);
        animator.SetFloat("moveY", moveY);
    }
}