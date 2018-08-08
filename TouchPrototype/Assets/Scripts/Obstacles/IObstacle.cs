using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObstacleMovement {
    void Move(Transform transform, float dt);
}

public interface IObstacleClick {
    void OnClick();
}

public interface IObstacleFinish {
    void OnFinish();
}

namespace ObstacleMovement {
    public class MovementFalling: IObstacleMovement {
        private float speed;

        public MovementFalling(float speed = 1) {
            this.speed = speed;
        }

        public void Move(Transform transform, float dt) {
            transform.Translate(Vector2.down * speed * dt);
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

        public void OnClick() {
            player.DeltaHp(-damage);
        }
    }

    public class ClickToBlock: IObstacleClick {
        public void OnClick() { }
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

        public void OnFinish() {
            player.DeltaHp(-damage);
        }
    }
}