using ProjectManagerMobile.Services.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagerMobile.Services
{
    public class NavigationDataService : INavigationDataService
    {
        private readonly ConcurrentDictionary<Type, object> _dataStore = new();

        public void Set<T>(T data)
        {
            _dataStore[typeof(T)] = data!;
        }

        public T? Get<T>()
        {
            _dataStore.TryGetValue(typeof(T), out var data);
            return data is T typed ? typed : default;
        }

        public void Clear<T>()
        {
            _dataStore.TryRemove(typeof(T), out _);
        }
    }
}
