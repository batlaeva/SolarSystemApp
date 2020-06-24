using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectTrigger : MonoBehaviour
{
    public Description description;
    SphereCollider collider;
    DescriptionManager descriptionManager;

    private void Start() {
        collider = GetComponent<SphereCollider>();
        descriptionManager = FindObjectOfType<DescriptionManager>();
    }

    private void OnTriggerEnter(Collider other) {
        descriptionManager.startDescription(description);
    }
    private void OnTriggerExit(Collider other) {
        if (gameObject.CompareTag("Teleport")) {
            collider.radius = 0f;
        }
        descriptionManager.stopDescription();
    }
}
