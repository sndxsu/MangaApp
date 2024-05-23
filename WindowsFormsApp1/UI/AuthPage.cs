using MaterialSkin.Controls;
using System.Windows.Forms;
using WindowsFormsApp1.UI.AdminSide;
using WindowsFormsApp1.Users;
namespace WindowsFormsApp1.UI
{
    public partial class AuthPage : MaterialForm
    {

        public AuthPage()
        {
            ThemeControl theme = new ThemeControl(this);
            User s = User.LoggedBefore();
            if (!AuthUser(s))
            {
                InitializeComponent();
                theme.Initialize();
            }
            else
            {
                Hide();
                Application.Run();
            }
        }

        private bool AuthUser(Account s)
        {
            if (s != null)
            {
                Account acc = s.AccountIsExist(true);
                if (acc != null)
                {
                    if (acc.isAdmin())
                    {
                        AdminForm adminForm = new AdminForm();
                        adminForm.Show();

                    }
                    else 
                    {
                        UserForm u = new UserForm((User)acc);
                        (acc as User).SaveLogin();
                        u.Show();
                    }
                    this.Hide();
                    return true;
                }
            }
            return false;
        }

        private void materialButton1_Click(object sender, System.EventArgs e)
        {
            if (TextBoxesIsValid())
            {
                string username = materialTextBox21.Text;
                string password = materialTextBox22.Text;
                var user = new User(username);
                user.SetPassword(password);
                if (!AuthUser(user))
                {
                    MaterialMessageBox.Show("Неправильні дані!", false);
                };
            }
        }


        private void materialButton2_Click(object sender, System.EventArgs e)
        {
            if (TextBoxesIsValid())
            {
                string username = materialTextBox21.Text;
                string password = materialTextBox22.Text;

                User user = new User(username);
                user.SetPassword(password);
                if (user.Registrate() == false)
                {
                    MaterialMessageBox.Show("Такий обліковий запис уже існує", false);
                }
                else
                {
                    MaterialMessageBox.Show("Реєстрація успішна", false);
                }
            }
        }

        private bool TextBoxesIsValid()
        {
            if (materialTextBox21.Text.Trim().Length<5 || materialTextBox22.Text.Trim().Length < 5) {
                MaterialMessageBox.Show("Одне із полей пусте або містить неправильні дані.\n" +
                    "Пароль та логін мусять бути довжиною від 5 символів");
                return false;
            }
            else return true;
        }

        private void AuthPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
