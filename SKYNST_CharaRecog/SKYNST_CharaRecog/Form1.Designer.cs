﻿namespace SKYNST_CharaRecog
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.button_start = new System.Windows.Forms.Button();
            this.button_output = new System.Windows.Forms.Button();
            this.button_webcam = new System.Windows.Forms.Button();
            this.button_brows = new System.Windows.Forms.Button();
            this.textBox_pass = new System.Windows.Forms.TextBox();
            this.textBox_result = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.checkBox_eng = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ファイルFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.フォルダから参照BToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.カメラ起動CToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.出力OToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.閉じるToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.編集ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.トリミングTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.バージョン情報ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button_show = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.戻るToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.進むToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox.Location = new System.Drawing.Point(12, 128);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(360, 268);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 9;
            this.pictureBox.TabStop = false;
            // 
            // button_start
            // 
            this.button_start.Location = new System.Drawing.Point(297, 402);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(75, 23);
            this.button_start.TabIndex = 5;
            this.button_start.Text = "解析";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // button_output
            // 
            this.button_output.Location = new System.Drawing.Point(297, 495);
            this.button_output.Name = "button_output";
            this.button_output.Size = new System.Drawing.Size(75, 23);
            this.button_output.TabIndex = 6;
            this.button_output.Text = "保存";
            this.button_output.UseVisualStyleBackColor = true;
            this.button_output.Click += new System.EventHandler(this.button_output_Click);
            // 
            // button_webcam
            // 
            this.button_webcam.Location = new System.Drawing.Point(297, 28);
            this.button_webcam.Name = "button_webcam";
            this.button_webcam.Size = new System.Drawing.Size(75, 23);
            this.button_webcam.TabIndex = 7;
            this.button_webcam.Text = "カメラフォーム起動";
            this.button_webcam.UseVisualStyleBackColor = true;
            this.button_webcam.Click += new System.EventHandler(this.button_webcam_Click);
            // 
            // button_brows
            // 
            this.button_brows.Location = new System.Drawing.Point(297, 57);
            this.button_brows.Name = "button_brows";
            this.button_brows.Size = new System.Drawing.Size(75, 23);
            this.button_brows.TabIndex = 8;
            this.button_brows.Text = "参照";
            this.button_brows.UseVisualStyleBackColor = true;
            this.button_brows.Click += new System.EventHandler(this.button_brows_Click);
            // 
            // textBox_pass
            // 
            this.textBox_pass.Location = new System.Drawing.Point(12, 59);
            this.textBox_pass.Name = "textBox_pass";
            this.textBox_pass.Size = new System.Drawing.Size(266, 19);
            this.textBox_pass.TabIndex = 3;
            this.textBox_pass.Text = "C:\\.....";
            // 
            // textBox_result
            // 
            this.textBox_result.Location = new System.Drawing.Point(12, 443);
            this.textBox_result.Multiline = true;
            this.textBox_result.Name = "textBox_result";
            this.textBox_result.Size = new System.Drawing.Size(266, 75);
            this.textBox_result.TabIndex = 4;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // checkBox_eng
            // 
            this.checkBox_eng.AutoSize = true;
            this.checkBox_eng.Location = new System.Drawing.Point(230, 409);
            this.checkBox_eng.Name = "checkBox_eng";
            this.checkBox_eng.Size = new System.Drawing.Size(61, 16);
            this.checkBox_eng.TabIndex = 11;
            this.checkBox_eng.Text = "English";
            this.checkBox_eng.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ファイルFToolStripMenuItem,
            this.編集ToolStripMenuItem,
            this.HelpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(384, 26);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ファイルFToolStripMenuItem
            // 
            this.ファイルFToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.フォルダから参照BToolStripMenuItem,
            this.カメラ起動CToolStripMenuItem,
            this.出力OToolStripMenuItem,
            this.toolStripMenuItem2,
            this.閉じるToolStripMenuItem});
            this.ファイルFToolStripMenuItem.Name = "ファイルFToolStripMenuItem";
            this.ファイルFToolStripMenuItem.Size = new System.Drawing.Size(85, 22);
            this.ファイルFToolStripMenuItem.Text = "ファイル(&F)";
            // 
            // フォルダから参照BToolStripMenuItem
            // 
            this.フォルダから参照BToolStripMenuItem.Name = "フォルダから参照BToolStripMenuItem";
            this.フォルダから参照BToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.フォルダから参照BToolStripMenuItem.Text = "フォルダから参照(&B)...";
            this.フォルダから参照BToolStripMenuItem.Click += new System.EventHandler(this.フォルダから参照BToolStripMenuItem_Click);
            // 
            // カメラ起動CToolStripMenuItem
            // 
            this.カメラ起動CToolStripMenuItem.Name = "カメラ起動CToolStripMenuItem";
            this.カメラ起動CToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.カメラ起動CToolStripMenuItem.Text = "カメラ起動(&C)...";
            this.カメラ起動CToolStripMenuItem.Click += new System.EventHandler(this.カメラ起動CToolStripMenuItem_Click);
            // 
            // 出力OToolStripMenuItem
            // 
            this.出力OToolStripMenuItem.Name = "出力OToolStripMenuItem";
            this.出力OToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.出力OToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.出力OToolStripMenuItem.Text = "保存(&S)...";
            this.出力OToolStripMenuItem.Click += new System.EventHandler(this.出力OToolStripMenuItem_Click);
            // 
            // 閉じるToolStripMenuItem
            // 
            this.閉じるToolStripMenuItem.Name = "閉じるToolStripMenuItem";
            this.閉じるToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.閉じるToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.閉じるToolStripMenuItem.Text = "終了(&X)";
            this.閉じるToolStripMenuItem.Click += new System.EventHandler(this.閉じるToolStripMenuItem_Click);
            // 
            // 編集ToolStripMenuItem
            // 
            this.編集ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.トリミングTToolStripMenuItem,
            this.戻るToolStripMenuItem,
            this.進むToolStripMenuItem});
            this.編集ToolStripMenuItem.Name = "編集ToolStripMenuItem";
            this.編集ToolStripMenuItem.Size = new System.Drawing.Size(61, 22);
            this.編集ToolStripMenuItem.Text = "編集(&E)";
            // 
            // トリミングTToolStripMenuItem
            // 
            this.トリミングTToolStripMenuItem.Name = "トリミングTToolStripMenuItem";
            this.トリミングTToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.トリミングTToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.トリミングTToolStripMenuItem.Text = "トリミング(&T)...";
            this.トリミングTToolStripMenuItem.Click += new System.EventHandler(this.トリミングTToolStripMenuItem_Click);
            // 
            // HelpToolStripMenuItem
            // 
            this.HelpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.バージョン情報ToolStripMenuItem});
            this.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
            this.HelpToolStripMenuItem.Size = new System.Drawing.Size(75, 22);
            this.HelpToolStripMenuItem.Text = "ヘルプ(&H)";
            // 
            // バージョン情報ToolStripMenuItem
            // 
            this.バージョン情報ToolStripMenuItem.Name = "バージョン情報ToolStripMenuItem";
            this.バージョン情報ToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.バージョン情報ToolStripMenuItem.Text = "バージョン情報(&V)...";
            this.バージョン情報ToolStripMenuItem.Click += new System.EventHandler(this.バージョン情報ToolStripMenuItem_Click);
            // 
            // button_show
            // 
            this.button_show.Location = new System.Drawing.Point(297, 86);
            this.button_show.Name = "button_show";
            this.button_show.Size = new System.Drawing.Size(75, 23);
            this.button_show.TabIndex = 8;
            this.button_show.Text = "画像表示";
            this.button_show.UseVisualStyleBackColor = true;
            this.button_show.Click += new System.EventHandler(this.button_show_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "プレビュー";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(199, 6);
            // 
            // 戻るToolStripMenuItem
            // 
            this.戻るToolStripMenuItem.Name = "戻るToolStripMenuItem";
            this.戻るToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.戻るToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.戻るToolStripMenuItem.Text = "元に戻す(&U)";
            this.戻るToolStripMenuItem.Click += new System.EventHandler(this.戻るToolStripMenuItem_Click);
            // 
            // 進むToolStripMenuItem
            // 
            this.進むToolStripMenuItem.Name = "進むToolStripMenuItem";
            this.進むToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.進むToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.進むToolStripMenuItem.Text = "やり直し(&R)";
            this.進むToolStripMenuItem.Click += new System.EventHandler(this.進むToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 524);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox_eng);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.button_start);
            this.Controls.Add(this.button_output);
            this.Controls.Add(this.button_webcam);
            this.Controls.Add(this.button_show);
            this.Controls.Add(this.button_brows);
            this.Controls.Add(this.textBox_pass);
            this.Controls.Add(this.textBox_result);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form1";
            this.Text = "文字認識システム";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.Button button_output;
        private System.Windows.Forms.Button button_webcam;
        private System.Windows.Forms.Button button_brows;
        private System.Windows.Forms.TextBox textBox_pass;
        private System.Windows.Forms.TextBox textBox_result;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.CheckBox checkBox_eng;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem HelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem バージョン情報ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ファイルFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 編集ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem フォルダから参照BToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem カメラ起動CToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 出力OToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 閉じるToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem トリミングTToolStripMenuItem;
        private System.Windows.Forms.Button button_show;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem 戻るToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 進むToolStripMenuItem;

    }
}

