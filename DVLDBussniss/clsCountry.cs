using System;
using System.Data;
using PersonDataAccess;

namespace DVLDBussniss
{
    public class clsCountry
    {

        public int CountryID { get; set; }

        public string CountryName { get; set; }


        public static DataTable GetAllCountries() {
        return clsCountryDataAccess.GetAllCountries();
        }

        public static int GetCountryIndexByName(string CountryName)
        {
            return clsCountryDataAccess.GetCountryIndexByName(CountryName);
        }

        public static string GetCountryNameByIndex(int CountryIndex)
        {
            return clsCountryDataAccess.GetCountryNameByIndex(CountryIndex);
        }

    }
}
