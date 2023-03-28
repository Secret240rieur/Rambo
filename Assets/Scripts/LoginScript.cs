using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;
using Newtonsoft.Json;

public class LoginScript : MonoBehaviour
{

    [SerializeField] TMP_Text password;
    [SerializeField] TMP_Text email;
    
   

    public void SignUp()
    {
        StartCoroutine(SignUpBackend());
        //StartCoroutine(VerifyEmail());
    }


    public IEnumerator SignUpBackend()
    {
        using var request = new UnityWebRequest("https://parseapi.back4app.com/users", "POST");
        request.SetRequestHeader("X-Parse-Application-Id", Back4app.ApplicationId);
        request.SetRequestHeader("X-Parse-REST-API-Key", Back4app.RestApiKey);
        request.SetRequestHeader("X-Parse-Revocable-Session", "1");
        request.SetRequestHeader("Content-Type", "application/json");
        var data = new { username = email.text, email = email.text, password = password.text };
        string json = JsonConvert.SerializeObject(data);
        request.uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(json));
        request.downloadHandler = new DownloadHandlerBuffer();
        yield return request.SendWebRequest();
        if (request.result != UnityWebRequest.Result.Success)
        {
           StartCoroutine(LoginBack4app());
        }
        Debug.Log(request.downloadHandler.text);
        //StartCoroutine(VerifyEmail());
    }


    public IEnumerator VerifyEmail()
    {
        using var request = new UnityWebRequest("https://parseapi.back4app.com/verificationEmailRequest", "POST");
        request.SetRequestHeader("X-Parse-Application-Id", Back4app.ApplicationId);
        request.SetRequestHeader("X-Parse-REST-API-Key", Back4app.RestApiKey);
        request.SetRequestHeader("Content-Type", "application/json");
        var data = new { email = email.text };
        string json = JsonConvert.SerializeObject(data);
        request.uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(json));
        request.downloadHandler = new DownloadHandlerBuffer();
        yield return request.SendWebRequest();
        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError(request.error);
            Debug.Log(email.text);

            yield break;
        }
        Debug.Log(email.text);
    }

    public IEnumerator LoginBack4app()
    {
        using var request = new UnityWebRequest("https://parseapi.back4app.com/login", "POST");
        request.SetRequestHeader("X-Parse-Application-Id", Back4app.ApplicationId);
        request.SetRequestHeader("X-Parse-REST-API-Key", Back4app.RestApiKey);
        request.SetRequestHeader("X-Parse-Revocable-Session", "1");
        request.SetRequestHeader("Content-Type", "application/json");
        var data = new { username = email.text, password = password.text };
        string json = JsonConvert.SerializeObject(data);
        request.uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(json));
        request.downloadHandler = new DownloadHandlerBuffer();
        yield return request.SendWebRequest();
        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError(request.error);
            yield break;
        }
        Debug.Log(request.downloadHandler.text);
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
