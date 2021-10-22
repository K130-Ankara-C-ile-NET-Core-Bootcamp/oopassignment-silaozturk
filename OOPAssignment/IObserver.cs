using System.Collections.Generic;

namespace OOPAssignment
{
    public interface IObserver<T>
        where T : class
    {
        void Update(T provider);
        List<T> GetObservables();
    }
}