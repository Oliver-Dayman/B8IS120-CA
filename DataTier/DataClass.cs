using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;

namespace AerLingus.DataTier
{
    public class DataClass
    {
        SqlConnection dataConnection = new SqlConnection();

        public DataClass()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "(LocalDB)\\MSSQLLocalDB";
            builder.InitialCatalog = "AerLingus";
            builder.IntegratedSecurity = true;

            dataConnection.ConnectionString = builder.ConnectionString;
        }

        public List<Flight> GetRestaurantNames()
        {
            dataConnection.Open();
            SqlCommand dataCommand = new SqlCommand();
            dataCommand.Connection = dataConnection;
            dataCommand.CommandType = CommandType.Text;
            dataCommand.CommandText = "SELECT RestaurantName FROM RestaurantsNames";

            SqlDataReader dataReader = dataCommand.ExecuteReader();

            List<RestaurantNames> listNames = new List<RestaurantNames>();
            while (dataReader.Read())
            {
                RestaurantNames NameList = new RestaurantNames();
                NameList.RestaurantName = dataReader.GetString(0);
                listNames.Add(NameList);
            }
            dataReader.Close();
            dataConnection.Close();

            return listNames;
        }
        public string BookingGeneral(GeneralBooking gb)
        {
            dataConnection.Open();
            SqlCommand dataCommand = new SqlCommand();
            dataCommand.Connection = dataConnection;
            dataCommand.CommandType = CommandType.Text;
            dataCommand.CommandText = "INSERT INTO GeneralBooking(RestaurantName, TableSize, BookingDate, NameUnder, PhoneNumber)" +
                                        "VALUES(@RestaurantName, @TableSize, @BookingDate, @NameUnder, @PhoneNumber)";

            SqlParameter param1 = new SqlParameter("@RestaurantName", SqlDbType.NVarChar);
            param1.Value = gb.RestaurantName;
            dataCommand.Parameters.Add(param1);
            SqlParameter param2 = new SqlParameter("@TableSize", SqlDbType.Int);
            param2.Value = gb.TableSize;
            dataCommand.Parameters.Add(param2);
            SqlParameter param3 = new SqlParameter("@BookingDate", SqlDbType.DateTime);
            param3.Value = gb.BookingDate;
            dataCommand.Parameters.Add(param3);
            SqlParameter param4 = new SqlParameter("@NameUnder", SqlDbType.NVarChar);
            param4.Value = gb.NameUnder;
            dataCommand.Parameters.Add(param4);
            SqlParameter param5 = new SqlParameter("@PhoneNumber", SqlDbType.Int);
            param5.Value = gb.PhoneNumber;
            dataCommand.Parameters.Add(param5);


            dataCommand.ExecuteNonQuery();

            dataConnection.Close();
            return "";

        }


    }
}
