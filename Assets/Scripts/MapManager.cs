using UnityEngine;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour {
  public static MapManager instance;

  Camera m_MainCamera;
  public Rigidbody2D player;
  public int numRooms = 25; // number of rooms to generate
  private int[,] map = new int[9, 9]; // 9x9 map to store room locations

  private void Start() {
  

        bool playerSpawned = false;

        // Mark the starting room as occupied
        map[4, 4] = 1;

        // Generate additional rooms
        int roomsGenerated = 1;
        while (roomsGenerated < numRooms)
        {
            // Pick a random occupied room to branch off of
            int x = Random.Range(1, 8);
            int y = Random.Range(1, 8);
            if (map[x, y] == 1)
            {
                // Try to generate a room in a random direction
                int direction = Random.Range(0, 4);
                switch (direction)
                {
                    case 0: // up
                        if (y > 0 && map[x, y - 1] == 0)
                        {
                            map[x, y - 1] = 1;
                            roomsGenerated++;
                        }
                        break;
                    case 1: // right
                        if (x < 8 && map[x + 1, y] == 0)
                        {
                            map[x + 1, y] = 1;
                            roomsGenerated++;
                        }
                        break;
                    case 2: // down
                        if (y < 8 && map[x, y + 1] == 0)
                        {
                            map[x, y + 1] = 1;
                            roomsGenerated++;
                        }
                        break;
                    case 3: // left
                        if (x > 0 && map[x - 1, y] == 0)
                        {
                            map[x - 1, y] = 1;
                            roomsGenerated++;
                        }
                        break;
                }
            }
        }

        //set the edges of the array to 0
        for (int i = 0; i < 9; i++) {
          map[i, 0] = 0;
          map[i, 8] = 0;
          map[0, i] = 0;
          map[8, i] = 0;
        }

        // Print the generated map to the console for debug purposes
        for (int i = 0; i < 9; i++)
        {
            string row = "";
            for (int j = 0; j < 9; j++)
            {
                row += map[j, i] + " ";
            }
            Debug.Log(row);
        }
    

    //player instantiated in one of the following due to time constraints
    if(SceneManager.GetActiveScene().buildIndex == 0){
      for(int j = 0; j < map.GetLength(0); j++){
        for(int i = 0; i < map.GetLength(1); i++){
          if(map[i,j] == 1 && map [i,j+1] == 1 && map [i,j-1] == 1 && map [i-1,j] == 1 && map [i+1,j] == 1){
            Instantiate(Resources.Load<GameObject>("StartingRoom"), new Vector3((j*10) + 0f, -(i*10) + 0.0f, 0), Quaternion.identity).name = "Start";
            if(playerSpawned == false){
              Vector3 newPosition = new Vector3((j*10) + 0f, -(i*10) + 0.0f, 0);
              player.transform.position = newPosition;
              playerSpawned = true;
            }
          }
          else if(map[i,j] == 1 && map [i+1, j] == 1 && map[i, j+1] ==  1 && map[i, j-1] == 1){
            Instantiate(Resources.Load<GameObject>("SEW"), new Vector3((j*10) + 0f, -(i*10) + 0.0f, 0), Quaternion.identity).name = "SEW";
            if(playerSpawned == false){
              Vector3 newPosition = new Vector3((j*10) + 0f, -(i*10) + 0.0f, 0);
              player.transform.position = newPosition;
              playerSpawned = true;
            }
          }
          else if(map[i,j] == 1 && map[i+1, j] == 1 && map[i, j+1] == 1){
            Instantiate(Resources.Load<GameObject>("SE"), new Vector3((j*10) + 0f, -(i*10) + 0.0f, 0), Quaternion.identity).name = "SE";
            if(playerSpawned == false){
              Vector3 newPosition = new Vector3((j*10) + 0f, -(i*10) + 0.0f, 0);
              player.transform.position = newPosition;
              playerSpawned = true;
            }
          }
          else if(map[i,j] == 1 && map[i-1,j] == 1 && map[i, j+1] == 1){
            Instantiate(Resources.Load<GameObject>("NE"), new Vector3((j*10) + 0f, -(i*10) + 0.0f, 0), Quaternion.identity).name = "NE";
          }
          else if(map[i,j] == 1 && map[i+1,j] == 1 && map[i, j-1] == 1){
            Instantiate(Resources.Load<GameObject>("SW"), new Vector3((j*10) + 0f, -(i*10) + 0.0f, 0), Quaternion.identity).name = "SW";
          }
          else if(map[i,j] == 1 && map[i,j+1] == 1 && map[i, j-1] == 1){
            Instantiate(Resources.Load<GameObject>("EW"), new Vector3((j*10) + 0f, -(i*10) + 0.0f, 0), Quaternion.identity).name = "EW";
          }
          else if(map[i,j] == 1 && map[i+1,j] == 1 && map[i-1, j] == 1){
            Instantiate(Resources.Load<GameObject>("NS"), new Vector3((j*10) + 0f, -(i*10) + 0.0f, 0), Quaternion.identity).name = "NS";
          }
          else if(map[i,j] == 1 && map[i-1,j] == 1 && map[i, j-1] == 1){
            Instantiate(Resources.Load<GameObject>("NW"), new Vector3((j*10) + 0f, -(i*10) + 0.0f, 0), Quaternion.identity).name = "NW";
          }
          else if(map[i,j] == 1 && map[i-1,j] == 1){
            Instantiate(Resources.Load<GameObject>("N"), new Vector3((j*10) + 0f, -(i*10) + 0.0f, 0), Quaternion.identity).name = "N";
          }
          else if(map[i,j] == 1 && map[i+1,j] == 1){
            Instantiate(Resources.Load<GameObject>("S"), new Vector3((j*10) + 0f, -(i*10) + 0.0f, 0), Quaternion.identity).name = "S";
          }
          else if(map[i,j] == 1 && map[i,j+1] == 1){
            Instantiate(Resources.Load<GameObject>("E"), new Vector3((j*10) + 0f, -(i*10) + 0.0f, 0), Quaternion.identity).name = "E";
          }
          else if(map[i,j] == 1 && map[i,j-1] == 1){
            Instantiate(Resources.Load<GameObject>("W"), new Vector3((j*10) + 0f, -(i*10) + 0.0f, 0), Quaternion.identity).name = "W";
          }
          else if(map[i,j] == 1){
            Instantiate(Resources.Load<GameObject>("StartingRoom"), new Vector3((j*10) + 0f, -(i*10) + 0.0f, 0), Quaternion.identity).name = "Starting";
          }
      }
    }

  }
}
}