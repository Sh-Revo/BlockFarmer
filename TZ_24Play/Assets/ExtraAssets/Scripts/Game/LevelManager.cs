using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _sections;
    private float _zPosition = 150;
    private float _distance = 30;
    private bool _isCreated = false;
    private int _sectionNumber;

    private void Update()
    {
        if (GameManager.Instance.gameStat != GameManager.GameStat.Failed)
        {
            if (_isCreated == false)
            {
                _isCreated = true;
                StartCoroutine(GenerateSection());
            }
        }
    }

    IEnumerator GenerateSection()
    {
        _sectionNumber = Random.Range(0, _sections.Count);
        Instantiate(_sections[_sectionNumber], new Vector3(0, 0, _zPosition), Quaternion.identity);
        _zPosition += _distance;
        yield return new WaitForSeconds(5f);
        _isCreated = false;
    }
}
