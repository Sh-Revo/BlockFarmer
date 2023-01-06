using UnityEngine;

public class PopupController : MonoBehaviour
{
    public static PopupController Instance { get; private set; }

    private float _speed = 4f;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Update()
    {
        transform.Translate(Vector3.up * _speed * Time.deltaTime);
    }

    public void DestroyText()
    {
        Destroy(gameObject, 5f);
    }
}
