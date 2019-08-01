using System.Collections.Generic;

namespace Reggora.Api.Storage
{
    public abstract class Storage<T, C> where T : Entity.Entity
    {
        public readonly ApiClient<C> Api;
        public readonly Dictionary<string, T> Known = new Dictionary<string, T>();

        protected Storage(ApiClient<C> api)
        {
            Api = api;
        }
    }
}