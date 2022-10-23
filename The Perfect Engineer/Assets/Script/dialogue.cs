using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class dialogue : MonoBehaviour
{
    public GameObject potrait;
    public TextMeshProUGUI text;
    bool isBoxOn = false;
    bool isBoxMoving = false;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        button();
    }
    void button()
    {
        if (Input.GetKeyDown(KeyCode.Space)&&!isBoxMoving) { if (!isBoxOn) { StartCoroutine(box_on()); isBoxOn = true; } else { StartCoroutine(box_off()); isBoxOn = false; } }
    }
    IEnumerator box_on()
    {
        isBoxMoving = true;
        player.Player.is_movable = false;
        for (int i = 0; i < 6; i++)
        {
            potrait.transform.localPosition = new Vector2(potrait.transform.localPosition.x, Mathf.Lerp(potrait.transform.localPosition.y, 100, 0.2f));
            yield return new WaitForFixedUpdate();
        }
        potrait.transform.localPosition = new Vector2(potrait.transform.localPosition.x, 100f);
        yield return new WaitForSeconds(0.1f);
        for (int i = 0; i < 6; i++)
        {
            GetComponent<RectTransform>().localPosition = new Vector2(Mathf.Lerp(GetComponent<RectTransform>().localPosition.x, 58, 0.2f), 40);
            GetComponent<RectTransform>().sizeDelta = new Vector2(Mathf.Lerp(GetComponent<RectTransform>().sizeDelta.x, 1500, 0.2f), 200);
            yield return new WaitForFixedUpdate();
        }
        GetComponent<RectTransform>().localPosition = new Vector2(58, 40);
        GetComponent<RectTransform>().sizeDelta = new Vector2(1500, 200);
        text.enabled = true;
        isBoxMoving = false;
    }
    IEnumerator box_off()
    {
        isBoxMoving = true;
        player.Player.is_movable = true;
        for (int i = 0; i < 6; i++)
        {
            GetComponent<RectTransform>().localPosition = new Vector2(Mathf.Lerp(GetComponent<RectTransform>().localPosition.x, -680, 0.2f), 40);
            GetComponent<RectTransform>().sizeDelta = new Vector2(Mathf.Lerp(GetComponent<RectTransform>().sizeDelta.x, 0, 0.2f), 200);
            yield return new WaitForFixedUpdate();
        }
        GetComponent<RectTransform>().localPosition = new Vector2(-680, 40);
        GetComponent<RectTransform>().sizeDelta = new Vector2(0, 200);
        yield return new WaitForSeconds(0.1f);
        for (int i = 0; i < 6; i++)
        {
            potrait.transform.localPosition = new Vector2(potrait.transform.localPosition.x, Mathf.Lerp(potrait.transform.localPosition.y, -400, 0.2f));
            yield return new WaitForFixedUpdate();
        }
        potrait.transform.localPosition = new Vector2(potrait.transform.localPosition.x, -400f);
        text.enabled = false;
        isBoxMoving = false;
    }
    
}
