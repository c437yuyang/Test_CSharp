namespace _26_socketClient
{
    partial class FormClient
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
            this.tb_msg = new System.Windows.Forms.TextBox();
            this.btn_sendMsg = new System.Windows.Forms.Button();
            this.tb_log = new System.Windows.Forms.TextBox();
            this.tb_port = new System.Windows.Forms.TextBox();
            this.tb_Ip = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btn_sendFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tb_msg
            // 
            this.tb_msg.Location = new System.Drawing.Point(12, 244);
            this.tb_msg.Name = "tb_msg";
            this.tb_msg.Size = new System.Drawing.Size(245, 21);
            this.tb_msg.TabIndex = 10;
            // 
            // btn_sendMsg
            // 
            this.btn_sendMsg.Location = new System.Drawing.Point(277, 244);
            this.btn_sendMsg.Name = "btn_sendMsg";
            this.btn_sendMsg.Size = new System.Drawing.Size(75, 23);
            this.btn_sendMsg.TabIndex = 9;
            this.btn_sendMsg.Text = "发送消息";
            this.btn_sendMsg.UseVisualStyleBackColor = true;
            this.btn_sendMsg.Click += new System.EventHandler(this.btn_sendMsg_Click);
            // 
            // tb_log
            // 
            this.tb_log.Location = new System.Drawing.Point(12, 61);
            this.tb_log.Multiline = true;
            this.tb_log.Name = "tb_log";
            this.tb_log.Size = new System.Drawing.Size(340, 161);
            this.tb_log.TabIndex = 8;
            // 
            // tb_port
            // 
            this.tb_port.Location = new System.Drawing.Point(157, 14);
            this.tb_port.Name = "tb_port";
            this.tb_port.Size = new System.Drawing.Size(100, 21);
            this.tb_port.TabIndex = 6;
            this.tb_port.Text = "50000";
            // 
            // tb_Ip
            // 
            this.tb_Ip.Location = new System.Drawing.Point(12, 15);
            this.tb_Ip.Name = "tb_Ip";
            this.tb_Ip.Size = new System.Drawing.Size(100, 21);
            this.tb_Ip.TabIndex = 7;
            this.tb_Ip.Text = "127.0.0.1";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(277, 15);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 5;
            this.btnStart.Text = "连接";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btn_sendFile
            // 
            this.btn_sendFile.Location = new System.Drawing.Point(277, 287);
            this.btn_sendFile.Name = "btn_sendFile";
            this.btn_sendFile.Size = new System.Drawing.Size(75, 23);
            this.btn_sendFile.TabIndex = 11;
            this.btn_sendFile.Text = "发送文件";
            this.btn_sendFile.UseVisualStyleBackColor = true;
            this.btn_sendFile.Click += new System.EventHandler(this.btn_sendFile_Click);
            // 
            // FormClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 322);
            this.Controls.Add(this.btn_sendFile);
            this.Controls.Add(this.tb_msg);
            this.Controls.Add(this.btn_sendMsg);
            this.Controls.Add(this.tb_log);
            this.Controls.Add(this.tb_port);
            this.Controls.Add(this.tb_Ip);
            this.Controls.Add(this.btnStart);
            this.Name = "FormClient";
            this.Text = "Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_msg;
        private System.Windows.Forms.Button btn_sendMsg;
        private System.Windows.Forms.TextBox tb_log;
        private System.Windows.Forms.TextBox tb_port;
        private System.Windows.Forms.TextBox tb_Ip;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btn_sendFile;
    }
}

