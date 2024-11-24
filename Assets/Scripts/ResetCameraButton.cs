using UnityEngine;
using UnityEngine.UI; // Import the UI namespace to access UI elements like Button

public class ResetCameraButton : MonoBehaviour
{
    public Button button; // Reference to the UI Button
    public Transform cameraTransform; // Reference to the camera's transform (or any object you want to reset)

    private Vector3 initialPosition; // Store the initial position of the camera
    private Quaternion initialRotation; // Store the initial rotation of the camera

    // Start is called before the first frame update
    void Start()
    {
        // Store the initial position and rotation of the camera
        if (cameraTransform != null)
        {
            initialPosition = cameraTransform.position;
            initialRotation = cameraTransform.rotation;
        }
        else
        {
            Debug.LogWarning("Camera Transform reference not assigned.");
        }

        // Ensure the button reference is set
        if (button != null)
        {
            button.onClick.AddListener(OnButtonClick); // Register the button click event
        }
        else
        {
            Debug.LogWarning("Button reference not assigned.");
        }
    }

    // This function is called when the button is clicked
    void OnButtonClick()
    {
        if (cameraTransform != null)
        {
            // Reset the camera's position and rotation to the initial values
            cameraTransform.position = initialPosition;
            cameraTransform.rotation = initialRotation;
        }
        else
        {
            Debug.LogWarning("Camera Transform is missing!");
        }
    }
}
