using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagerMobile.Services.Interfaces
{
    public interface INavigationDataService
    {
        void Set<T>(T data);
        T? Get<T>();
        void Clear<T>();
    }
}
