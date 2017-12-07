﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace FilterFiles
{
    public partial class MainForm : Form
    {
        public ViewModel ViewModel { get; set; }
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.bindingSource1.DataSource = this.ViewModel;
            if(this.ViewModel.IsAutoStart)
            {
                this.button1.PerformClick();
                this.Close();
            }
        }

        private bool IsExists(string[] array,string item)
        {
            foreach (var i in array)
            {
                if (i.ToLower() == item.ToLower())
                    return true;
            }
            return false;
        }



        public IEnumerable<FileInfo> GetFileList(DirectoryInfo dirInfo,string match,DateTime date,string[] ignoreFileList, string[] ignorePathList)
        {
            foreach (var item in dirInfo.GetFiles(match, SearchOption.TopDirectoryOnly))
            {
                if (item is FileInfo)
                {
                    if (this.IsExists(ignoreFileList,item.Extension)|| this.IsExists(ignoreFileList, item.Name))
                        continue;

                    var fileInfo = item as FileInfo;
                    if (fileInfo.LastWriteTime >= date)
                        yield return fileInfo;
                }
            }

            foreach (var item in dirInfo.GetDirectories())
            {
                if (item is DirectoryInfo)//判断是文件夹
                {
                    var childInfo = item as DirectoryInfo;
                    if (this.IsExists(ignorePathList, childInfo.Name))
                        continue;

                    foreach (var fileInfo in this.GetFileList(childInfo, match, date, ignoreFileList, ignorePathList))
                    {
                        yield return fileInfo;
                    }
                }
            }
        }


        private IEnumerable<FileInfo> FindFiles()
        {
            var date = DateTime.Now.Date.AddDays(-this.ViewModel.Days);
            DirectoryInfo dirInfo = new DirectoryInfo(this.ViewModel.FromPath);
            if (string.IsNullOrEmpty(ViewModel.IgnoreFileList))
                ViewModel.IgnoreFileList = string.Empty;
            if (string.IsNullOrEmpty(ViewModel.IgnorePathList))
                ViewModel.IgnorePathList = string.Empty;
            var ignoreFileList = ViewModel.IgnoreFileList.Replace(';', ',').Split(',');
            var ignoreFathList = ViewModel.IgnorePathList.Replace(';', ',').Split(',');
            var match = ViewModel.FileFilter;
            var files = this.GetFileList(dirInfo, match, date, ignoreFileList, ignoreFathList);
            return files;
        }

        private void CreateDictory(string dict)
        {
            var parent = System.IO.Path.GetDirectoryName(dict);
            if (!System.IO.Directory.Exists(parent))
            {
                CreateDictory(parent);
                System.IO.Directory.CreateDirectory(dict);
            }
            else
            {
                System.IO.Directory.CreateDirectory(dict);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.button1.Enabled = false;
            var fromPath = new DirectoryInfo(this.ViewModel.FromPath);
            var fileList = this.FindFiles();
            int count = 0;
            int error = 0;
            foreach (var item in fileList)
            {
                var file = item.FullName.Substring(this.ViewModel.FromPath.Length).Trim('\\').Trim('/');
                var toFile = System.IO.Path.Combine(this.ViewModel.ToPath, file);
                var dir = System.IO.Path.GetDirectoryName(toFile);
                var format = ViewModel.OutputFormat;
                format = format.Replace("{from}", item.FullName);
                format = format.Replace("{to}", toFile);
                format = format.Replace("{todir}", dir);
                count++;
                Console.WriteLine(format);
            }
            var msg = $"{DateTime.Now} {count} files find.";
            //Console.WriteLine(msg);
            this.button1.Enabled = true;
            if (!this.ViewModel.IsAutoStart)
            {
                MessageBox.Show(msg, "完成");
            }
        }

        private void button1_Click_del(object sender, EventArgs e)
        {
            this.button1.Enabled = false;
            Console.WriteLine($"{DateTime.Now} {this.ViewModel.FromPath} ==> {this.ViewModel.ToPath}");
            var fromPath = new DirectoryInfo(this.ViewModel.FromPath);
            var toPath = new DirectoryInfo(this.ViewModel.ToPath);
            var fileList = this.FindFiles();
            int count = 0;
            int error = 0;
            foreach (var item in fileList)
            {
                var file = item.FullName.Substring(this.ViewModel.FromPath.Length).Trim('\\').Trim('/');
                var toFile = System.IO.Path.Combine(this.ViewModel.ToPath, file);
                var dir = System.IO.Path.GetDirectoryName(toFile);
                if (!System.IO.Directory.Exists(dir))
                    this.CreateDictory(dir);
                try
                {
                    item.CopyTo(toFile, true);
                    count++;
                }
                catch
                {
                    error++;
                    Console.WriteLine($"copy file error: {item.FullName}");
                }
            }
            var msg = $"{DateTime.Now} copy {count} files success. {error} files failed.";
            Console.WriteLine(msg);
            this.button1.Enabled = true;
            if(!this.ViewModel.IsAutoStart)
            {
                MessageBox.Show(msg, "备份");
            }
        }

    }


}
