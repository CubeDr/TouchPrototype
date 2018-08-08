using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {
    public RectTransform background;
    public RectTransform foreground;
    private float maxWidth;

    public int maxHealth = 100;
    private int health = 0;
    public int Health {
        set {
            if (value < 0) value = 0;
            if (value > maxHealth) value = maxHealth;
            health = value;

            Vector2 size = foreground.sizeDelta;
            size.x = maxWidth * health / maxHealth;
            foreground.sizeDelta = size;
        }
    }


    private void Start() {
        Health = maxHealth;
        maxWidth = background.rect.width;
        Health = 100;
    }
}
