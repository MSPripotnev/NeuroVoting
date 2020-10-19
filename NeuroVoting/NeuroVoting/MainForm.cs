using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Xml.Linq;
using System.Windows.Forms;
using NeuroVoting.Properties;
using System.Globalization;
using System.Threading;

namespace NeuroVoting
{
    public partial class VotingForm : Form
    {
        #region Fields
        private bool is_discuss = false;
        bool Is_Discuss
        {
            get
            {
                return is_discuss;
            }
            set
            {
                OppositeCLB.Enabled = PlacetCLB.Enabled = ScoreLabel.Enabled = propertyGrid.Enabled = is_discuss = value;
                DescRTB.ReadOnly = !value;
                if (value)
                {
                    OppositeCLB.BackColor = Color.FromKnownColor(KnownColor.Firebrick);
                    PlacetCLB.BackColor = Color.FromKnownColor(KnownColor.Green);
                    ScoreLabel.BackColor = Color.FromKnownColor(KnownColor.Orange);
                    ScoreLabel.Text = "";
                }
                else
                {
                    propertyGrid.SelectedObject = null;
                    DescRTB.Text = "";
                    DescRTB.Enabled = false;
                }
            }
        }
        enum ELanguage
        {
            English,
            Russian
        }
        ELanguage elang = ELanguage.English;
        ELanguage ELang
        {
            get
            {
                return elang;
            }
            set
            {
                elang = value;
                CultureInfo ci;
                if (value == ELanguage.English)
                    ci = new CultureInfo("en");
                else if (value == ELanguage.Russian)
                    ci = new CultureInfo("ru");
                else throw new Exception();

                System.Threading.Thread.CurrentThread.CurrentUICulture = ci;
                ComponentResourceManager resources = new ComponentResourceManager(typeof(VotingForm));
                string[] vs =
                {
                    DebateB.Text,
                    MainInfoLabel.Text
                };
                void ResourcesApply(Control c)
                {
                    if (!(c is ContextMenuStrip))
                    {
                        if (c == MainInfoLabel && (Is_Discuss || (OppositeCLB.Items.Count > 0 || PlacetCLB.Items.Count > 0)))
                            return;
                        if (c == DebateB)
                        {
                            c.Text = Is_Discuss ? DynamicControlLocalization(c, 1) : DynamicControlLocalization(c, 0);
                            return;
                        }
                        if (c == ScoreLabel && currentDecision != null)
                        {
                            if (!Is_Discuss)
                                c.Text = CurrentDecision.EndDate == null ? DynamicControlLocalization(c, 2) :
                                ((currentDecision.OppositeSumWeight < currentDecision.PlacetSumWeight) ?
                                DynamicControlLocalization(c, 0) : DynamicControlLocalization(c, 1));
                            return;
                        }
                        var loc = c.Location;
                        var enabled = c.Enabled;
                        resources.ApplyResources(c, c.Name);
                        this.helpToolTip.SetToolTip(c, resources.GetString(c.Name + ".ToolTip"));
                        if (c.Controls != null)
                            foreach (Control c1 in c.Controls)
                                ResourcesApply(c1);
                        c.Location = loc;
                        c.Enabled = enabled;
                    }
                    else if (c is ContextMenuStrip && (c as ContextMenuStrip).Items != null)
                        foreach (ToolStripItem c1 in (c as ContextMenuStrip).Items)
                            resources.ApplyResources(c1, c1.Name);
                    
                }
                foreach (Control c in this.Controls)
                    ResourcesApply(c);
                ResourcesApply(ArgumentCMS);
                ResourcesApply(ChangeDecisionCMS);
                ResourcesApply(EndDebateCMS);
                resources.ApplyResources(DecisionOFD, nameof(DecisionOFD));
                resources.ApplyResources(DecisionSFD, nameof(DecisionSFD));
            }
        }
        enum ResultShowType
        {
            VotesCount,
            RoundPercent,
            Percent
        }
        private ResultShowType RST = ResultShowType.Percent;
        Decision currentDecision;
        Decision CurrentDecision
        {
            get
            {
                return currentDecision;
            }
            set
            {
                if (currentDecision != null)
                   currentDecision.SaveDecision();
                currentDecision = value;
                if (value != null && value != new Decision() && value.Name != null)
                    DecisionRefresh();
            }
        }
        #endregion

