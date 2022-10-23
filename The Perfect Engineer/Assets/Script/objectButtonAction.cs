using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectButtonAction : MonoBehaviour
{
    public bool isOnWall;
    // Start is called before the first frame update
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player"&&isOnWall) { collision.gameObject.GetComponent<SpriteRenderer>().color= new Color(255 / 255f, 255 / 255f, 255 / 255f, 0.5f); }
    }
    protected void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player"&&isOnWall) { collision.gameObject.GetComponent<SpriteRenderer>().color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 1f); }
    }
    public virtual void buttonAction() { }
}
