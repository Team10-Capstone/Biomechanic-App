using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject forkPanel;       // Panel with the user profile button
    public GameObject userProfilePanel; // Panel for the user profile

    public Button userProfileButton; // Button to open the user profile

    void Start()
    {
        // Ensure only the fork panel is active initially
        forkPanel.SetActive(true);
        userProfilePanel.SetActive(false);

        if (userProfileButton != null)
            userProfileButton.onClick.AddListener(OpenUserProfile);

        // if (backButton != null)
        //     backButton.onClick.AddListener(CloseUserProfile);
    }

    public void OpenUserProfile()
    {
        forkPanel.SetActive(false);       // Hide fork panel
        userProfilePanel.SetActive(true); // Show user profile panel
    }

    public void CloseUserProfile()
    {
        userProfilePanel.SetActive(false); // Hide user profile panel
        forkPanel.SetActive(true);         // Show fork panel again
    }
}
