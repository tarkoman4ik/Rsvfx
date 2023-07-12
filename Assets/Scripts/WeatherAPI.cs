using System.Collections;
using SimpleJSON;
//using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

//namespace AIR.Scripts.WeatherWidget
    public class WeatherAPI : MonoBehaviour
    {
        [SerializeField] private float cicleTime = 60f;
        private string url = "https://api.openweathermap.org/data/2.5/onecall?lat=51.77&lon=55.09&exclude=minutely,daily,alerts&appid=18a6eefb2b34b8b64b0e18f23d497227&lang=ru&units=metric";
        public string city;
        public string weatherDescription;
        public string temp;

        [ContextMenu("Debug")]
        private void DebugWeather()
        {
            WeatherUpdate?.Invoke();
        }

        public delegate void WeatherEvent();

        public event WeatherEvent WeatherUpdate;

        private void Start()
        {
            ShowWeather();
        }
        public void ShowWeather()
        {
            StartCoroutine(CicleWeather());
        }
        private IEnumerator CicleWeather()
        {
            while (true)
            {
                StartCoroutine(GetRequest());
                yield return new WaitForSeconds(cicleTime);
                StopCoroutine(GetRequest());
            }
        }
    IEnumerator GetRequest()
    {
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();
            SetWeatherAttributes(request.downloadHandler.text);
        }
    }

    //private IEnumerator SetWeather()
    //{
    //    WWWForm request = new WWWForm(url);
    //    UnityWebRequest request = new UnityWebRequest(url);
    //    WWW request = new WWW(url);

    //    yield return request.SendWebRequest();
    //    if (request.error == null || request.error == "")
    //    {
    //        Debug.Log(request.downloadHandler.text);
    //        SetWeatherAttributes(request.downloadHandler.text);
    //    }
    //    else
    //    {
    //        Debug.Log("Error: " + request.error);
    //    }
    //}
    void SetWeatherAttributes(string jsonString)
        {

            var weatherJson = JSON.Parse(jsonString);

            var weatherStatus = weatherJson["current"]["weather"][0]["id"].AsInt.ToString();
            if (weatherStatus == "800")
            {
                weatherDescription = Constants.CLEAR;
            }
            else
            {
                weatherStatus = weatherStatus.Substring(0, weatherStatus.Length - 1);
                if (weatherStatus == "80")
                {
                    weatherDescription = Constants.CLOUDS;
                }
                else
                {
                    weatherStatus = weatherStatus.Substring(0, weatherStatus.Length - 1);
                    switch (weatherStatus)
                    {
                        case "7":
                            {
                                weatherDescription = Constants.FOG;
                                break;
                            }
                        case "6":
                            {
                                weatherDescription = Constants.SNOW;
                                break;
                            }
                        case "5":
                            {
                                weatherDescription = Constants.RAIN;
                                break;
                            }
                        case "3":
                            {
                                weatherDescription = Constants.DRIZZLE;
                                break;
                            }
                        case "2":
                            {
                                weatherDescription = Constants.THUNDERSTORM;
                                break;
                            }
                    }
                }
            }

            city = "Оренбург";
            var sTemp = weatherJson["current"]["temp"].Value;
            temp = sTemp.Substring(0, sTemp.IndexOf('.'));
            WeatherUpdate?.Invoke();
            Debug.Log("WeatherUpdate: " + city + ", " + weatherDescription + ", " + temp);

        }
    }
