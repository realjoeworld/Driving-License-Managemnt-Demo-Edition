using System;
using System.Data;
using System.Data.SqlClient;

namespace PersonDataAccess
{
    public class clsTestTypesDataAccess
    {

        public static DataTable GetAllTestTypes()
        {
            DataTable dtTestTypes = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "select TestTypeID as ID,TestTypeTitle as TestTitle, TestTypeDescription as TestDescription, TestTypeFees as TestFees from TestTypes;";

            SqlCommand Command = new SqlCommand(Query, Connection);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    dtTestTypes.Load(Reader);
                }
            }
            catch (Exception)
            {
                dtTestTypes = null;
            }
            finally
            {
                Connection.Close();
            }

            return dtTestTypes;

        }

        public static bool GetTestTypeInfo(int ID, ref string TestTitle, ref string TestDescription, ref int Fees)
        {
            bool IsSuccess = false;
            
            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);
            
            string Query = "select TestTypeID,TestTypeTitle, TestTypeDescription, TestTypeFees from TestTypes where TestTypeID = @TestTypeID;";
            
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@TestTypeID", ID);
            
            try
            {
                
                Connection.Open();
                
                SqlDataReader Reader = Command.ExecuteReader();
                
                if (Reader.Read())
                {
                   
                    TestTitle = Reader["TestTypeTitle"].ToString();
                    TestDescription = Reader["TestTypeDescription"].ToString();
                    Fees = Convert.ToInt32(Reader["TestTypeFees"]);
                    IsSuccess = true;
                }

                Reader.Close();
            
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

        public static bool UpdateTestType(int ID, string TestTitle, string TestDescription, int Fees)
        {
            
            
            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);
            
            string Query = "update TestTypes set TestTypeTitle = @TestTypeTitle, TestTypeDescription = @TestTypeDescription, TestTypeFees = @TestTypeFees where TestTypeID = @TestTypeID;";
            
            SqlCommand Command = new SqlCommand(Query, Connection);
           
            Command.Parameters.AddWithValue("@TestTypeID", ID);
            Command.Parameters.AddWithValue("@TestTypeTitle", TestTitle);
            Command.Parameters.AddWithValue("@TestTypeDescription", TestDescription);
            Command.Parameters.AddWithValue("@TestTypeFees", Fees);

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
