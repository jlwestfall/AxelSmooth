using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
	[HideInInspector]
	public AudioSource audioSource;

	public AudioClip punch;
	public AudioClip pickUp;
	public AudioClip crateHit;

	void Start()
	{
		audioSource = this.gameObject.GetComponent<AudioSource>();
	}

	public void PlayGO(int vol)
	{
		audioSource.PlayOneShot(pickUp, vol);
	}
}
