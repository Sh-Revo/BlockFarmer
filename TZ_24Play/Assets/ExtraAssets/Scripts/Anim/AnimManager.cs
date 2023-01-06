using UnityEngine;

namespace Anim
{
    public class AnimManager : MonoBehaviour
    {
        public static AnimManager Instance { get; private set; }

        [SerializeField] private Animator _playerAnimator;
        [SerializeField] private GameObject _stackEffect;

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
        }

        public void SetAnim(string animName, bool anim)
        {
            _playerAnimator.SetBool(animName, anim);
        }

        public void PlayEffect(Vector3 pos)
        {
            GameObject _effect = Instantiate(_stackEffect, pos, Quaternion.identity);
            Destroy(_effect, 2f);
        }
    }
}

