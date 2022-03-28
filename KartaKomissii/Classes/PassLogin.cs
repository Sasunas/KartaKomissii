using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Commission_map.Classes
{
    static class PassLogin
    {
        public static int ID { get; set; }
        public static string Logins { get; set; }
        public static string Passwords { get; set; }
        public static ConnectionStringSettingsCollection connectionString = ConfigurationManager.ConnectionStrings;
    }
}
