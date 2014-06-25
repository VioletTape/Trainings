using System;
using System.Drawing;
using System.Windows.Forms;
using Installation_v2.InstallationLogic;
using Installation_v2.PresentationLogic;

namespace Installation_v2 {
    public partial class FormInstall : Form {
        private readonly UseCaseRunner runner = new UseCaseRunner(new ServiceLocator());

        public FormInstall() {
            InitializeComponent();
            SubscribeOnEvents();

            Text = string.Format("Установка \"{0}\"", runner.ApplicationName);

            runner.OnStep = StepBind;
            runner.OnStepView = StepViewBind;
            runner.OnExitWithConfiramtion = ExitWithConfiramtion;
            runner.OnExitWithoutConfiramtion = ExitWithoutConfiramtion;
            runner.RunNext(true);
        }

        private void ExitWithConfiramtion(bool obj) {
            if (MessageBox.Show(
                    "Завершить установку приложения?",
                    "Отмена",
                    MessageBoxButtons.YesNo) == DialogResult.Yes) {
                runner.RunCancel();
            }
        }

        private void ExitWithoutConfiramtion(bool obj) {
            runner.Closing();
            Close();
        }

        private void StepViewBind(object view) {
            mainStepPanel.Controls.Clear();

            var View = (Control) view;
            View.BackColor = mainStepPanel.BackColor;
            mainStepPanel.Controls.Add(View);
        }

        private void StepBind(BaseViewState obj) {
            bindingSource.DataSource = obj;
            bindingSource.ResetBindings(false);

            ResetNavigationFonts();

            switch (obj.TrackName) {
                case TrackName.InfoGathering:
                    infoGatheringLabel.ForeColor = Color.SteelBlue;
                    break;
                case TrackName.Setup:
                    setupLabel.ForeColor = Color.SteelBlue;
                    break;
                case TrackName.Install:
                    installLabel.ForeColor = Color.SteelBlue;
                    break;
                case TrackName.Finish:
                    finishLabel.ForeColor = Color.SteelBlue;
                    break;
            }
        }

        private void ResetNavigationFonts() {
            for (var i = 0; i < panel1.Controls.Count; i++) {
                var label = panel1.Controls[i] as Label;
                if (label == null) continue;

                label.ForeColor = Color.Black;
            }
        }

        private void SubscribeOnEvents() {
            for (var i = 0; i < panel3.Controls.Count; i++) {
                var button = panel3.Controls[i] as Button;
                if (button == null) continue;

                button.MouseClick += OnClickAction;
            }
        }

        private static void OnClickAction(object sender, EventArgs e) {
            if (((Button) sender).Tag == null) return;
            ((Action<bool>) ((Button) sender).Tag)(true);
        }

        private void FormInstall_FormClosing(object sender, FormClosingEventArgs e) {
        }
    }
}