﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlayerPrefsScript : EditorWindow
{
    [MenuItem("Window/Delete PlayerPrefs(All)")]
     static void DeleteAllPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}
