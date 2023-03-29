using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

public class LoginScript : MonoBehaviour
{

    [SerializeField] TMP_Text password;
    [SerializeField] TMP_Text email;
    [SerializeField] TMP_Text emailError;
    [SerializeField] TMP_Text passError;

    void EmailError(string message)
    {
        if (message == "{\"code\":125,\"error\":\"Email address format is invalid.\"}")
            emailError.text = "Email address format is invalid.";
       else if (message == "{\"code\":202,\"error\":\"Account already exists for this username.\"}")
            emailError.text = "Account already exists for this username.";
    }

    void PassError(string message)
    {
         if (message == "HTTP/1.1 404 Not Found")
            passError.text = "Wrong password";
    }

    public void SignUp()
    {
        if (password.text.Length == 1)
            passError.text = "You must enter a password";
        if (email.text.Length == 1)
            emailError.text = "You must enter an email";
        else StartCoroutine(SignUpBackend());
    }

    public void Login()
    {
        if (password.text.Length == 1)
         passError.text = "You must enter a password";
        if (email.text.Length == 1)
            emailError.text = "You must enter an email";
        else StartCoroutine(LoginBackend());
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
            Debug.LogError(request.error);
        }
        EmailError(request.downloadHandler.text);
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
            yield break;
        }
    }

    public IEnumerator LoginBackend()
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
            EmailError(request.error);
            PassError(request.error);
            yield break;
        }
        EmailError(request.downloadHandler.text);
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
