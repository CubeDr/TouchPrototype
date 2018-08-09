using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObstacleMovement {
    void Move(Transform transform, float dt);
}

public interface IObstacleClick {
    void OnClick(Obstacle o);
}

public interface IObstacleFinish {
    void OnFinish(Obstacle o);
}

namespace ObstacleMovement {
    public class MovementFalling: IObstacleMovement {
        private float speed;

        public MovementFalling(float speed = 1) {
            this.speed = speed;
        }

        public void Move(Transform transform, float dt) {
            transform.Translate(Vector2.down * speed * dt, Space.World);
        }
    }
}

namespace ObstacleClick {
    public class ClickToDamagePlayer: IObstacleClick {
        private Player player;
        private int damage;

        public ClickToDamagePlayer(Player player, int damage = 10) {
            this.player = player;
            this.damage = damage;
        }

        public void OnClick(Obstacle o) {
            player.DeltaHp(-damage);
        }
    }

    public class ClickToBlock: IObstacleClick {
        public void OnClick(Obstacle o) { }
    }

    public class ClickToGainMoreDamage: IObstacleClick {
        private Monster monster;
        private Player player;
        private float multiplier;

        public ClickToGainMoreDamage(Monster monster, Player player, float multiplier) {
            this.monster = monster;
            this.player = player;
            this.multiplier = multiplier;
        }

        public void OnClick(Obstacle o) {
            monster.DeltaHp(-(int)(player.Damage*multiplier));
        }
    }

    public class ClickToDestroy: IObstacleClick {
        public void OnClick(Obstacle o) {
            GameObject.Destroy(o.gameObject);
        }
    }
}

namespace ObstacleFinish {
    public class FinishToDamagePlayer: IObstacleFinish {
        private Player player;
        private int damage;

        public FinishToDamagePlayer(Player player, int damage = 10) {
            this.player = player;
            this.damage = damage;
        }

        public void OnFinish(Obstacle o) {
            player.DeltaHp(-damage);
        }
    }
}