using System;
using System.Collections;
using UnityEngine;

namespace Effects
{
    public class DissolveEffectView : MonoBehaviour
    {
        [SerializeField] private Material _material;

        private float _dissolveValue;
        private bool _isDissolving;

        private void OnEnable()
        {
            _isDissolving = true;
            StartCoroutine(CreateCoroutine(() =>
            {
                Debug.Log("DONE!!");
            }, 2f));
        }

        public void StartDissolve(Action callback, float seconds) =>
            StartCoroutine(CreateCoroutine(callback, seconds));
        
        private IEnumerator CreateCoroutine(Action callback, float seconds)
        {
            float elapsedTime = 0;

            while (elapsedTime < seconds)
            {
                elapsedTime += Time.deltaTime;
                Debug.Log(elapsedTime);
                yield return null;
            }
            
            callback?.Invoke();
        }
    }
}