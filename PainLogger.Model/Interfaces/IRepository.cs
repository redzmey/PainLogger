﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PainLogger.Model.Interfaces
{
    public interface IRepository<T> where T : IElement
    {
        Task AddNew(T element);
        Task Delete(T element);
        Task<List<T>> GetAll();
        //T GetOne(Guid id);
        //Task<bool> IsExistst(T element);
        //void Update(T element);
    }
}