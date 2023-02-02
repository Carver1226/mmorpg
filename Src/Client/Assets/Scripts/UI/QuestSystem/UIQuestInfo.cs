using Managers;
using Models;
using SkillBridge.Message;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIQuestInfo : MonoBehaviour
{
    public Text title;

    public Text[] targets;

    public Text description;

    public GameObject rewardItems;

    public Text rewardMoney;
    public Text rewardExp;

    public List<Image> rewards;

    public void SetQuestInfo(Quest quest)
    {
        this.title.text = string.Format("[{0}]{1}", quest.Define.Type, quest.Define.Name);
        if (quest.Info == null)
        {
            this.description.text = quest.Define.Dialog;
        }
        else
        {
            if (quest.Info.Status == QuestStatus.Completed)
            {
                this.description.text = quest.Define.DialogFinish;
            }
        }

        this.rewardMoney.text = quest.Define.RewardGold.ToString();
        this.rewardExp.text = quest.Define.RewardExp.ToString();

        if (quest.Define.RewardItem1 > 0)
        {
            if (rewards[0].transform.childCount > 0)
                Destroy(rewards[0].transform.GetChild(0).gameObject);

            GameObject go = Instantiate(rewardItems, rewards[0].transform);
            var ui = go.GetComponent<UIIconItem>();
            var def = DataManager.Instance.Items[quest.Define.RewardItem1];
            ui.SetMainIcon(def.Icon, quest.Define.RewardItem1Count.ToString());
        }
        if (quest.Define.RewardItem2 > 0)
        {
            if (rewards[1].transform.childCount > 0)
                Destroy(rewards[1].transform.GetChild(0).gameObject);

            GameObject go = Instantiate(rewardItems, rewards[1].transform);
            var ui = go.GetComponent<UIIconItem>();
            var def = DataManager.Instance.Items[quest.Define.RewardItem2];
            ui.SetMainIcon(def.Icon, quest.Define.RewardItem2Count.ToString());
        }
        if (quest.Define.RewardItem3 > 0)
        {
            if (rewards[2].transform.childCount > 0)
                Destroy(rewards[2].transform.GetChild(0).gameObject);

            GameObject go = Instantiate(rewardItems, rewards[2].transform);
            var ui = go.GetComponent<UIIconItem>();
            var def = DataManager.Instance.Items[quest.Define.RewardItem3];
            ui.SetMainIcon(def.Icon, quest.Define.RewardItem3Count.ToString());
        }

        foreach (var fitter in this.GetComponentsInChildren<ContentSizeFitter>())
        {
            fitter.SetLayoutVertical();
        }
    }
}