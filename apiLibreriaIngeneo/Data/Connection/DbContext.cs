using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using System.Text;

namespace Data.Connection
{
    public class DbContext
    {
        private static string _connectionString = string.Empty;
        private readonly SqlConnection _connection = CreateConnection();
        public static string GetConnectionString()
        {
            if (string.IsNullOrWhiteSpace(_connectionString))
                _connectionString = Util.ConfigReader.GetValue("dbConnectionString");
            return _connectionString;
        }
        public static SqlConnection CreateConnection()
        {
            SqlConnection DbConnection1 = new SqlConnection(GetConnectionString());
            DbConnection1.Open();
            int i = 0;
            while (DbConnection1.State != System.Data.ConnectionState.Open)
            {
                if (i < 10)
                {
                    System.Threading.Thread.Sleep(1500);
                    try
                    {
                        DbConnection1.Open();
                    }
                    catch
                    {
                    }
                    i++;
                }
                else break;
            }
            if (DbConnection1.State != System.Data.ConnectionState.Open)
            {
                throw new Exception("DbConnection1.State != ConnectionState.Open");
            }
            return DbConnection1;
        }
        public SqlCommand CreateCustomCommand(string CommandText)
        {
            SqlCommand sqlcommand = _connection.CreateCommand();
            sqlcommand.CommandTimeout = 30; //30 seconds Time out 
            sqlcommand.CommandType = CommandType.StoredProcedure;
            sqlcommand.CommandText = CommandText;
            return sqlcommand;
        }
        public void CommandSetParameters<TObject>(SqlCommand command, TObject actualModel)
          where TObject : new()
        {
            var inAttributes = actualModel.GetType().GetProperties();
            foreach (var inAttribute in inAttributes)
            {
                object parameterValue = inAttribute.GetValue(actualModel);
                if (parameterValue == null) parameterValue = DBNull.Value;
                command.Parameters.AddWithValue("@" + inAttribute.Name, parameterValue);
            }
        }
        private object GetNullableValue(SqlDataReader reader, PropertyInfo property)
        {
            var t = property.PropertyType;

            if (reader[property.Name] == null || reader[property.Name] is DBNull)
                return null;

            if (property.PropertyType.Name.Equals(typeof(Nullable<>).Name))
            {
                t = Nullable.GetUnderlyingType(t);
                return Convert.ChangeType(reader[property.Name], t);
            }

            return Convert.ChangeType(reader[property.Name], property.PropertyType);
        }
        public List<TModel> GetListByParameter<TModel, TObject>(string procedure, TObject actualModel)
            where TModel : class, new()
            where TObject : new()
        {
            var responseModel = new List<TModel>();

            using (_connection)
            {
                using (var command = CreateCustomCommand(procedure))
                {
                    CommandSetParameters<TObject>(command, actualModel);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TModel model = new TModel();
                            var properties = model.GetType().GetProperties();

                            foreach (var property in properties)
                            {
                                try
                                {
                                    var obj = GetNullableValue(reader, property);
                                    property.SetValue(model, obj);
                                }
                                catch
                                {

                                }
                            }
                            responseModel.Add(model);
                        }

                    }
                }
            }
            return responseModel;
        }
        public List<TModel> GetList<TModel, TObject>(string procedure)
            where TModel : class, new()
            where TObject : new()
        {
            var responseModel = new List<TModel>();

            using (_connection)
            {
                using (var command = CreateCustomCommand(procedure))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TModel model = new TModel();
                            var properties = model.GetType().GetProperties();

                            foreach (var property in properties)
                            {
                                try
                                {
                                    var obj = GetNullableValue(reader, property);
                                    property.SetValue(model, obj);
                                }
                                catch
                                {

                                }
                            }
                            responseModel.Add(model);
                        }

                    }
                }
            }
            return responseModel;
        }

    }
}
