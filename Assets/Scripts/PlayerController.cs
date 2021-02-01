using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public float moveSpeed;
    public Animator myAnim;

    public static PlayerController instance;  // reference to the script on Player-- only 1 allowed!

    public string areaTransitionName;

    private Vector3 bottomLeft;
    private Vector3 topRight;


    void Start()
    {
        // prevents character duplication
        if(instance == null)
        {
            instance = this;  // instance is THIS script
        }
        else
        {
            if(instance != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }


    void Update()
    {
        rigidBody.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * moveSpeed; // Vector 2 takes 2 values, the x and the y

        myAnim.SetFloat("moveX", rigidBody.velocity.x);
        myAnim.SetFloat("moveY", rigidBody.velocity.y);

        if(Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 ||  Input.GetAxisRaw("Vertical") == -1)
        {
            myAnim.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
            myAnim.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
        }

    transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLeft.x, topRight.x), Mathf.Clamp(transform.position.y, bottomLeft.y, topRight.y), transform.position.z);

    }

    public void SetBounds(Vector3 botLeftLimit, Vector3 topRightLimit)
    {
        bottomLeft = botLeftLimit + new Vector3(.5f, 1f, 0f);
        topRight = topRightLimit+ new Vector3(-.5f, -1f, 0f);
    }
}
