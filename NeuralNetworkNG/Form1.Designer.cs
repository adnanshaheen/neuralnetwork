namespace NeuralNetworkNG
{
    partial class Form1
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
            this.btnTest = new System.Windows.Forms.Button();
            this.btnTrain = new System.Windows.Forms.Button();
            this.btnLoadMNIST = new System.Windows.Forms.Button();
            this.btnTestMNIST = new System.Windows.Forms.Button();
            this.btnLoadPCA = new System.Windows.Forms.Button();
            this.btnTestPCA = new System.Windows.Forms.Button();
            this.groupbox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.groupbox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(113, 27);
            this.btnTest.Margin = new System.Windows.Forms.Padding(2);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(98, 23);
            this.btnTest.TabIndex = 0;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnTrain
            // 
            this.btnTrain.Location = new System.Drawing.Point(11, 27);
            this.btnTrain.Margin = new System.Windows.Forms.Padding(2);
            this.btnTrain.Name = "btnTrain";
            this.btnTrain.Size = new System.Drawing.Size(98, 23);
            this.btnTrain.TabIndex = 1;
            this.btnTrain.Text = "Train";
            this.btnTrain.UseVisualStyleBackColor = true;
            this.btnTrain.Click += new System.EventHandler(this.btnTrain_Click);
            // 
            // btnLoadMNIST
            // 
            this.btnLoadMNIST.Location = new System.Drawing.Point(232, 27);
            this.btnLoadMNIST.Name = "btnLoadMNIST";
            this.btnLoadMNIST.Size = new System.Drawing.Size(98, 23);
            this.btnLoadMNIST.TabIndex = 2;
            this.btnLoadMNIST.Text = "LoadMNIST";
            this.btnLoadMNIST.UseVisualStyleBackColor = true;
            this.btnLoadMNIST.Click += new System.EventHandler(this.btnLoadMNIST_Click);
            // 
            // btnTestMNIST
            // 
            this.btnTestMNIST.Location = new System.Drawing.Point(333, 27);
            this.btnTestMNIST.Name = "btnTestMNIST";
            this.btnTestMNIST.Size = new System.Drawing.Size(98, 23);
            this.btnTestMNIST.TabIndex = 3;
            this.btnTestMNIST.Text = "Test MNIST";
            this.btnTestMNIST.UseVisualStyleBackColor = true;
            this.btnTestMNIST.Click += new System.EventHandler(this.btnTestMNIST_Click);
            // 
            // btnLoadPCA
            // 
            this.btnLoadPCA.Location = new System.Drawing.Point(446, 27);
            this.btnLoadPCA.Name = "btnLoadPCA";
            this.btnLoadPCA.Size = new System.Drawing.Size(97, 23);
            this.btnLoadPCA.TabIndex = 4;
            this.btnLoadPCA.Text = "Load for PCA";
            this.btnLoadPCA.UseVisualStyleBackColor = true;
            this.btnLoadPCA.Click += new System.EventHandler(this.btnLoadPCA_Click);
            // 
            // btnTestPCA
            // 
            this.btnTestPCA.Location = new System.Drawing.Point(547, 27);
            this.btnTestPCA.Name = "btnTestPCA";
            this.btnTestPCA.Size = new System.Drawing.Size(94, 23);
            this.btnTestPCA.TabIndex = 5;
            this.btnTestPCA.Text = "Test PCA";
            this.btnTestPCA.UseVisualStyleBackColor = true;
            this.btnTestPCA.Click += new System.EventHandler(this.btnTestPCA_Click);
            // 
            // groupbox1
            // 
            this.groupbox1.Controls.Add(this.pictureBox10);
            this.groupbox1.Controls.Add(this.pictureBox5);
            this.groupbox1.Controls.Add(this.pictureBox4);
            this.groupbox1.Controls.Add(this.pictureBox3);
            this.groupbox1.Controls.Add(this.pictureBox2);
            this.groupbox1.Controls.Add(this.pictureBox1);
            this.groupbox1.Location = new System.Drawing.Point(12, 56);
            this.groupbox1.Name = "groupbox1";
            this.groupbox1.Size = new System.Drawing.Size(629, 429);
            this.groupbox1.TabIndex = 6;
            this.groupbox1.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox5.Location = new System.Drawing.Point(199, 221);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(184, 196);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox5.TabIndex = 16;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox4.Location = new System.Drawing.Point(9, 221);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(184, 196);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox4.TabIndex = 15;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Location = new System.Drawing.Point(392, 19);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(184, 196);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox3.TabIndex = 14;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(199, 19);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(184, 196);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(9, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(184, 196);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox10
            // 
            this.pictureBox10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox10.Location = new System.Drawing.Point(392, 221);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(184, 196);
            this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox10.TabIndex = 21;
            this.pictureBox10.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 488);
            this.Controls.Add(this.groupbox1);
            this.Controls.Add(this.btnTestPCA);
            this.Controls.Add(this.btnLoadPCA);
            this.Controls.Add(this.btnTestMNIST);
            this.Controls.Add(this.btnLoadMNIST);
            this.Controls.Add(this.btnTrain);
            this.Controls.Add(this.btnTest);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupbox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnTrain;
        private System.Windows.Forms.Button btnLoadMNIST;
        private System.Windows.Forms.Button btnTestMNIST;
        private System.Windows.Forms.Button btnLoadPCA;
        private System.Windows.Forms.Button btnTestPCA;
        private System.Windows.Forms.GroupBox groupbox1;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox10;
    }
}

