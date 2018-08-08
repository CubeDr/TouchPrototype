using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ObstacleMovement;
using ObstacleClick;
using ObstacleFinish;

public class Monster : MonoBehaviour {

    public List<Transform> spawns;
    public int maxHp = 100;
    public HealthBar healthBar;

    private int hp = 0;

    ObstacleFactory obstacleFactory;
    Engine engine;

    float last = 0;

    private void Awake() {
        GameObject engine = GameObject.FindGameObjectWithTag("Engine");
        obstacleFactory = engine.GetComponent<ObstacleFactory>();
        this.engine = engine.GetComponent<Engine>();
        healthBar.maxHealth = maxHp;
    }

    private void Start() {
        DeltaHp(maxHp);
    }

    private void Update() {
        if(Time.time > last) {
            Vector3 spawn = spawns[Random.Range(0, 5)].position;
            GameObject o = obstacleFactory.GetObstacle(Random.Range(0, 3), new MovementFalling(100), new ClickToDamagePlayer(engine.player), new FinishToDamagePlayer(engine.player, 1));
            o.transform.position = spawn;
            last = Time.time + 1f;
        }
    }

    public void DeltaHp(int deltaHp) {
        hp += deltaHp;
        if (hp < 0) hp = 0;
        if (hp > maxHp) hp = maxHp;
        healthBar.Health = hp;
    }
}
