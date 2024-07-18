using System;
using System.Collections.Generic;
using UI;
using UnityEngine;
using Zenject;

namespace Aplication
{
    public class MainSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ApplicationBase>().AsSingle().NonLazy();
        }
    }
}