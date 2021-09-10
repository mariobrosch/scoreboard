﻿using Scoreboard.DataCore.Data.Requests;
using Scoreboard.DataCore.Models;
using System;
using System.Linq;
using System.Windows;

namespace Scoreboard.Wpf.Windows
{
    /// <summary>
    /// Interaction logic for CreateSingleMatch.xaml
    /// </summary>
    public partial class CreateSingleMatch : Window
    {
        public CreateSingleMatch()
        {
            InitializeComponent();
            LoadData();
        }

        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            Player selectedPlayer = (Player)cboPlayer.SelectedItem;

            SinglePlayerMatch newMatch = new()
            {
                MatchDateParsed = DateTime.Now,
                PlayerId = selectedPlayer.Id
            };
            var newSavedMatch = SinglePlayerMatchData.Create(newMatch);
            var frmSinglePlayerMatch = new PlaySinglePlayer(newSavedMatch);
            Hide();
            frmSinglePlayerMatch.ShowDialog();
            Show();
        }

        private void LoadData()
        {
            cboPlayer.ItemsSource = PlayerData.Get().OrderBy(p => p.Name).ToList();
            cboPlayer.DisplayMemberPath = "Name";
            cboPlayer.SelectedIndex = 0;
        }
    }
}
