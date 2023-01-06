using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }

    [SerializeField] private bool _localMovement;
    [SerializeField] private Transform _transToMove;
    [SerializeField] private float _playerMoveSpeed;
    [SerializeField] private float _minX, _maxX;
    private Touch _touch;
    private Vector3 _newPos;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    void FixedUpdate()
    {
        if (GameManager.Instance.gameStat == GameManager.GameStat.Play)
        {
            PlayerMove();
        }
    }

    private void PlayerForwardMove()
    {
        _transToMove.Translate(Vector3.forward * _playerMoveSpeed * Time.fixedDeltaTime);
    }

    private void PlayerMove()
    {
        PlayerForwardMove();

        if (Input.touchCount > 0)
        {
            _touch = Input.GetTouch(0);
            if (_touch.phase == TouchPhase.Moved)
            {
                float newX = _touch.deltaPosition.x * Time.deltaTime;
                _newPos = _localMovement ? _transToMove.localPosition : _transToMove.position;
                _newPos.x += newX;
                _newPos.x = Mathf.Clamp(_newPos.x, _minX, _maxX);

                if (_localMovement)
                    _transToMove.localPosition = _newPos;
                else
                    _transToMove.position = _newPos;
            }
        }
    }
}
