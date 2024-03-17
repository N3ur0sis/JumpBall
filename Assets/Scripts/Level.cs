
/*          [  Solo Designs  ]          */
//This script is used to manage the 2 levels object independantly 

using UnityEngine;
public class Level : MonoBehaviour
{

    public BoxCollider2D floorCollider;
    public GameObject obstaclesParent;
    public GameObject cam;

    //The level space is divided in two obstacle area
    GameObject obstacle;
    GameObject obstacle2;
    int obstacleNum1;
    int obstacle2Num1;
    int obstacleNum2;
    int obstacle2Num2;

    public ScaleGameToScreenSize scale;
    public PlayerController player;

    public bool gameOver = false;
    public bool isDead = false;

    //Make the first Obstacles of the game 
    private void Start()
    {
        GenerateObstacle();
    }

    private void Update()
    {   

        if (gameOver)
        {
            GameOver();
        }
        
        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        //Respawn the level when player go up  (work with different screen size) 
        if (transform.position.y + (scale.LevelChange * 3) < screenBounds.y)
        {
            transform.position = new Vector2(0, transform.position.y + (scale.LevelChange * 4));
            floorCollider.enabled = false;
            
            Destroy(obstacle);
            Destroy(obstacle2);
            GenerateObstacle();
        }
        //Kill if player fall
        if (player.gameObject.transform.localPosition.y < (cam.transform.localPosition.y - 5) && !isDead)
        {
            player.GameOver();
            isDead = true;
        }
    }

    //Replace the start function and generate the first obstacle when restart.
    private void GameOver()
    {
        Destroy(obstacle);
        Destroy(obstacle2);
        GenerateObstacle();

        if (floorCollider.isActiveAndEnabled)
            floorCollider.enabled = false;

        gameOver = false;
    }

    private void GenerateObstacle()
    {
        //Obstacle model path random generation                     //Edit: change that when add the teleportation, add a step to get the type of obstacle first
        obstacleNum2 = Random.Range(0, 10);
        obstacle2Num2 = Random.Range(0, 10);
        obstacleNum1 = Random.Range(0, 9);
        obstacle2Num1 = Random.Range(0, 9);

        if (obstacleNum1 == 8 || obstacle2Num1 == 8)
        {
            obstacle = Instantiate(Resources.Load("Level 8" + " " + obstacleNum2, typeof(GameObject))) as GameObject;
            obstacle.transform.parent = obstaclesParent.transform;
            obstacle.transform.localScale = new Vector3(1, 0.5f, 1);
            obstacle.transform.localPosition = new Vector3(0, 0, 0);
        }
        else
        {
            obstacle = Instantiate(Resources.Load("Level " + obstacleNum1 + " " + obstacleNum2, typeof(GameObject))) as GameObject;
            obstacle2 = Instantiate(Resources.Load("Level " + obstacle2Num1 + " " + obstacle2Num2, typeof(GameObject))) as GameObject;
            //Obstacle 1
            obstacle.transform.parent = obstaclesParent.transform;
            obstacle.transform.localScale = new Vector3(1, 0.5f, 1);
            obstacle.transform.localPosition = new Vector3(0, -2.5f, 0);
            //Obstacle 2
            obstacle2.transform.parent = obstaclesParent.transform;
            obstacle2.transform.localScale = new Vector3(1, 0.5f, 1);
            obstacle2.transform.localPosition = new Vector3(0, 2.5f, 0);
        }
        

    }

}
