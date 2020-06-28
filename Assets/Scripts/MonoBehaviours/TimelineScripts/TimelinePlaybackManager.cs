using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

[RequireComponent(typeof(PlayableDirector))]
public class TimelinePlaybackManager : MonoBehaviour {

	private PlayableDirector playableDirector;

	[Header("Player Input Settings")]
	public KeyCode interactKey;
	public bool disablePlayerInput = false;

	[Header("Player Timeline Position")]
	public bool setPlayerTimelinePosition = false;
	public Transform playerTimelinePosition;

	[Header("Player Settings")]
	public string playerTag = "Player";
	private GameObject playerObject;

	private bool timelinePlaying = false;
	private float timelineDuration;

	private PlayerMovement playerMovement;
	
	void Start()
	{
		playerMovement = FindObjectOfType<PlayerMovement>();
		playableDirector = GetComponent<PlayableDirector>();
		playerObject = GameObject.FindWithTag (playerTag);
	}

	public void PlayTimeline(){

		if (setPlayerTimelinePosition) {
			SetPlayerToTimelinePosition ();
		}

		if (playableDirector) {
			playableDirector.Play ();
		}

		timelinePlaying = true;
			
		StartCoroutine (WaitForTimelineToFinish());
			
	}

	IEnumerator WaitForTimelineToFinish(){

		timelineDuration = (float)playableDirector.duration;
		
		ToggleInput ( !disablePlayerInput);
		yield return new WaitForSeconds(timelineDuration);
		ToggleInput (true);

		timelinePlaying = false;

	}
		
	void ToggleInput(bool handleInput)
	{
		playerMovement.HandleInput = handleInput;
	}

	void SetPlayerToTimelinePosition(){
		playerObject.transform.position = playerTimelinePosition.position;
		playerObject.transform.localRotation = playerTimelinePosition.rotation;
	}

}