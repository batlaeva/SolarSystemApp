using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour
{
    Image panelImage;
    bool transitionEND = false;
    Color color = new Color(0f, 0f, 0f, 1f);

    void Start() {
        panelImage = GetComponent<Image>(); 
        transitionEND = true;
    }

    void Update() {
        if (transitionEND) {
            color.a -=  0.5f * Time.deltaTime;
            // animator.SetBool("isMoveSS", false);
            if (color.a <= .0f) {
                color.a = 0;
                transitionEND = false;
            }
            panelImage.color = color;
        }
    }
}
