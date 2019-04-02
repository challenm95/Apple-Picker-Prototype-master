using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour {

	public GameObject applePrefab;
	public float speed = 50f; // speed of Apple Tree
	public float leftAndRightEdge = 10f;
	public float chanceToChangeDirections = 0.1f;
	public float secondsBetweenAppleDrops = 1f;

	// Use this for initialization
	void Start () {
		// wait 2 seconds before dropping an apple
		Invoke ("DropApple", 2f);
	}
	
	// Update is called once per frame
	void Update () {
		// Basic Movement
		// Get current position of AppleTree
		Vector3 pos = transform.position;
		// Calculate the amount of movement
		pos.x += speed * Time.deltaTime;
		// Move the tree by pos distance
		transform.position = pos;
		// Change Direction
		// if we hit the left edge
		if (pos.x < -leftAndRightEdge) {
			// change direction
			speed = Mathf.Abs (speed);
		}
		// if we hit the left edge
		else if (pos.x > leftAndRightEdge) {
			speed = -Mathf.Abs (speed);
		// every 10% of the time change direction randomly
		} else if (Random.value < chanceToChangeDirections) {
			speed *= -1; 
		}
	}

	void DropApple(){
		// create an apple
		GameObject apple = Instantiate<GameObject> (applePrefab);
		// Put the apple in the tree
		apple.transform.position = transform.position;
		// Repeat every few seconds
		Invoke ("DropApple", secondsBetweenAppleDrops);
	}
}
