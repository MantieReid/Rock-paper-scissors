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
using System.Windows.Threading;
using Image = System.Drawing.Image;




using MahApps.Metro.Controls;
using System.Globalization;
using Color = System.Windows.Media.Color;
using ColorConverter = System.Windows.Media.ColorConverter;

namespace Rock_paper_scissors
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  ///


  public partial class MainWindow : MetroWindow
  {


    public MainWindow()
    {
      InitializeComponent();


      DispatcherTimer dispatcherTimer = new DispatcherTimer();
      dispatcherTimer.Tick += dispatcherTimer_Tick;
      dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
      dispatcherTimer.Start();


    }


    private void dispatcherTimer_Tick(object sender, EventArgs e)
    {
      // code goes here
    }




    int numberofwins = 0; // the number of wins
    int numberoflosses = 0; // the number of losses
    int numberofties = 0;  // the number of ties

    int numberofwinsCPU = 0; // the number of wins for the CPU.
    int numberoflossesCPU = 0; // the number of losses for the CPU.
    int numberoftiesCPU = 0; // The Number of ties for the cpu.  


    private void RadioButton_Checked(object sender, RoutedEventArgs e) ///Rock Option

    {
      //Player1_Option_Chosen.Source = new BitmapImage(new Uri("Mickey Rockoldbad.jpg", UriKind.Relative)); //sets the image to rock.
      Player1_Option_Chosen.Source = new BitmapImage(new Uri("pack://application:,,,/ImagesBeingUsed/MickeyRockBetterfortheplayer.png")); // loads the paper image 



      SoundPlayer player = new SoundPlayer(); // creates a new sound player
      player.Stream = Properties.Resources.Rock_sound_wav; // plays the rock sound file. 
        player.Load(); // loads the file 
        player.Play(); // plays the file


      


      


    }

    private void Paper_Option_Checked(object sender, RoutedEventArgs e) // paper option
    {
      Player1_Option_Chosen.Source = new BitmapImage(new Uri("pack://application:,,,/ImagesBeingUsed/PAPER Proper left.png")); // loads the paper image 

      SoundPlayer player = new SoundPlayer(); // creates a new sound player
      player.Stream = Properties.Resources.Paper_Sound_Wav; // plays the paper sound file. 
      player.Load(); // loads the file 
      player.Play(); // plays the file
      

    }

    private void Scissior_Option_Checked(object sender, RoutedEventArgs e) // scissior option checked
    {
      Player1_Option_Chosen.Source = new BitmapImage(new Uri("pack://application:,,,/ImagesBeingUsed/Scissors2trans.png")); //loads the scissors image.

      SoundPlayer player = new SoundPlayer(); // creates a new sound player
      player.Stream = Properties.Resources.Scissors; // plays the paper sound file. 
      player.Load(); // loads the file 
      player.Play(); // plays the file

      
    }


    public static int NumMembers { get; protected set; }



    //player2 option chosen is for the cpu. 

    public void Button_Click(object sender, RoutedEventArgs e) //run game button
    {
      //array of choices to pick for the cpu.

      var choices  =  new List<string> { "rock", "paper", "scissor" };

      //0 = rock, 1 = paper. 3 = scissor. 

      //create a new random to be used. Will be used in the cpu picking a choice. 
      Random random = new Random();

      int index = random.Next(choices.Count); // randomly pick a choice. The CPU picks a random choice.
      String choicepicked = choices[index]; // choice is stored in the string. 

      Console.WriteLine($"choice picked by the cpu is " + choicepicked); //writes to the console to show what the choice is for the cpu.


      
      if (choicepicked.Equals("rock")) //if choice picked equals rock then load rock image for cpu. 

      {
        Player2_Option_Chosen.Source = new BitmapImage(new Uri(" pack://application:,,,/ImagesBeingUsed/MickeyRockBetter.png")); //loads the rock image. 
      }


      if (choicepicked.Equals("paper")) //if choice picked equals rock then load paper image for cpu. 

      {
        Player2_Option_Chosen.Source = new BitmapImage(new Uri("pack://application:,,,/ImagesBeingUsed/paperright.png")); //loads the Paper image.

      }

      if (choicepicked.Equals("paper") && Scissior_Option.IsChecked == true) //if choice picked equals paper and the player chose scissors then the player wins

      {
        //player wins. Increase the number of wins.
        numberofwins += 1; // increase number of wins by one 
       Console.WriteLine("number of wins is " + numberofwins); //writes the number of wins in the console. For Testing and debugging.

        

        numberoflossesCPU += 1; // increase the number of looses for the cpu
        Console.WriteLine("number of losses for the cpu is " + numberoflossesCPU);


       /// Color color2 = (Color)ColorConverter.ConvertFromString("#FF00FF23"); screw it


        Game_Status_Textblock.Text = "VICTORY"; //change game status to victory since player won. 
        Game_Status_Textblock.Foreground = System.Windows.Media.Brushes.Gold;  // change text to gold. 






        SoundPlayer player = new SoundPlayer(); // creates a new sound player
        player.Stream = Properties.Resources.snd_se_Narration_Victory; // plays the  defeat sound file 
        player.Load(); // loads the file 
        player.Play(); // plays the file


      }


      if (choicepicked.Equals("paper") && Rock_Option.IsChecked  == true) //if choice picked equals paper and the player chose rock then the player looses

      {
        //player loses. Increse the number of loses
        numberoflosses += 1; // increase number of wins by one
        Console.WriteLine("the number of losses is" + numberoflosses); //prints the number of losses to console.

        numberofwinsCPU += 1; //increase the number of wins for the cpu
        Console.WriteLine("number of wins for the cpu is " + numberofwinsCPU); //prints the number of cpu wins to the console. 



        Game_Status_Textblock.Text = "DEFEATED"; //change game status to DEFEATED
        Game_Status_Textblock.Foreground = System.Windows.Media.Brushes.Red; // CHange text Color to red


        SoundPlayer player = new SoundPlayer(); // creates a new sound player
        player.Stream = Properties.Resources.snd_se_narration_Defeated; // plays the  defeat sound file 
        player.Load(); // loads the file 
        player.Play(); // plays the file




      }


      if (choicepicked.Equals("paper") && Paper_Option.IsChecked == true) //if choice picked equals paper and the player chose paper then a tie is declared. 

      {
        //Tie is declared. Increase the number of ties. 
        numberofties += 1; // increase the number of ties. 
        Console.WriteLine("the number of ties is" + numberofties); //prints the number of ties to console. 



        numberoftiesCPU += 1; //increase the number of  ties for the cpu
        Console.WriteLine("number of ties for the cpu is " + numberoftiesCPU); //prints the number of ties for the cpu to the console.  

        Game_Status_Textblock.Text = "TIE"; //change game status to TIE
        Game_Status_Textblock.Foreground = System.Windows.Media.Brushes.Orange; // CHange text Color to Orange. 

        SoundPlayer player = new SoundPlayer(); // creates a new sound player
        player.Stream = Properties.Resources.snd_se_narration_Gameset; // plays the gameset soud file
        player.Load(); // loads the file 
        player.Play(); // plays the file



      }




      if (choicepicked.Equals("rock") && Paper_Option.IsChecked == true) // if paper option is made by and rock is chosen by the cpu then..

      {
        //player wins. Increase the  number of wins. 
        numberofwins += 1; // increase number of wins by one 

        Console.WriteLine("number of wins is " + numberofwins); //writes the number of wins in the console. For Testing and debugging. 


        numberoflossesCPU += 1; //increase the number of losses
        Console.WriteLine("number of losses for the cpu is " + numberoflossesCPU); //prints the number of cpu losses to the console. 



        Game_Status_Textblock.Text = "VICTORY"; //change game status to victory since player won. 
        Game_Status_Textblock.Foreground = System.Windows.Media.Brushes.Gold; // change text to gold. 




        SoundPlayer player = new SoundPlayer(); // creates a new sound player
        player.Stream = Properties.Resources.snd_se_Narration_Victory; // plays the Victory sound file 
        player.Load(); // loads the file 
        player.Play(); // plays the file



      }


      if (choicepicked.Equals("rock") && Scissior_Option.IsChecked == true) // if rock is chosen by the cpu, player chooses scissior then the player looses

      {
        //player looses, increase the number of looses
        numberoflosses += 1; // increase number of looses by one  


        numberofwinsCPU += 1; //increase the number of wins for the cpu
        Console.WriteLine("number of wins for the cpu is " + numberofwinsCPU); //prints the number of cpu wins to the console. 



        Console.WriteLine("number of looses is " + numberoflosses); //writes the number of looses in the console. For Testing and debugging.

        Game_Status_Textblock.Text = "DEFEATED"; //change game status to Defeated
        Game_Status_Textblock.Foreground = System.Windows.Media.Brushes.Red; // CHange text Color to Red. 


        SoundPlayer player = new SoundPlayer(); // creates a new sound player
        player.Stream = Properties.Resources.snd_se_narration_Defeated; // plays the defeated sound file 
        player.Load(); // loads the file 
        player.Play(); // plays the file




      }

     

      if (choicepicked.Equals("rock") && Rock_Option.IsChecked == true) // if rock is chosen by the cpu, player chooses rock then a tie is declared

      {
        // a Tie is declared. Incrase the number of ties
        numberofties += 1; // increase number of ties 




        numberoftiesCPU += 1; //increase the number of  ties for the cpu
        Console.WriteLine("number of ties for the cpu is " + numberoftiesCPU); //prints the number of ties for the cpu to the console.  

        Console.WriteLine("number of ties is " + numberofties); //writes the number of ties in the console. For Testing and debugging. 

        Game_Status_Textblock.Text = "TIE"; //change game status to tie. 
        Game_Status_Textblock.Foreground = System.Windows.Media.Brushes.Orange; // change text color to orange

        SoundPlayer player = new SoundPlayer(); // creates a new sound player
        player.Stream = Properties.Resources.snd_se_narration_Gameset; // plays the gameset soud file
        player.Load(); // loads the file 
        player.Play(); // plays the file



      }



      if (choicepicked.Equals("scissor") ) // if scissior is chosen by the cpu, load the scissior image

      {

        Player2_Option_Chosen.Source = new BitmapImage(new Uri("pack://application:,,,/ImagesBeingUsed/Scissors for the right sideTransparent.png")); //loads the Scissior image



      }



      if (choicepicked.Equals("scissor") && Paper_Option.IsChecked == true) // if scissior is chosen by the cpu, player chooses paper then a loss is declared

      {


        //Player looses. Increase the number of losses
        numberoflosses += 1; // increase number of losses

        Console.WriteLine("number of looses is " + numberoflosses); //writes the number of looses to the console.


        numberofwinsCPU += 1; //increase the number of wins for the cpu
        Console.WriteLine("number of wins for the cpu is " + numberofwinsCPU); //prints the number of cpu wins to the console. 



        SoundPlayer player = new SoundPlayer(); // creates a new sound player
        player.Stream = Properties.Resources.snd_se_narration_Defeated; // plays the defeated sound file 
        player.Load(); // loads the file 
        player.Play(); // plays the file


        Game_Status_Textblock.Text = "DEFEATED"; //change game status to Defeated
        Game_Status_Textblock.Foreground = System.Windows.Media.Brushes.Red; // change text color to red. 





      }


      if (choicepicked.Equals("scissor") && Scissior_Option.IsChecked == true) // if scissior is chosen by the cpu, player chooses Scissior then a tie is declared

      {


        //A tie is declared. Incrase the number of ties
        numberofties += 1; // increase number of ties


        numberoftiesCPU += 1; //increase the number of  ties for the cpu
        Console.WriteLine("number of ties for the cpu is " + numberoftiesCPU); //prints the number of ties for the cpu to the console.  


        Console.WriteLine("number of ties is " + numberofties); //writes the number of ties to the console.



        Game_Status_Textblock.Text = "TIE"; //change game status to Tie
        Game_Status_Textblock.Foreground = System.Windows.Media.Brushes.Orange; // change text to orange


        SoundPlayer player = new SoundPlayer(); // creates a new sound player
        player.Stream = Properties.Resources.snd_se_narration_Gameset; // plays the gameset soud file
        player.Load(); // loads the file 
        player.Play(); // plays the file




      }




      if (choicepicked.Equals("scissor") && Rock_Option.IsChecked == true) // if scissior is chosen by the cpu, player chooses rock then a win is declared

      {


        //Player wins. Increase the number of wins
        numberofwins += 1; // increase number of wins

        Console.WriteLine("number of wins is " + numberofwins); //writes the number of wins to the console.

        numberoflossesCPU += 1; //increase the number of losses
        Console.WriteLine("number of losses for the cpu is " + numberoflossesCPU); //prints the number of cpu losses to the console. 


        Game_Status_Textblock.Text = "SUCCESS"; //change game status to victory since player won. 
        Game_Status_Textblock.Foreground = System.Windows.Media.Brushes.Gold; // change text to gold. 
        

        SoundPlayer player = new SoundPlayer(); // creates a new sound player
        player.Stream = Properties.Resources.snd_se_narration_Success; // plays the sucess soud file
        player.Load(); // loads the file 
        player.Play(); // plays the file




      }






      Number_of_wins_textblock.Text = "Wins " + numberofwins; // puts the number of wins in the textblock.
      Number_of_Losses_textblock.Text = "Loses " + numberoflosses; // puts the number of losses in the textblock.
      Number_of_Ties_textblock.Text = "Ties " + numberofties; // the number of ties is put into the textblock. 
      Number_of_Losses_CPU_textblock.Text = "Loses " +  numberoflossesCPU; // the number of losses for the cpu is put into the textblock. 
      Number_of_Ties_CPU_textblock.Text = "Ties " + numberoftiesCPU; //the number of ties for the cpu is put into the textblock.
      Number_of_wins_CPU_textblock.Text = "Wins " + numberofwinsCPU; //the number of wins for the cpu is put into the textblock. 


    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
   // private void playsound(object sender, RoutedEventArgs e)
  //  {
   //   SoundPlayer player = new SoundPlayer(); // creates a new sound player
   //   player.Stream = Properties.Resources.snd_se_narration_Player_01; // plays the paper sound file. 
   //   player.Load(); // loads the file 
   //   player.Play(); // plays the file

   //   System.Threading.Thread.Sleep(3000);

    //  SoundPlayer player2 = new SoundPlayer(); // creates a new sound player
     // player2.Stream = Properties.Resources.snd_se_narration_Player_01; // plays the paper sound file. 
     // player2.Load(); // loads the file 
     // player2.Play(); // plays the file


   // }

    

    private void playsound(object sender, RoutedEventArgs e) //plays when the textblock loads
    {
      SoundPlayer player = new SoundPlayer(); // creates a new sound player
      player.Stream = Properties.Resources.snd_se_narration_Player_01; // plays the player1 sound. 
      player.Load(); // loads the file 
      player.Play(); // plays the file

      System.Threading.Thread.Sleep(3000);

      SoundPlayer player2 = new SoundPlayer(); // creates a new sound player
      player2.Stream = Properties.Resources.snd_se_narration_Go; // plays the go sound
      player2.Load(); // loads the file 
      player2.Play(); // plays the file

    }




    //TODO: Load the sound effects when the player wins, looses. DONE. 
    //TODO: If you can, find a sound effect for a  game tie. (Myabe a audience shock effect might be  a good idea).  DONE


    //TODO: Add The game Status Text when the player looses, Wins, or gets a tie. DONE

    //TODO: Add Wins, Ties and losses counter for the CPU. DONE.
    //TODO: Make the Wins, Ties, and losses Counter Functionsl for the cpu. DONE

    //TODO: Add the sound Effect game for when a tie is declared.  DONE

    //TODO:get rid of the old images we do not use. Try to orgnaize them into a folder if you can. DONE
    
    //TODO: Get rid of Sound files we are not using.
    //TODO: Add a About menu or a label with your name on it.
    //TODO: Organize the soud files into one folder.

   

    

   







  }
}


