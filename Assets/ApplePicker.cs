using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour {
	[Header("Set in Inspector")]
	public GameObject basketPrefab;
	public int numBaskets = 3;
	public float basketBottomY = -14f;
	public float basketSpacingY = 2f;
	public List<GameObject> basketList;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < numBaskets; i++) {
			GameObject tBasketGO = Instantiate<GameObject>
				(basketPrefab);	
			Vector3 pos = Vector3.zero;
			pos.y = basketBottomY + (basketSpacingY * i);
			tBasketGO.transform.position = pos;
			basketList.Add (tBasketGO);
			}
	}

	public void AppleDestroyed() {
		// get a list of all the apples in the screen
		GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag ("Apple");
		foreach (GameObject tGo in tAppleArray) {
			Destroy (tGo);
		}

		// We dropped an apple so get rid of a basket
		int basketIndex = basketList.Count -1; // get index of Last Index
		GameObject tBasketGO = basketList [basketIndex];
		basketList.RemoveAt(basketIndex);
		Destroy (tBasketGO);

		// if we ran out baskets we lose
		if (basketList.Count == 0) {
			SceneManager.LoadScene ("_Scene_0");

		}
	
	}
	// Update is called once per frame
	void Update () {
		
	}
}
