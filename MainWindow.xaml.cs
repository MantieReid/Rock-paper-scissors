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


    int numberofwins = 0; // the number of wins
    int numberoflosses = 0; // the number of losses
    int numberofties = 0;  // the number of ties


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
      Player1_Option_Chosen.Source = new BitmapImage(new Uri("PAPER Proper left.png", UriKind.Relative)); // loads the paper image 

      SoundPlayer player = new SoundPlayer(); // creates a new sound player
      player.Stream = Properties.Resources.Paper_Sound_Wav; // plays the paper sound file. 
      player.Load(); // loads the file 
      player.Play(); // plays the file
      

    }

    private void Scissior_Option_Checked(object sender, RoutedEventArgs e) // scissior option checked
    {
      Player1_Option_Chosen.Source = new BitmapImage(new Uri("Scissors.jpg", UriKind.Relative)); //loads the scissors image.

      SoundPlayer player = new SoundPlayer(); // creates a new sound player
      player.Stream = Properties.Resources.Scissors; // plays the paper sound file. 
      player.Load(); // loads the file 
      player.Play(); // plays the file

      
    }


    public static int NumMembers { get; protected set; }


    

    public void Button_Click(object sender, RoutedEventArgs e) //run game button
    {
      //array of choices to pick for the cpu.

      var choices  =  new List<string> { "rock", "paper", "scissor" };

      //0 = rock, 1 = paper. 3 = scissor. 

      //create a randomn object


      
      Random random = new Random();

      int index = random.Next(choices.Count); // randomly pick a choice. The CPU picks a random choice.
      String choicepicked = choices[index]; // choice is stored in the string. 

      Console.WriteLine($"choice picked is " + choicepicked); //writes to the console to show what the choice is

      if (choicepicked.Equals("rock")) //if choice picked equals rock then.....

      {
        Player2_Option_Chosen.Source = new BitmapImage(new Uri(" Mickey Rock for the right side.jpg", UriKind.Relative)); //loads the rock image. //changes the rock image to 
      }


      if (choicepicked.Equals("rock") && Paper_Option.IsChecked == true) // if paper option is made by and rock is chosen by the cpu then..

      {
        numberofwins += 1; // increase number of wins by one 

        Console.WriteLine("number of wins is " + numberofwins); //writes the number of wins in the console. For Testing and debugging. 

      }
      Number_of_wins_textblock.Text = "Wins" + numberofwins; // puts the number of wins in the textblock. 


    }


    //choices.RemoveAt(index);
    ///Console.WriteLine($"randomnly selected choice is {choices[index]}");






     
    }
}


