using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Linq;
using System.Data;
using System.Data.SqlClient; // System.Data.SqlClient is the ADO.NET provider you use to access SQL Server or Azure SQL Databases.
using Microsoft.Extensions.Configuration;
using HotelAppLibrary.Models;

namespace HotelAppLibrary.Databases
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration _config;

        public SqlDataAccess(IConfiguration config)
        {
            _config = config;
        }

        public IConfiguration Config { get; }

        public List<T> LoadData<T, U>(string sqlStatement,
                                      U parameters,
                                      string connectionStringName,
                                      bool isStoredProc = false)
        {
            string connectionString = _config.GetConnectionString(connectionStringName);
            CommandType commandType = CommandType.Text;

            if (isStoredProc == true)
            {
                commandType = CommandType.StoredProcedure;
            }

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                List<T> rows = connection.Query<T>(sqlStatement, parameters, commandType: commandType).ToList();
                return rows;
            }
        }

        public ReservationModel SaveData<T>(string sqlStatement,
                                T parameters,
                                string connectionStringName,
                                bool isStoredProc = false)
        {
            string connectionString = _config.GetConnectionString(connectionStringName);
            CommandType commandType = CommandType.Text;
            ReservationModel affectedRows;

            if (isStoredProc == true)
            {
                commandType = CommandType.StoredProcedure;
            }

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                 affectedRows = connection.Execute(sqlStatement, parameters, commandType: commandType);
                //Console.Write(affectedRows);
            }
            return (ReservationModel)affectedRows; //how to get it to return the obj (or at least the ID of the newly inserted row) rather than just an int of 1 or -1 ? ? 
        } //also looks like I can't push to git from the UI  ? ? ? 
    }

}
