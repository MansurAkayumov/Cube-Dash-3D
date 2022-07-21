using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    private void Awake()
    {
        if(!PlayerPrefs.HasKey("Tornado")) 
            PlayerPrefs.SetInt("Tornado", 3);
        if(!PlayerPrefs.HasKey("Teleport")) 
            PlayerPrefs.SetInt("Teleport", 3);
    }
}