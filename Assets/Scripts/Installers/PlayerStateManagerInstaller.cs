using UnityEngine;
using Zenject;

public class PlayerStateManagerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<PlayerStateManager>().FromComponentInHierarchy().AsSingle().NonLazy();
    }
}