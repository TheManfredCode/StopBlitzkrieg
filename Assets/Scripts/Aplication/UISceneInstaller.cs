using System;
using UI;
using UnityEngine;
using Zenject;

namespace Aplication
{
    public class UISceneInstaller : MonoInstaller
    {
        [SerializeField] private MainUI _mainUI;
        [SerializeField] private WindowsView _windowsView;

        private void Awake()
        {
            //Ticker.Init();
        }

        public override void InstallBindings()
        {
            Container.Bind<ApplicationBase>().AsSingle().NonLazy();
        }
    }
}