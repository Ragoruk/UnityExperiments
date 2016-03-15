using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ClickToPlay : MonoBehaviour {

	public Button b;

	// Use this for initialization
	void Start () {
		b.GetComponent<Button>().onClick.AddListener(() => loadGame ());
	}
	
	void loadGame() {
		Application.LoadLevel ("Touch_Demo");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
