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
            int obstacleId = Random.Range(0, 4);
            Vector3 spawn;
            if (obstacleId == 2) spawn = spawns[2].position;
            else spawn = spawns[Random.Range(0, 5)].position;

            IObstacleClick click = null;
            IObstacleFinish finish = null;
            switch( obstacleId ) {
                case 0: // 반사 - 원
                    click = new ClickToDamagePlayer(engine.player);
                    break;
                case 1: // 방어 - 사각형
                    click = new ClickToBlock();
                    break;
                case 2: // 추가 데미지 - 바
                    click = new ClickToGainMoreDamage(engine.monster, engine.player, 9);
                    break;
                case 3: // 맨 밑 - 삼각형
                    click = new ClickToDestroy();
                    finish = new FinishToDamagePlayer(engine.player);
                    break;
            }
            

            GameObject o = obstacleFactory.GetObstacle(obstacleId, new MovementFalling(100), click, finish);
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
