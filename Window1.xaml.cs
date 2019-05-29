using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

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
