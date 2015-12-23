using System;
using System.Collections.Generic;

namespace PainLogger.Model.Interfaces
{
    public interface IRepository<T> where T : IElement
    {
        void Create(T element);
        List<T> GetAll();
        T GetOne(Guid id);
        bool IsExistst(T element);
        void Update(T element);
    }
}