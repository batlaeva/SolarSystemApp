using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Trigger : MonoBehaviour
{
    public Description description;
    SphereCollider collider;
    DescriptionManager descriptionManager;
    Animator animator;

    EventTrigger trigger;

    private void Start() {
        collider = GetComponent<SphereCollider>();
        descriptionManager = FindObjectOfType<DescriptionManager>();
        animator = FindObjectOfType<Animator>();

        trigger = GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerEnter;
        entry.callback.AddListener((data) => { OnPointerEnterDelegate((PointerEventData)data); });
        trigger.triggers.Add(entry);
    }

    private void Update() {
        //режим VR
        if (!animator.GetBool("isPlay") && !animator.GetBool("isMoveSS")) {
            collider.radius = 0.5f;
        }
    }   

    private void OnTriggerEnter(Collider other) {
        descriptionManager.startDescription(description);
    }
    private void OnTriggerExit(Collider other) {
        if (gameObject.CompareTag("Sun")) {
            collider.radius = 0f;
        }
        descriptionManager.stopDescription();
    }

    public void OnPointerEnterDelegate(PointerEventData data)
    {
        Debug.Log("OnPointerEnterDelegate called.");
    }
}
