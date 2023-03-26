using System.Collections.Generic;
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

        public List<Flight> GetFlights()
        {
            dataConnection.Open();
            SqlCommand dataCommand = new SqlCommand();
            dataCommand.Connection = dataConnection;
            dataCommand.CommandType = CommandType.Text;
            dataCommand.CommandText = "SELECT ID, Reference, Departure, Arrival, Price FROM Flights";

            SqlDataReader dataReader = dataCommand.ExecuteReader();

            List<Flight> listFlights = new List<Flight>();
            while (dataReader.Read())
            {
                Flight flight = new Flight();
                flight.ID = dataReader.GetInt32(0);
                flight.Reference = dataReader.GetString(1);
                flight.Departure = dataReader.GetDateTime(2);
                flight.Arrival = dataReader.GetDateTime(3);
                flight.Price = dataReader.GetDecimal(4);
                flight.Carrier = "Aer Lingus";
                listFlights.Add(flight);
            }
            dataReader.Close();
            dataConnection.Close();

            return listFlights;
        }
        //public string BookingGeneral(GeneralBooking gb)
        //{
        //    dataConnection.Open();
        //    SqlCommand dataCommand = new SqlCommand();
        //    dataCommand.Connection = dataConnection;
        //    dataCommand.CommandType = CommandType.Text;
        //    dataCommand.CommandText = "INSERT INTO GeneralBooking(RestaurantName, TableSize, BookingDate, NameUnder, PhoneNumber)" +
        //                                "VALUES(@RestaurantName, @TableSize, @BookingDate, @NameUnder, @PhoneNumber)";

        //    SqlParameter param1 = new SqlParameter("@RestaurantName", SqlDbType.NVarChar);
        //    param1.Value = gb.RestaurantName;
        //    dataCommand.Parameters.Add(param1);
        //    SqlParameter param2 = new SqlParameter("@TableSize", SqlDbType.Int);
        //    param2.Value = gb.TableSize;
        //    dataCommand.Parameters.Add(param2);
        //    SqlParameter param3 = new SqlParameter("@BookingDate", SqlDbType.DateTime);
        //    param3.Value = gb.BookingDate;
        //    dataCommand.Parameters.Add(param3);
        //    SqlParameter param4 = new SqlParameter("@NameUnder", SqlDbType.NVarChar);
        //    param4.Value = gb.NameUnder;
        //    dataCommand.Parameters.Add(param4);
        //    SqlParameter param5 = new SqlParameter("@PhoneNumber", SqlDbType.Int);
        //    param5.Value = gb.PhoneNumber;
        //    dataCommand.Parameters.Add(param5);


        //    dataCommand.ExecuteNonQuery();

        //    dataConnection.Close();
        //    return "";

        //}
    }
}
