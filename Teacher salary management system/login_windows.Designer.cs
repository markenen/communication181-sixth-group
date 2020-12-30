namespace Teacher_salay_mangement_system
{
    partial class login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(login));
            this.login_ip = new System.Windows.Forms.Label();
            this.login_user_name = new System.Windows.Forms.Label();
            this.login_password = new System.Windows.Forms.Label();
            this.login_header = new System.Windows.Forms.Label();
            this.login_ip_input = new System.Windows.Forms.TextBox();
            this.login_user_input = new System.Windows.Forms.TextBox();
            this.login_passward_input = new System.Windows.Forms.TextBox();
            this.login_ip_ping = new System.Windows.Forms.Button();
            this.login_confirm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // login_ip
            // 
            resources.ApplyResources(this.login_ip, "login_ip");
            this.login_ip.Name = "login_ip";
            // 
            // login_user_name
            // 
            resources.ApplyResources(this.login_user_name, "login_user_name");
            this.login_user_name.Name = "login_user_name";
            // 
            // login_password
            // 
            resources.ApplyResources(this.login_password, "login_password");
            this.login_password.Name = "login_password";
            // 
            // login_header
            // 
            resources.ApplyResources(this.login_header, "login_header");
            this.login_header.Name = "login_header";
            // 
            // login_ip_input
            // 
            this.login_ip_input.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.login_ip_input, "login_ip_input");
            this.login_ip_input.Name = "login_ip_input";
            // 
            // login_user_input
            // 
            resources.ApplyResources(this.login_user_input, "login_user_input");
            this.login_user_input.Name = "login_user_input";
            this.login_user_input.ShortcutsEnabled = false;
            // 
            // login_passward_input
            // 
            resources.ApplyResources(this.login_passward_input, "login_passward_input");
            this.login_passward_input.Name = "login_passward_input";
            this.login_passward_input.UseSystemPasswordChar = true;
            // 
            // login_ip_ping
            // 
            this.login_ip_ping.BackColor = System.Drawing.SystemColors.ButtonFace;
            resources.ApplyResources(this.login_ip_ping, "login_ip_ping");
            this.login_ip_ping.Name = "login_ip_ping";
            this.login_ip_ping.TabStop = false;
            this.login_ip_ping.UseVisualStyleBackColor = false;
            this.login_ip_ping.Click += new System.EventHandler(this.login_ip_ping_Click);
            // 
            // login_confirm
            // 
            resources.ApplyResources(this.login_confirm, "login_confirm");
            this.login_confirm.Name = "login_confirm";
            this.login_confirm.UseVisualStyleBackColor = true;
            this.login_confirm.Click += new System.EventHandler(this.login_confirm_Click);
            // 
            // login
            // 
            this.AcceptButton = this.login_confirm;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.login_confirm);
            this.Controls.Add(this.login_ip_ping);
            this.Controls.Add(this.login_passward_input);
            this.Controls.Add(this.login_user_input);
            this.Controls.Add(this.login_ip_input);
            this.Controls.Add(this.login_header);
            this.Controls.Add(this.login_password);
            this.Controls.Add(this.login_user_name);
            this.Controls.Add(this.login_ip);
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "login";
            this.Opacity = 0.9D;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label login_ip;
        private System.Windows.Forms.Label login_user_name;
        private System.Windows.Forms.Label login_password;
        private System.Windows.Forms.Label login_header;
        private System.Windows.Forms.TextBox login_ip_input;
        private System.Windows.Forms.TextBox login_user_input;
        private System.Windows.Forms.TextBox login_passward_input;
        private System.Windows.Forms.Button login_ip_ping;
        private System.Windows.Forms.Button login_confirm;
    }

}