namespace AcademiaABM
{
    public partial class Usuarios : Form
    {
        public Usuarios()
        {
            InitializeComponent();
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            ConfigurarGrilla();
            // tsbEditar.Image = Properties.Resources.icon_edit;
            //Listar
            Usuario usuario = new();
            dgvUsuarios.DataSource = usuario.Listar();
        }

        //private void btnActualizar_Click(object sender, EventArgs e)
        //{
        //    this.Close();
        //}

        private void Actualizar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new();
            dgvUsuarios.DataSource = usuario.Listar();
        }

        private void Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConfigurarGrilla()
        {
            dgvUsuarios.AutoGenerateColumns = false;
            dgvUsuarios.Columns["Id"].Visible = false;
            dgvUsuarios.Columns["Nombre"].HeaderText = "Nombre";
            dgvUsuarios.Columns["Apellido"].HeaderText = "Apellido";
            dgvUsuarios.Columns["User"].HeaderText = "Usuario";
            dgvUsuarios.Columns["Email"].HeaderText = "Email";
            dgvUsuarios.Columns["Habilitado"].HeaderText = "Habilitado";
        }
    }


}
