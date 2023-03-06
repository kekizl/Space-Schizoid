using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManager : MonoBehaviour {
  public static MapManager instance;

  //[SerializeField] private int width = 15, height = 10; //12-8 or 15/10
  //[SerializeField] private Color32 darkColor = new Color32(0, 0, 0, 0), lightColor = new Color32(255, 255, 255, 255);
  //[SerializeField] private TileBase floorTile, wallTile;
  //[SerializeField] private Tilemap floorMap, obstacleMap;

  //public Tilemap FloorMap { get => floorMap; }
  //public Tilemap ObstacleMap { get => obstacleMap; }

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

    //for (int x = 0; x < wallBounds.size.x; x++) {
     // for (int y = 0; y < wallBounds.size.y; y++) {
      //  Vector3Int wallPosition = new Vector3Int(wallBounds.min.x + x, wallBounds.min.y + y, 0);
      //  obstacleMap.SetTile(wallPosition, wallTile);
     // }
   // }

    Instantiate(Resources.Load<GameObject>("Player"), centerTile, Quaternion.identity).name = "Player";
    //Instantiate(Resources.Load<GameObject>("StartingRoom"), startingRoom, Quaternion.identity).name = "StartingRoom";
    //Instantiate(Resources.Load<GameObject>("NPC"), new Vector3(0 + 3.5f, 0 + 0.5f, 0), Quaternion.identity).name = "NPC";
    //Instantiate(Resources.Load<GameObject>("NPC"), new Vector3(0 + 2.5f, 0 - 0.5f, 0), Quaternion.identity).name = "NPC2";
    //Instantiate(Resources.Load<GameObject>("SideWall"), new Vector3(width, height/2, 0), Quaternion.identity).name = "LeftWall";
    //Instantiate(Resources.Load<GameObject>("SideWall"), new Vector3(0, height/2, 0), Quaternion.identity).name = "RightWall";
    m_MainCamera = Camera.main;

    if (m_MainCamera.enabled){
      m_MainCamera.transform.position = cameraPos;
      m_MainCamera.orthographicSize = 20;
    }
    //Camera.main.transform.position = new Vector3(37, 23.2f, -10);
    //Camera.main.orthographicSize = 5;

    //define 2D grid
    int [ , ] map = new int[5, 5];

    map[2,2] = 1;
    map[1,2] = 1;
    map[3,2] = 1;
    map[2,3] = 1;
    map[2,1] = 1;
    map[1,1] = 1;


    //spawn in room
    for(int i = 0; i < map.GetLength(0); i++){
      for(int j = 0; j < map.GetLength(1); j++){
        if(map[i,j] == 1 && map [i,j+1] == 1 && map [i,j-1] == 1 && map [i-1,j] ==1 && map [i+1,j] == 1){
          Instantiate(Resources.Load<GameObject>("StartingRoom"), new Vector3((j*10) + 0f, -(i*10) + 0.0f, 0), Quaternion.identity).name = "Start";
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