using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using Microsoft.SqlServer.Dts.Runtime;


namespace Import_csv_to_IMP_TRANSACT_D
{
 
    class Program
    {
        //class MyEventListener : DefaultEvents
        //{
        //    //public override bool OnError(DtsObject source, int errorCode, string subComponent,
        //    //  string description, string helpFile, int helpContext, string idofInterfaceWithError)
        //    //{
        //    //    // Add application-specific diagnostics here.
        //    //    Console.WriteLine("Error in " + source + " / " + subComponent + " : " + description);
        //    //    return false;
        //    //}
        //}



        static void Main(string[] args)
        {
            string date="";//Fix Aegean report 20170206
            bool selectedday=false;

            if (args.Length == 1)//Fix Aegean report 20170206
            {   date=args[0];//ex 2017-02-06
                selectedday=true;
            }

            if (File.Exists(@"C:\Users\lnestoras\Desktop\ExportReport\Source file\report.csv"))
            {
               Console.WriteLine("C:\\Users\\lnestoras\\Desktop\\ExportReport\\Source file\\report.csv  exists.\r\n");
            }
            else
            {
                Console.WriteLine("C:\\Users\\lnestoras\\Desktop\\ExportReport\\Source file\\report.csv does not exist.\r\n");
            }

            
            string pkgLocation;
            Package pkg;
            DTSExecResult pkgResults;
            Microsoft.SqlServer.Dts.Runtime.Application app;
            //MyEventListener eventListener = new MyEventListener();

            app = new Microsoft.SqlServer.Dts.Runtime.Application();
            pkgLocation = @"C:\Users\lnestoras\Documents\Visual Studio 2013\Projects\SSIS\IMP_D_Trans\IMP_D_Trans\Package.dtsx";

            //pkgLocation = @".\ImportDaily.dtsx";
            //pkgLocation = @".\Package.dtsx";
            pkg = app.LoadPackage(pkgLocation, null);
            pkgResults = pkg.Execute();

            //System.IO.File.Move("C:\\Users\\lnestoras\\Desktop\\ExportReport\\Source file\\Temp\\report.csv", "C:\\Users\\lnestoras\\Desktop\\ExportReport\\Source file\\report.csv");

            Console.WriteLine("Import completed in IMP_TRANSACT_D. \r\n");
        }
    }
}
