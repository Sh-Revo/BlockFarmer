using System.Collections;
using UnityEngine;
using DG.Tweening;

public class Cube : MonoBehaviour
{
    private Transform _cubeParent;
    private bool _isTrigger = false;
    private float _shakeDuration = 0.15f;
    private float _shakeMagnitude = 0.3f;

    void Start()
    {
        DOTween.Init(this);
        _cubeParent = transform.parent;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NoStacked"))
        {
            Anim.AnimManager.Instance.SetAnim("Jump", true);
            Anim.AnimManager.Instance.PlayEffect(_cubeParent.transform.position);
            PopupManager.Instance.InitText(_cubeParent.transform.position);
            Vector3 pos = CubeController.Instance.cubeList[CubeController.Instance.cubeList.Count - 1].transform.localPosition;
            other.transform.parent = _cubeParent;
            other.tag = "Stacked";
            other.transform.localPosition = pos - Vector3.up;
            other.gameObject.AddComponent<Cube>();
            _cubeParent.transform.localPosition += Vector3.up;
            CubeController.Instance.cubeList.Add(other.gameObject);
            StartCoroutine(CameraShake.Instance.Shake(_shakeDuration, _shakeMagnitude));
        }

        if (!_isTrigger && other.CompareTag("Wall"))
        {
            _isTrigger = true;
            transform.parent = null;
            CubeController.Instance.cubeList.Remove(gameObject);
            CubeController.Instance.index++;
            if (CubeController.Instance.cubeList.Count == 0)
            {
                GameManager.Instance.gameStat = GameManager.GameStat.Failed;
            }
            StartCoroutine(Deactive());
            StartCoroutine(Delay());
        }

        if (other.CompareTag("Ground"))
        {
            Anim.AnimManager.Instance.SetAnim("Idle", true);
            CubeController.Instance.index = 0;
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.3f);
        _cubeParent.transform.DOLocalMoveY(_cubeParent.transform.localPosition.y - CubeController.Instance.index, 0.3f);
    }

    IEnumerator Deactive()
    {
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }
}
