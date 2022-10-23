using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class playerButtonAction : MonoBehaviour
{
    List<GameObject> usableObjects;
    GameObject focusedObject;
    // Start is called before the first frame update
    void Start()
    {
        usableObjects = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        buttonAction();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!usableObjects.Contains(collision.gameObject)&&collision.gameObject.tag=="actionObject") {
            RaycastHit2D hit= Physics2D.Raycast(transform.parent.transform.position, collision.bounds.center-transform.parent.transform.position
                                                ,Mathf.Infinity,(-1)-(1<<0));
            //Debug.DrawRay(transform.parent.transform.position, collision.bounds.center - transform.parent.transform.position, Color.red, 2f);
            if (hit.transform.gameObject.tag == collision.gameObject.tag)
            {
                usableObjects.Add(collision.gameObject);
            }
            
        }
        sortList();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (usableObjects.Contains(collision.gameObject) && collision.gameObject.tag == "actionObject") {
            usableObjects.Remove(collision.gameObject);
            if (usableObjects.Count==0) { focusedObject.GetComponent<Renderer>().material.SetFloat("_OutlineThickness", 0f); focusedObject = null; }
            else { sortList(); }
        }
    }
    private void sortList()
    {
        if (usableObjects.Count!=0)
        {
            if (usableObjects.Count > 1)
            {
                usableObjects.Sort((x1, x2) => Vector3.Distance(GetComponentInParent<player>().gameObject.transform.position,
                    x1.transform.position).CompareTo(Vector3.Distance(GetComponentInParent<player>().gameObject.transform.position, x2.transform.position)));
                if (usableObjects[0] != focusedObject) { focusedObject.GetComponent<Renderer>().material.SetFloat("_OutlineThickness", 0f); }
            }
            focusedObject = usableObjects[0];
            focusedObject.GetComponent<Renderer>().material.SetFloat("_OutlineThickness", 2f);

        }
    }
    void buttonAction()
    {
        if (Input.GetKeyDown(KeyCode.Z)) 
        {
            if (focusedObject)
            {
                focusedObject.GetComponent<objectButtonAction>().buttonAction();
            }
            
        }
    }
}
