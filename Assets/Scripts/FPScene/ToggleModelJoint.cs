using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class ToggleModelJoint : MonoBehaviour
{
    //ToggleGroups
    [SerializeField]
    private ToggleGroup jointToggleGroup;
    [SerializeField] 
    private ToggleGroup JointSectionToggleGroup;
    [SerializeField]
    private ToggleGroup ModeToggleGroup;
    //Focus center
    [SerializeField]
    private GameObject center;

    //non-serialized objects

    //Focus coroutine
    private IEnumerator coroutine;
    //used to select focus joint
    private Toggle toggleToFocus;
    //used to toggle checks initially without hiding the joint cubes. should only be set once
    private int init = 6; 

 
    private void Start()
    {
        SetAllTogglesOn(jointToggleGroup);
    }

    //used to set the recording object back to togglemode and reset all joints.
    public void DisableFocusMode() //This will retroactively call DisableToggleGroup(). I will probably update this later so that DisableFocusMode and DisableToggleGroup (and their counterparts) are just one function.
    {
        Toggle[] ToggleModes = ModeToggleGroup.GetComponentsInChildren<Toggle>();
        ToggleModes[0].isOn = true;
    }

    //used to set the recording object to focus mode. likely won't see use?
    public void EnableFocusMode()
    {


        Toggle[] ToggleModes = ModeToggleGroup.GetComponentsInChildren<Toggle>();
        ToggleModes[1].isOn = true;

    }

    //function for centering coroutine initialization so that code is cleaner
    private void startCentering(Vector3 position)
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
        coroutine = SetFocusCenter(position);
        StartCoroutine(coroutine);
    }

    //sets the 'Center' gameobject to a specific point, which the Freelook camera uses as a center.
    public IEnumerator SetFocusCenter(Vector3 endPosition)
    {

        while (Vector3.Distance(center.transform.position, endPosition) > .2f)
        {
            center.transform.position = Vector3.Lerp(center.transform.position, endPosition, Time.deltaTime * 8.0f);
            yield return null;  
        }
        center.transform.position = endPosition;
    }

    //fix Joint Section toggling. After, polish recording panel UI and add more playback functionality



    //THE TWO FUNCTIONS BELOW ARE CALLED BY THE MODETOGGLEGROUP TOGGLES. DisableFocusMode() & EnableFocusMode is used by other buttons to trigger the ModeToggleGroup toggles in order to call this Function.
    //Name is misleading: this button disables toggle focus.
    public void DisableToggleGroup(Toggle JointToggle)
    {
        if (JointToggle.isOn)
        {
            startCentering(new Vector3(600, 70, 40));
            SetAllTogglesOn(jointToggleGroup);
        }
    }

    //enables focus toggling and sets the joint of focus to either the Left Hip (if the toggle to focus is not already selected) OR a target previously selected through various means.
    //these means include: toggling a joint in toggle mode (focus joint will be last joint toggled) or centering a selection (toggle will always be the left toggle of the subgroup selected.)
    public void EnableToggleGroup(Toggle JointFocus)
    {
        if (JointFocus.isOn)
        {
            SetAllTogglesOff(JointSectionToggleGroup);
            Toggle[] toggles = jointToggleGroup.GetComponentsInChildren<Toggle>();
            jointToggleGroup.enabled = true;
            if (toggleToFocus == null)
            {
                toggleToFocus = toggles[0];
            }
            toggleToFocus.isOn = true;
        }
    }

    //SetAllTogglesOn: sets all joint toggles to 'on'.
    private void SetAllTogglesOn(ToggleGroup togglegroup)
    {
        jointToggleGroup.enabled = false;
        Toggle[] toggles = togglegroup.GetComponentsInChildren<Toggle>();
        foreach (Toggle toggle in toggles)
        {
            toggle.isOn = true;
        }
    }

    //SetAllTogglesOff: sets all joint toggles to 'off'.
    private void SetAllTogglesOff(ToggleGroup togglegroup)
    {
        Toggle[] toggles = togglegroup.GetComponentsInChildren<Toggle>();
        foreach (Toggle toggle in toggles)
        {
            toggle.isOn = false;
        }
    }

    //CenterSelection: used for the 'Center Selection buttons' (The buttons on the joints panel that say "hip", "knee", and "ankle"). 
    public void CenterSection(Toggle isChanging)
    {
        if (!isChanging.isOn)
        {
            SetAllTogglesOn(jointToggleGroup);
            startCentering(new Vector3(600, 70, 40));
            return;
        }
        DisableFocusMode();
        //toggleSelections is the list of slection toggles(hip, knee, and ankle)
        Toggle[] toggleSections = JointSectionToggleGroup.GetComponentsInChildren<Toggle>();
        Toggle[] toggles = jointToggleGroup.GetComponentsInChildren<Toggle>();

        if (toggleSections[0].isOn) //for hip
        {

            for (int i = 0; i < toggles.Length; i++)
            {
                if (i < 2)
                {
                    toggles[i].isOn = true;
                    
                }
                else
                {
                    toggles[i].isOn = false;
                }
            }
            toggleToFocus = toggles[0]; //toggle to focus is the left hip
            startCentering(new Vector3(600, 116.66f, 40));
        }
        else if (toggleSections[1].isOn)//for knee
        {
            
            for (int i = 0; i < toggles.Length; i++)
            {
                
                if (i >= 2 && i < 4)
                {
                    toggles[i].isOn = true;
                }
                else
                {
                    toggles[i].isOn = false;
                }
            }
            toggleToFocus = toggles[2]; //toggle to focus is the left knee
            startCentering(new Vector3(600, 70, 40));

        }
        else if (toggleSections[2].isOn)//for ankle
        {
            toggleToFocus = toggles[4]; //toggle to focus is the left ankle
            for (int i = 0; i < toggles.Length; i++)
            {
                if (i >= 4)
                {
                    toggles[i].isOn = true;
                }
                else
                {
                    toggles[i].isOn = false;
                }
            }
            startCentering(new Vector3(600, 46.66f, 40));

        }
    }
    //used for resetting the camera.
    public void TurnOffSectionToggle()
    {
        SetAllTogglesOff(JointSectionToggleGroup);
    }



    //this determines how the model joint will be displayed within the program. If the toggle focus 'joint group' is not active, joint view will be in toggle mode. if active, will be in focus mode.
    public void ToggleJoint(GameObject joint)
    {
        if (!jointToggleGroup.IsActive())
        {
            ToggleHide(joint);
        }
        else
        {
            ToggleFocus(joint);
        }
    }
    private void ToggleHide(GameObject joint) // this mode will hide and show joints that are toggled in the UI
    {
        if ((joint.activeSelf) && init < 1)   //for startup
        {
            joint.SetActive(false);
        }
        else
        {
            joint.SetActive(true);
            if (init > 0) init--;
        }
    }


    private void ToggleFocus(GameObject joint)//This mode will focus on a specific selected joint, disabling all others.
    {
        if ((joint.activeSelf)) // && init < 1 //not needed for togglefocus
        {
            joint.SetActive(false);
        }
        else
        {
            joint.SetActive(true);
            Renderer targetRenderer = joint.GetComponent<Renderer>();
            if (targetRenderer != null)
            {
                Vector3 centerTarget = targetRenderer.bounds.center;
                startCentering(centerTarget);
            }
        }
    }
}
