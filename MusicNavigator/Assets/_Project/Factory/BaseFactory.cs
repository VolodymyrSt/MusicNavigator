using UnityEngine;

namespace _Project.Factory
{
    public abstract class BaseFactory<T> where T : Object
    {
        public abstract T Create();
    }
}