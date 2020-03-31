using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;

    public List<GameObject> enemies = new List<GameObject>();
    public GameObject[] gameObjects;
    
    Vector3 position1 = new Vector3(10, 4, 0);
    Vector3 position2 = new Vector3(15, 4, 0);
    Vector3 position3 = new Vector3(20, 4, 0);

    int curr_position = 0;
    bool playing = false;
    bool isMoving = false; 

    public List<GameObject> curr_wave; 
    public List<GameObject> wave1 = new List<GameObject>();
    public List<GameObject> wave2 = new List<GameObject>();
    public List<GameObject> wave3 = new List<GameObject>();
    public List<Vector3> locations = new List<Vector3>();
    public List<Vector3> enemie_locations = new List<Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        locations.Add(new Vector3(7, 4, -27));
        locations.Add(new Vector3(21, 4, -6));
        locations.Add(new Vector3(40, 4, 9));
        change_currWave(); 
    }

    // Update is called once per frame
    void Update()
    {
        // fill game objects with current wave
        //gameObjects = GameObject.FindGameObjectsWithTag("Enemy");
        //gameObjects = currVave Enemies
        //strax og gameObjects eru 0. þá fer í næsta location og næsta wave 
        if(controller.transform.position == locations[curr_position])
        {
            isMoving = false; 
            if (curr_wave.Count == 0)
            {
                fill_enemies(curr_wave);
            }

        }else
        {
            isMoving = true;
            move_player(); 
        }


        if (clear() == true && isMoving == false)
        {
            // nr hvaða possition playerinn á að vera í
            if(curr_position < 3)
            {
                curr_position ++;
            }
            else
            {
                curr_position = 0;
            }
            isMoving = true;
            // fill gameObjects with new wave enemies 
            //change_currWave();
            change_currWave();
        }

    }


    //hreyfa playerinn 'i specefied location
    void move_player(){
        Vector3 location = locations[curr_position];
        //speed to walk to location 
        float step = speed * Time.deltaTime;
        //moving to that specific location 
        controller.transform.position = Vector3.MoveTowards(controller.transform.position, location, step);
    }

    //filla wave med enemies 
    void fill_enemies(List<GameObject> wave)
    {
        int ens = enemies.Count; 
        float x_pos = controller.transform.position.x;
        float y_pos = controller.transform.position.y;
        float z_pos = controller.transform.position.z;
        for(int nr_enemies= 0; nr_enemies < 5; nr_enemies++)
        {
            int temp_int = 10 * nr_enemies;
            Vector3 location = make_enemie_location();
            int rand = Random.Range(0, ens);
            GameObject temp_enemy = enemies[rand];
            GameObject new_enemy = Instantiate(temp_enemy,location, Quaternion.identity);
            new_enemy.SetActive(true); 
            //Destroy(enemies[rand]);
            wave.Add(new_enemy);
        }
    }
    //change current wave to next wave 
    void change_currWave()
    {
        if (curr_position == 0)
        {
            curr_wave = wave1;
        } else if (curr_position == 1)
        {
            curr_wave = wave2;
        } else if (curr_position == 2)
        {
            curr_wave = wave3;
        }
        //foreach (GameObject box in curr_wave)
        //{
        //    box.SetActive(true);
        //}
    }
    
    bool clear()
    {
        foreach (GameObject box in curr_wave)
        {
            if(box.active == true)
            {
                return false; 
            }
        }
        return true;
    }


    Vector3 make_enemie_location()
    {
        float x_pos = controller.transform.position.x;
        float y_pos = controller.transform.position.y;
        float z_pos = controller.transform.position.z;
        int random = Random.Range(0, 5);
        if (random == 0)
        {
            return new Vector3(x_pos+ 10, y_pos, z_pos+ 10);
        }else if(random == 1)
        {
            return new Vector3(x_pos+10, y_pos+5, z_pos+10);
        }
        else if (random == 2)
        {
            return new Vector3(x_pos-10, y_pos+10, z_pos+10);
        }
        else if (random == 3)
        {
            return new Vector3(x_pos-10, y_pos+5, z_pos+10);
        }
        else if (random == 4)
        {
            return new Vector3(x_pos-10, y_pos, z_pos-10);
        }
        else
        {
            return new Vector3(x_pos+5, y_pos+5, z_pos+5);
        }
    }
}
