using Scoreboard.DataCore.Data.Requests;
using Scoreboard.DataCore.Helpers;
using Scoreboard.DataCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

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

            if (settings.Count == 0)
            {
                txtId.Text = FormsHelper.GetResourceText("new");
            }
        }

        private void LbSettings_SelectedIndexChanged(object sender, EventArgs e)
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
            txtValue.Visible = true;
            cboValue.Visible = false;

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
                        cboValue.Visible = true;
                        txtValue.Visible = false;
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

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (txtId.Text != FormsHelper.GetResourceText("new"))
            {
                Setting setting = (Setting)lbSettings.SelectedItem;
                if (setting == null)
                {
                    return;
                }
                string value;
                if (txtValue.Visible)
                {
                    value = txtValue.Text;
                }
                else
                {
                    value = (string)cboValue.SelectedItem;
                }

                setting.Key = txtKey.Text;
                setting.Value = value;

                _ = SettingData.Update(setting);
            }
            else
            {
                Setting newSetting = new Setting
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
