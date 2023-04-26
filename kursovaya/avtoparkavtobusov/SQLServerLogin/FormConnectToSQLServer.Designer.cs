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
            labelServerName = new MaterialSkin.Controls.MaterialLabel();
            labelAuthentication = new MaterialSkin.Controls.MaterialLabel();
            labelLogin = new MaterialSkin.Controls.MaterialLabel();
            labelPassword = new MaterialSkin.Controls.MaterialLabel();
            comboBoxServerName = new MaterialSkin.Controls.MaterialComboBox();
            comboBoxLogin = new MaterialSkin.Controls.MaterialComboBox();
            buttonConnect = new MaterialSkin.Controls.MaterialButton();
            buttonCancel = new MaterialSkin.Controls.MaterialButton();
            buttonHelp = new MaterialSkin.Controls.MaterialButton();
            buttonOptions = new MaterialSkin.Controls.MaterialButton();
            checkBoxRememberPassword = new MaterialSkin.Controls.MaterialCheckbox();
            comboBoxAuthentication = new MaterialSkin.Controls.MaterialComboBox();
            labelServerType = new MaterialSkin.Controls.MaterialLabel();
            comboBoxServerType = new MaterialSkin.Controls.MaterialComboBox();
            textBoxPassword = new MaterialSkin.Controls.MaterialTextBox();
            SuspendLayout();
            // 
            // labelServerName
            // 
            labelServerName.AutoSize = true;
            labelServerName.Depth = 0;
            labelServerName.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            labelServerName.Location = new System.Drawing.Point(13, 158);
            labelServerName.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            labelServerName.MouseState = MaterialSkin.MouseState.HOVER;
            labelServerName.Name = "labelServerName";
            labelServerName.Size = new System.Drawing.Size(151, 19);
            labelServerName.TabIndex = 0;
            labelServerName.Text = "&Название сервера:";
            // 
            // labelAuthentication
            // 
            labelAuthentication.AutoSize = true;
            labelAuthentication.Depth = 0;
            labelAuthentication.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            labelAuthentication.Location = new System.Drawing.Point(13, 222);
            labelAuthentication.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            labelAuthentication.MouseState = MaterialSkin.MouseState.HOVER;
            labelAuthentication.Name = "labelAuthentication";
            labelAuthentication.Size = new System.Drawing.Size(92, 19);
            labelAuthentication.TabIndex = 1;
            labelAuthentication.Text = "&Тип входа:";
            // 
            // labelLogin
            // 
            labelLogin.AutoSize = true;
            labelLogin.Depth = 0;
            labelLogin.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            labelLogin.Location = new System.Drawing.Point(34, 290);
            labelLogin.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            labelLogin.MouseState = MaterialSkin.MouseState.HOVER;
            labelLogin.Name = "labelLogin";
            labelLogin.Size = new System.Drawing.Size(60, 19);
            labelLogin.TabIndex = 2;
            labelLogin.Text = "&Логин:";
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Depth = 0;
            labelPassword.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            labelPassword.Location = new System.Drawing.Point(34, 364);
            labelPassword.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            labelPassword.MouseState = MaterialSkin.MouseState.HOVER;
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new System.Drawing.Size(71, 19);
            labelPassword.TabIndex = 3;
            labelPassword.Text = "&Пароль:";
            // 
            // comboBoxServerName
            // 
            comboBoxServerName.AutoResize = false;
            comboBoxServerName.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            comboBoxServerName.Depth = 0;
            comboBoxServerName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            comboBoxServerName.DropDownHeight = 174;
            comboBoxServerName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBoxServerName.DropDownWidth = 121;
            comboBoxServerName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            comboBoxServerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            comboBoxServerName.ForeColor = System.Drawing.Color.FromArgb(222, 0, 0, 0);
            comboBoxServerName.FormattingEnabled = true;
            comboBoxServerName.IntegralHeight = false;
            comboBoxServerName.ItemHeight = 43;
            comboBoxServerName.Items.AddRange(new object[] { "localhost" });
            comboBoxServerName.Location = new System.Drawing.Point(176, 144);
            comboBoxServerName.Margin = new System.Windows.Forms.Padding(1);
            comboBoxServerName.MaxDropDownItems = 4;
            comboBoxServerName.MouseState = MaterialSkin.MouseState.OUT;
            comboBoxServerName.Name = "comboBoxServerName";
            comboBoxServerName.Size = new System.Drawing.Size(584, 49);
            comboBoxServerName.StartIndex = 0;
            comboBoxServerName.TabIndex = 6;
            comboBoxServerName.SelectedIndexChanged += comboBoxServerName_SelectedIndexChanged;
            // 
            // comboBoxLogin
            // 
            comboBoxLogin.AutoResize = false;
            comboBoxLogin.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            comboBoxLogin.Depth = 0;
            comboBoxLogin.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            comboBoxLogin.DropDownHeight = 174;
            comboBoxLogin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBoxLogin.DropDownWidth = 121;
            comboBoxLogin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            comboBoxLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            comboBoxLogin.ForeColor = System.Drawing.Color.FromArgb(222, 0, 0, 0);
            comboBoxLogin.FormattingEnabled = true;
            comboBoxLogin.IntegralHeight = false;
            comboBoxLogin.ItemHeight = 43;
            comboBoxLogin.Items.AddRange(new object[] { "sa" });
            comboBoxLogin.Location = new System.Drawing.Point(195, 286);
            comboBoxLogin.Margin = new System.Windows.Forms.Padding(1);
            comboBoxLogin.MaxDropDownItems = 4;
            comboBoxLogin.MouseState = MaterialSkin.MouseState.OUT;
            comboBoxLogin.Name = "comboBoxLogin";
            comboBoxLogin.Size = new System.Drawing.Size(565, 49);
            comboBoxLogin.StartIndex = 0;
            comboBoxLogin.TabIndex = 8;
            // 
            // buttonConnect
            // 
            buttonConnect.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            buttonConnect.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            buttonConnect.Depth = 0;
            buttonConnect.DialogResult = System.Windows.Forms.DialogResult.OK;
            buttonConnect.HighEmphasis = true;
            buttonConnect.Icon = null;
            buttonConnect.Location = new System.Drawing.Point(13, 474);
            buttonConnect.Margin = new System.Windows.Forms.Padding(1);
            buttonConnect.MouseState = MaterialSkin.MouseState.HOVER;
            buttonConnect.Name = "buttonConnect";
            buttonConnect.NoAccentTextColor = System.Drawing.Color.Empty;
            buttonConnect.Size = new System.Drawing.Size(144, 36);
            buttonConnect.TabIndex = 10;
            buttonConnect.Text = "&Подключится";
            buttonConnect.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            buttonConnect.UseAccentColor = false;
            buttonConnect.UseVisualStyleBackColor = true;
            buttonConnect.Click += buttonConnect_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            buttonCancel.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            buttonCancel.Depth = 0;
            buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            buttonCancel.HighEmphasis = true;
            buttonCancel.Icon = null;
            buttonCancel.Location = new System.Drawing.Point(159, 474);
            buttonCancel.Margin = new System.Windows.Forms.Padding(1);
            buttonCancel.MouseState = MaterialSkin.MouseState.HOVER;
            buttonCancel.Name = "buttonCancel";
            buttonCancel.NoAccentTextColor = System.Drawing.Color.Empty;
            buttonCancel.Size = new System.Drawing.Size(82, 36);
            buttonCancel.TabIndex = 11;
            buttonCancel.Text = "Отмена";
            buttonCancel.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            buttonCancel.UseAccentColor = false;
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // buttonHelp
            // 
            buttonHelp.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            buttonHelp.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            buttonHelp.Depth = 0;
            buttonHelp.HighEmphasis = true;
            buttonHelp.Icon = null;
            buttonHelp.Location = new System.Drawing.Point(243, 474);
            buttonHelp.Margin = new System.Windows.Forms.Padding(1);
            buttonHelp.MouseState = MaterialSkin.MouseState.HOVER;
            buttonHelp.Name = "buttonHelp";
            buttonHelp.NoAccentTextColor = System.Drawing.Color.Empty;
            buttonHelp.Size = new System.Drawing.Size(98, 36);
            buttonHelp.TabIndex = 12;
            buttonHelp.Text = "&Помощь";
            buttonHelp.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            buttonHelp.UseAccentColor = false;
            buttonHelp.UseVisualStyleBackColor = true;
            // 
            // buttonOptions
            // 
            buttonOptions.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            buttonOptions.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            buttonOptions.Depth = 0;
            buttonOptions.HighEmphasis = true;
            buttonOptions.Icon = null;
            buttonOptions.Location = new System.Drawing.Point(343, 474);
            buttonOptions.Margin = new System.Windows.Forms.Padding(1);
            buttonOptions.MouseState = MaterialSkin.MouseState.HOVER;
            buttonOptions.Name = "buttonOptions";
            buttonOptions.NoAccentTextColor = System.Drawing.Color.Empty;
            buttonOptions.Size = new System.Drawing.Size(139, 36);
            buttonOptions.TabIndex = 13;
            buttonOptions.Text = "&Настройки >>";
            buttonOptions.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            buttonOptions.UseAccentColor = false;
            buttonOptions.UseVisualStyleBackColor = true;
            // 
            // checkBoxRememberPassword
            // 
            checkBoxRememberPassword.AutoSize = true;
            checkBoxRememberPassword.Depth = 0;
            checkBoxRememberPassword.Location = new System.Drawing.Point(13, 424);
            checkBoxRememberPassword.Margin = new System.Windows.Forms.Padding(0);
            checkBoxRememberPassword.MouseLocation = new System.Drawing.Point(-1, -1);
            checkBoxRememberPassword.MouseState = MaterialSkin.MouseState.HOVER;
            checkBoxRememberPassword.Name = "checkBoxRememberPassword";
            checkBoxRememberPassword.ReadOnly = false;
            checkBoxRememberPassword.Ripple = true;
            checkBoxRememberPassword.Size = new System.Drawing.Size(177, 37);
            checkBoxRememberPassword.TabIndex = 14;
            checkBoxRememberPassword.Text = "Запомнить пароль";
            checkBoxRememberPassword.UseVisualStyleBackColor = true;
            // 
            // comboBoxAuthentication
            // 
            comboBoxAuthentication.AutoResize = false;
            comboBoxAuthentication.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            comboBoxAuthentication.Depth = 0;
            comboBoxAuthentication.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            comboBoxAuthentication.DropDownHeight = 174;
            comboBoxAuthentication.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBoxAuthentication.DropDownWidth = 121;
            comboBoxAuthentication.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            comboBoxAuthentication.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            comboBoxAuthentication.ForeColor = System.Drawing.Color.FromArgb(222, 0, 0, 0);
            comboBoxAuthentication.FormattingEnabled = true;
            comboBoxAuthentication.IntegralHeight = false;
            comboBoxAuthentication.ItemHeight = 43;
            comboBoxAuthentication.Location = new System.Drawing.Point(176, 206);
            comboBoxAuthentication.Margin = new System.Windows.Forms.Padding(1);
            comboBoxAuthentication.MaxDropDownItems = 4;
            comboBoxAuthentication.MouseState = MaterialSkin.MouseState.OUT;
            comboBoxAuthentication.Name = "comboBoxAuthentication";
            comboBoxAuthentication.Size = new System.Drawing.Size(584, 49);
            comboBoxAuthentication.StartIndex = 0;
            comboBoxAuthentication.TabIndex = 7;
            comboBoxAuthentication.SelectedIndexChanged += comboBoxAuthentication_SelectedIndexChanged;
            // 
            // labelServerType
            // 
            labelServerType.AutoSize = true;
            labelServerType.Depth = 0;
            labelServerType.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            labelServerType.Location = new System.Drawing.Point(13, 94);
            labelServerType.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            labelServerType.MouseState = MaterialSkin.MouseState.HOVER;
            labelServerType.Name = "labelServerType";
            labelServerType.Size = new System.Drawing.Size(97, 19);
            labelServerType.TabIndex = 17;
            labelServerType.Text = "Тип сервера:";
            // 
            // comboBoxServerType
            // 
            comboBoxServerType.AutoResize = false;
            comboBoxServerType.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            comboBoxServerType.Depth = 0;
            comboBoxServerType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            comboBoxServerType.DropDownHeight = 174;
            comboBoxServerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBoxServerType.DropDownWidth = 121;
            comboBoxServerType.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            comboBoxServerType.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            comboBoxServerType.ForeColor = System.Drawing.Color.FromArgb(222, 0, 0, 0);
            comboBoxServerType.FormattingEnabled = true;
            comboBoxServerType.IntegralHeight = false;
            comboBoxServerType.ItemHeight = 43;
            comboBoxServerType.Location = new System.Drawing.Point(176, 80);
            comboBoxServerType.Margin = new System.Windows.Forms.Padding(1);
            comboBoxServerType.MaxDropDownItems = 4;
            comboBoxServerType.MouseState = MaterialSkin.MouseState.OUT;
            comboBoxServerType.Name = "comboBoxServerType";
            comboBoxServerType.Size = new System.Drawing.Size(584, 49);
            comboBoxServerType.StartIndex = 0;
            comboBoxServerType.TabIndex = 18;
            // 
            // textBoxPassword
            // 
            textBoxPassword.AnimateReadOnly = false;
            textBoxPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            textBoxPassword.Depth = 0;
            textBoxPassword.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            textBoxPassword.LeadingIcon = null;
            textBoxPassword.Location = new System.Drawing.Point(195, 347);
            textBoxPassword.Margin = new System.Windows.Forms.Padding(1);
            textBoxPassword.MaxLength = 50;
            textBoxPassword.MouseState = MaterialSkin.MouseState.OUT;
            textBoxPassword.Multiline = false;
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Password = true;
            textBoxPassword.Size = new System.Drawing.Size(565, 50);
            textBoxPassword.TabIndex = 9;
            textBoxPassword.Text = "";
            textBoxPassword.TrailingIcon = null;
            // 
            // FormConnectToSQLServer
            // 
            AcceptButton = buttonConnect;
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = buttonCancel;
            ClientSize = new System.Drawing.Size(814, 667);
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
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            Margin = new System.Windows.Forms.Padding(1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormConnectToSQLServer";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Вход в систему";
            Load += FormConnectToSQLServer_Load;
            Resize += FormConnectToSQLServer_Resize;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MaterialSkin.Controls.MaterialTextBox textBoxPassword;
        private MaterialSkin.Controls.MaterialLabel labelServerType;
        private MaterialSkin.Controls.MaterialLabel labelServerName;
        private MaterialSkin.Controls.MaterialLabel labelAuthentication;
        private MaterialSkin.Controls.MaterialLabel labelLogin;
        private MaterialSkin.Controls.MaterialLabel labelPassword;
        private MaterialSkin.Controls.MaterialComboBox comboBoxServerName;
        private MaterialSkin.Controls.MaterialComboBox comboBoxLogin;
        private MaterialSkin.Controls.MaterialButton buttonConnect;
        private MaterialSkin.Controls.MaterialButton buttonCancel;
        private MaterialSkin.Controls.MaterialButton buttonHelp;
        private MaterialSkin.Controls.MaterialButton buttonOptions;
        private MaterialSkin.Controls.MaterialCheckbox checkBoxRememberPassword;
        private MaterialSkin.Controls.MaterialComboBox comboBoxAuthentication;
        private MaterialSkin.Controls.MaterialComboBox comboBoxServerType;

    }
}