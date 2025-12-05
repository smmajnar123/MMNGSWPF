using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using TestWpf.Helpers.Enums;

namespace TestWpf.Models
{
    public class ContentTabItemModel
    {
        public TabEnum Header { get; set; }
        public object Content { get; set; } = new TextBlock();
    }
}
