using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject forkPanel;       // Panel with the user profile button
    public GameObject userProfilePanel; // Panel for the user profile

    public GameObject userProfileEditPanel;

    public Button userProfileButton; // Button to open the user profile

    public Button backButton;

    public Button editButton;

    public Button cancelButton;

    void Start()
    {
        // Ensure only the fork panel is active initially
        forkPanel.SetActive(true);
        userProfilePanel.SetActive(false);
        userProfileEditPanel.SetActive(false);

        if (userProfileButton != null)
            userProfileButton.onClick.AddListener(OpenUserProfile);

        if (backButton != null)
            backButton.onClick.AddListener(CloseUserProfile);

        if (editButton != null)
            editButton.onClick.AddListener(OpenUserProfileEdit);

        if (cancelButton != null)
            cancelButton.onClick.AddListener(CloseUserProfileEdit);
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

    public void OpenUserProfileEdit()
    {
        userProfilePanel.SetActive(false);
        userProfileEditPanel.SetActive(true);
    }

    public void CloseUserProfileEdit()
    {
        userProfileEditPanel.SetActive(false);
        userProfilePanel.SetActive(true);
    }
}
