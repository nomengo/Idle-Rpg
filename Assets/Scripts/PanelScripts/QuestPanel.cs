using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestPanel : MonoBehaviour
{
    [SerializeField] private QuestDataList questDatas;
    [SerializeField] private QuestGoal questGoal;

    [SerializeField] private Text titleText;
    [SerializeField] private Text descriptionText;
    [SerializeField] private Text rewardText;
    [SerializeField] private Text experienceText;
    [SerializeField] private Text isQuestTakenText;
    [SerializeField] private Text isQuestDoneText;

    public int questID = 0;

    private void Awake()
    {
        //This part will change but for now this is what we have
        foreach (var fQuest in questDatas.quests)
        {
            if (fQuest.questID == 0)
            {
                if (fQuest.isActive == true)
                {
                    //Do nothing
                }
                else
                {
                    fQuest.isActive = true;
                }
            }
            else if(fQuest.questID != 0)
            {
                if(fQuest.isActive == true)
                {
                    fQuest.isActive = false;
                }
                else
                {
                    //Do nothing
                }
            }
        }
        //
    }

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
                isQuestTakenText.text = "Quest is not taken yet!";
            }
        }
    }

    private void Update()
    {
        //if (questGoal.quest.isDone)
        //{
        //    isQuestDoneText.text = "Quest is done!";
        //}
        //else
        //{

        //}
    }

    public void TakeQuest()
    {
        foreach (var quest in questDatas.quests)
        {
            if (quest.isActive)
            {
                //The reason why are we doing this because we dont wanna take the quest again when we already took it
                if (questGoal.quest.idThatWeNeededMost==quest.idThatWeNeededMost)
                {
                    Debug.Log("It's working!!!");
                }
                else
                {
                    Debug.Log("Here it is!!");
                    questGoal.quest.isActive = quest.isActive;
                    questGoal.quest.questTitle = quest.questTitle;
                    questGoal.quest.questDescription = quest.questDescription;
                    questGoal.quest.money = quest.money;
                    questGoal.quest.experience = quest.experience;
                    questGoal.quest.questID = quest.questID;
                    questGoal.quest.requiredCreatureID = quest.requiredCreatureID;
                    questGoal.quest.idThatWeNeededMost = quest.idThatWeNeededMost;
                    isQuestTakenText.text = "Quest is taken!";
                }
            }
        }
    }

    public void SubmitQuest()
    {
        if (questGoal.quest != null)
        {
            if (questGoal.quest.isDone)
            {
                questGoal.quest = null;
                foreach (var quest in questDatas.quests)
                {
                    if (quest.isActive)
                    {
                        quest.isActive = false;
                        questID++;
                        if(questID <= questDatas.quests.Count)
                        {
                            questDatas.quests[questID].isActive = true;
                            NewQuest();
                            isQuestTakenText.text = "Quest is not taken yet!";
                            break;
                        }
                    }
                }
            }
            else
            {
                isQuestDoneText.text = "Quest is not done yet!";
            }
        }
    }

    public void NewQuest()
    {
        foreach (var newQuest in questDatas.quests)
        {
            if (newQuest.isActive)
            {
                titleText.text = newQuest.questTitle;
                descriptionText.text = newQuest.questDescription;
                rewardText.text = newQuest.money.ToString("0");
                experienceText.text = newQuest.experience.ToString("0");
            }
        }
    }
}
