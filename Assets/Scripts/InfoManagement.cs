using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoManagement : MonoBehaviour
{
    public void Info(string info , float wait)
    {
        StartCoroutine(InfoCo(info, wait));
    }

    public IEnumerator InfoCo(string words, float waitTime)
    {
        while (true)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(0).transform.Find("InfoText").GetComponent<Text>().text = words;
            yield return new WaitForSeconds(waitTime);
            transform.GetChild(0).gameObject.SetActive(false);
            break;
        }
    }
}
