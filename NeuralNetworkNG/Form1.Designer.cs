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
            this.SuspendLayout();
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(56, 67);
            this.btnTest.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(98, 19);
            this.btnTest.TabIndex = 0;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnTrain
            // 
            this.btnTrain.Location = new System.Drawing.Point(56, 28);
            this.btnTrain.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnTrain.Name = "btnTrain";
            this.btnTrain.Size = new System.Drawing.Size(98, 19);
            this.btnTrain.TabIndex = 1;
            this.btnTrain.Text = "Train";
            this.btnTrain.UseVisualStyleBackColor = true;
            this.btnTrain.Click += new System.EventHandler(this.btnTrain_Click);
            // 
            // btnLoadMNIST
            // 
            this.btnLoadMNIST.Location = new System.Drawing.Point(56, 110);
            this.btnLoadMNIST.Name = "btnLoadMNIST";
            this.btnLoadMNIST.Size = new System.Drawing.Size(98, 23);
            this.btnLoadMNIST.TabIndex = 2;
            this.btnLoadMNIST.Text = "LoadMNIST";
            this.btnLoadMNIST.UseVisualStyleBackColor = true;
            this.btnLoadMNIST.Click += new System.EventHandler(this.btnLoadMNIST_Click);
            // 
            // btnTestMNIST
            // 
            this.btnTestMNIST.Location = new System.Drawing.Point(56, 163);
            this.btnTestMNIST.Name = "btnTestMNIST";
            this.btnTestMNIST.Size = new System.Drawing.Size(98, 23);
            this.btnTestMNIST.TabIndex = 3;
            this.btnTestMNIST.Text = "Test MNIST";
            this.btnTestMNIST.UseVisualStyleBackColor = true;
            this.btnTestMNIST.Click += new System.EventHandler(this.btnTestMNIST_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(219, 217);
            this.Controls.Add(this.btnTestMNIST);
            this.Controls.Add(this.btnLoadMNIST);
            this.Controls.Add(this.btnTrain);
            this.Controls.Add(this.btnTest);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnTrain;
        private System.Windows.Forms.Button btnLoadMNIST;
        private System.Windows.Forms.Button btnTestMNIST;
    }
}

