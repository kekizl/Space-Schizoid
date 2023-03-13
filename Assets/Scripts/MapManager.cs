using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManager : MonoBehaviour {
  public static MapManager instance;

  Camera m_MainCamera;

  private void Awake() {
    if (instance == null)
      instance = this;
    else
      Destroy(gameObject);
  }

  private void Start() {
    Vector3Int startingRoom = new Vector3Int(0, 0, 0);
    Vector3Int centerTile = new Vector3Int(4, -20, 0);
    Vector3Int cameraPos = new Vector3Int(4, 1-18, -10);

    BoundsInt wallBounds = new BoundsInt(new Vector3Int(29, 28, 0), new Vector3Int(3, 1, 0));

   

    Instantiate(Resources.Load<GameObject>("Player"), centerTile, Quaternion.identity).name = "Player";
    
    Instantiate(Resources.Load<GameObject>("Octopus"), new Vector3(0 + 1.5f, 0 - 6.5f, 0), Quaternion.identity).name = "Octopus";
    Instantiate(Resources.Load<GameObject>("Gorilla"), new Vector3(0 + 3.5f, 0 - 7.5f, 0), Quaternion.identity).name = "Gorilla";
    Instantiate(Resources.Load<GameObject>("Griffith"), new Vector3(0 - 3.5f, 0 - 17.5f, 0), Quaternion.identity).name = "Griffith";
    
    m_MainCamera = Camera.main;

    if (m_MainCamera.enabled){
      m_MainCamera.transform.position = cameraPos;
      m_MainCamera.orthographicSize = 20;
    }
    //Camera.main.transform.position = new Vector3(37, 23.2f, -10);
    //Camera.main.orthographicSize = 5;

    //define 2D grid
    int [ , ] map = new int[9, 9];

    int rand = Random.Range(1,3);
    if(rand == 1){
      Debug.Log("1");
      map[2,2] = 1;
      map[1,2] = 1;
      map[3,2] = 1;     
      map[2,3] = 1;
      map[2,1] = 1;
      map[1,1] = 1;
      map[4,2] = 1;
      map[4,3] = 1;
      map[2,4] = 1;
      map[1,4] = 1;
    }
    else{
      Debug.Log("2");
      map[2,2] = 1;
      map[3,2] = 1;
      map[4,2] = 1;
      map[5,2] = 1;
      map[5,3] = 1;
      map[2,1] = 1;
      map[1,2] = 1;
      map[2,3] = 1;
      map[1,3] = 1;
      map[1,4] = 1;
      map[1,5] = 1;
      map[2,5] = 1;
    }
    //spawn in rooms
    for(int i = 0; i < map.GetLength(0); i++){
      for(int j = 0; j < map.GetLength(1); j++){
        if(map[i,j] == 1 && map [i,j+1] == 1 && map [i,j-1] == 1 && map [i-1,j] ==1 && map [i+1,j] == 1){
          Instantiate(Resources.Load<GameObject>("StartingRoom"), new Vector3((j*10) + 0f, -(i*10) + 0.0f, 0), Quaternion.identity).name = "Start";
        }
        else if(map[i,j] == 1 && map [i+1, j] == 1 && map [i, j+1] ==  1 && map [i, j-1] == 1){
          Instantiate(Resources.Load<GameObject>("SEW"), new Vector3((j*10) + 0f, -(i*10) + 0.0f, 0), Quaternion.identity).name = "SEW";
        }
        else if(map[i,j] == 1 && map [i+1, j] == 1 && map [i, j+1] == 1){
          Instantiate(Resources.Load<GameObject>("SE"), new Vector3((j*10) + 0f, -(i*10) + 0.0f, 0), Quaternion.identity).name = "SE";
        }
        else if(map[i,j] == 1 && map [i-1,j] == 1 && map [i, j+1] == 1){
          Instantiate(Resources.Load<GameObject>("NE"), new Vector3((j*10) + 0f, -(i*10) + 0.0f, 0), Quaternion.identity).name = "NE";
        }
        else if(map[i,j] == 1 && map [i+1,j] == 1 && map [i, j-1] == 1){
          Instantiate(Resources.Load<GameObject>("SW"), new Vector3((j*10) + 0f, -(i*10) + 0.0f, 0), Quaternion.identity).name = "SW";
        }
        else if(map[i,j] == 1 && map [i,j+1] == 1 && map [i, j-1] == 1){
          Instantiate(Resources.Load<GameObject>("EW"), new Vector3((j*10) + 0f, -(i*10) + 0.0f, 0), Quaternion.identity).name = "EW";
        }
        else if(map[i,j] == 1 && map [i+1,j] == 1 && map [i-1, j] == 1){
          Instantiate(Resources.Load<GameObject>("NS"), new Vector3((j*10) + 0f, -(i*10) + 0.0f, 0), Quaternion.identity).name = "NS";
        }
        else if(map[i,j] == 1 && map [i-1,j] == 1 && map [i, j-1] == 1){
          Instantiate(Resources.Load<GameObject>("NW"), new Vector3((j*10) + 0f, -(i*10) + 0.0f, 0), Quaternion.identity).name = "NW";
        }
        else if(map[i,j] == 1 && map [i-1,j] == 1){
          Instantiate(Resources.Load<GameObject>("N"), new Vector3((j*10) + 0f, -(i*10) + 0.0f, 0), Quaternion.identity).name = "N";
        }
        else if(map[i,j] == 1 && map [i+1,j] == 1){
          Instantiate(Resources.Load<GameObject>("S"), new Vector3((j*10) + 0f, -(i*10) + 0.0f, 0), Quaternion.identity).name = "S";
        }
        else if(map[i,j] == 1 && map [i,j+1] == 1){
          Instantiate(Resources.Load<GameObject>("E"), new Vector3((j*10) + 0f, -(i*10) + 0.0f, 0), Quaternion.identity).name = "E";
        }
        else if(map[i,j] == 1 && map [i,j-1] == 1){
          Instantiate(Resources.Load<GameObject>("W"), new Vector3((j*10) + 0f, -(i*10) + 0.0f, 0), Quaternion.identity).name = "W";
        }
        else if(map[i,j] == 1){
          Instantiate(Resources.Load<GameObject>("StartingRoom"), new Vector3((j*10) + 0f, -(i*10) + 0.0f, 0), Quaternion.identity).name = "Starting";
        }

      }

      
    }
  }
}