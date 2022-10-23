using System.Collections;
using System.Collections.Generic;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class roomController : objectButtonAction
{
    float lightIntensity;
    [SerializeField]
    private Light2D[] roomLight;
    //private bool isRoomPanelOn;
    public GameObject roomPanel;
    public GameObject consolPanel;
    Slider Light;
    Slider Co2;
    Slider O2;
    Slider Gravity;
    Slider Temp;
    public string roomName;
    public float Co2Value=0.3f;
    public float O2Value = 0.5f;
    public float GravityValue = 1f;
    public int TempValue = 24;
    int accessLevel = 0;
    void Start()
    {
        //roomLight[0] = transform.GetChild(0).GetComponent<Light2D>();
        roomName = transform.parent.gameObject.name;
        roomLight[0].intensity = 0f;
        Light = roomPanel.transform.GetChild(1).GetComponent<Slider>();
        Co2 = roomPanel.transform.GetChild(2).GetComponent<Slider>();
        O2 = roomPanel.transform.GetChild(3).GetComponent<Slider>();
        Gravity = roomPanel.transform.GetChild(4).GetComponent<Slider>();
        Temp = roomPanel.transform.GetChild(5).GetComponent<Slider>();
    }


    void Update()
    {
        if (roomPanel.activeSelf&&roomName== roomPanel.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text)
        {
            roomLight[0].intensity = Light.value;
            Light.GetComponentInChildren<TextMeshProUGUI>().text = Light.value.ToString("N2");
            Co2.GetComponentInChildren<TextMeshProUGUI>().text = Co2.value.ToString("N2");
            O2.GetComponentInChildren<TextMeshProUGUI>().text = O2.value.ToString("N2");
            Gravity.GetComponentInChildren<TextMeshProUGUI>().text = Gravity.value.ToString("N2");
            Temp.GetComponentInChildren<TextMeshProUGUI>().text = Temp.value.ToString("N1");
            if (Input.GetKeyDown(KeyCode.Escape)) { roomPanel.SetActive(false); player.Player.is_movable = true; }
        }

    }
    void setPanel()
    {
        roomPanel.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = roomName;
        Light.value = roomLight[0].intensity;
        Light.GetComponentInChildren<TextMeshProUGUI>().text = Light.value.ToString("N2");
        Co2.GetComponentInChildren<TextMeshProUGUI>().text = Co2.value.ToString("N2");
        O2.GetComponentInChildren<TextMeshProUGUI>().text = O2.value.ToString("N2");
        Gravity.GetComponentInChildren<TextMeshProUGUI>().text = Gravity.value.ToString("N2");
        Temp.GetComponentInChildren<TextMeshProUGUI>().text = Temp.value.ToString("N1");
        roomPanel.transform.GetChild(0).GetComponent<Toggle>().onValueChanged.AddListener(toggleOn);
        switch (accessLevel)
        {
            case 0:
                Light.interactable = true;
                Co2.interactable = false;
                O2.interactable = false;
                Gravity.interactable = false;
                Temp.interactable = false;
                break;
            case 1:
                Light.interactable = true;
                Co2.interactable = true;
                O2.interactable = true;
                Gravity.interactable = false;
                Temp.interactable = false;
                break;
            case 2:
                Light.interactable = true;
                Co2.interactable = true;
                O2.interactable = true;
                Gravity.interactable = true;
                Temp.interactable = true;
                break;
            default:
                break;
        }
    }
    public override void buttonAction()
    {
        setPanel();
        roomPanel.SetActive(true);
        player.Player.is_movable = false;
        
    }
    public void toggleOn(bool a)
    {
        consolPanel.SetActive(true);
    }
}
