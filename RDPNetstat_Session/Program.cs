using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RDPNetstat_Session
{
    class Program
    {
        
        static void Main(string[] args)
        {
            //FileStream fileStream;
            //StreamWriter streamWriter;
            //TextWriter textWriter = Console.Out;
            //try
            //{
            //    fileStream = new FileStream(@"\\C:\Users\idah.koome\Desktop" + System.Environment.MachineName + " .txt",FileMode.OpenOrCreate,FileAccess.Write);
            //    streamWriter = new StreamWriter(fileStream);
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine("Cannot open Redirect.txt for writing");
            //    Console.WriteLine(e.Message);
            //    return;
            //}
            //Console.SetOut(streamWriter);
            //GetPorts();

            //Console.SetOut(textWriter);
            //streamWriter.Close();
            //fileStream.Close();

            //MessageBox.Show("Fired!!!");
            TcpPorts();
            //Console.ReadLine();
        }



        public static void TcpPorts()
        {
            try
            {
                IPGlobalProperties ipProperties = IPGlobalProperties.GetIPGlobalProperties();
                IPEndPoint[] endPoints = ipProperties.GetActiveTcpListeners();
                TcpConnectionInformation[] tcpConnections = ipProperties.GetActiveTcpConnections();
                foreach (TcpConnectionInformation info in tcpConnections)
            {
                    //string strbuilder = "Client name :" + Environment.MachineName + Environment.NewLine +
                    //     "Client IP :" + info.LocalEndPoint.Address.ToString() + ":" + info.LocalEndPoint.Port.ToString() + Environment.NewLine +
                    //     "Username :" + Environment.UserName + Environment.NewLine +
                    //     "Server IP: " + info.RemoteEndPoint.Address.ToString() + ":" + info.RemoteEndPoint.Port.ToString() + Environment.NewLine +
                    //     "State :" + info.State.ToString() + Environment.NewLine +
                    //     "Remote Machine Name :" + GetMachineNameFromIPAddress(info.RemoteEndPoint.Address.ToString())
                    //     ;
                    
                    if (info.State.ToString().Equals("Established"))
                {
                       
                        Console.WriteLine("Client name :" + GetMachineNameFromIPAddress(info.LocalEndPoint.Address.ToString()));
                    Console.WriteLine("Client IP :" + info.LocalEndPoint.Address.ToString()
               + ":" + info.LocalEndPoint.Port.ToString() 
               + "\nUsername :" + Environment.UserName
               + "\nServer IP :" + info.RemoteEndPoint.Address.ToString()
               + ":" + info.RemoteEndPoint.Port.ToString()
               + "\nState :" + info.State.ToString()
               + "\n(Server)Remote Machine Name :" + GetMachineNameFromIPAddress(info.RemoteEndPoint.Address.ToString())
               + "\n\n");
                    //Console.WriteLine(GetMachineNameFromIPAddress(info.RemoteEndPoint.Address.ToString()));
                    
                    //string tmpath = @"C:\";
                    //File.AppendAllText(tmpath + "tcpinfo.txt", strbuilder);
                    //MessageBox.Show(strbuilder);
                }
               
            }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            Console.ReadLine();
        }
        private static string GetMachineNameFromIPAddress(string ipAdress)
        {
            string machineName = string.Empty;
            try
            {
                System.Net.IPHostEntry hostEntry = System.Net.Dns.GetHostEntry(ipAdress);
                machineName = hostEntry.HostName;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return machineName;
        } 

        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------public  static void GetPorts()
        //{
        //    //var ports = new List<Port>();
        //    try
        //    {
        //        using (Process p = new Process())
        //        {
        //            ProcessStartInfo ps = new ProcessStartInfo();
        //            ps.UseShellExecute = false;
        //            ps.RedirectStandardOutput = true;
        //            ps.RedirectStandardInput = true;
        //            ps.RedirectStandardError = true;
        //            ps.FileName = "cmd.exe";
        //            ps.Arguments = "/c netstat -a -n -o";

        //            //ps.WindowStyle = ProcessWindowStyle.Hidden;

        //            p.StartInfo = ps;
        //            p.Start();

        //            //StreamReader stdOut = p.StandardOutput;
        //            //StreamReader stdError = p.StandardError;

        //            string content = p.StandardOutput.ReadToEnd();
        //            //string exitStatus = p.ExitCode.ToString();
        //            Regex ipcollect = new Regex(@"(.*[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}:50503.*)", RegexOptions.IgnoreCase);
        //            //if (exitStatus != "0")
        //            //{

        //            //}
        //            Match m = ipcollect.Match(content);
        //            Group tmpgroup = m.Groups[1];
        //            Console.WriteLine(tmpgroup.ToString());
        //            //var list = m.Cast<Match>().Select(match => match.Value).ToList();
        //            //foreach (string item in list)
        //            //{
        //            //    Console.WriteLine(item);
        //            //}


        //        }
        //    }
        //    catch (Exception e)

        //    {
        //        Console.WriteLine(e.Message);

        //    }
        //}
    }
}
