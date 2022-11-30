using Managers;
using Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMiniMap : MonoBehaviour {

	public Collider miniMapBoundingBox;
	public Image miniMap;
	public Image arrow;
	public Text mapName;

	private Transform playerTransform;

	// Use this for initialization
	void Start () {
		this.InitMap();
	}
	
	// Update is called once per frame
	void Update () {
		if (playerTransform == null)
        {
			playerTransform = MiniMapManager.Instance.PlayerTransform;
        }

		if (miniMapBoundingBox == null || playerTransform == null) return;

		float realWidth = miniMapBoundingBox.bounds.size.x;
		float realHeight = miniMapBoundingBox.bounds.size.z;

		float relaX = playerTransform.position.x - miniMapBoundingBox.bounds.min.x;
		float relaY = playerTransform.position.z - miniMapBoundingBox.bounds.min.z;

		float pivotX = relaX / realWidth;
		float pivotY = relaY / realHeight;

		this.miniMap.rectTransform.pivot = new Vector2(pivotX, pivotY);
		this.miniMap.rectTransform.localPosition = Vector2.zero;
		this.arrow.transform.eulerAngles = new Vector3(0, 0, -playerTransform.eulerAngles.y);
	}

	void InitMap()
    {
		this.mapName.text = User.Instance.CurrentMapData.Name;
		if (this.miniMap.overrideSprite == null)
			this.miniMap.overrideSprite = MiniMapManager.Instance.LoadCurrentMiniMap();

		this.miniMap.SetNativeSize();
		this.miniMap.transform.localPosition = Vector3.zero;
		//this.playerTransform = User.Instance.CurrentCharacterObject.transform;
    }
}
