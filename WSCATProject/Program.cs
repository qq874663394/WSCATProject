﻿using System;
using System.Windows.Forms;
using WSCATProject.Base;
using WSCATProject.Finance;
using WSCATProject.Purchase;
using WSCATProject.Sales;
using WSCATProject.Warehouse;

namespace WSCATProject
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new MainForm());
            Application.Run(new PurchaseTicketForm());
        }
    }
}