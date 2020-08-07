using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreaturePanel : MonoBehaviour
{
    public GameObject creaturePrefab;
    public GameObject creatureContainer;

    public int buttonLength; 

    void Start()
    {
        for (int i = 0; i < buttonLength; i++)
        {
            GameObject creatureInstance = (GameObject)Instantiate(creaturePrefab);
            creatureInstance.transform.SetParent(creatureContainer.transform, false);
        }
    }
}
