namespace UI.Desktop
{
    partial class formLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            txtUsuario = new TextBox();
            txtPass = new TextBox();
            btnIngresar = new Button();
            lnkOlvidePass = new LinkLabel();
            label3 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(296, 56);
            label1.Name = "label1";
            label1.Size = new Size(287, 40);
            label1.TabIndex = 0;
            label1.Text = "¡Bienvenidos al Sistema! \r\nPor favor digite su informacion de Ingreso";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.UseWaitCursor = true;
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(296, 144);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(325, 27);
            txtUsuario.TabIndex = 3;
            txtUsuario.UseWaitCursor = true;
            // 
            // txtPass
            // 
            txtPass.Location = new Point(296, 194);
            txtPass.Name = "txtPass";
            txtPass.PasswordChar = '*';
            txtPass.Size = new Size(325, 27);
            txtPass.TabIndex = 4;
            txtPass.UseWaitCursor = true;
            // 
            // btnIngresar
            // 
            btnIngresar.Location = new Point(527, 259);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(94, 29);
            btnIngresar.TabIndex = 5;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = true;
            btnIngresar.UseWaitCursor = true;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // lnkOlvidePass
            // 
            lnkOlvidePass.AutoSize = true;
            lnkOlvidePass.Location = new Point(296, 268);
            lnkOlvidePass.Name = "lnkOlvidePass";
            lnkOlvidePass.Size = new Size(149, 20);
            lnkOlvidePass.TabIndex = 6;
            lnkOlvidePass.TabStop = true;
            lnkOlvidePass.Text = "Olvidé mi contraseña";
            lnkOlvidePass.UseWaitCursor = true;
            lnkOlvidePass.LinkClicked += lnkOlvidePass_LinkClicked;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(171, 201);
            label3.Name = "label3";
            label3.Size = new Size(86, 20);
            label3.TabIndex = 2;
            label3.Text = "Contraseña:";
            label3.UseWaitCursor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(115, 151);
            label2.Name = "label2";
            label2.Size = new Size(142, 20);
            label2.TabIndex = 1;
            label2.Text = "Nombre de Usuario:";
            label2.UseWaitCursor = true;
            // 
            // formLogin
            // 
            AcceptButton = btnIngresar;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(867, 469);
            Controls.Add(lnkOlvidePass);
            Controls.Add(btnIngresar);
            Controls.Add(txtPass);
            Controls.Add(txtUsuario);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "formLogin";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Ingreso";
            UseWaitCursor = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtUsuario;
        private TextBox txtPass;
        private Button btnIngresar;
        private LinkLabel lnkOlvidePass;
        private Label label3;
        private Label label2;
    }
}
