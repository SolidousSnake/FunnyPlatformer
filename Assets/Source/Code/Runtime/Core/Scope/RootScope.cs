using Source.Code.Runtime.Core.SceneManagement;
using Source.Code.Runtime.Services.InputService;
using VContainer;
using VContainer.Unity;

namespace Source.Code.Runtime.Core.Scope
{
    public sealed class RootScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<ISceneLoader, SceneLoader>(Lifetime.Singleton);
            builder.RegisterEntryPoint<OldInputService>();
        }
    }
}