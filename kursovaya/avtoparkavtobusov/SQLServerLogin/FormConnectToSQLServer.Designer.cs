namespace SQLServerLoginTemplate
{
	partial class FormConnectToSQLServer
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
            this.labelServerName = new System.Windows.Forms.Label();
            this.labelAuthentication = new System.Windows.Forms.Label();
            this.labelLogin = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.comboBoxServerName = new System.Windows.Forms.ComboBox();
            this.comboBoxLogin = new System.Windows.Forms.ComboBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonHelp = new System.Windows.Forms.Button();
            this.buttonOptions = new System.Windows.Forms.Button();
            this.checkBoxRememberPassword = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelSQLServer = new System.Windows.Forms.Label();
            this.comboBoxAuthentication = new System.Windows.Forms.ComboBox();
            this.labelServerType = new System.Windows.Forms.Label();
            this.comboBoxServerType = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelServerName
            // 
            this.labelServerName.AutoSize = true;
            this.labelServerName.Location = new System.Drawing.Point(13, 108);
            this.labelServerName.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelServerName.Name = "labelServerName";
            this.labelServerName.Size = new System.Drawing.Size(105, 13);
            this.labelServerName.TabIndex = 0;
            this.labelServerName.Text = "&Название сервера:";
            // 
            // labelAuthentication
            // 
            this.labelAuthentication.AutoSize = true;
            this.labelAuthentication.Location = new System.Drawing.Point(13, 136);
            this.labelAuthentication.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelAuthentication.Name = "labelAuthentication";
            this.labelAuthentication.Size = new System.Drawing.Size(61, 13);
            this.labelAuthentication.TabIndex = 1;
            this.labelAuthentication.Text = "&Тип входа:";
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.Location = new System.Drawing.Point(33, 162);
            this.labelLogin.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(41, 13);
            this.labelLogin.TabIndex = 2;
            this.labelLogin.Text = "&Логин:";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(33, 187);
            this.labelPassword.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(48, 13);
            this.labelPassword.TabIndex = 3;
            this.labelPassword.Text = "&Пароль:";
            // 
            // comboBoxServerName
            // 
            this.comboBoxServerName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBoxServerName.FormattingEnabled = true;
            this.comboBoxServerName.Location = new System.Drawing.Point(171, 105);
            this.comboBoxServerName.Margin = new System.Windows.Forms.Padding(1);
            this.comboBoxServerName.Name = "comboBoxServerName";
            this.comboBoxServerName.Size = new System.Drawing.Size(306, 21);
            this.comboBoxServerName.TabIndex = 6;
            this.comboBoxServerName.SelectedIndexChanged += new System.EventHandler(this.comboBoxServerName_SelectedIndexChanged);
            // 
            // comboBoxLogin
            // 
            this.comboBoxLogin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBoxLogin.FormattingEnabled = true;
            this.comboBoxLogin.Location = new System.Drawing.Point(191, 159);
            this.comboBoxLogin.Margin = new System.Windows.Forms.Padding(1);
            this.comboBoxLogin.Name = "comboBoxLogin";
            this.comboBoxLogin.Size = new System.Drawing.Size(287, 21);
            this.comboBoxLogin.TabIndex = 8;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxPassword.Location = new System.Drawing.Point(191, 184);
            this.textBoxPassword.Margin = new System.Windows.Forms.Padding(1);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(287, 20);
            this.textBoxPassword.TabIndex = 9;
            // 
            // buttonConnect
            // 
            this.buttonConnect.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonConnect.Location = new System.Drawing.Point(112, 242);
            this.buttonConnect.Margin = new System.Windows.Forms.Padding(1);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(110, 21);
            this.buttonConnect.TabIndex = 10;
            this.buttonConnect.Text = "&Подключится";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(228, 242);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(1);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(69, 21);
            this.buttonCancel.TabIndex = 11;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonHelp
            // 
            this.buttonHelp.Location = new System.Drawing.Point(302, 241);
            this.buttonHelp.Margin = new System.Windows.Forms.Padding(1);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(81, 22);
            this.buttonHelp.TabIndex = 12;
            this.buttonHelp.Text = "&Помощь";
            this.buttonHelp.UseVisualStyleBackColor = true;
            // 
            // buttonOptions
            // 
            this.buttonOptions.Location = new System.Drawing.Point(385, 242);
            this.buttonOptions.Margin = new System.Windows.Forms.Padding(1);
            this.buttonOptions.Name = "buttonOptions";
            this.buttonOptions.Size = new System.Drawing.Size(91, 21);
            this.buttonOptions.TabIndex = 13;
            this.buttonOptions.Text = "&Настройки >>";
            this.buttonOptions.UseVisualStyleBackColor = true;
            // 
            // checkBoxRememberPassword
            // 
            this.checkBoxRememberPassword.AutoSize = true;
            this.checkBoxRememberPassword.Location = new System.Drawing.Point(191, 212);
            this.checkBoxRememberPassword.Margin = new System.Windows.Forms.Padding(1);
            this.checkBoxRememberPassword.Name = "checkBoxRememberPassword";
            this.checkBoxRememberPassword.Size = new System.Drawing.Size(121, 17);
            this.checkBoxRememberPassword.TabIndex = 14;
            this.checkBoxRememberPassword.Text = "Запомнить пароль";
            this.checkBoxRememberPassword.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(11, 230);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(463, 4);
            this.label1.TabIndex = 15;
            // 
            // labelSQLServer
            // 
            this.labelSQLServer.AutoSize = true;
            this.labelSQLServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSQLServer.Location = new System.Drawing.Point(153, 15);
            this.labelSQLServer.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelSQLServer.Name = "labelSQLServer";
            this.labelSQLServer.Size = new System.Drawing.Size(204, 36);
            this.labelSQLServer.TabIndex = 16;
            this.labelSQLServer.Text = "Авторизация";
            // 
            // comboBoxAuthentication
            // 
            this.comboBoxAuthentication.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBoxAuthentication.FormattingEnabled = true;
            this.comboBoxAuthentication.Location = new System.Drawing.Point(171, 133);
            this.comboBoxAuthentication.Margin = new System.Windows.Forms.Padding(1);
            this.comboBoxAuthentication.Name = "comboBoxAuthentication";
            this.comboBoxAuthentication.Size = new System.Drawing.Size(306, 21);
            this.comboBoxAuthentication.TabIndex = 7;
            this.comboBoxAuthentication.SelectedIndexChanged += new System.EventHandler(this.comboBoxAuthentication_SelectedIndexChanged);
            // 
            // labelServerType
            // 
            this.labelServerType.AutoSize = true;
            this.labelServerType.Location = new System.Drawing.Point(13, 80);
            this.labelServerType.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelServerType.Name = "labelServerType";
            this.labelServerType.Size = new System.Drawing.Size(74, 13);
            this.labelServerType.TabIndex = 17;
            this.labelServerType.Text = "Тип сервера:";
            // 
            // comboBoxServerType
            // 
            this.comboBoxServerType.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBoxServerType.FormattingEnabled = true;
            this.comboBoxServerType.Location = new System.Drawing.Point(171, 80);
            this.comboBoxServerType.Margin = new System.Windows.Forms.Padding(1);
            this.comboBoxServerType.Name = "comboBoxServerType";
            this.comboBoxServerType.Size = new System.Drawing.Size(306, 21);
            this.comboBoxServerType.TabIndex = 18;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.labelSQLServer);
            this.panel1.Location = new System.Drawing.Point(-11, -6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(512, 69);
            this.panel1.TabIndex = 19;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkOrange;
            this.panel2.Location = new System.Drawing.Point(0, 54);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(500, 10);
            this.panel2.TabIndex = 17;
            // 
            // FormConnectToSQLServer
            // 
            this.AcceptButton = this.buttonConnect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(484, 282);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.comboBoxServerType);
            this.Controls.Add(this.labelServerType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBoxRememberPassword);
            this.Controls.Add(this.buttonOptions);
            this.Controls.Add(this.buttonHelp);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.comboBoxLogin);
            this.Controls.Add(this.comboBoxAuthentication);
            this.Controls.Add(this.comboBoxServerName);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelLogin);
            this.Controls.Add(this.labelAuthentication);
            this.Controls.Add(this.labelServerName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormConnectToSQLServer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Вход в систему";
            this.Load += new System.EventHandler(this.FormConnectToSQLServer_Load);
            this.Resize += new System.EventHandler(this.FormConnectToSQLServer_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelServerName;
		private System.Windows.Forms.Label labelAuthentication;
		private System.Windows.Forms.Label labelLogin;
		private System.Windows.Forms.Label labelPassword;
		private System.Windows.Forms.ComboBox comboBoxServerName;
		private System.Windows.Forms.ComboBox comboBoxLogin;
		private System.Windows.Forms.TextBox textBoxPassword;
		private System.Windows.Forms.Button buttonConnect;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonHelp;
		private System.Windows.Forms.Button buttonOptions;
		private System.Windows.Forms.CheckBox checkBoxRememberPassword;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label labelSQLServer;
		private System.Windows.Forms.ComboBox comboBoxAuthentication;
		private System.Windows.Forms.Label labelServerType;
		private System.Windows.Forms.ComboBox comboBoxServerType;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}