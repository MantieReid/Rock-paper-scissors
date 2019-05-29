using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Rock_paper_scissors
{
  /// <summary>
  /// Interaction logic for Window1.xaml
  /// </summary>
  public partial class Window1 : Window
  {
    public Window1()
    {
      InitializeComponent();
    }
    
    private void RichTextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
      
    }


    private void Hyperlink_MouseLeftButtonDown(object sender, MouseEventArgs e) // event handler that allows the hyperlinks to be opened with just one click. 
    {
      var hyperlink = (Hyperlink)sender;
      Process.Start(hyperlink.NavigateUri.ToString());
    }
  }
}
