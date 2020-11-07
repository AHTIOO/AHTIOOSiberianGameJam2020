using UnityEngine;
using System;

public class ClockAnimator : MonoBehaviour {
	
	private const float
		hoursToDegrees = 360f / 12f,
		minutesToDegrees = 360f / 60f,
		secondsToDegrees = 360f / 60f;
	
	public Transform hours, minutes;
	
	private void Update () {
		
			hours.localRotation = Quaternion.Euler(
				0f, 0f, (float)GameTimeHolder.Instance.CurrentTime.Hours * -hoursToDegrees);
			minutes.localRotation = Quaternion.Euler(
				0f, 0f, (float)GameTimeHolder.Instance.CurrentTime.Minutes * -minutesToDegrees);
			
		}
		
	}
