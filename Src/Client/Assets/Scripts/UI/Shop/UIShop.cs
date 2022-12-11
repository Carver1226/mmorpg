using Common.Data;
using Managers;
using Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIShop : UIWindow {

	public Text title;
	public Text money;
	public Text PageNum;

	public GameObject shopItem;
	ShopDefine shop;
	public Transform[] itemRoot;

	// Use this for initialization
	void Start () {
		StartCoroutine(InitItems());
	}

	private int currentPage;
	private int allPage;
	IEnumerator InitItems()
    {
		int count = 0;
		int page = 0;
		currentPage = 1;
		allPage = 3;
		foreach (var kv in DataManager.Instance.ShopItems[shop.ID])
        {
			if (kv.Value.Status > 0)
            {
				GameObject go = Instantiate(shopItem, itemRoot[page]);
				UIShopItem ui = go.GetComponent<UIShopItem>();
				ui.SetShopItem(kv.Key, kv.Value, this);
				count++;
				if (count >= 10)
                {
					count = 0;
					page++;
					itemRoot[page].gameObject.SetActive(true);
                }
            }
        }
		yield return null;
    }

	public void SetShop(ShopDefine shop)
    {
		this.shop = shop;
		this.title.text = shop.Name;
		this.money.text = User.Instance.CurrentCharacter.Gold.ToString();
    }

	private UIShopItem selectedItem;
	public void SelectShopItem(UIShopItem item)
    {
		if (selectedItem != null)
			selectedItem.Selected = false;

		selectedItem = item;
    }

	public void OnClickBuy()
    {
		if (this.selectedItem == null)
        {
			MessageBox.Show("请选择要购买的道具", "购买提示");
			return;
        }
		if (!ShopManager.Instance.BuyItem(this.shop.ID, this.selectedItem.ShopItemId))
        {

        }
    }

	void Update()
    {
		if (this.money.text != User.Instance.CurrentCharacter.Gold.ToString())
			this.money.text = User.Instance.CurrentCharacter.Gold.ToString();
		if (PageNum.text != string.Format("{0}/{1}", currentPage, allPage))
		{
			PageNum.text = string.Format("{0}/{1}", currentPage, allPage);
		}

    }

	public void NextPage()
    {	
		if (currentPage < allPage)
        {
			itemRoot[currentPage - 1].parent.parent.gameObject.SetActive(false);
			currentPage++;
			itemRoot[currentPage - 1].parent.parent.gameObject.SetActive(true);
		}		
    }

	public void LastPage()
    {
		if (currentPage > 1)
        {
			itemRoot[currentPage - 1].parent.parent.gameObject.SetActive(false);
			currentPage--;
			itemRoot[currentPage - 1].parent.parent.gameObject.SetActive(true);
		}
	}

}
