using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
<<<<<<< HEAD
    public static CharacterController controller;
=======
    public CharacterController controller;
    public GameObject playerScore;
>>>>>>> f2f6544d50671aa9526af4aaf2488ae7ddc69781
    public float speed = 1f;

    public int moveHorizontalCounter = 0;
    public int moveVerticalCounter = 0;

    public string code;
    public bool scanned = false;

    public bool isEnemy;

    public bool moveRight = false;
    public bool moveLeft = false;
    public bool moveUp = false;
    public bool moveDown = false;


    // Start is called before the first frame update
    void Start()
    {
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
                if(isEnemy)
                {
                    playerScore.GetComponent<PlayerScore>().IncreaseScore();
                }
                else
                {
                    playerScore.GetComponent<PlayerScore>().DecreaseScore();
                }
                scanned = true;
                //Destroy(gameObject);
                gameObject.SetActive(false); 
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
