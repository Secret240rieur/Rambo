using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Text;
using Newtonsoft.Json;

public class PromoCodeGenerator : MonoBehaviour
{
    public int numberOfCodesToGenerate = 100;

    public void GeneratePromoCodes()
    {
        int codeLength = 7;

        List<string> promoCodes = new();

        for (int i = 0; i < numberOfCodesToGenerate; i++)
        {
            string code = GenerateCode(codeLength);

            promoCodes.Add(code);
        }

        StartCoroutine(UploadPromoCodes(promoCodes));
    }

    IEnumerator UploadPromoCodes(List<string> promoCodes)
    {
        foreach (string code in promoCodes)
        {
            Debug.Log("code to upload: "+code);

            using UnityWebRequest request = new("https://parseapi.back4app.com/classes/PromoCode", "POST");

            request.SetRequestHeader("X-Parse-Application-Id", Back4app.ApplicationId);
            request.SetRequestHeader("X-Parse-REST-API-Key", Back4app.RestApiKey);
            request.SetRequestHeader("Content-Type", "application/json");

            PromoCode promo = new PromoCode();
            promo.code = code;
            promo.isRedeemed = false;

            var data = new { promo= promo };
            string json = JsonConvert.SerializeObject(data);
            //var json = "{\"promo\":" + promo + "}";
            request.uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(json));
            request.downloadHandler = new DownloadHandlerBuffer();

            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError(request.error);
            }

        }

        Debug.Log("Les codes promo ont été générés et enregistrés dans la base de données !");
    }

    private string GenerateCode(int length)
    {
        string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        string code = "";

        for (int i = 0; i < length; i++)
        {
            int randomIndex = Random.Range(0, characters.Length);
            code += characters[randomIndex];
        }

        return code;
    }
}

[System.Serializable]
public class PromoCode
{
    public string code;
    public bool isRedeemed;
}

