using System;
using System.Collections;
using System.Net;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking.Types;
using UnityEngine.Networking;

namespace Covalent
{
    public class WebRequest
    {
        public static async Task<(string,long)> AsyncGetRquest(string url)
        {

            UnityWebRequest request = UnityWebRequest.Get(url);
            request.SendWebRequest();
            while (!request.isDone)
            {
                await Task.Yield();
            }


            if (request.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log($"Error while Sending: {request.error}");
                return (null,500);
            }
            else
            {
                return (request.downloadHandler.text, request.responseCode);
            }

        }
        public static async Task<Texture> AsyncGetTexture(string imageUrl)
        {
            var request = UnityWebRequestTexture.GetTexture(imageUrl);
            request.SendWebRequest();
            while (!request.isDone)
            {
                await Task.Yield();
            }

            if (request.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log($"Error while Sending: {request.error}");
                return null;
            }
            else
            {
                Texture myTexture = DownloadHandlerTexture.GetContent(request);
                return myTexture;
            }
        }
    }
}