using Scoreboard.DataCore.Data.Requests;
using Scoreboard.DataCore.Helpers;
using Scoreboard.DataCore.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Scoreboard.Wpf.Windows
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        private List<Setting> settings;
        public Settings()
        {
            InitializeComponent();
            LoadSettings();
        }

        private void LoadSettings()
        {
            settings = SettingData.Get()?.OrderBy(s => s.Key).ToList();

            lbSettings.ItemsSource = settings;
            lbSettings.DisplayMemberPath = "Key";

            if (settings.Count == 0)
            {
                txtId.Text = WpfHelper.GetResourceText("new");
            }
            lbSettings.SelectedIndex = 0;
        }

        private void LbSettings_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if ((Setting)lbSettings.SelectedItem != null)
            {
                LoadSetting((Setting)lbSettings.SelectedItem);
            }
        }

        private void LoadSetting(Setting setting)
        {
            Setting theDefault = SettingsHelper.GetDefaultSettings().FirstOrDefault(s => s.Key == setting.Key);

            txtId.Text = setting.Id.ToString();
            txtKey.Text = setting.Key;
            txtValue.Text = setting.Value;
            cboValue.Items.Clear();
            txtValue.Visibility = Visibility.Visible;
            cboValue.Visibility = Visibility.Hidden;

            if (theDefault == null)
            {
                lblPossibleValues.Text = "-";
            }
            else
            {
                lblPossibleValues.Text = theDefault.PossibleValues;

                if (theDefault.PossibleValues.Split(',').Length > 1)
                {
                    int selected = 0;
                    int index = 0;
                    foreach (string option in theDefault.PossibleValues.Split(','))
                    {
                        _ = cboValue.Items.Add(option.Trim(' '));
                        cboValue.Visibility = Visibility.Visible;
                        txtValue.Visibility = Visibility.Hidden;
                        if (setting.Value == option.Trim(' '))
                        {
                            selected = index;
                        }
                        index++;
                    }

                    cboValue.SelectedIndex = selected;
                }
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (txtId.Text != WpfHelper.GetResourceText("new"))
            {
                Setting setting = (Setting)lbSettings.SelectedItem;
                if (setting == null)
                {
                    return;
                }
                string value = txtValue.Visibility == Visibility.Visible ? txtValue.Text : (string)cboValue.SelectedItem;
                setting.Key = txtKey.Text;
                setting.Value = value;

                _ = SettingData.Update(setting);
            }
            else
            {
                Setting newSetting = new()
                {
                    Key = txtKey.Text,
                    Value = txtValue.Text
                };

                _ = SettingData.Create(newSetting);
            }
            LoadSettings();
        }
    }
}
