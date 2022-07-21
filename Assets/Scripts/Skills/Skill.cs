using UnityEngine;

public class Skill : MonoBehaviour 
{
    public static Skill Instance;

    [SerializeField] private TornadoManager _tornadoManager;
    [SerializeField] private Teleporter _teleporter;
    [HideInInspector] public bool _isTeleportEnabled = false;  
    
    private void Awake()
    {
        if(Instance == null)
            Instance = this;
    }

    public void ClaimSkill(string name)
    {
        if(name == "Tornado")
            _tornadoManager.AddTornado();
        if(name == "Teleport")
            _teleporter.AddTeleport();
    }
}