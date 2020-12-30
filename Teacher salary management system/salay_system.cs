using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Teacher_salay_mangement_system
{
    static class salay_system
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            MysqlConnector mysql_database = new MysqlConnector();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            login login_windows = new login();
            login_windows.ShowDialog();
            if (login_windows.DialogResult == DialogResult.OK)
            {
                login_windows.Dispose();
                Application.Run(new admin_windows(login_windows.User_Inf));
            }
            else if(login_windows.DialogResult == DialogResult.Yes)
            {
                login_windows.Dispose();
                Application.Run(new teacher_windows(login_windows.User_Inf));
            }
        }
    }
}
