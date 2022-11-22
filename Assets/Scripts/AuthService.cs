
using System;
using System.Collections;

using System.Text;
using UnityEngine;
using UnityEngine.Networking;
[System.Serializable]
public class AuthService : MonoBehaviour
{
    [SerializeField] private string m_Username = string.Empty;
    [SerializeField] private string m_Password = string.Empty;

    [SerializeField]
    public string username
    {
        get => m_Username;
        set => m_Username = value;

    }

    [SerializeField]
    public string password
    {
        get => m_Password;
        set => m_Password = value;
    }

    private class BypassCertificate : CertificateHandler
    {
        protected override bool ValidateCertificate(byte[] certificateData)
        {
            //Simply return true no matter what
            return true;
        }
    } 
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SignIn());
    }

    IEnumerator SignIn()
    {
       var body = "{\"username\": \"string\",\"password\": \"string\"}";
        using ( UnityWebRequest www = UnityWebRequest.Post("https://localhost:7292/api/Auth/login",body))
        {
            www.uploadHandler= new UploadHandlerRaw(string.IsNullOrEmpty(body) ? null : Encoding.UTF8.GetBytes(body));
            www.certificateHandler = new BypassCertificate() ;
            www.SetRequestHeader("Content-Type", "application/json");
            www.SetRequestHeader("accept","text/plain" ); 
           

            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.downloadHandler.text);
            }
            else
            {
                var token = www.downloadHandler.text;
                Debug.Log("Received : "+token);
                PlayerData.token = token;
            }

        }

    }
    
    UnityWebRequest CreateApiRequest(string url, string method, object body)
    {
        string bodyString = null;
        if (body is string)
        {
            bodyString = (string)body;
        }
        else if (body != null)
        {
            bodyString = JsonUtility.ToJson(body);
        }
 
        var request = new UnityWebRequest();
        request.url = url;
        request.method = method;
        request.downloadHandler = new DownloadHandlerBuffer();
        request.uploadHandler = new UploadHandlerRaw(string.IsNullOrEmpty(bodyString) ? null : Encoding.UTF8.GetBytes(bodyString));
        request.SetRequestHeader("Accept", "application/json");
        request.SetRequestHeader("Content-Type", "application/json");
        request.timeout = 60;
        return request;
    }
}
