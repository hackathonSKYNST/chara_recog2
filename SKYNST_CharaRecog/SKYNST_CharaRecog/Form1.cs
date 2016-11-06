using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SKYNST_CharaRecog
{
    public partial class Form1 : Form
    {
        /*================ グローバル変数 ================*/
        //15行目

        public static Bitmap image = null;// 読み込んだ画像を格納する変数

        // 現在の処理状態を管理するフラグ変数
        // 画像表示後（保存不要）：0
        // 解析後　　　（保存前）：1
        // 保存後　　　（保存後）：2
        int nowdo_flag = 0;
























        /*================================================*/
        //50行目


        //●コンストラクタ
        public Form1()
        {//55行目
            InitializeComponent();

            this.textBox_result.ReadOnly = true;//文字認識処理結果のテキストボックスは編集不可

            button_start.Enabled = false;//初期状態では、解析ボタンを不可にする

            button_output.Enabled = false;
            出力OToolStripMenuItem.Enabled = false;//初期状態では、保存ボタンを不可にする

            button_readout.Enabled = false;//初期状態では、読み上げボタンを不可にする

            radioButton_all.Enabled = false;
            radioButton_eng.Enabled = false;
            radioButton_jpn.Enabled = false;//初期状態では、各ラジオボタンを不可にする
















        }//86行目

        //●フォームを閉じる場合の処理
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result;
            // 保存をしたかどうかを判定する
            if (nowdo_flag == 1)
            {
                // →保存前ならば、ポップアップで保存確認
                result = MessageBox.Show("出力を保存しますか？", "確認", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    // →OKならば、保存フォームを開く
                    save();
                    // 終了メッセージボックスを出す
                    if (quit() == false) e.Cancel = true;//キャンセルならば、終了しない
                }
                else if (result == DialogResult.No)
                {
                    // NOならば、終了メッセージボックスを出す
                    if (quit() == false) e.Cancel = true;//キャンセルならば、終了しない
                }
                else
                {
                    // →キャンセルならば、終了しない
                    e.Cancel = true;
                }
            }
            else
            {
                // →保存後（あるいは保存不要）ならば、終了メッセージボックスを出す
                if (quit() == false) e.Cancel = true;//キャンセルならば、終了しない
            }
        }//120行目

        //●ドラッグアンドドロップの処理―――――――――――――――――
        private void textBox_pass_DragEnter(object sender, DragEventArgs e)
        {
            //ファイルがドラッグされている場合、カーソルを変更する。
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // ドラッグ中のファイルやディレクトリの取得
                string[] drags = (string[])e.Data.GetData(DataFormats.FileDrop);

                foreach (string d in drags)
                {
                    if (!System.IO.File.Exists(d))
                    {
                        // ファイル以外であればイベント・ハンドラを抜ける
                        return;
                    }
                }
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void textBox_pass_DragDrop(object sender, DragEventArgs e)
        {
            //ドロップされたファイルの一覧を取得
            string[] fileName = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if (fileName.Length <= 0)
            {
                return;
            }
            if (System.IO.File.Exists(fileName[0]) == true)
            {
                //ドロップ先がTextBoxであるかチェック
                TextBox txtTarget = sender as TextBox;
                if (txtTarget == null)
                {
                    return;
                }
                //TextBoxの内容をファイル名に変更
                txtTarget.Text = fileName[0];
                if (image_show() == false)
                {//画像以外のファイルをD&Dした場合、表記を元に戻す
                    textBox_pass.Text = "C:\\....";
                    return;
                }
            }
        }
        
        private void Form1_DragEnter(object sender, DragEventArgs e)//D&Dを行うためのイベント（DragDropと同時使用）
        {

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // ドラッグ中のファイルやディレクトリの取得
                string[] drags = (string[])e.Data.GetData(DataFormats.FileDrop);

                foreach (string d in drags)
                {
                    if (!System.IO.File.Exists(d))
                    {
                        // ファイル以外であればイベント・ハンドラを抜ける
                        return;
                    }
                }
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)//D&Dを行うためのイベント（DragEnterと同時使用）
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (System.IO.File.Exists(files[0]) == true)
            {

                //D&Dしてきたファイル名をテキストボックスに表示

                textBox_pass.Text = files[0];

                if (image_show() == false)
                {//画像以外のファイルをD&Dした場合、表記を元に戻す
                    textBox_pass.Text = "C:\\....";
                    return;
                }
            }
        }
        //――――――――――――――――――――――――――――――――
        //207行目

        /*================ ↓点字処理のイベント↓ ================*/






















































        















        

























        














































































































































































































































































































    /*================ ↓以下、各UIのイベント↓ ================*/

        //611行

        //●『カメラ起動』ボタン：クリックイベント
        private void button_webcam_Click(object sender, EventArgs e)
        {
            //ウェブカメラフォームを起動する
            webcam_open();








        }//626行目

        //●『参照』ボタン：クリックイベント
        private void button_brows_Click(object sender, EventArgs e)
        {
            //参照フォームを起動する
            brows_open();








        }//641行目     

        //●『画像表示』ボタン：クリックイベント
        private void button_show_Click(object sender, EventArgs e)
        {
            // 入力されたパスの画像をピクチャボックスに表示する
            if (!(image_show()))
            {
                return;//画像の読み込みに失敗した場合、このイベントを終了する
            }





        }//656行目

        //●『出力』ボタン：クリックイベント
        private void button_output_Click(object sender, EventArgs e)
        {
            //保存フォームを開く
            save();








        }//671行目

        //●『解析』ボタン：クリックイベント
        private void button_start_Click(object sender, EventArgs e)
        {
            //文字認識処理を開始する
            chara_recog_start(image);








        }//686行目


        /*================ ↓メニューバーのイベント↓ ================*/

        private void フォルダから参照BToolStripMenuItem_Click(object sender, EventArgs e)
        {
            brows_open();
        }

        private void カメラ起動CToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webcam_open();
        }

        private void 出力OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            save();
        }

        private void 閉じるToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void トリミングTToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 戻るToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 進むToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void バージョン情報ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            version_info();
        }


        /*================ 以下、自作のメソッド ================*/

        //734行

        //●入力されたパスの画像をピクチャボックスに表示するメソッド
        //・戻り値 true ：画像の読み込みに成功
        //         false：画像の読み込みに失敗
        private bool image_show()
        {
            try
            {
                image = new Bitmap(textBox_pass.Text);// 画像をビットマップ型で読み込み
                pictureBox.Image = image;// 画像をピクチャボックスに表示
            }
            //↓読み込めなかった場合の処理↓
            catch (System.ArgumentException)
            {
                // エラーのメッセージボックスを表示する
                MessageBox.Show("入力が無効です。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            //各UIのEnabale状態を変更
            nowdo_flag = 0;
            enable_change();

            return true;
        }

        //●ウェブカメラフォームを起動するメソッド
        private void webcam_open()
        {
            Form2 fo2 = new Form2();//インスタンス生成
            //Form2オープン、Form1は操作不能にする
            if (fo2.ShowDialog(this) == DialogResult.OK) { }
            else { /*オープンエラー処理が必要ならば書く*/ }

            fo2.Dispose();//リソースを開放

            if (image != null)//imageに画像が入力されていたら画像表示
            {
                pictureBox.Image = image;
            }

            //各UIのEnabale状態を変更
            nowdo_flag = 0;
            enable_change();
        }

        //●参照フォームを起動するメソッド
        private void brows_open()
        {
            //参照フォームを開く
            DialogResult dr = openFileDialog1.ShowDialog();

            //OKボタンを押下された場合
            if (dr == DialogResult.OK)
            {
                //ディレクトリパスを入力するフォームに参照したパスを入力する
                textBox_pass.Text = openFileDialog1.FileName;
            }
            else if (dr == DialogResult.Cancel)
            {
                //キャンセルが押されたらfalseを返して終了する
                return;
            }

            //画像をピクチャボックスに表示する
            if (!(image_show()))
            {
                //画像の読み込みに失敗したら終了する
                return;
            }
        }

        //●文字認識を行うメソッド
        //・引数    Bitmap img：文字認識処理対象の画像を指定する
        private void chara_recog_start(Bitmap img)
        {
            //処理中であることをテキストボックスに表示する
            textBox_result.Text = "解析中...";
            this.Refresh();

            //『English』のチェックボックスがチェックされているかの判定
            if (radioButton_eng.Checked)
            {
                // Englishにチェックが入っている
                // →engの言語データで文字認識処理を行う
                textBox_result.Text = chara_recog(img, "eng");
            }
            else
            {
                // Englishにチェックが入っていない
                // →jpnの言語データで文字認識処理を行う
                textBox_result.Text = chara_recog(img, "jpn");
            }

            //処理が完了したことを知らせるメッセージボックスを表示
            MessageBox.Show("解析が終了しました！", "解析終了", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //各UIのEnabale状態を変更
            nowdo_flag = 1;
            enable_change();
        }

        //●文字認識処理
        //・引数  Bitmap img ：文字認識処理対象の画像を指定する
        //        string lang：文字認識処理を行う言語を指定する
        //・戻り値：文字認識処理結果
        private string chara_recog(Bitmap img, string lang)
        {
            //文字認識結果を格納する変数
            string str = "";

            // OCRを行うオブジェクトの生成
            //  言語データの場所と言語名を引数で指定する
            var tesseract = new Tesseract.TesseractEngine(
                @"..\..\..\tessdata", // 言語ファイルを「C:\tessdata」に置いた場合
                lang);         // 英語なら"eng" 「○○.traineddata」の○○の部分

            try
            {   
                // OCRの実行と表示
                var page = tesseract.Process(img);
                str = page.GetText();
            }
            catch(Exception e)
            {
                MessageBox.Show("例外が発生しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //文字認識結果を返す
            return str;
        }
        
        //●ファイル出力（保存）を行うメソッド
        private void save()
        {
            //ここから出力ダイアログボックスの設定//
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = "新しいファイル.txt";
            sfd.InitialDirectory = @"C:\";
            sfd.Filter = "テキストファイル(*.txt;)|*.txt;*|すべてのファイル(*.*)|*.*";
            sfd.FilterIndex = 2;
            sfd.Title = "保存先のファイルを選択してください";
            sfd.RestoreDirectory = true;
            sfd.OverwritePrompt = true;
            sfd.CheckPathExists = true;
            //ここまで出力ダイアログボックスの設定//

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
                System.IO.StreamWriter writer = new System.IO.StreamWriter(@sfd.FileName, false, sjisEnc);
                writer.WriteLine(textBox_result.Text);//ここにtesseractから送られてきた文字をぶち込む//
                writer.Close();

                // 処理フラグを2（保存後）にする
                nowdo_flag = 2;
            }
        }

        // ●終了確認を行うメソッド
        private bool quit()
        {
            // ポップアップで終了確認
            DialogResult result = MessageBox.Show("終了しますか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result == DialogResult.Cancel)
            {
                return false;
            }
            return true;
        }

        // ●各UIのEnable操作を行うメソッド
        private void enable_change()
        {
            // 0：読上、保存ボタンのみEnable=false
            // 1：全てEnable=true
            // 2：状態２のまま
            switch (nowdo_flag)
            {
                case 0://画像表示後
                    radioButton_all.Enabled = true;
                    radioButton_eng.Enabled = true;
                    radioButton_jpn.Enabled = true;//各ラジオボタンを可にする
                    radioButton_all.Checked = true;//『全て』ラジオボタンのみチェックを付ける

                    button_start.Enabled = true;//『解析』ボタンを可にする

                    button_readout.Enabled = false;//『読み上げ』ボタンを不可にする
                    button_output.Enabled = false;//『保存』ボタンを不可にする

                    textBox_result.Text = "";//リザルトのテキストをリセットする
                    break;
                case 1://解析後
                    button_readout.Enabled = true;//『読み上げ』ボタンを不可にする
                    button_output.Enabled = true;//『保存』ボタンを不可にする
                    break;
                case 2:
                    break;
            }
        }

        // ●バージョン情報を表示するメソッド
        private void version_info()
        {
            MessageBox.Show("文字認識システム\nVersion1.0\nSKYNST (System Knowledge Young geNeration Student Team)", "バージョン情報", MessageBoxButtons.OK);
        }

        // ●読み上げを行うメソッド
        private void button_readout_Click(object sender, EventArgs e)
        {
            if (System.Diagnostics.Process.GetProcessesByName("BouyomiChan").Length <= 0)//棒読みちゃん起動していなければ起動
            {
                System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo();
                psi.FileName = @"..\..\..\packages\BouyomiChan_0_1_11_0_Beta16\BouyomiChan.exe";
                psi.WindowStyle = System.Diagnostics.ProcessWindowStyle.Minimized;
                System.Diagnostics.Process p = System.Diagnostics.Process.Start(psi);
                System.Threading.Thread.Sleep(5000);
            }
            System.Diagnostics.ProcessStartInfo qsi = new System.Diagnostics.ProcessStartInfo();
            qsi.FileName = @"..\..\..\packages\BouyomiChan_0_1_11_0_Beta16\RemoteTalk\RemoteTalk.exe";
            qsi.Arguments = String.Format("/T {0}", textBox_result.Text);
            qsi.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            System.Diagnostics.Process q = System.Diagnostics.Process.Start(qsi);
        }
















































        



































































































































































































        //1200行目
    }
}