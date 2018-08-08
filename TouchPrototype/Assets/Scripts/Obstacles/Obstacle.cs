using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Obstacle : MonoBehaviour, IPointerDownHandler {

    public IObstacleMovement movement;
    public IObstacleClick click;
    public IObstacleFinish finish;

	void Update () {
        if(movement != null) movement.Move(transform, Time.deltaTime);
	}

    public void OnPointerDown(PointerEventData eventData) {
        if(click != null) click.OnClick();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Finish")) {
            if (finish != null) finish.OnFinish();
            Destroy(gameObject);
        }
    }

}
