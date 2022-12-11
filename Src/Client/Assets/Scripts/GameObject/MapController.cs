using Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour {

	public Collider miniMapBoundingBox;
	// Use this for initialization
	void Start () {
		MiniMapManager.Instance.UpdateMiniMap(miniMapBoundingBox);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
