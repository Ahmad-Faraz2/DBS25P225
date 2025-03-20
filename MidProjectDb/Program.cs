using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace MidProjectDb
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            // Now run the main form (e.g., LoginForm).
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);
            Application.Run(new LoginForm());
        }
    }
}
