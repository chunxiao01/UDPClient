namespace UDPClient
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_local_ip = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_local_port = new System.Windows.Forms.TextBox();
            this.textBox_remote_port = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_remote_ip = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox_multi = new System.Windows.Forms.CheckBox();
            this.textBox_multi_port = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button_connect = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_send = new System.Windows.Forms.TextBox();
            this.button_send = new System.Windows.Forms.Button();
            this.button_receive = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox_receive = new System.Windows.Forms.TextBox();
            this.textBox_multi_ip = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "本地：";
            // 
            // comboBox_local_ip
            // 
            this.comboBox_local_ip.FormattingEnabled = true;
            this.comboBox_local_ip.Location = new System.Drawing.Point(80, 8);
            this.comboBox_local_ip.Name = "comboBox_local_ip";
            this.comboBox_local_ip.Size = new System.Drawing.Size(235, 23);
            this.comboBox_local_ip.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(349, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "端口号：";
            // 
            // textBox_local_port
            // 
            this.textBox_local_port.Location = new System.Drawing.Point(423, 8);
            this.textBox_local_port.Name = "textBox_local_port";
            this.textBox_local_port.Size = new System.Drawing.Size(136, 25);
            this.textBox_local_port.TabIndex = 3;
            this.textBox_local_port.Text = "9000";
            // 
            // textBox_remote_port
            // 
            this.textBox_remote_port.Location = new System.Drawing.Point(423, 56);
            this.textBox_remote_port.Name = "textBox_remote_port";
            this.textBox_remote_port.Size = new System.Drawing.Size(136, 25);
            this.textBox_remote_port.TabIndex = 7;
            this.textBox_remote_port.Text = "9001";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(349, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "端口号：";
            // 
            // comboBox_remote_ip
            // 
            this.comboBox_remote_ip.FormattingEnabled = true;
            this.comboBox_remote_ip.Location = new System.Drawing.Point(81, 56);
            this.comboBox_remote_ip.Name = "comboBox_remote_ip";
            this.comboBox_remote_ip.Size = new System.Drawing.Size(235, 23);
            this.comboBox_remote_ip.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "远端：";
            // 
            // checkBox_multi
            // 
            this.checkBox_multi.AutoSize = true;
            this.checkBox_multi.Location = new System.Drawing.Point(16, 106);
            this.checkBox_multi.Name = "checkBox_multi";
            this.checkBox_multi.Size = new System.Drawing.Size(59, 19);
            this.checkBox_multi.TabIndex = 8;
            this.checkBox_multi.Text = "组播";
            this.checkBox_multi.UseVisualStyleBackColor = true;
            // 
            // textBox_multi_port
            // 
            this.textBox_multi_port.Location = new System.Drawing.Point(423, 100);
            this.textBox_multi_port.Name = "textBox_multi_port";
            this.textBox_multi_port.Size = new System.Drawing.Size(136, 25);
            this.textBox_multi_port.TabIndex = 11;
            this.textBox_multi_port.Text = "9090";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(349, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "端口号：";
            // 
            // button_connect
            // 
            this.button_connect.Location = new System.Drawing.Point(16, 157);
            this.button_connect.Name = "button_connect";
            this.button_connect.Size = new System.Drawing.Size(148, 33);
            this.button_connect.TabIndex = 12;
            this.button_connect.Text = "打开连接";
            this.button_connect.UseVisualStyleBackColor = true;
            this.button_connect.Click += new System.EventHandler(this.button_connect_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_send);
            this.groupBox1.Location = new System.Drawing.Point(16, 210);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(543, 156);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "发送";
            // 
            // textBox_send
            // 
            this.textBox_send.Location = new System.Drawing.Point(7, 25);
            this.textBox_send.Multiline = true;
            this.textBox_send.Name = "textBox_send";
            this.textBox_send.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_send.Size = new System.Drawing.Size(530, 125);
            this.textBox_send.TabIndex = 0;
            // 
            // button_send
            // 
            this.button_send.Location = new System.Drawing.Point(565, 270);
            this.button_send.Name = "button_send";
            this.button_send.Size = new System.Drawing.Size(100, 33);
            this.button_send.TabIndex = 14;
            this.button_send.Text = "发送";
            this.button_send.UseVisualStyleBackColor = true;
            this.button_send.Click += new System.EventHandler(this.button_send_Click);
            // 
            // button_receive
            // 
            this.button_receive.Location = new System.Drawing.Point(565, 443);
            this.button_receive.Name = "button_receive";
            this.button_receive.Size = new System.Drawing.Size(100, 33);
            this.button_receive.TabIndex = 16;
            this.button_receive.Text = "接收";
            this.button_receive.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox_receive);
            this.groupBox2.Location = new System.Drawing.Point(16, 383);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(543, 156);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "接收";
            // 
            // textBox_receive
            // 
            this.textBox_receive.Location = new System.Drawing.Point(7, 25);
            this.textBox_receive.Multiline = true;
            this.textBox_receive.Name = "textBox_receive";
            this.textBox_receive.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_receive.Size = new System.Drawing.Size(530, 125);
            this.textBox_receive.TabIndex = 0;
            // 
            // textBox_multi_ip
            // 
            this.textBox_multi_ip.Location = new System.Drawing.Point(81, 100);
            this.textBox_multi_ip.Name = "textBox_multi_ip";
            this.textBox_multi_ip.Size = new System.Drawing.Size(235, 25);
            this.textBox_multi_ip.TabIndex = 17;
            this.textBox_multi_ip.Text = "234.22.23.24";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 551);
            this.Controls.Add(this.textBox_multi_ip);
            this.Controls.Add(this.button_receive);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button_send);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_connect);
            this.Controls.Add(this.textBox_multi_port);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.checkBox_multi);
            this.Controls.Add(this.textBox_remote_port);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox_remote_ip);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_local_port);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox_local_ip);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_local_ip;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_local_port;
        private System.Windows.Forms.TextBox textBox_remote_port;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_remote_ip;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBox_multi;
        private System.Windows.Forms.TextBox textBox_multi_port;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_connect;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox_send;
        private System.Windows.Forms.Button button_send;
        private System.Windows.Forms.Button button_receive;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox_receive;
        private System.Windows.Forms.TextBox textBox_multi_ip;
    }
}

