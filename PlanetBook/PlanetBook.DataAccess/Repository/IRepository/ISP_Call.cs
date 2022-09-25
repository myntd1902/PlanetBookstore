﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetBook.DataAccess.Repository.IRepository
{
    public interface ISP_Call : IDisposable
    {
        T Single<T>(string procedureName, DynamicParameters dynamicParameters = null);
        void Execute(string procedureName, DynamicParameters dynamicParameters = null);
        T OneRecord<T>(string procedureName, DynamicParameters dynamicParameters = null);
        IEnumerable<T> List<T>(string procedureName, DynamicParameters dynamicParameters = null);
        Tuple<IEnumerable<T1>, IEnumerable<T2>> List<T1, T2>(string procedureName, DynamicParameters dynamicParameters = null);
    }
}
