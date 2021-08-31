using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Scoreboard.Data.data.requests;
using Scoreboard.Data.Helpers;
using Scoreboard.Data.models;

namespace Scoreboard.forms
{
    public partial class FrmSettings : Form
    {
        private List<Setting> settings;

        public FrmSettings()
        {
            InitializeComponent();
            LoadSettings();
        }

        private void LoadSettings()
        {
            settings = SettingData.Get()?.OrderBy(s => s.Key).ToList();

            lbSettings.DataSource = settings;
            lbSettings.DisplayMember = "Key";

            if(settings.Count == 0)
            {
                txtId.Text = FormsHelper.GetResourceText("new");
            }
        }

        private void LbSettings_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((Setting)lbSettings.SelectedItem != null)
            {
                LoadSetting(((Setting)lbSettings.SelectedItem));
            }
        }

        private void LoadSetting(Setting setting)
        {
            var theDefault = SettingsHelper.GetDefaultSettings().FirstOrDefault(s => s.Key == setting.Key);
            
            txtId.Text = setting.Id.ToString();
            Key.Text = setting.Key;
            txtValue.Text = setting.Value;

            if (theDefault == null)
            {
                lblPossibleValues.Text = "-";
            } else
            {
                lblPossibleValues.Text = theDefault.PossibleValues;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (txtId.Text != FormsHelper.GetResourceText("new"))
            {
                var setting = (Setting)lbSettings.SelectedItem;
                if (setting == null)
                {
                    return;
                }
                setting.Key = Key.Text;
                setting.Value = txtValue.Text;

                SettingData.Update(setting);
            }
            else
            {
                var newSetting = new Setting
                {
                    Key = Key.Text,
                    Value = txtValue.Text
                };

                SettingData.Create(newSetting);
            }
            LoadSettings();
        }
    }
}
