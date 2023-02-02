using Models;
using SkillBridge.Message;
using UnityEngine;

public class UIQuestDialog : UIWindow
{
    public UIQuestInfo questInfo;

    public Quest quest;

    public GameObject receiveButtons;
    public GameObject completeButtons;

    public void SetQuest(Quest quest)
    {
        this.quest = quest;
        this.UpdateQuest();
        if (this.quest.Info == null)
        {
            receiveButtons.SetActive(true);
            completeButtons.SetActive(false);
        }
        else
        {
            if (this.quest.Info.Status == QuestStatus.Completed)
            {
                receiveButtons.SetActive(false);
                completeButtons.SetActive(true);
            }
            else
            {
                receiveButtons.SetActive(false);
                completeButtons.SetActive(false);
            }
        }
    }

    void UpdateQuest()
    {
        if (this.quest != null)
        {
            if (this.questInfo != null)
            {
                this.questInfo.SetQuestInfo(quest);
            }
        }
    }
}