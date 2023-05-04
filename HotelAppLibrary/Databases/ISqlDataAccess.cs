using HotelAppLibrary.Models;
using Microsoft.Extensions.Configuration;

namespace HotelAppLibrary.Databases
{
    public interface ISqlDataAccess
    {
        IConfiguration Config { get; }

        List<T> LoadData<T, U>(string sqlStatement, 
                               U parameters, 
                               string connectionStringName, 
                               bool isStoredProc = false);

        T SaveData<T>(string sqlStatement,
                         object parameters,
                         string connectionStringName,
                         bool isStoredProc = false);
    }
}