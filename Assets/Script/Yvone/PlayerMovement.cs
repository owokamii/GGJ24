using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;

    private Rigidbody2D body;
    private Vector2 direction;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        ProcessInputs();
    }

    private void Movement1()
    {
        // get direction of input
        direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;

        // set walk based on direction
        body.velocity = direction * movementSpeed;
    }

    private void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal") * movementSpeed;
        float moveY = Input.GetAxisRaw("Vertical") * movementSpeed;

        body.velocity = new Vector2(moveX, moveY);
    }
}
