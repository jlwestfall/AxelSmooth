using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatTextInFront : MonoBehaviour
{
	public MeshRenderer renderer;
	public int order;

	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Update()
	{
		renderer.sortingLayerName = "Player";
	}
}
