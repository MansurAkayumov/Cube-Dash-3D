using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NewCubeManager : MonoBehaviour 
{
    [SerializeField] private GameObject _newCubePanel;
    [SerializeField] private GameObject[] _skills;
    [SerializeField] private Animator _animator;
    [SerializeField] private Text _newCubeValueText;
    private AudioManager _audioManager;
    private Skill _skillManager;
    private int _randomSkill;

    private void Start() 
    {
        _audioManager = FindObjectOfType<AudioManager>();
        _skillManager = FindObjectOfType<Skill>();
    }

    public IEnumerator OpenNewCubePanel(int value)
    {
        yield return new WaitForSeconds(1f);

        foreach (var skill in _skills)
        {
            skill.SetActive(false);
        }
        _newCubePanel.SetActive(true);
        _animator.SetBool("isOpen", true);
        _newCubeValueText.text = "" + value;
        _audioManager.Play(3);
        _randomSkill = Random.Range(0, _skills.Length);
        _skills[_randomSkill].SetActive(true);
    }

    public void CloseNewCubePanel()
    {
        _newCubePanel.SetActive(false);
        _animator.SetBool("isOpen", false);
    }

    public void ClaimSkill()
    {   
        _skillManager.ClaimSkill(_skills[_randomSkill].name);
    }
}