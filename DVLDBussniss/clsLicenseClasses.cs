using System;
using System.Data;
using DVLDBussniss;
using PersonDataAccess;

namespace DVLDBussniss
{
    public class clsLicenseClasses
    {

        public static DataTable GetClassNameAndID()
        {
            return clsLicenseClassDataAccess.GetClassNameAndID();
        }

    }
}
