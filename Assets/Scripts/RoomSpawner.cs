using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int openingDirection;
    //1 --> needs to spawn room with south door
    //2 --> needs to spawn room with north door
    //3 --> needs to spawn room with west door
    //4 --> needs to spawn room with east door

    private RoomTemplates templates;
    private int rand;
    private bool spawned = false;
    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        //call function with time delay
        Spawn();
        Debug.Log("spawnpoint position");
        Debug.Log(transform.position);
    }
    void Spawn()
    {
        if(spawned == false){
            if(openingDirection == 1){
            //spawn room with SOUTH door
                rand = Random.Range(0, templates.southRooms.Length);
                Instantiate(templates.southRooms[rand], transform.position, Quaternion.identity);
            }
            else if(openingDirection == 2){
                //spawn room with NORTH door
                rand = Random.Range(0, templates.northRooms.Length);
                Instantiate(templates.northRooms[rand], transform.position, Quaternion.identity);
            }
            else if(openingDirection == 3){
                //spawn room with WEST door
                rand = Random.Range(0, templates.westRooms.Length);
                Instantiate(templates.westRooms[rand], transform.position, Quaternion.identity);
            }
            else if(openingDirection == 4){
                //spawn room with EAST door
                rand = Random.Range(0, templates.eastRooms.Length);
                Instantiate(templates.eastRooms[rand], transform.position, Quaternion.identity);
            }
            //set spawned to true so no more rooms are generated for that spawn point
            spawned = true;
        }
        
        
    }
    //to check if there already is a room there
    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("SpawnPoint")){
            Destroy(gameObject);
        }
    }
}
