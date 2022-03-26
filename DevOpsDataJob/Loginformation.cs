using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.VisualBasic;
using System.Configuration;

namespace DevOpsDataJob
{
   internal class Loginformation
    {
        string logfilepath =ConfigurationManager.AppSettings["logfilepath"];
        string Loginformationtxt = ConfigurationManager.AppSettings["LOGINFORMATIONTXT"];
        string Information = ConfigurationManager.AppSettings["INFORMATION"];
            /// <summary>
            ///     This method is used for line seperator
            /// </summary>
            /// <returns>string containg line separator.</returns>
        public string LineSeparator()
            {
                return new string('-', 80);
            }

            /// <summary>
            ///     This method is used to write the service line.
            /// </summary>
            /// <param name="strText">Service line message</param>
            public void WriteServiceLine(string strText)
            {
            
                var strDate = DateTime.Now.ToString("yyyy-MM-dd");
                var strLogFilePath = Path.Combine(logfilepath ,strDate);
                WriteFiles(strText, Loginformationtxt, strLogFilePath, Information, "1");
                WriteFiles(Environment.NewLine, Loginformationtxt, strLogFilePath, Information, "1");
            }

            /// <summary>
            ///     This method is used to write the log into the files
            /// </summary>
            /// <param name="strText">Message</param>
            /// <param name="strFileNameWithPath">File name with path</param>
            /// <param name="strSentFolderPath">sent folder path</param>
            /// <param name="strFileType">File type</param>
            /// <param name="strLogOnOrOff">Log on or off</param>
            private void WriteFiles(string strText, string strFileNameWithPath, string strSentFolderPath, string strFileType,
                string strLogOnOrOff)
            {
                if (strLogOnOrOff == "1")
                {
                    if (string.IsNullOrWhiteSpace(strFileNameWithPath))
                    {
                        if (strFileType == "Information")
                            strFileNameWithPath = "Information_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
                        else
                            strFileNameWithPath = "FileInformation_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
                    }

                    if (!Directory.Exists(strSentFolderPath)) Directory.CreateDirectory(strSentFolderPath);

                    var file1 = Path.Combine(strSentFolderPath, strFileNameWithPath);
                    var sw = File.AppendText(file1);

                    try
                    {
                        if (!strText.Contains("-------") && !strText.Contains("\r\n"))
                            sw.Write(DateTime.Now + "   " + strText);
                        else
                            sw.Write(strText);
                        sw.Flush();
                        sw.Close();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("error:{0}", e);
                    }
                }
            }

            /// <summary>
            ///     Appends the line to the output file specified by Path.
            /// </summary>
            /// <param name="strLogFile">The path.</param>
            /// <param name="strMessage">The line.</param>
            public void WriteToFile(string strLogFile, string strMessage)
            {
                if (!File.Exists(strLogFile))
                {
                    var fileInfo = new FileInfo(strLogFile);
                    var fstream = fileInfo.Open(FileMode.Create);
                    fstream.Flush();
                    fstream.Close();
                }
                var fileStream = new FileStream(strLogFile, FileMode.Append, FileAccess.Write);
                var sw = new StreamWriter(fileStream);
                sw.Write(strMessage + "\r\n");
                sw.Close();
                fileStream.Close();
            }
        }
    }

