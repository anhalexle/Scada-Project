
namespace Building_OPC_UA
{
    partial class Motor_Faceplates
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Motor_Faceplates));
            this.cbMode = new System.Windows.Forms.ComboBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.pbRunFeedback = new System.Windows.Forms.PictureBox();
            this.pbFault = new System.Windows.Forms.PictureBox();
            this.UpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.btnReset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbRunFeedback)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFault)).BeginInit();
            this.SuspendLayout();
            // 
            // cbMode
            // 
            this.cbMode.FormattingEnabled = true;
            this.cbMode.Items.AddRange(new object[] {
            "MANUAL",
            "AUTO"});
            this.cbMode.Location = new System.Drawing.Point(101, 23);
            this.cbMode.Name = "cbMode";
            this.cbMode.Size = new System.Drawing.Size(121, 24);
            this.cbMode.TabIndex = 0;
            this.cbMode.Text = "MANUAL";
            this.cbMode.SelectedIndexChanged += new System.EventHandler(this.cbMode_SelectedIndexChanged);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(101, 64);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(121, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "START";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnStart_MouseDown);
            this.btnStart.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnStart_MouseUp);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(101, 106);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(121, 23);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "STOP";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnStop_MouseDown);
            this.btnStop.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnStop_MouseUp);
            // 
            // pbRunFeedback
            // 
            this.pbRunFeedback.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbRunFeedback.BackgroundImage")));
            this.pbRunFeedback.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbRunFeedback.Location = new System.Drawing.Point(67, 205);
            this.pbRunFeedback.Name = "pbRunFeedback";
            this.pbRunFeedback.Size = new System.Drawing.Size(121, 117);
            this.pbRunFeedback.TabIndex = 3;
            this.pbRunFeedback.TabStop = false;
            // 
            // pbFault
            // 
            this.pbFault.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbFault.BackgroundImage")));
            this.pbFault.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbFault.Location = new System.Drawing.Point(194, 247);
            this.pbFault.Name = "pbFault";
            this.pbFault.Size = new System.Drawing.Size(81, 75);
            this.pbFault.TabIndex = 4;
            this.pbFault.TabStop = false;
            // 
            // UpdateTimer
            // 
            this.UpdateTimer.Interval = 250;
            this.UpdateTimer.Tick += new System.EventHandler(this.UpdateTimer_Tick);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(101, 156);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(121, 23);
            this.btnReset.TabIndex = 5;
            this.btnReset.Text = "RESET";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnReset_MouseDown);
            this.btnReset.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnReset_MouseUp);
            // 
            // Motor_Faceplates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 330);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.pbFault);
            this.Controls.Add(this.pbRunFeedback);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.cbMode);
            this.Name = "Motor_Faceplates";
            this.Text = "Motor_Faceplates";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Motor_Faceplates_FormClosing);
            this.Load += new System.EventHandler(this.Motor_Faceplates_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbRunFeedback)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFault)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbMode;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.PictureBox pbRunFeedback;
        private System.Windows.Forms.PictureBox pbFault;
        private System.Windows.Forms.Timer UpdateTimer;
        private System.Windows.Forms.Button btnReset;
    }
}