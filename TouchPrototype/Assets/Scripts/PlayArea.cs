using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayArea : MonoBehaviour, IPointerDownHandler {
    private Engine engine;
    public int damage = 1;

    private void Awake() {
        engine = GameObject.FindGameObjectWithTag("Engine").GetComponent<Engine>();
    }

    public void OnPointerDown(PointerEventData eventData) {
        engine.monster.DeltaHp(-damage);
    }
}
