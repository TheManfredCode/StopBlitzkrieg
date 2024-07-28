using System;
using System.Collections;
using UnityEngine;

namespace Effects
{
    public class DissolveEffectView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;

        private Material _material;
        private float _dissolveValue;
        private int _dissolveValueId = Shader.PropertyToID("_DissolveValue");

        // private void OnEnable()
        // {
        //     StartDissolve(() =>
        //     {
        //         Debug.Log("DONE!!");
        //     }, 1f);
        // }
        
        public void ResetEffect()
        {
            _material.SetFloat(_dissolveValueId, 0);
        }

        public void StartDissolve(Action callback, float seconds) =>
            StartCoroutine(CreateDissolveCoroutine(callback, seconds));
        
        private IEnumerator CreateDissolveCoroutine(Action callback, float seconds)
        {
            float elapsedTime = 0;
            _material ??= _spriteRenderer.material;

            while (elapsedTime < seconds)
            {
                elapsedTime += Time.deltaTime;

                float lerpedDissolve = Mathf.Lerp(0, 1f, (elapsedTime / seconds));
                _material.SetFloat(_dissolveValueId, lerpedDissolve);
                
                yield return null;
            }
            
            callback?.Invoke();
        }
    }
}