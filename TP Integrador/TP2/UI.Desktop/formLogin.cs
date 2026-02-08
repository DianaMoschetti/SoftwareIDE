namespace UI.Desktop
{
    public partial class formLogin : Form
    {
        public formLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            // TODO: Implementar la lógica de autenticación real aquí, por bd
            if (this.txtUsuario.Text == "Admin" && this.txtPass.Text == "admin")
            {
                //MessageBox.Show("Usted ha ingresado al sistema correctamente", "Login",
                //    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos", "Login",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lnkOlvidePass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // TODO: Implementar recuperar por mail
            // chequear https://learn.microsoft.com/es-es/dotnet/api/system.net.mail.smtpclient?view=net-7.0 
            MessageBox.Show("Es Usted un usuario muy descuidado, haga memoria", "Olvidé mi contraseña",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
