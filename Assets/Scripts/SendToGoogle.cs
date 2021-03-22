using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class SendToGoogle : MonoBehaviour
{
    private string id;
    private string stage;
    private string solve;
    private string success;
    private string nextMove;
    private string url = "https://docs.google.com/forms/u/1/d/e/1FAIpQLSc2Qr40jWdyUBtFJc0HIYSwnGQBcTPSnQp8lF-OMLkWvK2AKg/formResponse";

    public string Stage { get => stage; set => stage = value; }
    public string Solve { get => solve; set => solve = value; }
    public string Success { get => success; set => success = value; }
    public string Id { get => id; set => id = value; }
    public string NextMove { get => nextMove; set => nextMove = value; }

    public void Send()
    {
        StartCoroutine(PostToGoogle());
    }

    IEnumerator PostToGoogle()
    {
        WWWForm form = new WWWForm();
        form.AddField("entry.418765262", id);
        form.AddField("entry.1715759344", stage);
        form.AddField("entry.421502292", solve);
        form.AddField("entry.790747918", success);
        form.AddField("entry.1364689016", nextMove);

        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
            }
        }
    }

    public void SetDatas(string _id, string _stage, string _solve, string _success, string _nextMove)
    {
        id = _id;
        stage = _stage;
        solve = _solve;
        success = _success;
        nextMove = _nextMove;
    }

}
