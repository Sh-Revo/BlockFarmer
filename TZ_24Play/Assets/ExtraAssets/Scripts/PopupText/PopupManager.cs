using UnityEngine;

public class PopupManager : MonoBehaviour
{
    public static PopupManager Instance { get; private set; }

    [SerializeField] private GameObject _popupText;
    private Vector3 _offset = new Vector3(-2, 0, 0);

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void InitText(Vector3 pos)
    {
        GameObject _text = Instantiate(_popupText, pos + _offset, Quaternion.identity);
    }
}
