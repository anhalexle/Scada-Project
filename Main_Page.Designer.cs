
namespace Building_OPC_UA
{
    partial class OPC_UA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OPC_UA));
            this.pbStart = new System.Windows.Forms.PictureBox();
            this.START = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pbStop = new System.Windows.Forms.PictureBox();
            this.pbTank = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pbMotor_1 = new System.Windows.Forms.PictureBox();
            this.pbMotor_2 = new System.Windows.Forms.PictureBox();
            this.pbMotor_3 = new System.Windows.Forms.PictureBox();
            this.pbSenHi = new System.Windows.Forms.PictureBox();
            this.pbSenLo = new System.Windows.Forms.PictureBox();
            this.UpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.lbWaterLevel = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.Read_Data = new System.Windows.Forms.Timer(this.components);
            this.btnDelete = new System.Windows.Forms.Button();
            this.pbLevel = new Building_OPC_UA.VerticalBarProgress();
            ((System.ComponentModel.ISupportInitialize)(this.pbStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMotor_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMotor_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMotor_3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSenHi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSenLo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // pbStart
            // 
            this.pbStart.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbStart.BackgroundImage")));
            this.pbStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbStart.Location = new System.Drawing.Point(96, 12);
            this.pbStart.Name = "pbStart";
            this.pbStart.Size = new System.Drawing.Size(71, 67);
            this.pbStart.TabIndex = 0;
            this.pbStart.TabStop = false;
            this.pbStart.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbStart_MouseDown);
            this.pbStart.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbStart_MouseUp);
            // 
            // START
            // 
            this.START.AutoSize = true;
            this.START.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.START.Location = new System.Drawing.Point(2, 27);
            this.START.Name = "START";
            this.START.Size = new System.Drawing.Size(93, 29);
            this.START.TabIndex = 1;
            this.START.Text = "START";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "STOP";
            // 
            // pbStop
            // 
            this.pbStop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbStop.BackgroundImage")));
            this.pbStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbStop.Location = new System.Drawing.Point(96, 105);
            this.pbStop.Name = "pbStop";
            this.pbStop.Size = new System.Drawing.Size(71, 67);
            this.pbStop.TabIndex = 2;
            this.pbStop.TabStop = false;
            this.pbStop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbStop_MouseDown);
            this.pbStop.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbStop_MouseUp);
            // 
            // pbTank
            // 
            this.pbTank.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbTank.BackgroundImage")));
            this.pbTank.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbTank.Location = new System.Drawing.Point(437, 27);
            this.pbTank.Name = "pbTank";
            this.pbTank.Size = new System.Drawing.Size(168, 420);
            this.pbTank.TabIndex = 4;
            this.pbTank.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(350, 108);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 23);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // pbMotor_1
            // 
            this.pbMotor_1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbMotor_1.BackgroundImage")));
            this.pbMotor_1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbMotor_1.Location = new System.Drawing.Point(256, 74);
            this.pbMotor_1.Name = "pbMotor_1";
            this.pbMotor_1.Size = new System.Drawing.Size(100, 98);
            this.pbMotor_1.TabIndex = 9;
            this.pbMotor_1.TabStop = false;
            this.pbMotor_1.Click += new System.EventHandler(this.pbMotor_1_Click);
            // 
            // pbMotor_2
            // 
            this.pbMotor_2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbMotor_2.BackgroundImage")));
            this.pbMotor_2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbMotor_2.Location = new System.Drawing.Point(256, 309);
            this.pbMotor_2.Name = "pbMotor_2";
            this.pbMotor_2.Size = new System.Drawing.Size(100, 98);
            this.pbMotor_2.TabIndex = 10;
            this.pbMotor_2.TabStop = false;
            this.pbMotor_2.Click += new System.EventHandler(this.pbMotor_2_Click);
            // 
            // pbMotor_3
            // 
            this.pbMotor_3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbMotor_3.BackgroundImage")));
            this.pbMotor_3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbMotor_3.Location = new System.Drawing.Point(728, 313);
            this.pbMotor_3.Name = "pbMotor_3";
            this.pbMotor_3.Size = new System.Drawing.Size(100, 114);
            this.pbMotor_3.TabIndex = 11;
            this.pbMotor_3.TabStop = false;
            this.pbMotor_3.Click += new System.EventHandler(this.pbMotor_3_Click);
            // 
            // pbSenHi
            // 
            this.pbSenHi.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbSenHi.BackgroundImage")));
            this.pbSenHi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbSenHi.Location = new System.Drawing.Point(602, 27);
            this.pbSenHi.Name = "pbSenHi";
            this.pbSenHi.Size = new System.Drawing.Size(100, 78);
            this.pbSenHi.TabIndex = 12;
            this.pbSenHi.TabStop = false;
            // 
            // pbSenLo
            // 
            this.pbSenLo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbSenLo.BackgroundImage")));
            this.pbSenLo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbSenLo.Location = new System.Drawing.Point(605, 369);
            this.pbSenLo.Name = "pbSenLo";
            this.pbSenLo.Size = new System.Drawing.Size(100, 78);
            this.pbSenLo.TabIndex = 13;
            this.pbSenLo.TabStop = false;
            // 
            // UpdateTimer
            // 
            this.UpdateTimer.Interval = 250;
            this.UpdateTimer.Tick += new System.EventHandler(this.UpdateTimer_Tick);
            // 
            // lbWaterLevel
            // 
            this.lbWaterLevel.AutoSize = true;
            this.lbWaterLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbWaterLevel.Location = new System.Drawing.Point(451, 460);
            this.lbWaterLevel.Name = "lbWaterLevel";
            this.lbWaterLevel.Size = new System.Drawing.Size(147, 29);
            this.lbWaterLevel.TabIndex = 14;
            this.lbWaterLevel.Text = "Water_Level";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(350, 343);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(100, 23);
            this.pictureBox2.TabIndex = 15;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.BackgroundImage")));
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Location = new System.Drawing.Point(602, 313);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(129, 23);
            this.pictureBox3.TabIndex = 16;
            this.pictureBox3.TabStop = false;
            // 
            // Read_Data
            // 
            this.Read_Data.Interval = 5000;
            this.Read_Data.Tick += new System.EventHandler(this.Read_Data_Tick);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(13, 231);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 45);
            this.btnDelete.TabIndex = 17;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // pbLevel
            // 
            this.pbLevel.Location = new System.Drawing.Point(456, 93);
            this.pbLevel.Name = "pbLevel";
            this.pbLevel.Size = new System.Drawing.Size(127, 290);
            this.pbLevel.TabIndex = 5;
            // 
            // OPC_UA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1345, 553);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.lbWaterLevel);
            this.Controls.Add(this.pbMotor_3);
            this.Controls.Add(this.pbMotor_2);
            this.Controls.Add(this.pbMotor_1);
            this.Controls.Add(this.pbLevel);
            this.Controls.Add(this.pbTank);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbStop);
            this.Controls.Add(this.START);
            this.Controls.Add(this.pbStart);
            this.Controls.Add(this.pbSenHi);
            this.Controls.Add(this.pbSenLo);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox3);
            this.Name = "OPC_UA";
            this.Text = "OPC_UA";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OPC_UA_FormClosing);
            this.Load += new System.EventHandler(this.OPC_UA_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMotor_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMotor_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMotor_3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSenHi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSenLo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbStart;
        private System.Windows.Forms.Label START;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbStop;
        private System.Windows.Forms.PictureBox pbTank;
        private VerticalBarProgress pbLevel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pbMotor_1;
        private System.Windows.Forms.PictureBox pbMotor_2;
        private System.Windows.Forms.PictureBox pbMotor_3;
        private System.Windows.Forms.PictureBox pbSenHi;
        private System.Windows.Forms.PictureBox pbSenLo;
        private System.Windows.Forms.Timer UpdateTimer;
        private System.Windows.Forms.Label lbWaterLevel;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Timer Read_Data;
        private System.Windows.Forms.Button btnDelete;
    }
}

