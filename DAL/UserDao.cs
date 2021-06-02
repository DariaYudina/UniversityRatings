using Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class UserDao : IUserDao
    {
        private readonly string connectionstring;

        public UserDao(string connectionstring)
        {
            this.connectionstring = connectionstring;
        }

        public bool AddUser(User user)
        {
            string sqlExpression = "AddUser";
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    SqlParameter name = new SqlParameter
                    {
                        ParameterName = "@name",
                        Value = user.Login
                    };
                    command.Parameters.Add(name);
                    SqlParameter pswd = new SqlParameter
                    {
                        ParameterName = "@password",
                        Value = user.Password
                    };
                    command.Parameters.Add(pswd);
                    SqlParameter role = new SqlParameter
                    {
                        ParameterName = "@role",
                        Value = user.Role
                    };
                    command.Parameters.Add(role);
                    var returnParameter = command.Parameters.Add("RetVal", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;
                    command.ExecuteNonQuery();
                    int returnValue = (int)returnParameter.Value;
                    return returnValue < 0 ? true : false;
                }
                catch
                {
                    throw new Exception("layer = DAL, class = UserDBDao, method = AddUser");
                }
            }
        }

        public bool ChangeRoleUser(string name, string role)
        {
            string sqlExpression = "ChangeUserRole";
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    SqlParameter login = new SqlParameter
                    {
                        ParameterName = "@name",
                        Value = name
                    };
                    command.Parameters.Add(login);
                    SqlParameter newRole = new SqlParameter
                    {
                        ParameterName = "@role",
                        Value = role
                    };
                    command.Parameters.Add(newRole);
                    var returnParameter = command.Parameters.Add("RetVal", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;
                    command.ExecuteNonQuery();
                    int returnValue = (int)returnParameter.Value;
                    return returnValue < 0 ? true : false;
                }
                catch
                {
                    throw new Exception("layer = DAL, class = UserDBDao, method = ChangeRoleUser");
                }
            }
        }

        public ICollection<User> GetAllUsers()
        {
            string sqlExpression = "GetAllUsers";
            List<User> users = new List<User>();
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    SqlDataReader reader;
                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        User user = new User()
                        {
                            Login = (string)reader.GetValue(0),
                            Password = (string)reader.GetValue(1),
                            Role = (string)reader.GetValue(2),
                        };

                        users.Add(user);
                    }
                }
                catch
                {
                    throw new Exception("layer = DAL, class = UserDBDao, method = GetAllUsers");
                }
            }

            return users;
        }
    }
}
