using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public class Preloader :MonoBehaviour
    {
        [SerializeField] private TMP_Text _errorLogLabel;
        [SerializeField] private Button _reload;

        private InterfaceController _interfaceController;
        
        [Inject]
        private void Construct(InterfaceController interfaceController)
        {
            gameObject.SetActive(true);
            _interfaceController = interfaceController;
            
            AfterConstruct();
        }

        private void AfterConstruct()
        {
            _interfaceController.HidePreloaderEvent += Hide;
        }

        private void Hide() => gameObject.SetActive(false);
    }
}