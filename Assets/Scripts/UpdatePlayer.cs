using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class UpdatePlayer : MonoBehaviour
{
    public TMPro.TMP_Text player_name;
    public void UpdatePlayerFunc()
    {

        StartCoroutine(UpdatePlayerCoroutine(player_name.text));
    }

    IEnumerator UpdatePlayerCoroutine(string name)
    {
        UnityWebRequest www = UnityWebRequest.Get("https://localhost:44330/api/SetPlayer?name=" + name);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            // Show results as text
            Debug.Log(www.downloadHandler.text);
        }
    }
}
