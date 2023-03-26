using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Ryanair.DataTier
{
    public class DataClass
    {
        SqlConnection dataConnection = new SqlConnection();

        public DataClass()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "(LocalDB)\\MSSQLLocalDB";
            builder.InitialCatalog = "Ryanair";
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
                flight.Carrier = "Ryanair";
                flight.ID = dataReader.GetInt32(0);
                flight.Reference = dataReader.GetString(1);
                flight.Departure = dataReader.GetDateTime(2);
                flight.Arrival = dataReader.GetDateTime(3);
                flight.Price = dataReader.GetDecimal(4);
                listFlights.Add(flight);
            }
            dataReader.Close();
            dataConnection.Close();

            return listFlights;
        }

    }
}
