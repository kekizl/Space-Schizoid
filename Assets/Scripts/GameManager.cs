using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //public GameObject player;

    public static GameManager instance;

    [SerializeField] private int entityNum = 0;
    [SerializeField] private List<Entity> entities = new List<Entity>();


    private void Awake(){
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        //Vector3 startPosition = new Vector3(0, 0, 0);
        //SpawnPlayer(startPosition);
        
    }

    public void AddEntity(Entity entity) {
        entities.Add(entity);
        Debug.Log("current entities:" + entityNum);
    }

    public void InsertEntity(Entity entity, int index) {
        entities.Insert(index, entity);
    }

    //void SpawnPlayer(Vector3 pos){
       // Instantiate(player, pos, Quaternion.identity);
    //}
}
