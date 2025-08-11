using System;
using System.Data;
using System.Data.SqlClient;


namespace PersonDataAccess
{
    public class clsCountryDataAccess
    {


        public static DataTable GetAllCountries() {
        
            DataTable dtCountries = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "select * from Countries";

            SqlCommand Command = new SqlCommand(Query, Connection);


            try
            {

                Connection.Open();

                SqlDataReader Read = Command.ExecuteReader();

                if (Read.Read())
                {

                    dtCountries.Load(Read);

                }

                Read.Close();


            }
            catch (Exception) {
            

            }
            finally
            {

                Connection.Close();

            }


            return dtCountries;

        } 

        public static int GetCountryIndexByName(string CountryName)
        {
            int CountryID = 0;
            DataTable dtCountries = GetAllCountries();
            foreach (DataRow row in dtCountries.Rows)
            {
                if (row["CountryName"].ToString().Equals(CountryName, StringComparison.OrdinalIgnoreCase))
                {
                    CountryID = Convert.ToInt32(row["CountryID"]);
                    break;
                }
            }
            return CountryID;
        }


        public static string GetCountryNameByIndex(int CountryIndex)
        {
            string CountryName = string.Empty;
            DataTable dtCountries = GetAllCountries();

            foreach (DataRow row in dtCountries.Rows)
            {
                // 1. Check if the value in the row is not DBNull.
                // 2. Convert the object value to an integer.
                // 3. Compare it with the provided integer CountryIndex.
                if (row["CountryID"] != DBNull.Value && Convert.ToInt32(row["CountryID"]) == CountryIndex)
                {
                    CountryName = row["CountryName"].ToString();
                    break;
                }
            }
            return CountryName;
        }



    }
}
