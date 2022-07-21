using UnityEngine;
using UnityEngine.UI;

public class Teleporter : MonoBehaviour 
{
    [SerializeField] private Text _amountText;
    private int _amount;
    private float _alphaValue = 0;
    private CubeSpawner _cubeSpawner;
    private CubeValue[] _cubeValues;

    private void Start()
    {
        _amount = PlayerPrefs.GetInt("Teleport");
        UpdateAmount();
        _cubeSpawner = GameObject.Find("CubeSpawner").GetComponent<CubeSpawner>();
    }

    public void Teleport()
    {
        if(_amount >= 1)
        {
            _amount--;
            UpdateAmount();
            _cubeValues = FindObjectsOfType<CubeValue>();

            foreach (var cubeValue in _cubeValues)
            {
                GameObject cube = cubeValue.gameObject;
                CubeValue lastSpawnedCube = _cubeSpawner._lastSpawnedCube.GetComponent<CubeValue>();

                if(cubeValue._value != lastSpawnedCube._value)
                {
                    Skill.Instance._isTeleportEnabled = true;
                    ColorManager.Instance.SetAlpha(cube.GetComponent<Renderer>().material, _alphaValue);
                    ColorManager.Instance.SetTextAlpha(cubeValue._valueTexts, _alphaValue);
                    cube.GetComponent<BoxCollider>().enabled = false;
                    cube.GetComponent<Rigidbody>().isKinematic = true;
                }
            }
        }
    }

    public void AddTeleport()
    {
        _amount++;
        FindObjectOfType<NewCubeManager>().CloseNewCubePanel();
        UpdateAmount();
    }

    private void UpdateAmount()
    {
        _amountText.text = _amount.ToString();
        PlayerPrefs.SetInt("Teleport", _amount);
        Debug.Log("amount: " + _amount);
    }
}