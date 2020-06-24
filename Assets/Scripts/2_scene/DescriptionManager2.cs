using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DescriptionManager2 : MonoBehaviour
{
    public TextMeshProUGUI nameTMP;
    public TextMeshProUGUI descriptionTMP;
    public TextMeshProUGUI messageTMP;
    public AudioSource typewriter;

    Description description;
    string message_continue = "Нажмите на кнопку для, чтобы убрать описание.";

    public void startDescription(Description descrip){
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
        nameTMP.text = "";
        descriptionTMP.text = "";
        messageTMP.text = "";
    }
}
