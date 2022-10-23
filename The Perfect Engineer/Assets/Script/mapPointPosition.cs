using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapPointPosition : MonoBehaviour
{
    public GameObject playerPoint;
    public GameObject cam;
    bool isMaxed=false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (isMaxed)
            {
                cam.transform.SetParent(player.Player.transform);
                cam.transform.localPosition = new Vector3(0, 0, -1f);
                cam.GetComponent<Camera>().orthographicSize = 14f;
                GetComponent<RectTransform>().localPosition = new Vector2(960-220, 540-270);
                playerPoint.transform.localScale =new Vector3 (1, 1, 1);
                GetComponent<RectTransform>().sizeDelta = new Vector2(350, 250);
                isMaxed = false;
            }
            else
            {
                cam.transform.SetParent(null);
                cam.GetComponent<Camera>().orthographicSize = 90f;
                cam.transform.position = new Vector3(0, 0, -1f);
                GetComponent<RectTransform>().localPosition = new Vector2(0, 0);
                GetComponent<RectTransform>().sizeDelta = new Vector2(1820, 980);
                playerPoint.transform.localScale = new Vector3(4, 4, 4);
                isMaxed = true;
            }
            
        }
        if (this.gameObject.activeSelf)
        {
            
            
        }
        
    }
}
