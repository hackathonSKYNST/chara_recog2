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

        // 保存を行ったかどうかを管理するフラグ変数
        // 保存不要：0
        // 保存前　：1
        // 保存後　：2
        int save_flag = 0;






        /*================================================*/
        //30行目


        //●コンストラクタ
        public Form1()
        {//35行目
            InitializeComponent();

            this.textBox_result.ReadOnly = true;//文字認識処理結果のテキストボックスは編集不可

            button_start.Enabled = false;//初期状態では、解析ボタンを不可にする

            button_output.Enabled = false;
            出力OToolStripMenuItem.Enabled = false;//初期状態では、保存ボタンを不可にする

            button_readout.Enabled = false;//初期状態では、読み上げボタンを不可にする

            radioButton_all.Enabled = false;
            radioButton_eng.Enabled = false;
            radioButton_jpn.Enabled = false;//初期状態では、各ラジオボタンを不可にする
















        }//66行目

        //●フォームを閉じる場合の処理
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {//70行目
            DialogResult result;
            // 保存をしたかどうかを判定する
            if (save_flag == 1)
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
        }//100行目


        //================ ↓以下、各UIのイベント↓ ================

        //●『カメラ起動』ボタン：クリックイベント
        private void button_webcam_Click(object sender, EventArgs e)
        {
            //ウェブカメラフォームを起動する
            webcam_open();








        }//118行目

        //●『参照』ボタン：クリックイベント
        private void button_brows_Click(object sender, EventArgs e)
        {
            //参照フォームを起動する
            brows_open();








        }//133行目     

        //●『画像表示』ボタン：クリックイベント
        private void button_show_Click(object sender, EventArgs e)
        {
            // 入力されたパスの画像をピクチャボックスに表示する
            if (!(image_show()))
            {
                return;//画像の読み込みに失敗した場合、このイベントを終了する
            }





        }//148行目

        //●『出力』ボタン：クリックイベント
        private void button_output_Click(object sender, EventArgs e)
        {
            //保存フォームを開く
            save();








        }//163行目

        //●『解析』ボタン：クリックイベント
        private void button_start_Click(object sender, EventArgs e)
        {
            //文字認識処理を開始する
            chara_recog_start(image);








        }//178行目


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

        }


        /*================ 以下、自作のメソッド ================*/

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

            //ラジオボタンを使用可能にする
            radioButton_all.Enabled = true;
            radioButton_eng.Enabled = true;
            radioButton_jpn.Enabled = true;
            //『全て』ラジオボタンにチェックマークを付ける
            radioButton_all.Checked = true;

            //解析ボタンを押下可能にする;
            button_start.Enabled = true;

            //出力ボタン・読み上げボタンを押下不可にする
            button_output.Enabled = false;
            出力OToolStripMenuItem.Enabled = false;
            button_readout.Enabled = false;

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

            //ラジオボタンを使用可能にする
            radioButton_all.Enabled = true;
            radioButton_eng.Enabled = true;
            radioButton_jpn.Enabled = true;
            //『全て』ラジオボタンにチェックマークを付ける
            radioButton_all.Checked = true;

            //解析ボタンを押下可能にする;
            button_start.Enabled = true;

            //出力ボタン・読み上げボタンを押下不可にする
            button_output.Enabled = false;
            出力OToolStripMenuItem.Enabled = false;
            button_readout.Enabled = false;
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

            //出力ボタンを押下可能にする
            button_output.Enabled = true;
            出力OToolStripMenuItem.Enabled = true;
            //読み上げボタンを押下可能にする
            button_readout.Enabled = true;

            //保存フラグを1（保存前）にする
            save_flag = 1;
        }//311行

        //●文字認識処理
        //・引数  Bitmap img ：文字認識処理対象の画像を指定する
        //        string lang：文字認識処理を行う言語を指定する
        //・戻り値：文字認識処理結果
        private string chara_recog(Bitmap img, string lang)
        {
            //文字認識結果を格納する変数
            string str;

            // OCRを行うオブジェクトの生成
            //  言語データの場所と言語名を引数で指定する
            var tesseract = new Tesseract.TesseractEngine(
                @"..\..\..\tessdata", // 言語ファイルを「C:\tessdata」に置いた場合
                lang);         // 英語なら"eng" 「○○.traineddata」の○○の部分

            // OCRの実行と表示
            var page = tesseract.Process(img);
            str = page.GetText();

            //文字認識結果を返す
            return str;
        }//311行


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

                // 保存フラグを2（保存後）にする
                save_flag = 2;
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
    }
}
