using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace TestWpf.Models
{
    public class TabItemModel
    {
        public string Header { get; set; } = string.Empty;
        public object Content { get; set; } = new TextBlock();
    }
}
