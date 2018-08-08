using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public int maxHp = 100;
    private int hp=0;

    private int damage = 1;
    public int Damage {
        get { return damage; }
    }

    public HealthBar healthBar;

    private void Start() {
        DeltaHp(maxHp);
    }

    public void DeltaHp(int deltaHp) {
        hp += deltaHp;
        if (hp < 0) hp = 0;
        if (hp > maxHp) hp = maxHp;
        healthBar.Health = hp;
    }
}
