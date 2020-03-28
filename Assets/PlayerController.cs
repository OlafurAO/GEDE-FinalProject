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
        gameObjects = GameObject.FindGameObjectsWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
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

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime); ;
    }
}
