using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectTrigger2 : MonoBehaviour
{
    public Description description;
    DescriptionManager2 descriptionManager;

    EventTrigger trigger;
    bool descriptionIsDisplayed = false;

    private void Start() {
        descriptionManager = FindObjectOfType<DescriptionManager2>();

        trigger = GetComponent<EventTrigger>();
        EventTrigger.Entry entry3 = new EventTrigger.Entry();
        entry3.eventID = EventTriggerType.PointerDown;
        entry3.callback.AddListener((data) => { OnPointerDownDelegate((PointerEventData)data); });
        trigger.triggers.Add(entry3);
    }

    public void OnPointerDownDelegate(PointerEventData data)
    {
        if (!descriptionIsDisplayed) {
            descriptionIsDisplayed = true;
            descriptionManager.startDescription(description);
        } else{
            descriptionIsDisplayed = false;
            descriptionManager.stopDescription();
        }
    }
}
