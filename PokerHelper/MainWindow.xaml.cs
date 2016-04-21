using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Text.RegularExpressions;

namespace PokerHelper
{    
    public partial class MainWindow : Window
    {
        const int _STARTING_MONEY = 10000;
        static int jackpot = 0;

        static int[] players_budget = {_STARTING_MONEY, _STARTING_MONEY, _STARTING_MONEY};

        public MainWindow()
        {
            InitializeComponent();
            RefreshPlayersBudget();
        }



        void ElableAllBidsBoxes()
        {
            TextBox_Player1_Bid.IsEnabled = true;
            TextBox_Player2_Bid.IsEnabled = true;
            TextBox_Player3_Bid.IsEnabled = true;
        }



        void RefreshJackpot()
        {
            Label_Jackpot.Content = string.Format("${0:N0}", jackpot);
        }



        void RefreshPlayersBudget()
        {
            Label_Player1_Money.Content = string.Format("${0:N0}", players_budget[0]);
            Label_Player2_Money.Content = string.Format("${0:N0}", players_budget[1]);
            Label_Player3_Money.Content = string.Format("${0:N0}", players_budget[2]);
        }



        private void Button_Player1_MakeBid_Click(object sender, RoutedEventArgs e)
        {
            var bid = TextBox_Player1_Bid.Text;
            if(Regex.IsMatch(bid, @"^\d+$"))
            {
                int summ = 0;

                if (!int.TryParse(bid, out summ))
                    return;

                if(summ <= players_budget[0])
                {
                    players_budget[0] -= summ;

                    jackpot += summ;
                    RefreshPlayersBudget();
                    RefreshJackpot();

                    TextBox_Player1_Bid.Text = "";
                    //TextBox_Player1_Bid.IsEnabled = false;
                }
            }
        }

        private void Button_Player2_MakeBid_Click(object sender, RoutedEventArgs e)
        {
            var bid = TextBox_Player2_Bid.Text;
            if (Regex.IsMatch(bid, @"^\d+$"))
            {
                int summ = 0;

                if (!int.TryParse(bid, out summ))
                    return;

                if (summ <= players_budget[1])
                {
                    players_budget[1] -= summ;

                    jackpot += summ;
                    RefreshPlayersBudget();
                    RefreshJackpot();

                    TextBox_Player2_Bid.Text = "";
                    //TextBox_Player2_Bid.IsEnabled = false;
                }
            }
        }

        private void Button_Player3_MakeBid_Click(object sender, RoutedEventArgs e)
        {
            var bid = TextBox_Player3_Bid.Text;
            if (Regex.IsMatch(bid, @"^\d+$"))
            {
                int summ = 0;

                if (!int.TryParse(bid, out summ))
                    return;

                if (summ <= players_budget[2])
                {
                    players_budget[2] -= summ;

                    jackpot += summ;
                    RefreshPlayersBudget();
                    RefreshJackpot();

                    TextBox_Player3_Bid.Text = "";
                    //TextBox_Player3_Bid.IsEnabled = false;
                }
            }
        }

        private void Button_Player1_HasWon_Click(object sender, RoutedEventArgs e)
        {
            players_budget[0] += jackpot;

            jackpot = 0;

            RefreshJackpot();
            RefreshPlayersBudget();
            ElableAllBidsBoxes();
        }

        private void Button_Player2_HasWon_Click(object sender, RoutedEventArgs e)
        {
            players_budget[1] += jackpot;

            jackpot = 0;

            RefreshJackpot();
            RefreshPlayersBudget();
            ElableAllBidsBoxes();
        }

        private void Button_Player3_HasWon_Click(object sender, RoutedEventArgs e)
        {
            players_budget[2] += jackpot;

            jackpot = 0;

            RefreshJackpot();
            RefreshPlayersBudget();
            //ElableAllBidsBoxes();
        }
    }
}
