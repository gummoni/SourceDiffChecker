namespace SourceDiffChecker
{
    partial class FormMain
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btClose = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btFolderSetting = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btHashCompare = new System.Windows.Forms.Button();
            this.btHashCreate = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btClose);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btFolderSetting);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.btHashCompare);
            this.panel1.Controls.Add(this.btHashCreate);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(717, 73);
            this.panel1.TabIndex = 0;
            // 
            // btClose
            // 
            this.btClose.Location = new System.Drawing.Point(582, 10);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(75, 40);
            this.btClose.TabIndex = 7;
            this.btClose.Text = "終了";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(159, 35);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 19);
            this.textBox2.TabIndex = 6;
            this.textBox2.Text = "*.vb";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "ハッシュ化するファイル拡張子";
            // 
            // btFolderSetting
            // 
            this.btFolderSetting.Location = new System.Drawing.Point(338, 4);
            this.btFolderSetting.Name = "btFolderSetting";
            this.btFolderSetting.Size = new System.Drawing.Size(31, 23);
            this.btFolderSetting.TabIndex = 4;
            this.btFolderSetting.Text = "...";
            this.btFolderSetting.UseVisualStyleBackColor = true;
            this.btFolderSetting.Click += new System.EventHandler(this.btFolderSetting_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "プロジェクトフォルダ";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(109, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(223, 19);
            this.textBox1.TabIndex = 2;
            // 
            // btHashCompare
            // 
            this.btHashCompare.Location = new System.Drawing.Point(490, 10);
            this.btHashCompare.Name = "btHashCompare";
            this.btHashCompare.Size = new System.Drawing.Size(75, 40);
            this.btHashCompare.TabIndex = 1;
            this.btHashCompare.Text = "ハッシュ比較";
            this.btHashCompare.UseVisualStyleBackColor = true;
            this.btHashCompare.Click += new System.EventHandler(this.btHashCompare_Click);
            // 
            // btHashCreate
            // 
            this.btHashCreate.Location = new System.Drawing.Point(399, 10);
            this.btHashCreate.Name = "btHashCreate";
            this.btHashCreate.Size = new System.Drawing.Size(75, 40);
            this.btHashCreate.TabIndex = 0;
            this.btHashCreate.Text = "ハッシュ作成";
            this.btHashCreate.UseVisualStyleBackColor = true;
            this.btHashCreate.Click += new System.EventHandler(this.btHashCreate_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "BuntyuMae.sln";
            this.openFileDialog1.Filter = "slnファイル|*.sln|すべてのファイル|*.*";
            this.openFileDialog1.InitialDirectory = "c:\\";
            this.openFileDialog1.Title = "BuntyuMae.slnを指定してください";
            // 
            // textBox3
            // 
            this.textBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox3.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox3.Location = new System.Drawing.Point(0, 73);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox3.Size = new System.Drawing.Size(717, 478);
            this.textBox3.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 551);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ソース比較ツール";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btFolderSetting;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btHashCompare;
        private System.Windows.Forms.Button btHashCreate;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox3;
    }
}

