namespace CapaPresentacion
{
    partial class MsgBox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MsgBox));
            pL1 = new Panel();
            pL2 = new Panel();
            lblTitulo = new Label();
            lblMsg = new Label();
            pbQuestion = new PictureBox();
            pbWarning = new PictureBox();
            pbError = new PictureBox();
            btnAceptar = new Button();
            btnCancelar = new Button();
            ((System.ComponentModel.ISupportInitialize)pbQuestion).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbWarning).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbError).BeginInit();
            SuspendLayout();
            // 
            // pL1
            // 
            pL1.BackColor = SystemColors.ActiveCaptionText;
            pL1.Location = new Point(-1, 64);
            pL1.Name = "pL1";
            pL1.Size = new Size(422, 4);
            pL1.TabIndex = 0;
            // 
            // pL2
            // 
            pL2.BackColor = Color.Silver;
            pL2.Location = new Point(-1, 155);
            pL2.Name = "pL2";
            pL2.Size = new Size(422, 4);
            pL2.TabIndex = 1;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Candara", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitulo.Location = new Point(68, 25);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(56, 23);
            lblTitulo.TabIndex = 2;
            lblTitulo.Text = "label1";
            // 
            // lblMsg
            // 
            lblMsg.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblMsg.Location = new Point(10, 71);
            lblMsg.Name = "lblMsg";
            lblMsg.Size = new Size(400, 81);
            lblMsg.TabIndex = 3;
            lblMsg.Text = "label1";
            // 
            // pbQuestion
            // 
            pbQuestion.Image = (Image)resources.GetObject("pbQuestion.Image");
            pbQuestion.Location = new Point(12, 12);
            pbQuestion.Name = "pbQuestion";
            pbQuestion.Size = new Size(50, 50);
            pbQuestion.SizeMode = PictureBoxSizeMode.Zoom;
            pbQuestion.TabIndex = 4;
            pbQuestion.TabStop = false;
            pbQuestion.Visible = false;
            // 
            // pbWarning
            // 
            pbWarning.Image = (Image)resources.GetObject("pbWarning.Image");
            pbWarning.Location = new Point(12, 12);
            pbWarning.Name = "pbWarning";
            pbWarning.Size = new Size(50, 50);
            pbWarning.SizeMode = PictureBoxSizeMode.Zoom;
            pbWarning.TabIndex = 5;
            pbWarning.TabStop = false;
            pbWarning.Visible = false;
            // 
            // pbError
            // 
            pbError.Image = (Image)resources.GetObject("pbError.Image");
            pbError.Location = new Point(12, 12);
            pbError.Name = "pbError";
            pbError.Size = new Size(50, 50);
            pbError.SizeMode = PictureBoxSizeMode.Zoom;
            pbError.TabIndex = 6;
            pbError.TabStop = false;
            pbError.Visible = false;
            // 
            // btnAceptar
            // 
            btnAceptar.BackColor = Color.FromArgb(1, 28, 83);
            btnAceptar.FlatAppearance.BorderSize = 0;
            btnAceptar.FlatStyle = FlatStyle.Flat;
            btnAceptar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnAceptar.ForeColor = Color.White;
            btnAceptar.Location = new Point(207, 165);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(85, 30);
            btnAceptar.TabIndex = 7;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = false;
            btnAceptar.Click += btnAceptar_Click;
            btnAceptar.MouseEnter += btn_MouseEnter;
            btnAceptar.MouseLeave += btn_MouseLeave;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.FromArgb(1, 28, 83);
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(312, 165);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(85, 30);
            btnCancelar.TabIndex = 8;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            btnCancelar.MouseEnter += btn_MouseEnter;
            btnCancelar.MouseLeave += btn_MouseLeave;
            // 
            // MsgBox
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(420, 200);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(pbError);
            Controls.Add(pbWarning);
            Controls.Add(pbQuestion);
            Controls.Add(lblMsg);
            Controls.Add(lblTitulo);
            Controls.Add(pL2);
            Controls.Add(pL1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MsgBox";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Aviso";
            ((System.ComponentModel.ISupportInitialize)pbQuestion).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbWarning).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbError).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pL1;
        private Panel pL2;
        private Label lblTitulo;
        private Label lblMsg;
        private PictureBox pbQuestion;
        private PictureBox pbWarning;
        private PictureBox pbError;
        private Button btnAceptar;
        private Button btnCancelar;
    }
}