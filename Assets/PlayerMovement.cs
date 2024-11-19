using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;     // Speed of the player movement
    public float turnSpeed = 700f;   // Speed of turning the player
    public float jumpForce = 5f;     // Jump force
    public float groundCheckDistance = 0.3f;  // Distance to check if the player is grounded

    private Rigidbody rb;            // Rigidbody component of the player
    private bool isGrounded;         // Whether the player is on the ground or not

    void Start()
    {
        // Get the Rigidbody attached to the Player GameObject
        rb = GetComponent<Rigidbody>();
    }



    void Update()
    {
        // Check if the player is grounded using a raycast
        isGrounded = CheckIfGrounded();

        // Get input for movement (WASD or Arrow keys)
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Calculate movement direction (forward/backward, left/right)
        Vector3 moveDirection = (transform.right * moveHorizontal + transform.forward * moveVertical).normalized;

        // Apply movement to the player using Rigidbody
        rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.deltaTime);

        // Get input for turning the player based on mouse X movement (left/right)
        float turn = Input.GetAxis("Mouse X");

        // Rotate the player based on mouse movement (turning around the Y axis)
        transform.Rotate(Vector3.up * turn * turnSpeed * Time.deltaTime);

        // Handle jumping input
        if (Input.GetButtonDown("Jump")) // Only allow jump if grounded
        {
            Jump();
        }
    }



    // Function to check if the player is grounded
    bool CheckIfGrounded()
    {
        // Use a raycast from the player's position downwards to check if the player is grounded
        RaycastHit hit;
        if (isGrounded && Physics.Raycast(transform.position, Vector3.down, out hit, groundCheckDistance))
        {
            return true; // The player is grounded
        }
        return false; // The player is not grounded
    }

    // Function to make the player jump
    void Jump()
    {
        // Apply upward force to the player to make them jump
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
