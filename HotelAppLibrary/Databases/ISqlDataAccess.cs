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
        void SaveData<T>(string sqlStatement, 
                         T parameters, 
                         string connectionStringName, 
                         bool isStoredProc = false);
    }
}