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
            labelServerName = new System.Windows.Forms.Label();
            labelAuthentication = new System.Windows.Forms.Label();
            labelLogin = new System.Windows.Forms.Label();
            labelPassword = new System.Windows.Forms.Label();
            comboBoxServerName = new System.Windows.Forms.ComboBox();
            comboBoxLogin = new System.Windows.Forms.ComboBox();
            textBoxPassword = new System.Windows.Forms.TextBox();
            buttonConnect = new System.Windows.Forms.Button();
            buttonCancel = new System.Windows.Forms.Button();
            buttonHelp = new System.Windows.Forms.Button();
            buttonOptions = new System.Windows.Forms.Button();
            checkBoxRememberPassword = new System.Windows.Forms.CheckBox();
            labelSQLServer = new System.Windows.Forms.Label();
            comboBoxAuthentication = new System.Windows.Forms.ComboBox();
            labelServerType = new System.Windows.Forms.Label();
            comboBoxServerType = new System.Windows.Forms.ComboBox();
            panel1 = new System.Windows.Forms.Panel();
            panel2 = new System.Windows.Forms.Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // labelServerName
            // 
            labelServerName.AutoSize = true;
            labelServerName.Location = new System.Drawing.Point(13, 108);
            labelServerName.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            labelServerName.Name = "labelServerName";
            labelServerName.Size = new System.Drawing.Size(107, 13);
            labelServerName.TabIndex = 0;
            labelServerName.Text = "&Название сервера:";
            // 
            // labelAuthentication
            // 
            labelAuthentication.AutoSize = true;
            labelAuthentication.Location = new System.Drawing.Point(13, 136);
            labelAuthentication.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            labelAuthentication.Name = "labelAuthentication";
            labelAuthentication.Size = new System.Drawing.Size(63, 13);
            labelAuthentication.TabIndex = 1;
            labelAuthentication.Text = "&Тип входа:";
            // 
            // labelLogin
            // 
            labelLogin.AutoSize = true;
            labelLogin.Location = new System.Drawing.Point(33, 162);
            labelLogin.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            labelLogin.Name = "labelLogin";
            labelLogin.Size = new System.Drawing.Size(43, 13);
            labelLogin.TabIndex = 2;
            labelLogin.Text = "&Логин:";
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Location = new System.Drawing.Point(33, 187);
            labelPassword.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new System.Drawing.Size(50, 13);
            labelPassword.TabIndex = 3;
            labelPassword.Text = "&Пароль:";
            // 
            // comboBoxServerName
            // 
            comboBoxServerName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            comboBoxServerName.FormattingEnabled = true;
            comboBoxServerName.Location = new System.Drawing.Point(171, 105);
            comboBoxServerName.Margin = new System.Windows.Forms.Padding(1);
            comboBoxServerName.Name = "comboBoxServerName";
            comboBoxServerName.Size = new System.Drawing.Size(306, 21);
            comboBoxServerName.TabIndex = 6;
            comboBoxServerName.SelectedIndexChanged += comboBoxServerName_SelectedIndexChanged;
            // 
            // comboBoxLogin
            // 
            comboBoxLogin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            comboBoxLogin.FormattingEnabled = true;
            comboBoxLogin.Location = new System.Drawing.Point(191, 159);
            comboBoxLogin.Margin = new System.Windows.Forms.Padding(1);
            comboBoxLogin.Name = "comboBoxLogin";
            comboBoxLogin.Size = new System.Drawing.Size(287, 21);
            comboBoxLogin.TabIndex = 8;
            // 
            // textBoxPassword
            // 
            textBoxPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBoxPassword.Location = new System.Drawing.Point(191, 184);
            textBoxPassword.Margin = new System.Windows.Forms.Padding(1);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.PasswordChar = '*';
            textBoxPassword.Size = new System.Drawing.Size(287, 22);
            textBoxPassword.TabIndex = 9;
            // 
            // buttonConnect
            // 
            buttonConnect.DialogResult = System.Windows.Forms.DialogResult.OK;
            buttonConnect.Location = new System.Drawing.Point(112, 242);
            buttonConnect.Margin = new System.Windows.Forms.Padding(1);
            buttonConnect.Name = "buttonConnect";
            buttonConnect.Size = new System.Drawing.Size(110, 21);
            buttonConnect.TabIndex = 10;
            buttonConnect.Text = "&Подключится";
            buttonConnect.UseVisualStyleBackColor = true;
            buttonConnect.Click += buttonConnect_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            buttonCancel.Location = new System.Drawing.Point(228, 242);
            buttonCancel.Margin = new System.Windows.Forms.Padding(1);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new System.Drawing.Size(69, 21);
            buttonCancel.TabIndex = 11;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // buttonHelp
            // 
            buttonHelp.Location = new System.Drawing.Point(302, 241);
            buttonHelp.Margin = new System.Windows.Forms.Padding(1);
            buttonHelp.Name = "buttonHelp";
            buttonHelp.Size = new System.Drawing.Size(81, 22);
            buttonHelp.TabIndex = 12;
            buttonHelp.Text = "&Помощь";
            buttonHelp.UseVisualStyleBackColor = true;
            // 
            // buttonOptions
            // 
            buttonOptions.Location = new System.Drawing.Point(385, 242);
            buttonOptions.Margin = new System.Windows.Forms.Padding(1);
            buttonOptions.Name = "buttonOptions";
            buttonOptions.Size = new System.Drawing.Size(91, 21);
            buttonOptions.TabIndex = 13;
            buttonOptions.Text = "&Настройки >>";
            buttonOptions.UseVisualStyleBackColor = true;
            // 
            // checkBoxRememberPassword
            // 
            checkBoxRememberPassword.AutoSize = true;
            checkBoxRememberPassword.Location = new System.Drawing.Point(191, 212);
            checkBoxRememberPassword.Margin = new System.Windows.Forms.Padding(1);
            checkBoxRememberPassword.Name = "checkBoxRememberPassword";
            checkBoxRememberPassword.Size = new System.Drawing.Size(127, 17);
            checkBoxRememberPassword.TabIndex = 14;
            checkBoxRememberPassword.Text = "Запомнить пароль";
            checkBoxRememberPassword.UseVisualStyleBackColor = true;
            // 
            // labelSQLServer
            // 
            labelSQLServer.AutoSize = true;
            labelSQLServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            labelSQLServer.Location = new System.Drawing.Point(153, 15);
            labelSQLServer.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            labelSQLServer.Name = "labelSQLServer";
            labelSQLServer.Size = new System.Drawing.Size(204, 36);
            labelSQLServer.TabIndex = 16;
            labelSQLServer.Text = "Авторизация";
            labelSQLServer.Click += labelSQLServer_Click;
            // 
            // comboBoxAuthentication
            // 
            comboBoxAuthentication.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            comboBoxAuthentication.FormattingEnabled = true;
            comboBoxAuthentication.Location = new System.Drawing.Point(171, 133);
            comboBoxAuthentication.Margin = new System.Windows.Forms.Padding(1);
            comboBoxAuthentication.Name = "comboBoxAuthentication";
            comboBoxAuthentication.Size = new System.Drawing.Size(306, 21);
            comboBoxAuthentication.TabIndex = 7;
            comboBoxAuthentication.SelectedIndexChanged += comboBoxAuthentication_SelectedIndexChanged;
            // 
            // labelServerType
            // 
            labelServerType.AutoSize = true;
            labelServerType.Location = new System.Drawing.Point(13, 80);
            labelServerType.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            labelServerType.Name = "labelServerType";
            labelServerType.Size = new System.Drawing.Size(76, 13);
            labelServerType.TabIndex = 17;
            labelServerType.Text = "Тип сервера:";
            // 
            // comboBoxServerType
            // 
            comboBoxServerType.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            comboBoxServerType.FormattingEnabled = true;
            comboBoxServerType.Location = new System.Drawing.Point(171, 80);
            comboBoxServerType.Margin = new System.Windows.Forms.Padding(1);
            comboBoxServerType.Name = "comboBoxServerType";
            comboBoxServerType.Size = new System.Drawing.Size(306, 21);
            comboBoxServerType.TabIndex = 18;
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.Color.White;
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(labelSQLServer);
            panel1.Location = new System.Drawing.Point(-11, -6);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(512, 69);
            panel1.TabIndex = 19;
            // 
            // panel2
            // 
            panel2.BackColor = System.Drawing.Color.DarkOrange;
            panel2.Location = new System.Drawing.Point(0, 54);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(500, 10);
            panel2.TabIndex = 17;
            // 
            // FormConnectToSQLServer
            // 
            AcceptButton = buttonConnect;
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = buttonCancel;
            ClientSize = new System.Drawing.Size(484, 282);
            Controls.Add(panel1);
            Controls.Add(comboBoxServerType);
            Controls.Add(labelServerType);
            Controls.Add(checkBoxRememberPassword);
            Controls.Add(buttonOptions);
            Controls.Add(buttonHelp);
            Controls.Add(buttonCancel);
            Controls.Add(buttonConnect);
            Controls.Add(textBoxPassword);
            Controls.Add(comboBoxLogin);
            Controls.Add(comboBoxAuthentication);
            Controls.Add(comboBoxServerName);
            Controls.Add(labelPassword);
            Controls.Add(labelLogin);
            Controls.Add(labelAuthentication);
            Controls.Add(labelServerName);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            Margin = new System.Windows.Forms.Padding(1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormConnectToSQLServer";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Вход в систему";
            Load += FormConnectToSQLServer_Load;
            Resize += FormConnectToSQLServer_Resize;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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
        private System.Windows.Forms.Label labelSQLServer;
        private System.Windows.Forms.ComboBox comboBoxAuthentication;
        private System.Windows.Forms.Label labelServerType;
        private System.Windows.Forms.ComboBox comboBoxServerType;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}