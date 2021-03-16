using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class SendToGoogle : MonoBehaviour
{
    public InputField ageField;
    public InputField stageField;
    public InputField solveField;
    public InputField successField;

    private string age;
    private string stage;
    private string solve;
    private string success;
    private string url = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSfUaosyNh0SZPlOhIYkbrCFzRFcY2zn4vXUW4qJKhjFnkJ_jQ/formResponse";

    public string Age { get => age; set => age = value; }
    public string Stage { get => stage; set => stage = value; }
    public string Solve { get => solve; set => solve = value; }
    public string Success { get => success; set => success = value; }
    

    public void Send()
    {
        //DateTime dateTime = DateTime.Today;
        //date = dateTime.ToString("d");
        age = ageField.text;
        stage = stageField.text;
        solve = solveField.text;
        success = successField.text;

        StartCoroutine(PostToGoogle());
    }

    IEnumerator PostToGoogle()
    {
        WWWForm form = new WWWForm();
        form.AddField("entry.740524157", age);
        form.AddField("entry.881140541", stage);
        form.AddField("entry.48220974", solve);
        form.AddField("entry.1609107582", success);

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

}
