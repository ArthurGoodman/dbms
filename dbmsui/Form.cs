using System.Drawing;
using System.Windows.Forms;

namespace dbmsui {
    public class Form : System.Windows.Forms.Form {
        Browser browser = new Browser();

        public Form() {
            Text = "DBMS";

            Size = new Size((int)(Screen.PrimaryScreen.WorkingArea.Size.Width / 1.5), (int)(Screen.PrimaryScreen.WorkingArea.Size.Height / 1.5));
            StartPosition = FormStartPosition.CenterScreen;

            Controls.Add(browser);
        }
    }
}
