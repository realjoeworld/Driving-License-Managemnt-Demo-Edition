using System;
using System.Data.SqlClient;
using System.Data;

namespace PersonDataAccess
{
    public class clsApplicationTypesDataAccess
    {

        public static DataTable GetAllApplicationTypes()
        {
            DataTable dtApplicationTypes = new DataTable();
            
            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "select ApplicationTypeID as ID, ApplicationTypeTitle, ApplicationFees as Fees from ApplicationTypes;";

            SqlCommand Command = new SqlCommand(Query, Connection);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    dtApplicationTypes.Load(Reader);
                }

            }
            catch(Exception)
            {
                dtApplicationTypes = null;
            }
            finally
            {
              Connection.Close();
            }

            return dtApplicationTypes;

        }

        public static bool GetApplicationTypeInfo(int ID,ref string ApplicationType,ref int Fees)
        {

            bool IsSuccess = false;

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);
            
            string Query = "select ApplicationTypes.ApplicationTypeID,ApplicationTypes.ApplicationTypeTitle, ApplicationTypes.ApplicationFees from ApplicationTypes where ApplicationTypeID = @ApplicationTypeID;";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@ApplicationTypeID", ID);

            try
            {
                
                Connection.Open();
                
                SqlDataReader Reader = Command.ExecuteReader();
                
                if (Reader.Read())
                {
                  
                    ApplicationType = Reader["ApplicationTypeTitle"].ToString();
                    Fees = Convert.ToInt32(Reader["ApplicationFees"]);
                    IsSuccess = true;
                }
            }
            catch (Exception)
            {
                IsSuccess = false;
            }
            finally
            {
                Connection.Close();
            }

            return IsSuccess;

        }


        public static bool UpdateApplicationType(int ApplicationTypeID, string ApplicationTypeTitle, int ApplicationFees)
        {
            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);
            string Query = "update ApplicationTypes set ApplicationTypeTitle = @ApplicationTypeTitle, ApplicationFees = @ApplicationFees where ApplicationTypeID = @ApplicationTypeID;";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            Command.Parameters.AddWithValue("@ApplicationTypeTitle", ApplicationTypeTitle);
            Command.Parameters.AddWithValue("@ApplicationFees", ApplicationFees);


            int RowsAffected = 0;

            try
            {
                Connection.Open();
                 RowsAffected = Command.ExecuteNonQuery();
               
            }
            catch (Exception)
            {
                RowsAffected = 0;
            }
            finally
            {
                Connection.Close();
            }
            return (RowsAffected > 0);
        }




    }
}
