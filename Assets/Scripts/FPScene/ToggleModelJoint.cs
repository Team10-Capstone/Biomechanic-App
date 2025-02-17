using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ToggleModelJoint : MonoBehaviour
{

    [SerializeField]
    private ToggleGroup jointGroup;
    [SerializeField]
    private GameObject center;
    private int init = 6; //used to toggle checks initially without hiding the joint cubes. should only be set once
    //private Transform baseTransform = center.transform;

    // Start is called before the first frame update
    private void Start()
    {
        SetAllTogglesOn();
    }


    public IEnumerator SetCenter(Vector3 endPosition)
    {

        while (Vector3.Distance(center.transform.position, endPosition) > 1f)
        {
            center.transform.position = Vector3.Lerp(center.transform.position, endPosition, Time.deltaTime * 20.0f);
            yield return null;  
        }
        center.transform.position = endPosition;
    }
    public void DisableToggleGroup(Toggle JointToggle)
    {
        if (JointToggle.isOn)
        {

            StartCoroutine(SetCenter(new Vector3(600, 70, 40)));
            SetAllTogglesOn();
        }
    }

    public void EnableToggleGroup(Toggle JointFocus)
    {
        if (JointFocus.isOn)
        {
            //SetAllTogglesOff();
            jointGroup.enabled = true;
        }
    }


    private void SetAllTogglesOn()
    {
        jointGroup.enabled = false;
        Toggle[] toggles = jointGroup.GetComponentsInChildren<Toggle>();
        foreach (Toggle toggle in toggles)
        {
            toggle.isOn = true;
        }
    }
    private void SetAllTogglesOff()
    {
        Toggle[] toggles = jointGroup.GetComponentsInChildren<Toggle>();
        foreach (Toggle toggle in toggles)
        {
            toggle.isOn = false;
        }
    }
    public void ToggleJoint(GameObject joint)
    {
        if (!jointGroup.IsActive())
        {
            ToggleHide(joint);
        }
        else
        {
            ToggleFocus(joint);
        }
    }
    private void ToggleHide(GameObject joint)
    {
        if ((joint.activeSelf) && init < 1)   //for startup
        {
            joint.SetActive(false);
        }
        else
        {
            joint.SetActive(true);
            init--;
        }
    }


    private void ToggleFocus(GameObject joint)
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
                StartCoroutine(SetCenter(centerTarget));
            }
        }
    }

}
