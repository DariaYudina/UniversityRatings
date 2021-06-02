using Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class IndicatorDao : IIndicatorDao
    {
        private readonly string connectionstring;

        public IndicatorDao(string connectionstring)
        {
            this.connectionstring = connectionstring;
        }

        public bool UpdateIndicator(Indicator indicator)
        {
            string sqlExpression = "UpdateIndicator";
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    SqlParameter id = new SqlParameter
                    {
                        ParameterName = "@Indicator_Id",
                        Value = indicator.IndicatorId
                    };

                    SqlParameter name = new SqlParameter
                    {
                        ParameterName = "@Value",
                        Value = indicator.Value
                    };

                    command.Parameters.Add(id);
                    command.Parameters.Add(name);

                    var returnParameter = command.ExecuteNonQuery();
                    return returnParameter > 0 ? true : false;
                }
                catch
                {
                    throw new Exception("layer = DAL, class = UserDBDao, method = AddUser");
                }
            }
        }

        public List<Indicator> GetAllIndicators(int universitiid)
        {
            string sqlExpression = "GetAllIndicators";
            List<Indicator> indicators = new List<Indicator>();
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    SqlParameter id = new SqlParameter
                    {
                        ParameterName = "@UniversityId",
                        Value = universitiid
                    };

                    command.Parameters.Add(id);

                    SqlDataReader reader;
                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Indicator indicator = new Indicator()
                        {
                            IndicatorId = (int)reader.GetValue(0),
                            UniversityId = (int)reader.GetValue(1),
                            IndicatorName = (string)reader.GetValue(2),
                            Value = (int)reader.GetValue(3),
                            UnitOfMeasure = (string)reader.GetValue(4),
                            UniversityName = (string)reader.GetValue(5)
                        };

                        indicators.Add(indicator);
                    }
                }
                catch
                {
                    throw new Exception("layer = DAL, class = UserDBDao, method = GetAllIndicators");
                }
            }

            return indicators;
        }
    }
}
