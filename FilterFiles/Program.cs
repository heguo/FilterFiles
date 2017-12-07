using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FilterFiles
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var f = new MainForm();
            var tip = "FilterFiles.exe -run:是否自动启动 -from:需备份的文件夹 -match:*.* -to:目标文件夹 -day:最近修改天数 -ip:忽略的文件夹名称1;名称2 -if:忽略的文件1;文件2 -output:dir_{from}>>output.bat";
            if (args.Length == 0)
            {
                f.ViewModel = new ViewModel();
            }
            else
            {
                var m = ParseArgs(args);
                if (m == null)
                {
                    Console.WriteLine($"调用格式: {tip}");
                    return;
                }
                f.ViewModel = m;
            }

            f.ViewModel.Tip = tip;
            Application.Run(f);
        }

        static private ViewModel ParseArgs(string[] args)
        {
            ViewModel m = new ViewModel();
            for (int i = 0; i < args.Length; i++)
            {
                var p = args[i].ToLower();
                if (p.StartsWith("-f:"))
                {
                    m.FromPath = p.Substring("-f:".Length);
                }
                else if (p.StartsWith("-from:"))
                {
                    m.FromPath = p.Substring("-from:".Length);
                }
                else if (p.StartsWith("-t:"))
                {
                    m.ToPath = p.Substring("-t:".Length);
                }
                else if (p.StartsWith("-match:"))
                {
                    m.FileFilter = p.Substring("-match:".Length);
                }
                else if (p.StartsWith("-m:"))
                {
                    m.FileFilter = p.Substring("-m:".Length);
                }
                else if (p.StartsWith("-to:"))
                {
                    m.ToPath = p.Substring("-to:".Length);
                }
                else if (p.StartsWith("-d:"))
                {
                    m.Days = int.Parse(p.Substring("-d:".Length));
                }
                else if (p.StartsWith("-day:"))
                {
                    m.Days = int.Parse(p.Substring("-day:".Length));
                }
                else if (p.StartsWith("-ip:"))
                {
                    m.IgnorePathList = p.Substring("-ip:".Length);
                }
                else if (p.StartsWith("-if:"))
                {
                    m.IgnoreFileList = p.Substring("-if:".Length);
                }
                else if (p.StartsWith("-run:"))
                {
                    m.IsAutoStart = bool.Parse(p.Substring("-run:".Length));
                }
                else if (p.StartsWith("-format:"))
                {
                    m.OutputFormat = p.Substring("-format:".Length);
                }
                else if (p.StartsWith("-output:"))
                {
                    m.OutputFormat = p.Substring("-output:".Length);
                }
                else if (p.StartsWith("-o:"))
                {
                    m.OutputFormat = p.Substring("-o:".Length);
                }
            }

            if (string.IsNullOrEmpty(m.FileFilter))
                m.FileFilter = "*.*";

            if (string.IsNullOrEmpty(m.OutputFormat))
                m.OutputFormat = "{from} {to} {todir}";

            m.OutputFormat = m.OutputFormat.Replace("_"," ");

            if (string.IsNullOrEmpty(m.FromPath))
                return null;

            return m;
        }
    }
}
