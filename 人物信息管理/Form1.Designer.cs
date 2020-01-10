namespace 人物信息管理
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewPerson = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxAddAge = new System.Windows.Forms.TextBox();
            this.textBoxAddName = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelID = new System.Windows.Forms.Label();
            this.btnUpd = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDel = new System.Windows.Forms.Button();
            this.textBoxAddGender = new System.Windows.Forms.TextBox();
            this.textBoxHeight = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxUpdGender = new System.Windows.Forms.TextBox();
            this.textBoxUpdHeight = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxUpdAge = new System.Windows.Forms.TextBox();
            this.textBoxUpdName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPerson)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewPerson
            // 
            this.dataGridViewPerson.AllowUserToAddRows = false;
            this.dataGridViewPerson.AllowUserToDeleteRows = false;
            this.dataGridViewPerson.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewPerson.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dataGridViewPerson.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPerson.Location = new System.Drawing.Point(12, 167);
            this.dataGridViewPerson.MultiSelect = false;
            this.dataGridViewPerson.Name = "dataGridViewPerson";
            this.dataGridViewPerson.ReadOnly = true;
            this.dataGridViewPerson.RowTemplate.Height = 23;
            this.dataGridViewPerson.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPerson.Size = new System.Drawing.Size(545, 312);
            this.dataGridViewPerson.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxAddGender);
            this.groupBox1.Controls.Add(this.textBoxHeight);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.textBoxAddAge);
            this.groupBox1.Controls.Add(this.textBoxAddName);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(546, 120);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "添加人员";
            // 
            // textBoxAddAge
            // 
            this.textBoxAddAge.Location = new System.Drawing.Point(297, 36);
            this.textBoxAddAge.Name = "textBoxAddAge";
            this.textBoxAddAge.Size = new System.Drawing.Size(100, 21);
            this.textBoxAddAge.TabIndex = 4;
            // 
            // textBoxAddName
            // 
            this.textBoxAddName.Location = new System.Drawing.Point(9, 36);
            this.textBoxAddName.Name = "textBoxAddName";
            this.textBoxAddName.Size = new System.Drawing.Size(100, 21);
            this.textBoxAddName.TabIndex = 3;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(453, 91);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(295, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "年龄";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "名称";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxUpdGender);
            this.groupBox2.Controls.Add(this.textBoxUpdHeight);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.textBoxUpdAge);
            this.groupBox2.Controls.Add(this.textBoxUpdName);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.labelID);
            this.groupBox2.Controls.Add(this.btnUpd);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(11, 485);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(546, 170);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "修改人员";
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.Location = new System.Drawing.Point(8, 36);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(0, 12);
            this.labelID.TabIndex = 7;
            // 
            // btnUpd
            // 
            this.btnUpd.Location = new System.Drawing.Point(453, 141);
            this.btnUpd.Name = "btnUpd";
            this.btnUpd.Size = new System.Drawing.Size(75, 23);
            this.btnUpd.TabIndex = 3;
            this.btnUpd.Text = "修改";
            this.btnUpd.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "ID";
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(465, 661);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 23);
            this.btnDel.TabIndex = 7;
            this.btnDel.Text = "删除";
            this.btnDel.UseVisualStyleBackColor = true;
            // 
            // textBoxAddGender
            // 
            this.textBoxAddGender.Location = new System.Drawing.Point(428, 36);
            this.textBoxAddGender.Name = "textBoxAddGender";
            this.textBoxAddGender.Size = new System.Drawing.Size(100, 21);
            this.textBoxAddGender.TabIndex = 8;
            // 
            // textBoxHeight
            // 
            this.textBoxHeight.Location = new System.Drawing.Point(140, 36);
            this.textBoxHeight.Name = "textBoxHeight";
            this.textBoxHeight.Size = new System.Drawing.Size(100, 21);
            this.textBoxHeight.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(426, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "性别";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(138, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 5;
            this.label7.Text = "身高";
            // 
            // textBoxUpdGender
            // 
            this.textBoxUpdGender.Location = new System.Drawing.Point(428, 83);
            this.textBoxUpdGender.Name = "textBoxUpdGender";
            this.textBoxUpdGender.Size = new System.Drawing.Size(100, 21);
            this.textBoxUpdGender.TabIndex = 16;
            // 
            // textBoxUpdHeight
            // 
            this.textBoxUpdHeight.Location = new System.Drawing.Point(140, 83);
            this.textBoxUpdHeight.Name = "textBoxUpdHeight";
            this.textBoxUpdHeight.Size = new System.Drawing.Size(100, 21);
            this.textBoxUpdHeight.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(426, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "性别";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(138, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "身高";
            // 
            // textBoxUpdAge
            // 
            this.textBoxUpdAge.Location = new System.Drawing.Point(297, 83);
            this.textBoxUpdAge.Name = "textBoxUpdAge";
            this.textBoxUpdAge.Size = new System.Drawing.Size(100, 21);
            this.textBoxUpdAge.TabIndex = 12;
            // 
            // textBoxUpdName
            // 
            this.textBoxUpdName.Location = new System.Drawing.Point(9, 83);
            this.textBoxUpdName.Name = "textBoxUpdName";
            this.textBoxUpdName.Size = new System.Drawing.Size(100, 21);
            this.textBoxUpdName.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(295, 68);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 10;
            this.label8.Text = "年龄";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 68);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 9;
            this.label9.Text = "名称";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 693);
            this.Controls.Add(this.dataGridViewPerson);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnDel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPerson)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewPerson;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxAddAge;
        private System.Windows.Forms.TextBox textBoxAddName;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.Button btnUpd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.TextBox textBoxAddGender;
        private System.Windows.Forms.TextBox textBoxHeight;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxUpdGender;
        private System.Windows.Forms.TextBox textBoxUpdHeight;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxUpdAge;
        private System.Windows.Forms.TextBox textBoxUpdName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}

