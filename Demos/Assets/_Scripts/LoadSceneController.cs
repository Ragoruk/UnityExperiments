using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadSceneController : MonoBehaviour {

	public Button movementDemo;
	public Button collisionDemo;
	public Button menu;

	// Use this for initialization
	void Start () {
		if (movementDemo != null) {
			movementDemo.GetComponent<Button>().onClick.AddListener(() => loadScene ("Movement"));
		}
		if (collisionDemo != null) {
			collisionDemo.GetComponent<Button>().onClick.AddListener(() => loadScene ("Interaction"));
		}
		if (menu != null) {
			menu.GetComponent<Button>().onClick.AddListener(() => loadScene ("Menu"));
		}
	}
	
	void loadScene(string scene) {
		Application.LoadLevel (scene);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
