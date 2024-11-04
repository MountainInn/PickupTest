using UnityEngine;
using Zenject;

public class MainInstaller : MonoInstaller
{
    public override void InstallBindings() 
    {
        Container.Bind<Hand>()                     .FromComponentInHierarchy().AsSingle();
        Container.Bind<InteractionRaycast>()       .FromComponentInHierarchy().AsSingle();
        Container.Bind<CharacterController>()      .FromComponentInHierarchy().AsSingle();
        Container.Bind<PlayerCharacterMouseLook>() .FromComponentInHierarchy().AsSingle();
    }
}
