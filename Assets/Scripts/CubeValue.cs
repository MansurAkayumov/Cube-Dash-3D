using UnityEngine;
using TMPro;
using System.Collections;

public class CubeValue : MonoBehaviour 
{
    [HideInInspector] public int _value;
    [HideInInspector] public int _point => (int)Mathf.Pow(2, _value);
    [SerializeField] private int[] _congValues;
    public TextMeshPro[] _valueTexts;
    private NewCubeManager _newCubeManager;
    private const int _maxValue = 18;

    private void Start() 
    {
        _newCubeManager = FindObjectOfType<NewCubeManager>();
    }

    public void SetValue(int value)
    {
        _value = value;
        UpdateValue();
    }

    private void UpdateValue()
    {
        UpdateValueText();
        ColorManager.Instance.SetColor(GetComponent<Renderer>(), _value);

        if(_value >= _maxValue)
        {
            Destroy(gameObject);
        }

        CheckRewardValues();
    }

    private void UpdateValueText()
    {
        foreach(TextMeshPro valueText in _valueTexts)
        {
            if(_value >= 17)
                valueText.text = _point.ToString().Substring(0, 3) + "K";
            else if(_value >= 14)
                valueText.text = _point.ToString().Substring(0, 2) + "K";
            else if(_value >= 1)
                valueText.text = _point.ToString();
        }
    }

    private void CheckRewardValues()
    {
        foreach(int rewardValue in _congValues)
        {
            if(_value == rewardValue)
                Reward();
        }
    }

    private void Reward()
    {
        StartCoroutine(_newCubeManager.OpenNewCubePanel(_point));
    }
}