using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public static CharacterController controller;
    public float speed = 1f;

    public int moveHorizontalCounter = 0;
    public int moveVerticalCounter = 0;

    public string code;
    public bool scanned = false;

    public bool moveRight = true;
    public bool moveLeft = false;
    public bool moveUp = false;
    public bool moveDown = false;

    public float x_pos = controller.transform.position.x;
    public float y_pos = controller.transform.position.y;
    public float z_pos = controller.transform.position.z;


    // Start is called before the first frame update
    void Start()
    {
        gameObject.active = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            //Debug.LogWarning(code);
            //Debug.LogWarning(Input.inputString);
            //Debug.LogWarning("///////////////////");

            if (Input.inputString.Trim() == code)
            {
                scanned = true;
                gameObject.active = false; 
            }
        }

        int hor = 0, vert = 0;

        if(moveHorizontalCounter < 120)
        {
            if (moveRight)
            {
                hor = 1;
            }

            else if(moveLeft)
            {
                hor = -1;
            }
        }

        else
        {
            moveHorizontalCounter = 0;

            if(moveRight)
            {
                moveRight = false;
                moveLeft = true;
            }
            
            else if(moveLeft)
            {
                moveLeft = false;
                moveRight = true;
            }
            
        }

        if(!scanned)
        {
            Vector3 move = transform.forward * hor;
            controller.Move(move * speed * Time.deltaTime);
        }

        moveHorizontalCounter += 1; 

    }
}
