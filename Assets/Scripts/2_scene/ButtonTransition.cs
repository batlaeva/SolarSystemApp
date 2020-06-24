using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonTransition : MonoBehaviour
{
    public GameObject[] buttons;
    public GameObject player;
    public GameObject buttonMenu;
    public Image imgGaze;

    float timer = 0.0f;
    float totalTime = 1.0f;
    bool[] isEnter = new bool[11];
    bool timerIsRunning = false;

    public GameObject panelTransition;
    Image panelImage;
    bool transitionBegin = false;
    bool transitionEND = false;
    Color color = new Color(.0f, .0f, .0f, 0.0f);

    void Start() {
        panelImage = panelTransition.GetComponent<Image>();

        setDelegate();
    }
    
    void Update() {
        if (timerIsRunning) {
            timer += Time.deltaTime;
            imgGaze.fillAmount = timer / totalTime;
            if(timer >= totalTime) {
                transitionBegin = true;
                if (transitionEND) {
                    for (int i = 0; i < buttons.Length; i++) {
                        if (isEnter[i]) {
                            // rectTransform.anchoredPosition  = Vector3.zero;
                            switch (i) {
                                case 0: 
                                    toSun();
                                    break;
                                case 1: 
                                    toMercury();
                                    break;
                                case 2: 
                                    toVenus();
                                    break;
                                case 3: 
                                    toEarth();
                                    break;
                                case 4: 
                                    toMoon();
                                    break;
                                case 5: 
                                    toMars();
                                    break;
                                case 6: 
                                    toJupiter();
                                    break;
                                case 7: 
                                    toSaturn();
                                    break;
                                case 8: 
                                    toUranus();
                                    break;
                                case 9: 
                                    toNeptune();
                                    break;
                                case 10: 
                                    toScene1();
                                    break;
                                default:
                                    break;
                            }
                            gameObject.SetActive(false);
                        }
                    }
                }
            }
        }

        if (transitionBegin) {
            color.a +=  0.9f * Time.deltaTime;
            if (color.a >= 1.0f) {
                color.a = 1.0f;
                transitionBegin = false;
                transitionEND = true;
            }
            panelImage.color = color;
        }      
    }

    public void OnPointerEnterDelegate(PointerEventData data, int i) {
        isEnter[i] = true;
        timerIsRunning  = true;
    }

    public void OnPointerExitDelegate(PointerEventData data, int i) {
        isEnter[i] = false;
        timerIsRunning = false;
        timer = 0.0f;
        imgGaze.fillAmount = 0;
    }

    void toSun() {
        SceneManager.LoadScene("Sun");
        // player.transform.rotation = new Quaternion(.0f, 180.0f, .0f, player.transform.rotation.w);
        // player.transform.position = new Vector3(.0f, .0f, 26.0f);
    }
    void toMercury() {
        SceneManager.LoadScene("Mercury");
        // player.transform.rotation = new Quaternion(.0f, player.transform.rotation.y -334.0f, .0f, player.transform.rotation.w);
        // player.transform.position = new Vector3(-13.0f, -0.3f, 2.0f);
    }
    void toVenus() {
        SceneManager.LoadScene("Venus");
        // player.transform.rotation = new Quaternion(.0f, 306.0f, .0f, player.transform.rotation.w);
        // player.transform.position = new Vector3(-15.0f, 0.9f, -3.0f);
    }
    void toEarth() {
        SceneManager.LoadScene("Earth");
        // player.transform.rotation = new Quaternion(.0f, 296.0f, .0f, player.transform.rotation.w);
        // player.transform.position = new Vector3(-17.1f, .0f, 5.7f);
    }
    void toMoon() {
        SceneManager.LoadScene("Moon");
        // player.transform.rotation = new Quaternion(.0f, 324.8f, .0f, player.transform.rotation.w);
        // player.transform.position = new Vector3(-17.18f, .0f, 6.88f);
    }
    void toMars() {
        SceneManager.LoadScene("Mars");
        // player.transform.rotation = new Quaternion(.0f, 319.8f, .0f, player.transform.rotation.w);
        // player.transform.position = new Vector3(-30.7f, -0.05f, 1.07f);
    }
    void toJupiter() {
        SceneManager.LoadScene("Jupiter");
        // player.transform.rotation = new Quaternion(.0f, 280.0f, .0f, player.transform.rotation.w);
        // player.transform.position = new Vector3(-35.1f, .4f, -27.0f);
    }
    void toSaturn() {
        SceneManager.LoadScene("Saturn");
        // player.transform.rotation = new Quaternion(9.1f, 279.2f, .0f, player.transform.rotation.w);
        // player.transform.position = new Vector3(-67.7f, 1.4f, 14.0f);
    }
    void toUranus() {
        SceneManager.LoadScene("Uranus");
        // player.transform.rotation = new Quaternion(.0f, 287.5f, .0f, player.transform.rotation.w);
        // player.transform.position = new Vector3(-110.3f, -1.4f, 62.9f);
    }
    void toNeptune() {
        SceneManager.LoadScene("Neptune");
        // player.transform.rotation = new Quaternion(.0f, 277.0f, .0f, player.transform.rotation.w);
        // player.transform.position = new Vector3(-38.7f, 4.0f, -81.1f);
    }
    void toScene1() {
        SceneManager.LoadScene("SolarSystem4");
    }

    void setDelegate() {
        EventTrigger trigger;
        trigger = buttons[0].GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        EventTrigger.Entry entry2 = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerEnter;
        entry2.eventID = EventTriggerType.PointerExit;
        entry.callback.AddListener((data) => { OnPointerEnterDelegate((PointerEventData)data, 0); });
        trigger.triggers.Add(entry);
        entry2.callback.AddListener((data) => { OnPointerExitDelegate((PointerEventData)data, 0); });
        trigger.triggers.Add(entry2);

        EventTrigger trigger2;
        trigger2 = buttons[1].GetComponent<EventTrigger>();
        EventTrigger.Entry entry3 = new EventTrigger.Entry();
        EventTrigger.Entry entry4 = new EventTrigger.Entry();
        entry3.eventID = EventTriggerType.PointerEnter;
        entry4.eventID = EventTriggerType.PointerExit;
        entry3.callback.AddListener((data) => { OnPointerEnterDelegate((PointerEventData)data, 1); });
        trigger2.triggers.Add(entry3);
        entry4.callback.AddListener((data) => { OnPointerExitDelegate((PointerEventData)data, 1); });
        trigger2.triggers.Add(entry4);

        EventTrigger trigger3;
        trigger3 = buttons[2].GetComponent<EventTrigger>();
        EventTrigger.Entry entry5 = new EventTrigger.Entry();
        EventTrigger.Entry entry6 = new EventTrigger.Entry();
        entry5.eventID = EventTriggerType.PointerEnter;
        entry6.eventID = EventTriggerType.PointerExit;
        entry5.callback.AddListener((data) => { OnPointerEnterDelegate((PointerEventData)data, 2); });
        trigger3.triggers.Add(entry5);
        entry6.callback.AddListener((data) => { OnPointerExitDelegate((PointerEventData)data, 2); });
        trigger3.triggers.Add(entry6);

        EventTrigger trigger4;
        trigger4 = buttons[3].GetComponent<EventTrigger>();
        EventTrigger.Entry entry7 = new EventTrigger.Entry();
        EventTrigger.Entry entry8 = new EventTrigger.Entry();
        entry7.eventID = EventTriggerType.PointerEnter;
        entry8.eventID = EventTriggerType.PointerExit;
        entry7.callback.AddListener((data) => { OnPointerEnterDelegate((PointerEventData)data, 3); });
        trigger4.triggers.Add(entry7);
        entry8.callback.AddListener((data) => { OnPointerExitDelegate((PointerEventData)data, 3); });
        trigger4.triggers.Add(entry8);

        EventTrigger trigger5;
        trigger5 = buttons[4].GetComponent<EventTrigger>();
        EventTrigger.Entry entry9 = new EventTrigger.Entry();
        EventTrigger.Entry entry10 = new EventTrigger.Entry();
        entry9.eventID = EventTriggerType.PointerEnter;
        entry10.eventID = EventTriggerType.PointerExit;
        entry9.callback.AddListener((data) => { OnPointerEnterDelegate((PointerEventData)data, 4); });
        trigger5.triggers.Add(entry9);
        entry10.callback.AddListener((data) => { OnPointerExitDelegate((PointerEventData)data, 4); });
        trigger5.triggers.Add(entry10);

        EventTrigger trigger6;
        trigger6 = buttons[5].GetComponent<EventTrigger>();
        EventTrigger.Entry entry11 = new EventTrigger.Entry();
        EventTrigger.Entry entry12 = new EventTrigger.Entry();
        entry11.eventID = EventTriggerType.PointerEnter;
        entry12.eventID = EventTriggerType.PointerExit;
        entry11.callback.AddListener((data) => { OnPointerEnterDelegate((PointerEventData)data, 5); });
        trigger6.triggers.Add(entry11);
        entry12.callback.AddListener((data) => { OnPointerExitDelegate((PointerEventData)data, 5); });
        trigger6.triggers.Add(entry12);

        EventTrigger trigger7;
        trigger7 = buttons[6].GetComponent<EventTrigger>();
        EventTrigger.Entry entry13 = new EventTrigger.Entry();
        EventTrigger.Entry entry14 = new EventTrigger.Entry();
        entry13.eventID = EventTriggerType.PointerEnter;
        entry14.eventID = EventTriggerType.PointerExit;
        entry13.callback.AddListener((data) => { OnPointerEnterDelegate((PointerEventData)data, 6); });
        trigger7.triggers.Add(entry13);
        entry14.callback.AddListener((data) => { OnPointerExitDelegate((PointerEventData)data, 6); });
        trigger7.triggers.Add(entry14);

        EventTrigger trigger8;
        trigger8 = buttons[7].GetComponent<EventTrigger>();
        EventTrigger.Entry entry15 = new EventTrigger.Entry();
        EventTrigger.Entry entry16 = new EventTrigger.Entry();
        entry15.eventID = EventTriggerType.PointerEnter;
        entry16.eventID = EventTriggerType.PointerExit;
        entry15.callback.AddListener((data) => { OnPointerEnterDelegate((PointerEventData)data, 7); });
        trigger8.triggers.Add(entry15);
        entry16.callback.AddListener((data) => { OnPointerExitDelegate((PointerEventData)data, 7); });
        trigger8.triggers.Add(entry16);

        EventTrigger trigger9;
        trigger9 = buttons[8].GetComponent<EventTrigger>();
        EventTrigger.Entry entry17 = new EventTrigger.Entry();
        EventTrigger.Entry entry18 = new EventTrigger.Entry();
        entry17.eventID = EventTriggerType.PointerEnter;
        entry18.eventID = EventTriggerType.PointerExit;
        entry17.callback.AddListener((data) => { OnPointerEnterDelegate((PointerEventData)data, 8); });
        trigger9.triggers.Add(entry17);
        entry18.callback.AddListener((data) => { OnPointerExitDelegate((PointerEventData)data, 8); });
        trigger9.triggers.Add(entry18);

        EventTrigger trigger10;
        trigger10 = buttons[9].GetComponent<EventTrigger>();
        EventTrigger.Entry entry19 = new EventTrigger.Entry();
        EventTrigger.Entry entry20 = new EventTrigger.Entry();
        entry19.eventID = EventTriggerType.PointerEnter;
        entry20.eventID = EventTriggerType.PointerExit;
        entry19.callback.AddListener((data) => { OnPointerEnterDelegate((PointerEventData)data, 9); });
        trigger10.triggers.Add(entry19);
        entry20.callback.AddListener((data) => { OnPointerExitDelegate((PointerEventData)data, 9); });
        trigger10.triggers.Add(entry20);

        EventTrigger trigger11;
        trigger11 = buttons[10].GetComponent<EventTrigger>();
        EventTrigger.Entry entry21 = new EventTrigger.Entry();
        EventTrigger.Entry entry22 = new EventTrigger.Entry();
        entry21.eventID = EventTriggerType.PointerEnter;
        entry22.eventID = EventTriggerType.PointerExit;
        entry21.callback.AddListener((data) => { OnPointerEnterDelegate((PointerEventData)data, 10); });
        trigger11.triggers.Add(entry21);
        entry22.callback.AddListener((data) => { OnPointerExitDelegate((PointerEventData)data, 10); });
        trigger11.triggers.Add(entry22);
    }
}
