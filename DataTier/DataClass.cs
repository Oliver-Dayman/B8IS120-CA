using System;
using System.Collections.Generic;
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
            string cmdText = "SELECT ID, Reference, Departure, Arrival, Price FROM Flights";
            return RetrieveFlights(cmdText);
        }

        public List<Flight> GetFlights(string dt)
        {
            string cmdText = "SELECT ID, Reference, Departure, Arrival, Price FROM Flights WHERE DATEADD(dd, 0, DATEDIFF(dd, 0, Departure)) = '" + dt + "'";
            return RetrieveFlights(cmdText);
        }

        public List<Flight> RetrieveFlights(string cmdText)
        {
            List<Flight> listFlights = new List<Flight>();
            try
            {
                dataConnection.Open();
                SqlCommand dataCommand = new SqlCommand();
                dataCommand.Connection = dataConnection;
                dataCommand.CommandType = CommandType.Text;
                dataCommand.CommandText = cmdText;

                SqlDataReader dataReader = dataCommand.ExecuteReader();

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

                return listFlights;
            }
            catch (Exception e)
            {
                return listFlights;
            }
            finally
            {
                if (dataConnection != null)
                { dataConnection.Close(); }
            }
        }

        public string CreateBooking(Booking newBooking)
        {
            try
            {
                dataConnection.Open();
                SqlCommand dataCommand = new SqlCommand();
                dataCommand.Connection = dataConnection;
                dataCommand.CommandType = CommandType.Text;
                dataCommand.CommandText = "INSERT INTO Bookings(Name, Address1, Phone, Email, FlightRef, Price, PayRef)" +
                                            " VALUES(@Name, @Address, @Phone, @Email, @FlightRef, @Price, @Payref);SELECT SCOPE_IDENTITY();";

                SqlParameter param1 = new SqlParameter("@Name", SqlDbType.NVarChar);
                param1.Value = newBooking.Name;
                dataCommand.Parameters.Add(param1);

                SqlParameter param2 = new SqlParameter("@Address", SqlDbType.NVarChar);
                param2.Value = newBooking.Address1;
                dataCommand.Parameters.Add(param2);

                SqlParameter param3 = new SqlParameter("@Phone", SqlDbType.NVarChar);
                param3.Value = newBooking.Phone;
                dataCommand.Parameters.Add(param3);

                SqlParameter param4 = new SqlParameter("@Email", SqlDbType.NVarChar);
                param4.Value = newBooking.Email;
                dataCommand.Parameters.Add(param4);

                SqlParameter param5 = new SqlParameter("@FlightRef", SqlDbType.NVarChar);
                param5.Value = newBooking.FlightRef;
                dataCommand.Parameters.Add(param5);

                SqlParameter param6 = new SqlParameter("@Price", SqlDbType.Decimal);
                param6.Value = newBooking.Price;
                dataCommand.Parameters.Add(param6);

                SqlParameter param7 = new SqlParameter("@Payref", SqlDbType.NVarChar);
                param7.Value = newBooking.PayRef;
                dataCommand.Parameters.Add(param7);

                SqlParameter param8 = new SqlParameter("@ID", SqlDbType.Int, 0, "ID");
                param8.Direction = ParameterDirection.Output;
                dataCommand.Parameters.Add(param8);

                string bookingRef = "";
                object retObject = dataCommand.ExecuteScalar();
                if (retObject != null)
                {
                    bookingRef = retObject.ToString();
                }

                return bookingRef;
            }
            catch (Exception e)
            {
                return "";
            }
            finally
            {
                if (dataConnection != null)
                { dataConnection.Close(); }
            }
        }
        public string ConfirmBooking(Confirmation newConfirmation)
        {
            try
            {
                dataConnection.Open();
                SqlCommand dataCommand = new SqlCommand();
                dataCommand.Connection = dataConnection;
                dataCommand.CommandType = CommandType.Text;
                dataCommand.CommandText = "UPDATE Bookings SET PayRef = @PayRef WHERE ID = @ID";

                SqlParameter param1 = new SqlParameter("@PayRef", SqlDbType.NVarChar);
                param1.Value = newConfirmation.PayRef;
                dataCommand.Parameters.Add(param1);

                SqlParameter param2 = new SqlParameter("@ID", SqlDbType.Int);
                param2.Value = newConfirmation.BookingID;
                dataCommand.Parameters.Add(param2);

                dataCommand.ExecuteNonQuery();

                return "ok";
            }
            catch (Exception e)
            {
                return "";
            }
            finally
            {
                if (dataConnection != null)
                { dataConnection.Close(); }
            }
        }
    }
}
