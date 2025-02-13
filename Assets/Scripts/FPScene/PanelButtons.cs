using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject forkPanel;       // Panel with the user profile button
    public GameObject userProfilePanel; // Panel for the user profile
    public GameObject RecordingsPanel;
    public GameObject userProfileEditPanel;

    public Button SelectRecordingButton;

    void Start()
    {
        // Ensure only the fork panel is active initially
        forkPanel.SetActive(true);

        if (SelectRecordingButton != null)
            SelectRecordingButton.onClick.AddListener(DisableSelf);


    }

    public void DisableSelf()
    {
        userProfilePanel.SetActive(false);
        //userProfileEditPanel.SetActive(true);
    }

}
