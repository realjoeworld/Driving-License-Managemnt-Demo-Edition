using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonDataAccess;

namespace DVLDBussniss
{
    public class clsApplicationTypes
    {

        public static DataTable GetAllApplicationTypes()
        {
            return clsApplicationTypesDataAccess.GetAllApplicationTypes();
        }

        public static bool GetApplicationTypeInfo( int ID,ref string ApplicationTypeName,ref int Fees)
        {
            return clsApplicationTypesDataAccess.GetApplicationTypeInfo(ID,ref ApplicationTypeName,ref Fees);
        }

        public static bool UpdateApplicationType(int ID, string ApplicationTypeName, int Fees)
        {
            return clsApplicationTypesDataAccess.UpdateApplicationType(ID, ApplicationTypeName, Fees);
        }

    }
}
