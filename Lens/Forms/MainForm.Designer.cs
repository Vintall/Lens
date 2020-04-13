namespace Lens
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.paramButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.transparencyBar = new System.Windows.Forms.TrackBar();
            this.absorptionBar = new System.Windows.Forms.TrackBar();
            this.reflectionBar = new System.Windows.Forms.TrackBar();
            this.checkDrawVertexNormal = new System.Windows.Forms.CheckBox();
            this.checkDrawNormal = new System.Windows.Forms.CheckBox();
            this.checkDrawVertex = new System.Windows.Forms.CheckBox();
            this.checkDrawVerge = new System.Windows.Forms.CheckBox();
            this.checkDrawObj = new System.Windows.Forms.CheckBox();
            this.loadButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.editButton = new System.Windows.Forms.Button();
            this.addObject = new System.Windows.Forms.Button();
            this.fullScreen = new System.Windows.Forms.CheckBox();
            this.DrawRaysButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.transparencyBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.absorptionBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reflectionBar)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(2, -12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(984, 711);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUp);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // paramButton
            // 
            this.paramButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.paramButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.paramButton.Location = new System.Drawing.Point(12, 12);
            this.paramButton.Name = "paramButton";
            this.paramButton.Size = new System.Drawing.Size(211, 38);
            this.paramButton.TabIndex = 1;
            this.paramButton.Text = "Параметры";
            this.paramButton.UseVisualStyleBackColor = true;
            this.paramButton.Click += new System.EventHandler(this.paramButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DrawRaysButton);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.transparencyBar);
            this.groupBox1.Controls.Add(this.absorptionBar);
            this.groupBox1.Controls.Add(this.reflectionBar);
            this.groupBox1.Controls.Add(this.checkDrawVertexNormal);
            this.groupBox1.Controls.Add(this.checkDrawNormal);
            this.groupBox1.Controls.Add(this.checkDrawVertex);
            this.groupBox1.Controls.Add(this.checkDrawVerge);
            this.groupBox1.Controls.Add(this.checkDrawObj);
            this.groupBox1.Controls.Add(this.loadButton);
            this.groupBox1.Controls.Add(this.saveButton);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.editButton);
            this.groupBox1.Controls.Add(this.addObject);
            this.groupBox1.Controls.Add(this.fullScreen);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBox1.Location = new System.Drawing.Point(12, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(211, 654);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(15, 468);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 20;
            this.label2.Text = "label2";
            // 
            // transparencyBar
            // 
            this.transparencyBar.Location = new System.Drawing.Point(6, 420);
            this.transparencyBar.Maximum = 100;
            this.transparencyBar.Name = "transparencyBar";
            this.transparencyBar.Size = new System.Drawing.Size(60, 45);
            this.transparencyBar.TabIndex = 19;
            this.transparencyBar.Value = 1;
            this.transparencyBar.Scroll += new System.EventHandler(this.transparencyBar_Scroll);
            // 
            // absorptionBar
            // 
            this.absorptionBar.Location = new System.Drawing.Point(138, 420);
            this.absorptionBar.Maximum = 100;
            this.absorptionBar.Name = "absorptionBar";
            this.absorptionBar.Size = new System.Drawing.Size(60, 45);
            this.absorptionBar.TabIndex = 18;
            this.absorptionBar.Value = 1;
            this.absorptionBar.Scroll += new System.EventHandler(this.absorptionBar_Scroll);
            // 
            // reflectionBar
            // 
            this.reflectionBar.Location = new System.Drawing.Point(72, 420);
            this.reflectionBar.Maximum = 100;
            this.reflectionBar.Name = "reflectionBar";
            this.reflectionBar.Size = new System.Drawing.Size(60, 45);
            this.reflectionBar.TabIndex = 17;
            this.reflectionBar.Value = 1;
            this.reflectionBar.Scroll += new System.EventHandler(this.reflectionBar_Scroll);
            // 
            // checkDrawVertexNormal
            // 
            this.checkDrawVertexNormal.AutoSize = true;
            this.checkDrawVertexNormal.Location = new System.Drawing.Point(19, 382);
            this.checkDrawVertexNormal.Name = "checkDrawVertexNormal";
            this.checkDrawVertexNormal.Size = new System.Drawing.Size(186, 24);
            this.checkDrawVertexNormal.TabIndex = 16;
            this.checkDrawVertexNormal.Text = "Draw Vertex Normals?";
            this.checkDrawVertexNormal.UseVisualStyleBackColor = true;
            // 
            // checkDrawNormal
            // 
            this.checkDrawNormal.AutoSize = true;
            this.checkDrawNormal.Location = new System.Drawing.Point(19, 363);
            this.checkDrawNormal.Name = "checkDrawNormal";
            this.checkDrawNormal.Size = new System.Drawing.Size(136, 24);
            this.checkDrawNormal.TabIndex = 15;
            this.checkDrawNormal.Text = "Draw Normals?";
            this.checkDrawNormal.UseVisualStyleBackColor = true;
            // 
            // checkDrawVertex
            // 
            this.checkDrawVertex.AutoSize = true;
            this.checkDrawVertex.Location = new System.Drawing.Point(19, 343);
            this.checkDrawVertex.Name = "checkDrawVertex";
            this.checkDrawVertex.Size = new System.Drawing.Size(124, 24);
            this.checkDrawVertex.TabIndex = 14;
            this.checkDrawVertex.Text = "Draw Vertex?";
            this.checkDrawVertex.UseVisualStyleBackColor = true;
            this.checkDrawVertex.CheckedChanged += new System.EventHandler(this.checkDrawVertex_CheckedChanged);
            // 
            // checkDrawVerge
            // 
            this.checkDrawVerge.AutoSize = true;
            this.checkDrawVerge.Location = new System.Drawing.Point(19, 322);
            this.checkDrawVerge.Name = "checkDrawVerge";
            this.checkDrawVerge.Size = new System.Drawing.Size(121, 24);
            this.checkDrawVerge.TabIndex = 13;
            this.checkDrawVerge.Text = "Draw Verge?";
            this.checkDrawVerge.UseVisualStyleBackColor = true;
            this.checkDrawVerge.CheckedChanged += new System.EventHandler(this.checkDrawVerge_CheckedChanged);
            // 
            // checkDrawObj
            // 
            this.checkDrawObj.AutoSize = true;
            this.checkDrawObj.Location = new System.Drawing.Point(19, 302);
            this.checkDrawObj.Name = "checkDrawObj";
            this.checkDrawObj.Size = new System.Drawing.Size(132, 24);
            this.checkDrawObj.TabIndex = 12;
            this.checkDrawObj.Text = "Draw Objects?";
            this.checkDrawObj.UseVisualStyleBackColor = true;
            this.checkDrawObj.CheckedChanged += new System.EventHandler(this.checkDrawObj_CheckedChanged);
            // 
            // loadButton
            // 
            this.loadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loadButton.Location = new System.Drawing.Point(6, 250);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(199, 29);
            this.loadButton.TabIndex = 11;
            this.loadButton.Text = "Load";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.Location = new System.Drawing.Point(6, 215);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(199, 29);
            this.saveButton.TabIndex = 10;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(6, 188);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // editButton
            // 
            this.editButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editButton.Location = new System.Drawing.Point(6, 81);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(199, 29);
            this.editButton.TabIndex = 9;
            this.editButton.Text = "Edit Object";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // addObject
            // 
            this.addObject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addObject.Location = new System.Drawing.Point(6, 46);
            this.addObject.Name = "addObject";
            this.addObject.Size = new System.Drawing.Size(199, 29);
            this.addObject.TabIndex = 7;
            this.addObject.Text = "Add Object";
            this.addObject.UseVisualStyleBackColor = true;
            this.addObject.Click += new System.EventHandler(this.AddObject_Click);
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
            // DrawRaysButton
            // 
            this.DrawRaysButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DrawRaysButton.Location = new System.Drawing.Point(6, 148);
            this.DrawRaysButton.Name = "DrawRaysButton";
            this.DrawRaysButton.Size = new System.Drawing.Size(199, 33);
            this.DrawRaysButton.TabIndex = 21;
            this.DrawRaysButton.Text = "Draw Rays";
            this.DrawRaysButton.UseVisualStyleBackColor = true;
            this.DrawRaysButton.Click += new System.EventHandler(this.DrawRaysButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(984, 711);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.paramButton);
            this.Controls.Add(this.pictureBox1);
            this.Name = "MainForm";
            this.Text = "Rays";
            this.SizeChanged += new System.EventHandler(this.FormSizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.transparencyBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.absorptionBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reflectionBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button paramButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox fullScreen;
        private System.Windows.Forms.Button addObject;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.CheckBox checkDrawVertexNormal;
        private System.Windows.Forms.CheckBox checkDrawNormal;
        private System.Windows.Forms.CheckBox checkDrawVertex;
        private System.Windows.Forms.CheckBox checkDrawVerge;
        private System.Windows.Forms.CheckBox checkDrawObj;
        private System.Windows.Forms.TrackBar absorptionBar;
        private System.Windows.Forms.TrackBar reflectionBar;
        private System.Windows.Forms.TrackBar transparencyBar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button DrawRaysButton;
    }
}

