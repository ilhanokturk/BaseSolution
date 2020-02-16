using Dapper;
using System;
using System.Collections.Generic;

namespace BaseSolution.Abstraction.Repository.Base
{
    public interface ISP_Call:IDisposable
    {
        /// <summary>
        /// Listing to datas in database
        /// </summary>
        /// <typeparam name="T">entity</typeparam>
        /// <param name="procedureName">stored procedure name</param>
        /// <param name="param">parameters</param>
        /// <returns>IEnumerable<T></returns>
        IEnumerable<T> ReturnList<T>(string procedureName, DynamicParameters param = null);

        
        /// <summary>
        /// Just execute procedure
        /// </summary>
        /// <param name="procedureName">stored procedure name</param>
        /// <param name="param">parameters</param>
        void ExecuteWithOutReturn(string procedureName, DynamicParameters param = null);

        /// <summary>
        /// execute procedure return only 1 data
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="procedureName"></param>
        /// <param name="param"></param>
        /// <returns>T</returns>
        T ExecuteReturnScaler<T>(string procedureName, DynamicParameters param = null);
    }
}
