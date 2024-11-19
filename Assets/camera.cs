using UnityEngine;

public class FPSCamera : MonoBehaviour
{
    public float lookSpeedX = 0.4f;     // Horizontal look speed
    public float lookSpeedY = 0.4f;     // Vertical look speed
    public float moveSpeed = 5f;      // Player movement speed
    public float upperLookLimit = 80f; // Max up angle of camera
    public float lowerLookLimit = -80f; // Max down angle of camera
    
    private float rotationX = 0f;    // Rotation around X axis (looking up/down)
    private float rotationY = 0f;    // Rotation around Y axis (looking left/right)
    private Camera playerCamera;     // The camera component attached to the player
    private Rigidbody rb;            // Rigidbody component to move the player

    // Control variables for cursor
    private bool isCursorLocked = true;  // Tracks the cursor lock state

    void Start()
    {
        playerCamera = GetComponentInChildren<Camera>();  // Get the camera attached to the player (usually a child of the player)
        rb = GetComponent<Rigidbody>();  // Get the Rigidbody component

        // Initially lock the cursor and hide it
        LockCursor();
    }

    void Update()
    {
        // Handle mouse look rotation
        HandleMouseLook();

        // Toggle cursor visibility and lock state when Escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isCursorLocked = !isCursorLocked;

            if (isCursorLocked)
                LockCursor();
            else
                UnlockCursor();
        }
    }



    void HandleMouseLook()
    {
        // Get mouse input for looking around
        rotationX -= Input.GetAxis("Mouse Y") * lookSpeedY;  // Vertical look (up/down)
        rotationX = Mathf.Clamp(rotationX, lowerLookLimit, upperLookLimit);  // Prevent going too far up/down

        rotationY += Input.GetAxis("Mouse X") * lookSpeedX;  // Horizontal look (left/right)

        // Apply the rotation to the player (Y axis) and the camera (X axis)
        transform.localRotation = Quaternion.Euler(0f, rotationY, 0f);  // Rotate the player (left/right)
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);  // Rotate the camera (up/down)
    }

    // Lock the cursor to the center of the screen and hide it
    void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;  // Lock the cursor to the screen center
        Cursor.visible = false;  // Hide the cursor
    }

    // Unlock the cursor and make it visible
    void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;  // Unlock the cursor
        Cursor.visible = true;  // Show the cursor
    }
}


