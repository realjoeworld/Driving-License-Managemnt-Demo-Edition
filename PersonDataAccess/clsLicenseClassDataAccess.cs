using System;
using System.Data;
using System.Data.SqlClient;


namespace PersonDataAccess
{
    public class clsLicenseClassDataAccess
    {

        public static DataTable GetClassNameAndID()
        {

            DataTable dtGetClassNameAndID = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "select LicenseClassID,ClassName from LicenseClasses;";

            SqlCommand Command = new SqlCommand(Query, Connection);

            try
            {

                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    dtGetClassNameAndID.Load(Reader);
                }

                Reader.Close();

            }
            catch (Exception)
            {
                dtGetClassNameAndID = null;
            }
            finally
            {
                Connection.Close();

            }
            return dtGetClassNameAndID;
        }

    }
}
