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

      if (choicepicked.Equals("rock")) //if choice picked equals rock then load rock image for cpu. 

      {
        Player2_Option_Chosen.Source = new BitmapImage(new Uri(" Mickey Rock for the right side.jpg", UriKind.Relative)); //loads the rock image. 
      }


      if (choicepicked.Equals("paper")) //if choice picked equals rock then load paper image for cpu. 

      {
        Player2_Option_Chosen.Source = new BitmapImage(new Uri(" PAPER Proper right.png", UriKind.Relative)); //loads the Paper image.

      }

      if (choicepicked.Equals("paper") && Scissior_Option.IsChecked == true) //if choice picked equals paper and the player chose scissors then the player wins

      {
        //player wins. Increase the number of wins.
        numberofwins += 1; // increase number of wins by one 
       Console.WriteLine("number of wins is " + numberofwins); //writes the number of wins in the console. For Testing and debugging. 

      }


      if (choicepicked.Equals("paper") && Rock_Option.IsChecked  == true) //if choice picked equals paper and the player chose rock then the player looses

      {
        //player loses. Increse the number of loses
        numberoflosses += 1; // increase number of wins by one
        Console.WriteLine("the number of losses is" + numberoflosses); //prints the number of losses to console.
        


      }


      if (choicepicked.Equals("paper") && Paper_Option.IsChecked == true) //if choice picked equals paper and the player chose paper then a tie is declared. 

      {
        //Tie is declared. Increase the number of ties. 
        numberofties += 1; // increase the number of ties. 
        Console.WriteLine("the number of ties is" + numberofties); //prints the number of ties to console. 



      }




      if (choicepicked.Equals("rock") && Paper_Option.IsChecked == true) // if paper option is made by and rock is chosen by the cpu then..

      {
        //player wins. Increase the  number of wins. 
        numberofwins += 1; // increase number of wins by one 

        Console.WriteLine("number of wins is " + numberofwins); //writes the number of wins in the console. For Testing and debugging. 

      }


      if (choicepicked.Equals("rock") && Scissior_Option.IsChecked == true) // if rock is chosen by the cpu, player chooses scissior then the player looses

      {
        //player looses, increase the number of looses
        numberoflosses += 1; // increase number of looses by one  

        Console.WriteLine("number of looses is " + numberoflosses); //writes the number of looses in the console. For Testing and debugging. 

      }


      if (choicepicked.Equals("rock") && Rock_Option.IsChecked == true) // if rock is chosen by the cpu, player chooses rock then a tie is declared

      {
        // a Tie is declared. Incrase the number of ties
        numberofties += 1; // increase number of ties 

        Console.WriteLine("number of ties is " + numberofties); //writes the number of ties in the console. For Testing and debugging. 

      }


      Number_of_wins_textblock.Text = "Wins " + numberofwins; // puts the number of wins in the textblock.
      Number_of_Losses_textblock.Text = "Loses " + numberoflosses; // puts the number of losses in the textblock.
      Number_of_Ties_textblock.Text = "Ties " + numberofties;
      


    }


    //choices.RemoveAt(index);
    ///Console.WriteLine($"randomnly selected choice is {choices[index]}");






     
    }
}


