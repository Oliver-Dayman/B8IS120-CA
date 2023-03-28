using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Data;

namespace VISA.DataTier
{
    public class DataClass
    {
        SqlConnection dataConnection = new SqlConnection();

        public DataClass()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "(LocalDB)\\MSSQLLocalDB";
            builder.InitialCatalog = "VISA";
            builder.IntegratedSecurity = true;

            dataConnection.ConnectionString = builder.ConnectionString;
        }

        public string CreatePayment(Payment newPayment)
        {
            dataConnection.Open();
            SqlCommand dataCommand = new SqlCommand();
            dataCommand.Connection = dataConnection;
            dataCommand.CommandType = CommandType.Text;
            dataCommand.CommandText = "INSERT INTO Payment(Merchant, ExternalRef, Card, Expiry, CVV, Name, Price)" +
                                        " VALUES(@Merchant, @ExternalRef, @Card, @Expiry, @CVV, @Name, @Price)";

            SqlParameter param1 = new SqlParameter("@Merchant", SqlDbType.NVarChar);
            param1.Value = newPayment.Merchant;
            dataCommand.Parameters.Add(param1);

            SqlParameter param2 = new SqlParameter("@ExternalRef", SqlDbType.NVarChar);
            param2.Value = newPayment.ExternalRef;
            dataCommand.Parameters.Add(param2);

            SqlParameter param3 = new SqlParameter("@Card", SqlDbType.NVarChar);
            param3.Value = newPayment.Card;
            dataCommand.Parameters.Add(param3);

            SqlParameter param4 = new SqlParameter("@Expiry", SqlDbType.NVarChar);
            param4.Value = newPayment.Expiry;
            dataCommand.Parameters.Add(param4);

            SqlParameter param5 = new SqlParameter("@CVV", SqlDbType.NVarChar);
            param5.Value = newPayment.CVV;
            dataCommand.Parameters.Add(param5);

            SqlParameter param6 = new SqlParameter("@Name", SqlDbType.Decimal);
            param6.Value = newPayment.Name;
            dataCommand.Parameters.Add(param6);

            SqlParameter param7 = new SqlParameter("@Price", SqlDbType.NVarChar);
            param7.Value = newPayment.Price;
            dataCommand.Parameters.Add(param7);

            //output parameter - to receive back Auth Code/ID
            SqlParameter param8 = new SqlParameter("@ID", SqlDbType.Int);
            param8.Direction = ParameterDirection.Output;
            dataCommand.Parameters.Add(param8);

            dataCommand.ExecuteNonQuery();
            string authCode = dataCommand.Parameters["@ID"].Value.ToString();

            dataConnection.Close();
            return authCode;
        }
    }
}
