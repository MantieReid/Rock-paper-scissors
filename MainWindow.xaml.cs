using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Image = System.Drawing.Image;

namespace Rock_paper_scissors
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
    }


    private void RadioButton_Checked(object sender, RoutedEventArgs e) ///Rock Option

    {
      Player1_Option_Chosen.Source = new BitmapImage(new Uri("Mickey Rock.jpg", UriKind.Relative)); //sets the image to rock.


      SoundPlayer player = new SoundPlayer(); // creates a new sound player
      player.Stream = Properties.Resources.Rock_sound_wav; // plays the rock sound file. 
        player.Load(); // loads the file 
        player.Play(); // plays the file



      


    }

    private void Paper_Option_Checked(object sender, RoutedEventArgs e) // paper option
    {
      //Player1_Option_Chosen.Source = new BitmapImage(new Uri(@"C:\Users\gunzs\source\repos\Rock–paper–scissors\PAPER Proper left.png"));
      Player1_Option_Chosen.Source = new BitmapImage(new Uri("PAPER Proper left.png", UriKind.Relative));

    }

    private void Scissior_Option_Checked(object sender, RoutedEventArgs e) // scissior option checked
    {
      Player1_Option_Chosen.Source = new BitmapImage(new Uri(@"C:\Users\gunzs\source\repos\Rock–paper–scissors\Scissors.jpg"));

    }

    private void Button_Click(object sender, RoutedEventArgs e) //run game button
    {

    }
  }
}
