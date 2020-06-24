using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonMenu : MonoBehaviour
{
    EventTrigger trigger;
    bool isEnter = false;
    float timer = 0.0f;
    float totalTime = 1.0f;
    GameObject player;
    string sceneName;

    public Image imgGaze;
    public GameObject panelMenu;

    public GameObject panelTransition;
    Image panelImage;
    bool transitionBegin = false;
    bool transitionEND = false;
    Color color = new Color(.0f, .0f, .0f, 0.0f);

    void Start()
    {
        trigger = GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerEnter;
        entry.callback.AddListener((data) => { OnPointerEnterDelegate((PointerEventData)data); });
        trigger.triggers.Add(entry);
        EventTrigger.Entry entry2 = new EventTrigger.Entry();
        entry2.eventID = EventTriggerType.PointerExit;
        entry2.callback.AddListener((data) => { OnPointerExitDelegate((PointerEventData)data); });
        trigger.triggers.Add(entry2);

        player = GameObject.Find("Player");
        sceneName = SceneManager.GetActiveScene().name;
        panelImage = panelTransition.GetComponent<Image>();
    }

    void Update()
    {
        if (isEnter) {
            timer += Time.deltaTime;
            imgGaze.fillAmount = timer / totalTime;
            if(timer >= totalTime) {
                transitionBegin = true;
                if (transitionEND) {
                    switch (sceneName) {
                        case "SolarSystem6":
                            player.transform.position = new Vector3(.0f, .0f, -60.0f);
                            break;
                        case "Sun":
                            player.transform.position = new Vector3(41.4f, 27.7f, 1.22f);
                            break;
                        case "Mercury":
                            player.transform.position = new Vector3(-26.0f, 13.0f, 11.0f);
                            break;
                        case "Venus":
                            player.transform.position = new Vector3(-8.4f, 16.0f, 3.94f);
                            break;
                        case "Earth":
                            player.transform.position = new Vector3(-47.1f, 15.5f, 49.6f);
                            break;
                        case "Moon":
                            player.transform.position = new Vector3(-82f, 8.5f, -18.7f);
                            break;
                        case "Mars":
                            player.transform.position = new Vector3(-82f, 8.5f, -18.7f);
                            break;
                        case "Jupiter":
                            player.transform.position = new Vector3(-82f, 8.5f, -18.7f);
                            break;
                        case "Saturn":
                            player.transform.position = new Vector3(-104.9f, -8.6f, 18.3f);
                            break;
                        case "Uranus":
                            player.transform.position = new Vector3(-143.7f, 8.5f, 87.6f);
                            break;
                        case "Neptune":
                            player.transform.position = new Vector3(-64.3f, 8.5f, -77.7f);
                            break;
                        default:
                            
                            break;
                        
                    }
                }
            }
        }
        if (transitionBegin) {
            color.a +=  0.9f * Time.deltaTime;
            if (color.a >= 1.0f) {
                color.a = 1.0f;
                transitionBegin = false;
                panelMenu.gameObject.SetActive(true);
                transitionEND = true;
            }
            panelImage.color = color;
        }
        if (transitionEND) {
            color.a -=  0.9f * Time.deltaTime;
            if (color.a <= .0f) {
                color.a = 0.0f;
                transitionEND = false;
            }
            panelImage.color = color;
        }
    }

    public void OnPointerEnterDelegate(PointerEventData data) {
        isEnter = true;
    }

    public void OnPointerExitDelegate(PointerEventData data) {
        isEnter = false;
        timer = 0.0f;
        imgGaze.fillAmount = 0;
    }
}
