namespace Lens
{
    partial class ObjectEditor
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.CancelButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.checkDrawVertexNormal = new System.Windows.Forms.CheckBox();
            this.checkDrawNormal = new System.Windows.Forms.CheckBox();
            this.checkDrawVertex = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.fullScreen = new System.Windows.Forms.CheckBox();
            this.paramButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.PointTypeBox = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.PointTypeBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Silver;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox1.Location = new System.Drawing.Point(1, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(773, 435);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // CancelButton
            // 
            this.CancelButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.CancelButton.Location = new System.Drawing.Point(6, 333);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(199, 33);
            this.CancelButton.TabIndex = 2;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ConfirmButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConfirmButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ConfirmButton.Location = new System.Drawing.Point(6, 294);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(199, 33);
            this.ConfirmButton.TabIndex = 6;
            this.ConfirmButton.Text = "Confirm";
            this.ConfirmButton.UseVisualStyleBackColor = true;
            this.ConfirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // checkDrawVertexNormal
            // 
            this.checkDrawVertexNormal.AutoSize = true;
            this.checkDrawVertexNormal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.checkDrawVertexNormal.Location = new System.Drawing.Point(6, 106);
            this.checkDrawVertexNormal.Name = "checkDrawVertexNormal";
            this.checkDrawVertexNormal.Size = new System.Drawing.Size(186, 24);
            this.checkDrawVertexNormal.TabIndex = 19;
            this.checkDrawVertexNormal.Text = "Draw Vertex Normals?";
            this.checkDrawVertexNormal.UseVisualStyleBackColor = true;
            this.checkDrawVertexNormal.CheckedChanged += new System.EventHandler(this.checkDrawVertexNormal_CheckedChanged);
            // 
            // checkDrawNormal
            // 
            this.checkDrawNormal.AutoSize = true;
            this.checkDrawNormal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.checkDrawNormal.Location = new System.Drawing.Point(6, 76);
            this.checkDrawNormal.Name = "checkDrawNormal";
            this.checkDrawNormal.Size = new System.Drawing.Size(136, 24);
            this.checkDrawNormal.TabIndex = 18;
            this.checkDrawNormal.Text = "Draw Normals?";
            this.checkDrawNormal.UseVisualStyleBackColor = true;
            this.checkDrawNormal.CheckedChanged += new System.EventHandler(this.checkDrawNormal_CheckedChanged);
            // 
            // checkDrawVertex
            // 
            this.checkDrawVertex.AutoSize = true;
            this.checkDrawVertex.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.checkDrawVertex.Location = new System.Drawing.Point(6, 46);
            this.checkDrawVertex.Name = "checkDrawVertex";
            this.checkDrawVertex.Size = new System.Drawing.Size(124, 24);
            this.checkDrawVertex.TabIndex = 17;
            this.checkDrawVertex.Text = "Draw Vertex?";
            this.checkDrawVertex.UseVisualStyleBackColor = true;
            this.checkDrawVertex.CheckedChanged += new System.EventHandler(this.checkDrawVertex_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CancelButton);
            this.groupBox1.Controls.Add(this.checkDrawVertexNormal);
            this.groupBox1.Controls.Add(this.ConfirmButton);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.fullScreen);
            this.groupBox1.Controls.Add(this.checkDrawNormal);
            this.groupBox1.Controls.Add(this.checkDrawVertex);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBox1.Location = new System.Drawing.Point(13, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(211, 372);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(19, 422);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(186, 24);
            this.checkBox1.TabIndex = 16;
            this.checkBox1.Text = "Draw Vertex Normals?";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // fullScreen
            // 
            this.fullScreen.AutoSize = true;
            this.fullScreen.Location = new System.Drawing.Point(6, 16);
            this.fullScreen.Name = "fullScreen";
            this.fullScreen.Size = new System.Drawing.Size(152, 24);
            this.fullScreen.TabIndex = 4;
            this.fullScreen.Text = "Full Screen Mode";
            this.fullScreen.UseVisualStyleBackColor = true;
            this.fullScreen.CheckedChanged += new System.EventHandler(this.fullScreen_CheckedChanged);
            // 
            // paramButton
            // 
            this.paramButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.paramButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.paramButton.Location = new System.Drawing.Point(13, 12);
            this.paramButton.Name = "paramButton";
            this.paramButton.Size = new System.Drawing.Size(211, 38);
            this.paramButton.TabIndex = 20;
            this.paramButton.Text = "Параметры";
            this.paramButton.UseVisualStyleBackColor = true;
            this.paramButton.Click += new System.EventHandler(this.paramButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(286, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "label1";
            // 
            // PointTypeBox
            // 
            this.PointTypeBox.Controls.Add(this.radioButton2);
            this.PointTypeBox.Controls.Add(this.radioButton1);
            this.PointTypeBox.Location = new System.Drawing.Point(618, 12);
            this.PointTypeBox.Name = "PointTypeBox";
            this.PointTypeBox.Size = new System.Drawing.Size(145, 72);
            this.PointTypeBox.TabIndex = 23;
            this.PointTypeBox.TabStop = false;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.radioButton2.Location = new System.Drawing.Point(6, 43);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(135, 24);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "Radiation Point";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.radioButton1.Location = new System.Drawing.Point(6, 13);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(73, 24);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Vertex";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // ObjectEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(775, 440);
            this.Controls.Add(this.PointTypeBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.paramButton);
            this.Controls.Add(this.pictureBox1);
            this.Name = "ObjectEditor";
            this.Text = "ObjectEditor";
            this.SizeChanged += new System.EventHandler(this.ObjectEditor_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ObjectEditor_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ObjectEditor_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.PointTypeBox.ResumeLayout(false);
            this.PointTypeBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button ConfirmButton;
        private System.Windows.Forms.CheckBox checkDrawVertexNormal;
        private System.Windows.Forms.CheckBox checkDrawNormal;
        private System.Windows.Forms.CheckBox checkDrawVertex;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox fullScreen;
        private System.Windows.Forms.Button paramButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox PointTypeBox;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
    }
}