/*
 * ========================================================
 * SISTEM INFORMASI KASIR TOKO SEMBAKO
 * Arsitektur : Multi-Role (Owner, Kasir, Gudang)
 * Database   : SQL Server (Terpusat)
 * Status     : Siap Diuji UCP 
 * ========================================================
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jijehh_TokoSembako
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormLogin());
        }
    }
}
