using System;
using System.Threading.Tasks;

namespace _Project.Infrustructure.Services.SceneLoader
{
    public interface ISceneLoaderService
    {
        SceneName CurrentScene { get; }
        Task Load(SceneName name, Action onLoaded = null);
    }
}