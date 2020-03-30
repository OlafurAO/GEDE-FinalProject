using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;

    public List<GameObject> enemies = new List<GameObject>();
    public GameObject[] gameObjects;

    Vector3 position0 = new Vector3(10, 4, 0);
    Vector3 position1 = new Vector3(10, 4, 0);
    Vector3 position2 = new Vector3(15, 4, 0);
    Vector3 position3 = new Vector3(20, 4, 0);

    int curr_position = 0;
    bool playing = false; 

    public List<GameObject> wave1 = new List<GameObject>();
    public List<GameObject> wave2 = new List<GameObject>();
    public List<GameObject> wave3 = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        gameObjects = GameObject.FindGameObjectsWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        gameObjects = GameObject.FindGameObjectsWithTag("Enemy");
        if(curr_position == 0 && playing == false)
        {
            fill_enemies(wave1);
            curr_position = 1;
            playing = true; 
        }
             if (gameObjects.Length == 0)
            {
                //location 
                Vector3 target = new Vector3(10, 4, 0);
                move_player(target);
            }



    }

    void move_player(Vector3 location){
        if(location == controller.transform.position)
        {
            fill_enemies(wave1);
        };
        //speed to walk to location 
        float step = speed * Time.deltaTime;
        //moving to that specific location 
        controller.transform.position = Vector3.MoveTowards(controller.transform.position, location, step);

    }
    void fill_enemies(List<GameObject> wave)
    {
        int ens = enemies.Count - 1;
        float x_pos = controller.transform.position.x;
        float y_pos = controller.transform.position.y;
        float z_pos = controller.transform.position.z;
        for(int nr_enemies= 0; nr_enemies < 5; nr_enemies++)
        {
            int rand = Random.Range(0, ens);
            GameObject temp_enemy = enemies[rand];
            temp_enemy.active = true; 
            Instantiate(temp_enemy,new  Vector3(x_pos-50, y_pos, z_pos-50), Quaternion.identity);
            Destroy(enemies[rand]);
            wave.Add(temp_enemy);
        }
    }
}
