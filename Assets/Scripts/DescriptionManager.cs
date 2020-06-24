using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DescriptionManager : MonoBehaviour
{
    public TextMeshProUGUI nameTMP;
    public TextMeshProUGUI descriptionTMP;
    public TextMeshProUGUI messageTMP;
    public AudioSource typewriter;
    public Animator animator;

    Description description;
    string message_continue = "Для продолжения нажмите на кнопку.";

    public void startDescription(Description descrip){
        animator.SetBool("isPlay", false);
        description = descrip;
        nameTMP.text = "";
        descriptionTMP.text = "";
        messageTMP.text = "";

        StartCoroutine(typeWriterEffect());
    }

    IEnumerator typeWriterEffect(){
        yield return new WaitForSeconds(0.5f);

        typewriter.Play();
        for (int i = 0; i < description.name.Length; i++) {
            nameTMP.text += description.name[i];
            yield return new WaitForSeconds(0.05f);
        }

        for (int i = 0; i < description.sentences.Length; i++) {
            descriptionTMP.text += description.sentences[i];
            yield return new WaitForSeconds(0.01f);
        }
        typewriter.Stop();

        yield return new WaitForSeconds(0.5f);
        typewriter.Play();
        for (int i = 0; i < message_continue.Length; i++) {
            messageTMP.text += message_continue[i];
            yield return new WaitForSeconds(0.01f);
        }
        typewriter.Stop();

    }

    public void stopDescription(){
        animator.SetBool("isPlay", true);
        nameTMP.text = "";
        descriptionTMP.text = "";
        messageTMP.text = "";
    }

    private void Update() {
        //пропуск описания
        if (Input.GetMouseButtonDown(0) && !animator.GetBool("isPlay")){
            FindObjectOfType<DescriptionManager>().stopDescription();
        }
    }
}
