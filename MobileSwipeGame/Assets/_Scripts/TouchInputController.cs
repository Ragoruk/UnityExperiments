using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TouchInputController : MonoBehaviour
{
	private float fingerStartTime = 0.0f;
	private Vector2 fingerStartPos = Vector2.zero;
	private bool isSwipe = false;
	private float minSwipeDist = 50.0f;
	private float maxSwipeTime = 2.0f;
	
	private float timer;
	private int counter;
	private bool gameover;
	private int currentDirection;
	
	public Button button_restart;
	public Text text_left;
	public Text text_right;
	public Text text_up;
	public Text text_down;
	public Text text_counter;
	public Text text_timer;

	// Use this for initialization
	void Start ()
	{
		restartGame ();
		button_restart.onClick.AddListener(() => restartGame ());
	}	
	
	void restartGame() {
		button_restart.enabled = false;
		button_restart.image.enabled = false;
		button_restart.GetComponentInChildren<Text>().enabled = false;
		timer = 2;
		counter = 0;
		text_timer.text = "" + timer;
		text_counter.text = "" + counter;
		selectDirection();
		gameover = false;
	}
	
	void endGame() {
		gameover = true;
		button_restart.enabled = true;
		button_restart.image.enabled = true;
		button_restart.GetComponentInChildren<Text>().enabled = true;
	}
	
	void selectDirection ()
	{
		text_left.enabled = false;
		text_right.enabled = false;
		text_up.enabled = false;
		text_down.enabled = false;
	
		currentDirection = Random.Range (0, 100) % 4;
	
		switch (currentDirection) {
			case 0:
				text_left.enabled = true;
				break;
			case 1:
				text_right.enabled = true;				
				break;
			case 2:
				text_up.enabled = true;	
				break;
			case 3:
				text_down.enabled = true;
				break;
		}
	}
	
	void setTimer() {
		if (counter >= 21) {
			timer = 0.75f;
		} else if (counter >= 18) {
			timer = 1.0f;
		} else if (counter >= 14) {
			timer = 1.25f;
		} else if (counter >= 10) {
			timer = 1.5f;
		} else if (counter >= 5) {
			timer = 1.75f;
		} else {
			timer = 2.0f;
		}
	}
	
	void processSwipe(int swipeDirection) {
		if (swipeDirection == currentDirection) {
			setTimer ();
			text_timer.text = "" + timer;
			text_counter.text = "" + ++counter; 
			selectDirection ();
		}
		else {
			endGame();
		}
	}

	// Update is called once per frame
	void Update ()
	{
		
		if (! gameover) {
			timer -= Time.deltaTime;
			
			if (timer <= 0) {
				text_timer.text = "0";
				endGame();
				return;
			}
			
			text_timer.text = timer.ToString("F2");
			
		
			
			if (Input.touchCount > 0) {
				foreach (Touch touch in Input.touches) {
					switch (touch.phase) {
					case TouchPhase.Began:
							/* this is a new touch */
						isSwipe = true;
						fingerStartTime = Time.time;
						fingerStartPos = touch.position;
						break;
	
					case TouchPhase.Canceled:
							/* The touch is being canceled */
						isSwipe = false;
						break;
	
					case TouchPhase.Ended:
						float gestureTime = Time.time - fingerStartTime;
						float gestureDist = (touch.position - fingerStartPos).magnitude;
	
						if (isSwipe && gestureTime < maxSwipeTime && gestureDist > minSwipeDist) {
							Vector2 direction = touch.position - fingerStartPos;
							Vector2 swipeType = Vector2.zero;
	
							if (Mathf.Abs (direction.x) > Mathf.Abs (direction.y)) {
								// the swipe is horizontal:
								swipeType = Vector2.right * Mathf.Sign (direction.x);
							} else {
								// the swipe is vertical:
								swipeType = Vector2.up * Mathf.Sign (direction.y);
							}
	
							int swipeDirection = -1;
							if (swipeType.x != 0.0f) {
								if (swipeType.x < 0.0f) {
									// MOVE LEFT
									swipeDirection = 0;
								} else {
									// MOVE RIGHT
									swipeDirection = 1;
								}
							}
	
							if (swipeType.y != 0.0f) {
								if (swipeType.y > 0.0f) {
									// MOVE UP
									swipeDirection = 2;
								} else {
									// MOVE DOWN
									swipeDirection = 3;
								}
							}

							processSwipe (swipeDirection);
						}
						break;
					}
				}
			}
		}
	}
}