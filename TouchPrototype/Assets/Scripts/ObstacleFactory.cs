using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ObstacleMovement;
using ObstacleClick;
using ObstacleFinish;

public class ObstacleFactory : MonoBehaviour {
    public List<GameObject> obstaclePrefabs;
    public GameObject playArea;

	
    public GameObject GetObstacle(int obstacleId, IObstacleMovement movement, IObstacleClick click, IObstacleFinish finish=null) {
        GameObject obstacle = Instantiate(obstaclePrefabs[obstacleId], playArea.transform);
        Obstacle o = obstacle.GetComponent<Obstacle>();
        o.movement = movement;
        o.click = click;
        o.finish = finish;
        return obstacle;
    }
}
