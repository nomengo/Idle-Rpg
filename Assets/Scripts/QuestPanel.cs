using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestPanel : MonoBehaviour
{
    [SerializeField] private QuestDataList questDatas;
    [SerializeField] private QuestGoal questGoal;

    public Text titleText;
    public Text descriptionText;
    public Text rewardText;
    public Text experienceText;

    private void Start()
    {
        foreach(var quest in questDatas.quests)
        {
            if (quest.isActive)
            {
                titleText.text = quest.questTitle;
                descriptionText.text = quest.questDescription;
                rewardText.text = quest.money.ToString("0");
                experienceText.text = quest.experience.ToString("0");
            }
        }
    }

    public void TakeQuest()
    {
        foreach (var quest in questDatas.quests)
        {
            if (quest.isActive)
            {
                questGoal.quest.isActive = quest.isActive;
                questGoal.quest.questTitle = quest.questTitle;
                questGoal.quest.questDescription = quest.questDescription;
                questGoal.quest.money = quest.money;
                questGoal.quest.experience = quest.experience;
                questGoal.quest.questID = quest.questID;
            }
        }
    }

    public void SubmitQuest()
    {
        if (questGoal.quest != null)
        {
            if (questGoal.quest.isDone)
            {
                foreach (var quest in questDatas.quests)
                {
                    if (quest.isActive)
                    {
                        quest.isActive = false;
                        break;
                    }
                }
            }
        }
    }

}
