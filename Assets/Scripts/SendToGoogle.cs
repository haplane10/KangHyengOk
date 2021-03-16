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

    private string date;
    private string age;
    private string stage;
    private string solve;
    private string success;
    private string url = "https://docs.google.com/forms/d/1TTDKUj30ZELYCMdaMfaCoochjpYx2N4zAAbncrnpDPk/formResponse";

    public string Date { get => date; set => date = value; }
    public string Age { get => age; set => age = value; }
    public string Stage { get => stage; set => stage = value; }
    public string Solve { get => solve; set => solve = value; }
    public string Success { get => success; set => success = value; }
    

    public void Send()
    {
        DateTime dateTime = DateTime.Today;
        date = dateTime.ToString("d");
        age = ageField.text;
        stage = stageField.text;
        solve = solveField.text;
        success = successField.text;

        StartCoroutine(PostToGoogle());
    }

    IEnumerator PostToGoogle()
    {
        WWWForm form = new WWWForm();
        form.AddField("", date);
        form.AddField("", age);
        form.AddField("", stage);
        form.AddField("", solve);
        form.AddField("", success);

        ;

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
