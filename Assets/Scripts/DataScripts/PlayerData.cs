using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public static class PlayerData
    {
        public static int money { get { return PlayerPrefs.GetInt("Money"); } set { PlayerPrefs.SetInt("Money", value); } }
        public static int level { get { return PlayerPrefs.GetInt("Level"); } set { PlayerPrefs.SetInt("Level", value); } }
        public static int questID { get { return PlayerPrefs.GetInt("QuestID"); } set { PlayerPrefs.SetInt("QuestID", value); } }
    }
