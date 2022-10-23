using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public static player Player;
    private void Awake()
    {
        if (Player == null)
        {
            DontDestroyOnLoad(this.gameObject);
            Player = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    Vector3 moveVelocity;
    Animator animator;
    RaycastHit2D moveRay;
    Vector3 moveCheckPoint;
    public float speed = 1f;
    public float moverayLength = 1f;
    public float moverayDepth = 1f;
    public bool is_movable=true;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        buttonCheck();
    }
    void buttonCheck()
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("player_standup")&&is_movable)
        {
            moveButtonCheck();
        }
    }
    void moveButtonCheck()
    {
        moveVelocity = Vector3.zero;
        moveCheckPoint = new Vector3(transform.position.x, transform.position.y - moverayDepth, transform.position.z);
        if (Input.GetAxisRaw("Vertical") > 0)
        {

            moveRay = Physics2D.Raycast(moveCheckPoint, Vector2.up, moverayLength * 0.5f, 1 << 8);
            Debug.DrawRay(moveCheckPoint, Vector2.up * moverayLength * 0.5f, Color.red, 0.02f);
            if (moveRay) { moveVelocity = Vector3.zero; }
            else { moveVelocity = Vector3.up; }
            animator.SetBool("isMoving", true);
            animator.SetFloat("x", 0); animator.SetFloat("y", 1);
        }
        else if (Input.GetAxisRaw("Vertical") < 0)
        {
            moveRay = Physics2D.Raycast(moveCheckPoint, Vector2.down, moverayLength * 0.5f, 1 << 8);
            Debug.DrawRay(moveCheckPoint, Vector2.down * moverayLength * 0.5f, Color.red, 0.02f);
            if (moveRay) { moveVelocity = Vector3.zero; }
            else { moveVelocity = Vector3.down; }
            animator.SetBool("isMoving", true);
            animator.SetFloat("x", 0); animator.SetFloat("y", -1);
        }
        transform.position += moveVelocity * speed * Time.deltaTime;
        moveVelocity = Vector3.zero;
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            moveRay = Physics2D.Raycast(moveCheckPoint, Vector2.left, moverayLength, 1 << 8);
            Debug.DrawRay(moveCheckPoint, Vector2.left * moverayLength, Color.red, 0.02f);
            if (moveRay) { moveVelocity = Vector3.zero; }
            else { moveVelocity = Vector3.left; }
            transform.localScale = new Vector3(1, 1, 1);
            animator.SetBool("isMoving", true);
            animator.SetFloat("x", -1); animator.SetFloat("y", 0);
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            moveRay = Physics2D.Raycast(moveCheckPoint, Vector2.right, moverayLength, 1 << 8);
            Debug.DrawRay(moveCheckPoint, Vector2.right * moverayLength, Color.red, 0.02f);
            if (moveRay) { moveVelocity = Vector3.zero; }
            else { moveVelocity = Vector3.right; }
            transform.localScale = new Vector3(-1, 1, 1);
            animator.SetBool("isMoving", true);
            animator.SetFloat("x", 1); animator.SetFloat("y", 0);
        }
        transform.position += moveVelocity * speed * Time.deltaTime;
        if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0) { animator.SetBool("isMoving", false); }
    }
}
