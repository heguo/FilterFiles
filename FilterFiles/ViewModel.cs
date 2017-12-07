using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace FilterFiles
{
    public class ViewModel : INotifyPropertyChanged
    {
        private string tip;
        public string Tip
        {
            get
            {
                return this.tip;
            }
            set
            {
                this.tip = value;
                this.Invoke(nameof(this.Tip));
            }
        }


        private bool isAutoStart;
        public bool IsAutoStart
        {
            get
            {
                return this.isAutoStart;
            }
            set
            {
                this.isAutoStart = value;
                this.Invoke(nameof(this.IsAutoStart));
            }
        }

        private string fromPath;
        public string FromPath
        {
            get
            {
                return this.fromPath;
            }
            set
            {
                this.fromPath = value;
                this.Invoke(nameof(this.FromPath));
            }
        }


        private string fileFilter;
        public string FileFilter
        {
            get
            {
                return this.fileFilter;
            }
            set
            {
                this.fileFilter = value;
                this.Invoke(nameof(this.FileFilter));
            }
        }

        private string toPath;
        public string ToPath
        {
            get
            {
                return this.toPath;
            }
            set
            {
                this.toPath = value;
                this.Invoke(nameof(this.ToPath));
            }
        }

        private string ignoreFileList;
        public string IgnoreFileList
        {
            get
            {
                return this.ignoreFileList;
            }
            set
            {
                this.ignoreFileList = value;
                this.Invoke(nameof(this.IgnoreFileList));
            }
        }

        private string ignorePathList;
        public string IgnorePathList
        {
            get
            {
                return this.ignorePathList;
            }
            set
            {
                this.ignorePathList = value;
                this.Invoke(nameof(this.IgnorePathList));
            }
        }

        private int days;
        public int Days
        {
            get
            {
                return this.days;
            }
            set
            {
                this.days = value;
                this.Invoke(nameof(this.Days));
            }
        }

        private string outputFormat;
        public string OutputFormat
        {
            get
            {
                return this.outputFormat;
            }
            set
            {
                this.outputFormat = value;
                this.Invoke(nameof(this.OutputFormat));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void Invoke(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
