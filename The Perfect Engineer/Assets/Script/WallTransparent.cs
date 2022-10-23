using System.Collections;
using System.Reflection;
using System.Collections.Generic;
using UnityEditor.U2D.Path;
using UnityEngine;
using UnityEditor.iOS;

public class WallTransparent : MonoBehaviour
{
    public float trans = 0.5f;
    LineRenderer LR;
    public Material material;
    public float line_width = 0.015f;
    public bool isDoor;
    // Start is called before the first frame update
    void Start()
    {
        LR = gameObject.AddComponent<LineRenderer>();
        LR.positionCount = 4;
        LR.loop = true;
        LR.widthMultiplier = line_width;
        LR.endColor = new Color(97 / 255f, 171 / 255f, 74 / 255f);
        LR.startColor = new Color(97 / 255f, 171 / 255f, 74 / 255f);
        LR.sortingLayerName = "Object";
        LR.material = material;
        List<Vector3> vertexList = new List<Vector3>();
        vertexList.Add(new Vector3(transform.parent.gameObject.GetComponent<Collider2D>().bounds.min.x, transform.parent.gameObject.GetComponent<Collider2D>().bounds.min.y, this.gameObject.transform.position.z));
        vertexList.Add(new Vector3(transform.parent.gameObject.GetComponent<Collider2D>().bounds.max.x, transform.parent.gameObject.GetComponent<Collider2D>().bounds.min.y, this.gameObject.transform.position.z));
        vertexList.Add(new Vector3(transform.parent.gameObject.GetComponent<Collider2D>().bounds.max.x, transform.parent.gameObject.GetComponent<Collider2D>().bounds.max.y, this.gameObject.transform.position.z));
        vertexList.Add(new Vector3(transform.parent.gameObject.GetComponent<Collider2D>().bounds.min.x, transform.parent.gameObject.GetComponent<Collider2D>().bounds.max.y, this.gameObject.transform.position.z));
        for (int i = 0; i < 4; i++)
        {
            LR.SetPosition(i, vertexList[i]);
        }
        LR.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if ((player.Player.transform.position.x >= GetComponent<Collider2D>().bounds.min.x && player.Player.transform.position.x <= GetComponent<Collider2D>().bounds.max.x) &&
            (player.Player.transform.position.y <= GetComponent<Collider2D>().bounds.max.y &&
            player.Player.transform.position.y >= GetComponent<Collider2D>().bounds.min.y))
        {
            StartCoroutine(fadeOut());

        }
        else { StartCoroutine(fadeIn()); }
    }
    IEnumerator fadeIn()
    {
        if (GetComponentInParent<SpriteRenderer>().color.a <= 1f)
        {
            LR.enabled = false;
            while (GetComponentInParent<SpriteRenderer>().color.a <= 1f)
            {
                GetComponentInParent<SpriteRenderer>().color += new Color(0f, 0f, 0f, 0.004f);
                yield return new WaitForEndOfFrame();
            }
            GetComponentInParent<SpriteRenderer>().color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 1f);
        }
    }
    IEnumerator fadeOut()
    {
        if (GetComponentInParent<SpriteRenderer>().color.a >= trans)
        {
            
            while (GetComponentInParent<SpriteRenderer>().color.a >= trans)
            {
                GetComponentInParent<SpriteRenderer>().color -= new Color(0f, 0f, 0f, 0.004f);
                yield return new WaitForEndOfFrame();
            }
            GetComponentInParent<SpriteRenderer>().color = new Color(255 / 255f, 255 / 255f, 255 / 255f, trans);
        }
        if (isDoor)
        {
            if (!transform.parent.GetComponent<Animator>().GetBool("isOpen")) { LR.enabled = true; }
        }
        else { LR.enabled = true; }
       
    }
}
