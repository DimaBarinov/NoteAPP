using System.Windows.Forms;

namespace NoteAppUI
{
    /// <summary>
    /// Форма About.
    /// </summary>
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Копирование почти при нажатии.
        /// </summary>
        private void EmailLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clipboard.SetText("dima.barinov98@list.ru");
        }

        /// <summary>
        /// Переход в GitHub при нажатии.
        /// </summary>
        private void GitHubLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/DimaBarinov/NoteAPP");
        }
    }
}
