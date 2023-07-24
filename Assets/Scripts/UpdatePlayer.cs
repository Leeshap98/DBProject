using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class UpdatePlayer : MonoBehaviour
{
    public TMPro.TMP_Text player_name;
    public Button startGameButton;

    public void UpdatePlayerFunc()
    {

        StartCoroutine(UpdatePlayerCoroutine(player_name.text));
    }

    IEnumerator UpdatePlayerCoroutine(string name)
    {
        UnityWebRequest www = UnityWebRequest.Get("https://localhost:44330/api/SetPlayer?name=" + name);
        UnityWebRequest www1 = UnityWebRequest.Get("https://localhost:44330/api/SetActive?name=" + name);
        yield return www.SendWebRequest();
        yield return www1.SendWebRequest();
        if (www.result != UnityWebRequest.Result.Success || www1.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
            Debug.Log(www1.error);
        }
        else
        {
            // Show results as text
            Debug.Log(www1.downloadHandler.text);
            Debug.Log(www.downloadHandler.text);
        }
    }

    IEnumerator CheckPlayersInGame() // NEED TO LIVE CHECK
    {
        UnityWebRequest playersRequest = UnityWebRequest.Get("https://localhost:44330/api/GetPlayersInGame");
        yield return playersRequest.SendWebRequest();

        if (playersRequest.result == UnityWebRequest.Result.Success)
        {
            // Assuming the server responds with the number of players in the game as text
            int playersInGameCount = int.Parse(playersRequest.downloadHandler.text);

            // Update the interactable status of the "Start Game" button based on the number of players in the game
            startGameButton.interactable = playersInGameCount >= 2;
        }
        else
        {
            Debug.Log(playersRequest.error);
        }
    }

}
