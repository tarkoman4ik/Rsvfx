using System.Collections;
//using AIR.Scripts.WeatherWidget;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
//using TMPro;

namespace WeatherWidget
{
    public class WeatherWidget : MonoBehaviour
    {
        //[SerializeField] public VideoPlayer WeatherVideo;

        [SerializeField] public GameObject Description;
        [SerializeField] public GameObject Temperature;
        [SerializeField] public GameObject City;
        [SerializeField] public Image WeatherIcon;

        [SerializeField] public Sprite ClearSprite;
        [SerializeField] public Sprite CloudsSprite;
        [SerializeField] public Sprite FogSprite;
        [SerializeField] public Sprite SnowSprite;
        [SerializeField] public Sprite RainSprite;
        [SerializeField] public Sprite DrizzleSprite;
        [SerializeField] public Sprite ThunderstormSprite;
        //[SerializeField] public TMP_Text _temperatureText;

        public static WeatherWidget Instance { get; private set; }

        private Text _descriptionText;
        private Text _temperatureText;
        private Text _cityText;

        private string _newDescriptionText;
        private string _newTemperatureText;
        private string _newCityText;

        private WeatherAPI _weatherData;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            _descriptionText = Description.GetComponent<Text>();
            _temperatureText = Temperature.GetComponent<Text>();
            _cityText = City.GetComponent<Text>();

            _weatherData = GetComponent<WeatherAPI>();

            _weatherData.WeatherUpdate += WidgetUpdate;

            InitialState();
        }

        private void InitialState()
        {
            transform.DOScaleX(0, 0);
        }

        [ContextMenu("WidgetUpdate")]
        private void WidgetUpdate()
        {
            StartCoroutine(UpdateView());
        }

        private IEnumerator UpdateView()
        {
            yield return HideWidget();
            UpdateInfo();
            ShowWidget();
        }

        private void UpdateInfo()
        {
            SetFields();
            SetWeatherVideo();
        }

        private void SetFields()
        {
            _newDescriptionText = _weatherData.weatherDescription;
            _newCityText = _weatherData.city;
            if (int.Parse(_weatherData.temp) > 0)
            {
                _newTemperatureText = "+" + _weatherData.temp + "°Ñ";
            }
            else _newTemperatureText = _weatherData.temp + "°Ñ";
        }

        private void SetWeatherVideo()
        {
            switch (_newDescriptionText)
            {
                case Constants.CLEAR:
                    {
                        WeatherIcon.GetComponent<Image>().sprite = ClearSprite;
                        break;
                    }
                case Constants.CLOUDS:
                    {
                        WeatherIcon.GetComponent<Image>().sprite = CloudsSprite;
                        break;
                    }
                case Constants.RAIN:
                    {
                        WeatherIcon.GetComponent<Image>().sprite = RainSprite;
                        break;
                    }
                case Constants.FOG:
                    {
                        WeatherIcon.GetComponent<Image>().sprite = FogSprite;
                        break;
                    }
                case Constants.SNOW:
                    {
                        WeatherIcon.GetComponent<Image>().sprite = SnowSprite;
                        break;
                    }
                case Constants.DRIZZLE:
                    {
                        WeatherIcon.GetComponent<Image>().sprite = DrizzleSprite;
                        break;
                    }
                case Constants.THUNDERSTORM:
                    {
                        WeatherIcon.GetComponent<Image>().sprite = ThunderstormSprite;
                        break;
                    }
            }
        }

        [ContextMenu("HideWidget")]
        public YieldInstruction HideWidget()
        {
            return transform.DOScaleX(0, 1).SetEase(Ease.InOutExpo).OnComplete(HideAllText).WaitForCompletion();
        }

        [ContextMenu("ShowWidget")]
        public void ShowWidget()
        {
            transform.DOScaleX(1, 1).SetEase(Ease.InOutExpo).OnComplete(ShowAllText);
        }

        private void ShowAllText()
        {
            var S = DOTween.Sequence();

            S.Append(_descriptionText.DOText(_newDescriptionText, 1).SetEase(Ease.InOutExpo))
                .Join(Description.GetComponent<CanvasGroup>().DOFade(1, 1).SetEase(Ease.InOutExpo))
                .Join(_temperatureText.DOText(_newTemperatureText, 1).SetEase(Ease.InOutExpo))
                .Join(Temperature.GetComponent<CanvasGroup>().DOFade(1, 1).SetEase(Ease.InOutExpo))
                .Join(_cityText.DOText(_newCityText, 1).SetEase(Ease.InOutExpo))
                .Join(City.GetComponent<CanvasGroup>().DOFade(1, 1).SetEase(Ease.InOutExpo));
        }
        private void HideAllText()
        {
            var S = DOTween.Sequence();

            S.Append(_descriptionText.DOText("", 1).SetEase(Ease.InOutExpo))
                .Join(Description.GetComponent<CanvasGroup>().DOFade(0, 1).SetEase(Ease.InOutExpo))
                .Join(_temperatureText.DOText("", 1).SetEase(Ease.InOutExpo))
                .Join(Temperature.GetComponent<CanvasGroup>().DOFade(0, 1).SetEase(Ease.InOutExpo))
                .Join(_cityText.DOText("", 1).SetEase(Ease.InOutExpo))
                .Join(City.GetComponent<CanvasGroup>().DOFade(0, 1).SetEase(Ease.InOutExpo));

        }
    }
}
