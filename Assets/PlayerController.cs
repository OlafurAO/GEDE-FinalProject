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

    public List<GameObject> curr_wave; 
    public List<GameObject> wave1 = new List<GameObject>();
    public List<GameObject> wave2 = new List<GameObject>();
    public List<GameObject> wave3 = new List<GameObject>();
    public List<Vector3> locations = new List<Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        fill_enemies(wave1);
        fill_enemies(wave2);
        fill_enemies(wave3);
        locations.Add(new Vector3(7, 4, -27));
        locations.Add(new Vector3(21, 2, -6));
        locations.Add(new Vector3(36, 4, 11));
        change_currWave(); 
    }

    // Update is called once per frame
    void Update()
    {
        // fill game objects with current wave
        //gameObjects = GameObject.FindGameObjectsWithTag("Enemy");
        //gameObjects = currVave Enemies
        //strax og gameObjects eru 0. þá fer í næsta location og næsta wave 
        if (clear())
        {
            // nr hvaða possition playerinn á að vera í
            curr_position ++;
            // fill gameObjects with new wave enemies 
            change_currWave();
        }
        if(controller.transform.position == locations[curr_position])
        {
           move_player();

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
            int rand = Random.Range(0, ens);
            GameObject temp_enemy = enemies[rand];
            temp_enemy.active = false; 
            GameObject new_enemy = Instantiate(temp_enemy,new  Vector3(x_pos + 10, y_pos, z_pos+20), Quaternion.identity);
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
        foreach (GameObject box in curr_wave)
        {
            box.active = true;
        }
    }
    
    bool clear()
    {
        foreach (GameObject box in curr_wave)
        {
            if(box.active = true)
            {
                return false; 
            }
        }
        return true;
    }
}
