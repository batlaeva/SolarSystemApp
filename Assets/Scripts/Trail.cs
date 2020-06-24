using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trail : MonoBehaviour
{
    public Animator animator;
    TrailRenderer tr;

    void Start()
    {
        tr = gameObject.AddComponent<TrailRenderer>();
        tr.time = 10f;
        tr.startWidth = 0.2f;
        tr.endWidth = 0;
        tr.material = Resources.Load("Trail", typeof(Material)) as Material;
        tr.startColor = new Color(1, 1, 0, 0.1f);
        tr.endColor = new Color(0, 0, 0, 0);
    }

    private void Update() {
        if (!animator.GetBool("isMoveSS")) {
            tr.Clear();
        }
    }
}
