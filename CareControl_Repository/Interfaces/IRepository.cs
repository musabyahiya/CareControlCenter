using CareControl_DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace CareControl_Repository.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Get(int id);
        IEnumerable<T> GetAll();
    }
}
