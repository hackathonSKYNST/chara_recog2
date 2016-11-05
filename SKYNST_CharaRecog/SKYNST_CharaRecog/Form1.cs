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
        /*================ グローバル変数 ================*/　//15行目
        // 読み込んだ画像を格納する変数
        public static Bitmap image = null;







        




        /*================================================*/  //30行目


        //●コンストラクタ
        public Form1()
        {//35行目
            InitializeComponent();

            this.textBox_result.ReadOnly = true;//文字認識処理結果のテキストボックスは編集不可

            button_output.Enabled = false;//初期状態では、出力ボタンを不可にする
            
















            
            






        }//66行目
        
        /*test
         
          
          
         */

        //●『カメラ起動』ボタン：クリックイベント
        private void button_webcam_Click(object sender, EventArgs e)
        {//71行目
            Form2 fo2 = new Form2();//インスタンス生成
            //Form2オープン、Form1は操作不能にする
            if (fo2.ShowDialog(this) == DialogResult.OK) { }
            else { }

            fo2.Dispose();//リソースを開放

            if (image != null)//imageに画像が入力されていたら画像表示
            {
                pictureBox.Image = image;
            }





















            



            






            




              
          
            
        }//123行目


        //●『参照』ボタン：クリックイベント
        private void button_brows_Click(object sender, EventArgs e)
        {//128行目
            DialogResult dr = openFileDialog1.ShowDialog();//参照フォームを開く
            
            //OKボタンを押下された場合
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                textBox_pass.Text = openFileDialog1.FileName;//ディレクトリパスを入力するフォームに参照したパスを入力する
            }

            //画像をピクチャボックスに表示する
            if (!(image_show()))
            {
                return;//画像の読み込みに失敗した場合、このイベントを終了する
            }



































                                    


        }//180行目
        

        //●『画像表示』ボタン：クリックイベント
        private void button_show_Click(object sender, EventArgs e)
        {//185行目
            // 入力されたパスの画像をピクチャボックスに表示する
            if(!(image_show()))
            {
                return;//画像の読み込みに失敗した場合、このイベントを終了する
            }










































            



        }//237行目
        

        //●『出力』ボタン：クリックイベント
        private void button_output_Click(object sender, EventArgs e)
        {//242行目
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
            }





            


























        }//294行目


        //●『解析』ボタン：クリックイベント
        private void button_start_Click(object sender, EventArgs e)
        {//299行目
            //文字認識処理を開始する
            chara_recog_start(image);

            















































        }//350行目


        /*================ メニューバーのイベント ================*/

        private void フォルダから参照BToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void カメラ起動CToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 出力OToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 閉じるToolStripMenuItem_Click(object sender, EventArgs e)
        {

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
            return true;
        }


        //●文字認識を行うメソッド
        //・引数    Bitmap img：文字認識処理対象の画像を指定する
        private void chara_recog_start(Bitmap img)
        {
            //処理中であることをテキストボックスに表示する
            textBox_result.Text = "解析中...";
            this.Refresh();

            //『English』のチェックボックスがチェックされているかの判定
            if (checkBox_eng.Checked)
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
    }
}
