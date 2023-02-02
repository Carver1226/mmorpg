using Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMain : MonoSingleton<UIMain> {

	public Text avatarName;
	public Text avatarLevel;
	public List<Image> avatarImage;
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
		int currentClass = (int)User.Instance.CurrentCharacter.Class;
		for (int i = 0; i < avatarImage.Count; i++)
        {
			if (avatarImage[i] != null)
            {
				avatarImage[i].gameObject.SetActive(i == currentClass);
            }
        }
    }

	public void BackToCharSelect()
    {
		SceneManager.Instance.LoadScene("CharSelect");
		Services.UserService.Instance.SendGameLeave();
    }

	public void OnClickBag()
    {
		UIManager.Instance.Show<UIBag>();
    }

	public void OnClickCharEquip()
	{
		UIManager.Instance.Show<UICharEquip>();
	}

	public void OnClickQuest()
	{
		UIManager.Instance.Show<UIQuestSystem>();
	}

	public void OnClickFriend()
	{
		UIManager.Instance.Show<UIFriends>();
	}
}