        #region Initialize
        private void DecisionClear()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(VotingForm));
            OppositeCLB.Items.Clear();
            PlacetCLB.Items.Clear();
            OppositeCLB.BackColor = Color.FromKnownColor(KnownColor.Firebrick);
            PlacetCLB.BackColor = Color.FromKnownColor(KnownColor.Green);
            ScoreLabel.BackColor = Color.FromKnownColor(KnownColor.Orange);
            ScoreLabel.Text = "";
            
            resources.ApplyResources(MainInfoLabel, MainInfoLabel.Name);
        }
        private void DecisionRefresh()
        {
            DecisionClear();
            foreach (var arg in CurrentDecision.Argums)
                if (arg.Placet) PlacetCLB.Items.Add(arg.Name, (arg.Weight > 0));
                else OppositeCLB.Items.Add(arg.Name, (arg.Weight > 0));
            MainInfoLabel.Text = CurrentDecision.Name;

            #region Scores
            if (RST==ResultShowType.Percent)
            {
                double Percent = CurrentDecision.RecalcPercentage(4) * 100;
                if (Double.IsNaN(Percent)) ScoreLabel.Text = "";
                else ScoreLabel.Text = (100 - Percent).ToString() + "% vs. " + Percent.ToString() + "%";
            }
            else if (RST == ResultShowType.RoundPercent)
            {
                double Percent = CurrentDecision.RecalcPercentage(2) * 100;
                if (Double.IsNaN(Percent)) ScoreLabel.Text = "";
                else ScoreLabel.Text = (100 - Percent).ToString() + "% vs. " + Percent.ToString() + "%";
            }
            else if (RST == ResultShowType.VotesCount)
            {
                int SumPlacet = 0, SumOpposite = 0;
                foreach (Argument arg in CurrentDecision.Argums)
                    if (arg.Placet) SumPlacet += arg.Weight;
                    else SumOpposite += arg.Weight;
                ScoreLabel.Text = SumOpposite.ToString() + " vs. " + SumPlacet.ToString();
            }
            #endregion
        }
        
        public VotingForm()
        {
            InitializeComponent();
        }
        #endregion

        #region Cosmetic

        #region Localization
        private string DynamicControlLocalization(Control C, int state)
        {
            if (C == ScoreLabel)
            {
                if (ELang == ELanguage.English)
                    switch (state)
                    {
                        case 0: return "Decision accepted";
                        case 1: return "Decision declined";
                        case 2: return "Decision adjourned";
                        default: return String.Empty;
                    }
                else if (ELang == ELanguage.Russian)
                    switch (state)
                    {
                        case 0: return "Решение принято";
                        case 1: return "Решение отклонено";
                        case 2: return "Решение отложено";
                        default: return String.Empty;
                    }
                else return String.Empty;
            }
            else if (C == DebateB)
            {
                if (ELang == ELanguage.English)
                    switch (state)
                    {
                        case 0: return "Start Debate";
                        case 1: return "End Debate";
                        default: return String.Empty;
                    }
                else if (ELang == ELanguage.Russian)
                    switch (state)
                    {
                        case 0: return "Начать обсуждение";
                        case 1: return "Закончить обсуждение";
                        default: return String.Empty;
                    }
                else return String.Empty;
            }
            else return String.Empty;
        }
        private void LanguageB_Click(object sender, EventArgs e)
        {
            int cur = (int)ELang;
            cur++;
            cur %= typeof(ELanguage).GetFields().Count() - 1;
            ELang = (ELanguage)cur;
        }
        #endregion
        private void CLB_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool is_placet = sender == PlacetCLB;
            //сброс
            if ((sender as CheckedListBox).SelectedIndex == -1) return;
            var a = (is_placet ? OppositeCLB.SelectedItem = null : PlacetCLB.SelectedItem = null);
            int k = -1;
            //поиск необходимого
            for(int i = 0; i < CurrentDecision.Argums.Count; i++)
            {
                if (CurrentDecision.Argums[i].Placet != is_placet) continue; else k++;
                if (k == (sender as CheckedListBox).SelectedIndex)
                {
                    propertyGrid.SelectedObject = CurrentDecision.Argums[i];
                    return;
                }
            }
        }
        private void MainInfoLabel_Click(object sender, EventArgs e)
        {
            if (CurrentDecision != null && Is_Discuss)
                propertyGrid.SelectedObject = CurrentDecision;
            else if (CurrentDecision != null && CurrentDecision.EndDate != null)
            {
                DescRTB.Text = CurrentDecision.Description;
                DescRTB.Enabled = !(DescRTB.ReadOnly = DateTime.Now - CurrentDecision.EndDate > TimeSpan.FromDays(1));
            }
            else
            {
                DescRTB.Text = "";
                DescRTB.Enabled = false;
            }
        }
        private void ScoreLabel_Click(object sender, EventArgs e)
        {
            if (CurrentDecision != null)
            {
                RST = (ResultShowType)(((int)(RST) + 1) % 3);
                DecisionRefresh();
            }
        }
        private void progressTimer_Tick(object sender, EventArgs e)
        {
            if (progressBar.Value != progressBar.Maximum)
                progressBar.Value += progressBar.Step;
            else
            {
                Is_Discuss = false;
                DecisionRefresh();
                progressTimer.Stop();
                progressBar.Value = 0;
                progressBar.Visible = false;
                LanguageB.Enabled = DebateB.Visible = true;
                this.Cursor = Cursors.Default;
                TakeDecision();
            }
        }

        #region PropertyGrid
        private void propertyGrid_SelectedGridItemChanged(object sender, SelectedGridItemChangedEventArgs e)
        {
            if (e.NewSelection.Label == "Description")
            {
                if ((sender as PropertyGrid).SelectedObject is Argument)
                    DescRTB.Text = ((sender as PropertyGrid).SelectedObject as Argument).Description;
                else if ((sender as PropertyGrid).SelectedObject is Decision)
                    DescRTB.Text = ((sender as PropertyGrid).SelectedObject as Decision).Description;
                DescRTB.Enabled = true;
            }
            else
            {
                DescRTB.Enabled = false;
            }
        }
        #endregion

        #region DescRTB
        private void DescRTB_TextChanged(object sender, EventArgs e)
        {
            Control S = sender as Control;
            if (!S.Enabled) return;
            else if (S.ForeColor != Color.FromKnownColor(KnownColor.InactiveCaptionText))
            {
                if (propertyGrid.SelectedObject is Argument)
                    (propertyGrid.SelectedObject as Argument).Description = S.Text;
                else if (propertyGrid.SelectedObject is Decision)
                    (propertyGrid.SelectedObject as Decision).Description = S.Text;
                else if (CurrentDecision != null && !Is_Discuss && !progressBar.Visible)
                    CurrentDecision.Description = S.Text;
            }
        }
        private void DescRTB_Enter(object sender, EventArgs e)
        {

        }
        private void DescRTB_Leave(object sender, EventArgs e)
        {
            Control S = sender as Control;
            S.Enabled = false;
        }
        private void DescRTB_EnabledChanged(object sender, EventArgs e)
        {
            Control S = sender as Control;
            if (!S.Enabled)
            {
                //if (S.Text == "")
                //{
                if (ELang == ELanguage.English)
                    S.Text = "Enter the description in this window...";
                else if (ELang == ELanguage.Russian)
                    S.Text = "Введите описание в этом окне...";
                S.ForeColor = Color.FromKnownColor(KnownColor.InactiveCaptionText);
                //}
                //else
                //{
                //    S.Text = "";
                //    S.ForeColor = Color.FromKnownColor(KnownColor.ActiveCaptionText);
                //}
            }
            else S.ForeColor = Color.FromKnownColor(KnownColor.ActiveCaptionText);
        }
        #endregion

        #endregion

        #region Work
        private void TakeDecision()
        {
            if (CurrentDecision.EndDate != null && CurrentDecision.EndDate != DateTime.MinValue)
            {
                if (CurrentDecision.PlacetSumWeight > CurrentDecision.OppositeSumWeight)
                {
                    ScoreLabel.Text = DynamicControlLocalization(ScoreLabel, 0);
                    OppositeCLB.BackColor = ScoreLabel.BackColor = PlacetCLB.BackColor;
                }
                else if (CurrentDecision.PlacetSumWeight < CurrentDecision.OppositeSumWeight)
                {
                    ScoreLabel.Text = DynamicControlLocalization(ScoreLabel, 1);
                    PlacetCLB.BackColor = ScoreLabel.BackColor = OppositeCLB.BackColor;
                }
                else if (CurrentDecision.PlacetSumWeight == CurrentDecision.OppositeSumWeight)
                    ScoreLabel.Text = DynamicControlLocalization(ScoreLabel, 2);
                DescRTB.ReadOnly = false;
            }
            else 
                ScoreLabel.Text = DynamicControlLocalization(ScoreLabel, 2);
        }

        #region OpenSaveDecision
        private void DebateB_Click(object sender, EventArgs e)
        {
            if (CurrentDecision == null || !Is_Discuss)
                ChangeDecisionCMS.Show(MousePosition.X, MousePosition.Y);
            else
                EndDebateCMS.Show(MousePosition.X, MousePosition.Y);
        }
        private void DecisionTSMI_Click(object sender, EventArgs e)
        {
            DebateB.ContextMenuStrip = EndDebateCMS;
            CurrentDecision = null;
            DecisionClear();
            if (sender == openTSMI)
                DecisionOFD.ShowDialog(this);
            else if (sender == createTSMI)
                DecisionSFD.ShowDialog(this);
        }
        private void DecisionFD_FileOk(object sender, CancelEventArgs e)
        {
            if (sender == DecisionOFD)
            {
                XDocument xDoc = XDocument.Load(DecisionOFD.FileName);
                CurrentDecision = new Decision(xDoc, DecisionOFD.FileName);
                if (CurrentDecision.EndDate != DateTime.MinValue)
                {
                    Is_Discuss = false;
                    DescRTB.Text = CurrentDecision.Description;
                    DecisionRefresh();
                    TakeDecision();
                    DescRTB.ReadOnly = true;
                    return;
                }
            }
            else if (sender == DecisionSFD)
            {
                DecisionOFD.FileName = DecisionSFD.FileName;
                XDocument xDoc = new XDocument(
                    new XElement("Head", 
                    new XAttribute("name", DecisionOFD.SafeFileName
                    .Remove(DecisionOFD.SafeFileName.Length - 4, 4)), //"erase a .xml"
                        new XElement("Arguments"),
                        new XElement("Settings",
                            new XElement("Description"),
                            new XElement("Date",
                                new XAttribute("start", DateTime.Now),
                                new XAttribute("end", ""))
                        )
                    ));
                xDoc.Save(DecisionSFD.FileName);
                CurrentDecision = new Decision();
                CurrentDecision.XDocumentLoad(DecisionSFD.FileName);
            }
            Is_Discuss = true;
            DecisionRefresh();
            DebateB.Text = DynamicControlLocalization(DebateB, 1);
        }
        private void EndDebateTSMI_Click(object sender, EventArgs e)
        {
            if (sender == EndTSMI)
                CurrentDecision.TakeDecision(DateTime.Now);
            progressBar.Visible = true;
            LanguageB.Enabled =  DebateB.Visible = false;
            progressTimer.Start();
            DebateB.Text = DynamicControlLocalization(DebateB, 0);
            this.Cursor = Cursors.WaitCursor;
            Is_Discuss = false;
            DebateB.ContextMenuStrip = ChangeDecisionCMS;
        }
        private void CLB_KeyPress(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                deleteArgumentTSMI.PerformClick();
        }
        #endregion

        #region Arguments
        private void addNewArgumentTSMI_Click(object sender, EventArgs e)
        {
            ContextMenuStrip CMS = ((sender as ToolStripMenuItem).Owner as ContextMenuStrip);

            Argument arg = new Argument("argument", CMS.SourceControl == PlacetCLB);
            CurrentDecision.AddArgument(arg);
            DecisionRefresh();
        }
        private void deleteArgumentTSMI_Click(object sender, EventArgs e)
        {
            Argument arg;
            if (PlacetCLB.SelectedIndex > -1)
                arg = CurrentDecision.Argums.FindAll(a => a.Placet)[PlacetCLB.SelectedIndex];
            else if (OppositeCLB.SelectedIndex > -1)
                arg = CurrentDecision.Argums.FindAll(a => !a.Placet)[OppositeCLB.SelectedIndex];
            else
            {
                MessageBox.Show("There is no selected argument to delete. Please select it from listbox", "Selecting error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CurrentDecision.DelArgument(arg);
            DecisionRefresh();
        }
        private void propertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            DecisionRefresh();
            CurrentDecision.SaveDecision();
        }
        #endregion

        #endregion
    }
}