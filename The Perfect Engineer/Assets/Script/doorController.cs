using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorController : objectButtonAction
{
    bool isOpen = false;
    public bool isDisable_handle;
    GameObject door;
    // Start is called before the first frame update
    void Start()
    {
        door = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (door.GetComponent<Animator>().GetBool("isOpen")&& door.GetComponent<Animator>().enabled)
        {
            //Debug.Log(Vector2.Distance(player.Player.transform.position, door.transform.position));
            if (Vector2.Distance(player.Player.transform.position, door.transform.position) >= 5.2f)
            {
                door.GetComponent<Animator>().SetBool("isOpen", false); isOpen = false;
            }
        }
    }
    public override void buttonAction()
    {
        
        if (!door.GetComponent<Animator>().enabled) { door.GetComponent<Animator>().enabled = true; return; }
        if (door.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            if (!isOpen) { door.GetComponent<Animator>().SetBool("isOpen", true); isOpen = true; }
            else { door.GetComponent<Animator>().SetBool("isOpen", false); isOpen = false; }
        }
        
    }
    

}
