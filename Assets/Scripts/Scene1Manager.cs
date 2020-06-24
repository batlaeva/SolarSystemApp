using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Scene1Manager : MonoBehaviour
{
    public Animator animator;
    public Image panelImage;

    bool transition = false;
    Color color = new Color(0f, 0f, 0f, 0f);

    private void Start() {
        animator.SetBool("isMoveSS", true);
        animator.SetBool("isPlay", true);
    }

    void Update() {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Sun")){
            animator.SetBool("isMoveSS", false); 
        }

        //переход на сцену VR
        if (animator.GetBool("isPlay") && Input.GetMouseButtonDown(0)){
            transition = true;
        }
        if (transition) {
            color.a +=  0.9f * Time.deltaTime;
            animator.SetBool("isMoveSS", false);
            if (color.a >= 1f) {
                color.a = 1;
                transition = false;
                SceneManager.LoadScene("SolarSystem6");
            }
            panelImage.color = color;
        }
    }

    //переход на сцену VR
    public void loadScene() {
        Debug.Log("Here");
        if (animator.GetBool("isPlay")){
            transition = true;
        }
    }
}
