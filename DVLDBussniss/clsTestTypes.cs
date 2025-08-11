using System;
using System.Data;
using PersonDataAccess;

namespace DVLDBussniss
{
    public class clsTestTypes
    {

        public static DataTable GetAllTestTypes()
        {
            return clsTestTypesDataAccess.GetAllTestTypes();
        }

        public static bool GetTestTypeInfo(int ID, ref string TestTitle, ref string TestDescription, ref int Fees)
        {
            return clsTestTypesDataAccess.GetTestTypeInfo(ID, ref TestTitle, ref TestDescription, ref Fees);
        }

        public static bool UpdateTestType(int ID, string TestTitle, string TestDescription, int Fees)
        {
            return clsTestTypesDataAccess.UpdateTestType(ID, TestTitle, TestDescription, Fees);
        }

    }
}
