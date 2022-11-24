
namespace Device_test
{
    partial class Active
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
            this.btn_relay1 = new System.Windows.Forms.Button();
            this.btn_relay2 = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_scanner = new System.Windows.Forms.TextBox();
            this.btn_relay4 = new System.Windows.Forms.Button();
            this.btn_relay3 = new System.Windows.Forms.Button();
            this.door1_open = new System.Windows.Forms.Button();
            this.door1_close = new System.Windows.Forms.Button();
            this.door2_close = new System.Windows.Forms.Button();
            this.door2_open = new System.Windows.Forms.Button();
            this.btn_power2_off = new System.Windows.Forms.Button();
            this.btn_power2_on = new System.Windows.Forms.Button();
            this.btn_power1_off = new System.Windows.Forms.Button();
            this.btn_power1_on = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_relay1
            // 
            this.btn_relay1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_relay1.Font = new System.Drawing.Font("굴림", 14F);
            this.btn_relay1.Location = new System.Drawing.Point(16, 122);
            this.btn_relay1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_relay1.Name = "btn_relay1";
            this.btn_relay1.Size = new System.Drawing.Size(130, 130);
            this.btn_relay1.TabIndex = 0;
            this.btn_relay1.Text = "1번문열림";
            this.btn_relay1.UseVisualStyleBackColor = false;
            this.btn_relay1.Click += new System.EventHandler(this.btn_relay1_Click);
            // 
            // btn_relay2
            // 
            this.btn_relay2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_relay2.Font = new System.Drawing.Font("굴림", 14F);
            this.btn_relay2.Location = new System.Drawing.Point(154, 122);
            this.btn_relay2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_relay2.Name = "btn_relay2";
            this.btn_relay2.Size = new System.Drawing.Size(130, 130);
            this.btn_relay2.TabIndex = 1;
            this.btn_relay2.Text = "1번문닫힘";
            this.btn_relay2.UseVisualStyleBackColor = false;
            this.btn_relay2.Click += new System.EventHandler(this.btn_relay2_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.Location = new System.Drawing.Point(38, 838);
            this.btn_exit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(509, 90);
            this.btn_exit.TabIndex = 4;
            this.btn_exit.Text = "프로그램 종료";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 20F);
            this.label1.Location = new System.Drawing.Point(242, 601);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 27);
            this.label1.TabIndex = 5;
            this.label1.Text = "스캐너";
            // 
            // tb_scanner
            // 
            this.tb_scanner.BackColor = System.Drawing.Color.White;
            this.tb_scanner.Font = new System.Drawing.Font("굴림", 20F);
            this.tb_scanner.Location = new System.Drawing.Point(38, 644);
            this.tb_scanner.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_scanner.Multiline = true;
            this.tb_scanner.Name = "tb_scanner";
            this.tb_scanner.ReadOnly = true;
            this.tb_scanner.Size = new System.Drawing.Size(509, 153);
            this.tb_scanner.TabIndex = 6;
            this.tb_scanner.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_relay4
            // 
            this.btn_relay4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_relay4.Font = new System.Drawing.Font("굴림", 14F);
            this.btn_relay4.Location = new System.Drawing.Point(440, 122);
            this.btn_relay4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_relay4.Name = "btn_relay4";
            this.btn_relay4.Size = new System.Drawing.Size(130, 130);
            this.btn_relay4.TabIndex = 8;
            this.btn_relay4.Text = "2번문닫힘";
            this.btn_relay4.UseVisualStyleBackColor = false;
            this.btn_relay4.Click += new System.EventHandler(this.btn_relay4_Click);
            // 
            // btn_relay3
            // 
            this.btn_relay3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_relay3.Font = new System.Drawing.Font("굴림", 14F);
            this.btn_relay3.Location = new System.Drawing.Point(303, 122);
            this.btn_relay3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_relay3.Name = "btn_relay3";
            this.btn_relay3.Size = new System.Drawing.Size(130, 130);
            this.btn_relay3.TabIndex = 7;
            this.btn_relay3.Text = "2번문열림";
            this.btn_relay3.UseVisualStyleBackColor = false;
            this.btn_relay3.Click += new System.EventHandler(this.btn_relay3_Click);
            // 
            // door1_open
            // 
            this.door1_open.BackColor = System.Drawing.Color.Lime;
            this.door1_open.Enabled = false;
            this.door1_open.Font = new System.Drawing.Font("굴림", 14F);
            this.door1_open.Location = new System.Drawing.Point(16, 263);
            this.door1_open.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.door1_open.Name = "door1_open";
            this.door1_open.Size = new System.Drawing.Size(130, 130);
            this.door1_open.TabIndex = 9;
            this.door1_open.Text = "OPEN";
            this.door1_open.UseVisualStyleBackColor = false;
            // 
            // door1_close
            // 
            this.door1_close.BackColor = System.Drawing.Color.Red;
            this.door1_close.Enabled = false;
            this.door1_close.Font = new System.Drawing.Font("굴림", 14F);
            this.door1_close.Location = new System.Drawing.Point(154, 263);
            this.door1_close.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.door1_close.Name = "door1_close";
            this.door1_close.Size = new System.Drawing.Size(130, 130);
            this.door1_close.TabIndex = 10;
            this.door1_close.Text = "CLOSE";
            this.door1_close.UseVisualStyleBackColor = false;
            // 
            // door2_close
            // 
            this.door2_close.BackColor = System.Drawing.Color.Red;
            this.door2_close.Enabled = false;
            this.door2_close.Font = new System.Drawing.Font("굴림", 14F);
            this.door2_close.Location = new System.Drawing.Point(440, 263);
            this.door2_close.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.door2_close.Name = "door2_close";
            this.door2_close.Size = new System.Drawing.Size(130, 130);
            this.door2_close.TabIndex = 12;
            this.door2_close.Text = "CLOSE";
            this.door2_close.UseVisualStyleBackColor = false;
            // 
            // door2_open
            // 
            this.door2_open.BackColor = System.Drawing.Color.Lime;
            this.door2_open.Enabled = false;
            this.door2_open.Font = new System.Drawing.Font("굴림", 14F);
            this.door2_open.Location = new System.Drawing.Point(303, 263);
            this.door2_open.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.door2_open.Name = "door2_open";
            this.door2_open.Size = new System.Drawing.Size(130, 130);
            this.door2_open.TabIndex = 11;
            this.door2_open.Text = "OPEN";
            this.door2_open.UseVisualStyleBackColor = false;
            // 
            // btn_power2_off
            // 
            this.btn_power2_off.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btn_power2_off.Font = new System.Drawing.Font("굴림", 14F);
            this.btn_power2_off.Location = new System.Drawing.Point(440, 410);
            this.btn_power2_off.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_power2_off.Name = "btn_power2_off";
            this.btn_power2_off.Size = new System.Drawing.Size(130, 130);
            this.btn_power2_off.TabIndex = 16;
            this.btn_power2_off.Text = "2번전원OFF";
            this.btn_power2_off.UseVisualStyleBackColor = false;
            this.btn_power2_off.Click += new System.EventHandler(this.btn_power2_off_Click);
            // 
            // btn_power2_on
            // 
            this.btn_power2_on.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btn_power2_on.Font = new System.Drawing.Font("굴림", 14F);
            this.btn_power2_on.Location = new System.Drawing.Point(303, 410);
            this.btn_power2_on.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_power2_on.Name = "btn_power2_on";
            this.btn_power2_on.Size = new System.Drawing.Size(130, 130);
            this.btn_power2_on.TabIndex = 15;
            this.btn_power2_on.Text = "2번전원ON";
            this.btn_power2_on.UseVisualStyleBackColor = false;
            this.btn_power2_on.Click += new System.EventHandler(this.btn_power2_on_Click);
            // 
            // btn_power1_off
            // 
            this.btn_power1_off.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btn_power1_off.Font = new System.Drawing.Font("굴림", 14F);
            this.btn_power1_off.Location = new System.Drawing.Point(154, 410);
            this.btn_power1_off.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_power1_off.Name = "btn_power1_off";
            this.btn_power1_off.Size = new System.Drawing.Size(130, 130);
            this.btn_power1_off.TabIndex = 14;
            this.btn_power1_off.Text = "1번전원OFF";
            this.btn_power1_off.UseVisualStyleBackColor = false;
            this.btn_power1_off.Click += new System.EventHandler(this.btn_power1_off_Click);
            // 
            // btn_power1_on
            // 
            this.btn_power1_on.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btn_power1_on.Font = new System.Drawing.Font("굴림", 14F);
            this.btn_power1_on.Location = new System.Drawing.Point(16, 410);
            this.btn_power1_on.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_power1_on.Name = "btn_power1_on";
            this.btn_power1_on.Size = new System.Drawing.Size(130, 130);
            this.btn_power1_on.TabIndex = 13;
            this.btn_power1_on.Text = "1번전원ON";
            this.btn_power1_on.UseVisualStyleBackColor = false;
            this.btn_power1_on.Click += new System.EventHandler(this.btn_power1_on_Click);
            // 
            // Active
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 985);
            this.Controls.Add(this.btn_power2_off);
            this.Controls.Add(this.btn_power2_on);
            this.Controls.Add(this.btn_power1_off);
            this.Controls.Add(this.btn_power1_on);
            this.Controls.Add(this.door2_close);
            this.Controls.Add(this.door2_open);
            this.Controls.Add(this.door1_close);
            this.Controls.Add(this.door1_open);
            this.Controls.Add(this.btn_relay4);
            this.Controls.Add(this.btn_relay3);
            this.Controls.Add(this.tb_scanner);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.btn_relay2);
            this.Controls.Add(this.btn_relay1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Active";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Active";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_relay1;
        private System.Windows.Forms.Button btn_relay2;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_scanner;
        private System.Windows.Forms.Button btn_relay4;
        private System.Windows.Forms.Button btn_relay3;
        private System.Windows.Forms.Button door1_open;
        private System.Windows.Forms.Button door1_close;
        private System.Windows.Forms.Button door2_close;
        private System.Windows.Forms.Button door2_open;
        private System.Windows.Forms.Button btn_power2_off;
        private System.Windows.Forms.Button btn_power2_on;
        private System.Windows.Forms.Button btn_power1_off;
        private System.Windows.Forms.Button btn_power1_on;
    }
}