using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;

    public List<GameObject> enemies;
    public GameObject[] gameObjects;
    

    // Start is called before the first frame update
    void Start()
    {
        enemies = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObjects = GameObject.FindGameObjectsWithTag("Enemy");
        /*
        if(Input.anyKeyDown)
        {
            foreach (var enemy in gameObjects)
            {
                Debug.LogWarning("BAM");

                var cubeControllerScript = enemy.GetComponent<CubeController>();
                Debug.LogWarning(cubeControllerScript.code);

                if (Input.inputString == cubeControllerScript.code)
                {
                    cubeControllerScript.scanned = true;
                }
            }
        }
        */

        float x = 10; //Input.GetAxis("Horizontal");
        float z = 0;//Input.GetAxis("Vertical");

         if (gameObjects.Length == 0)
        {
            //location 
            Vector3 target = new Vector3(10, 4, 0);
            move_player(target);
        }

    }

    void move_player(Vector3 location){
            //speed to walk to location 
            float step = speed * Time.deltaTime;
            //moving to that specific location 
            controller.transform.position = Vector3.MoveTowards(controller.transform.position, location, step);

    }
}
