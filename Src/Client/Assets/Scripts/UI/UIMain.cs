using Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMain : MonoSingleton<UIMain> {

	public Text avatarName;
	public Text avatarLevel;
	// Use this for initialization
	protected override void OnStart()
	{
		this.UpdateAvatar();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void UpdateAvatar()
    {
		this.avatarName.text = User.Instance.CurrentCharacter.Name;
		this.avatarLevel.text = User.Instance.CurrentCharacter.Level.ToString();
    }

	public void BackToCharSelect()
    {
		SceneManager.Instance.LoadScene("CharSelect");
		Services.UserService.Instance.SendGameLeave();
    }

	public void OnClickTest()
    {
		UITest test = UIManager.Instance.Show<UITest>();
		test.SetTitle("测试");
    }

	public void OnClickBag()
    {
		UIManager.Instance.Show<UIBag>();
    }

	public void OnClickCharEquip()
	{
		UIManager.Instance.Show<UICharEquip>();
	}
}
