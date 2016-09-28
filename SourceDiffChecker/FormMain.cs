using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SourceDiffChecker
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            //コンストラクタ
            InitializeComponent();

            var dir1 = Folder.SearchFile(@"c:\Buntyu", "BuntyuMae.sln");
            var dir2 = Folder.SearchFile(@"c:\project\srl\mae", "BuntyuMae.sln");

            if (string.Empty != dir1)
            {
                textBox1.Text = dir1;
                textBox1.BackColor = Color.Lime;
            }
            else if (string.Empty != dir2)
            {
                textBox1.Text = dir2;
                textBox1.BackColor = Color.Lime;
            }
            else
            {
                textBox1.BackColor = Color.Yellow;
            }
        }

        private void btFolderSetting_Click(object sender, EventArgs e)
        {
            //プロジェクトファイルを探すダイアログ表示
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var result = openFileDialog1.FileName;
                textBox1.Text = Path.GetDirectoryName(result);
                textBox1.BackColor = Color.Lime;
            }
        }

        void LogWrite(string message)
        {
            textBox3.Invoke(new Action(() =>
            {
                textBox3.Text += message + "\r\n";
                textBox3.SelectionLength = textBox3.Text.Length;
                textBox3.ScrollToCaret();
            }));
        }

        private async void btHashCreate_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                LogWrite("ハッシュ作成開始");
                //ハッシュリスト作成
                var dir = textBox1.Text;
                var ext = textBox2.Text;
                var collection = HashCollection.Create(dir, ext);
                collection.Save("hashlist.txt");
                LogWrite("ハッシュ作成完了");
            });
        }

        private async void btHashCompare_Click(object sender, EventArgs e)
        {
            //ハッシュリスト比較
            await Task.Run(() =>
            {
                LogWrite("ハッシュ比較開始");
                var dir = textBox1.Text;
                var ext = textBox2.Text;
                var collection1 = HashCollection.Load("hashlist.txt");  //比較先（見本）
                var collection2 = HashCollection.Create(dir, ext);      //比較元
                var errorFileList = new List<string>();

                //比較
                foreach (var model in collection2)
                {
                    if (!collection1.Compare(model))
                    {
                        if (0 > model.Filename.IndexOf(".g.i.vb"))
                        {
                            LogWrite($"不一致: {model.Filename}");
                            errorFileList.Add(model.Fullname);
                        }
                    }
                }

                //結果
                if (0 == errorFileList.Count)
                {
                    LogWrite("完全一致！");
                }
                else
                {
                    //不一致あり
                    var machineName = Environment.MachineName;
                    foreach (var ch in Path.GetInvalidFileNameChars())
                    {
                        machineName = machineName.Replace(ch, '_');
                    }
                    LogWrite($"{errorFileList.Count}件 不一致項目がありました。");
                    LogWrite($"USBメモリ内に[{machineName}_src.zip]ファイルを作成するので、メールで送ってください");
                    Files.Compress(errorFileList.ToArray(), $"{machineName}_src.zip", dir);
                }
            });
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            //閉じる
            Close();
        }
    }


    /// <summary>
    /// フォルダヘルパー
    /// </summary>
    public static class Folder
    {
        /// <summary>
        /// 指定したファイルがどこにあるか探す
        /// </summary>
        /// <param name="startDirectory">検索開始フォルダ</param>
        /// <param name="filename">探すファイル名</param>
        /// <returns>ディレクトリ（見つからない場合はEmptyを返す）</returns>
        public static string SearchFile(string startDirectory, string filename)
        {
            var ext = "*" + Path.GetExtension(filename);
            var files = Directory.GetFiles(startDirectory, ext, SearchOption.AllDirectories);
            foreach (var file in files)
            {
                var dirname = Path.GetDirectoryName(file);
                var fname = Path.GetFileName(file);
                if (filename == fname)
                {
                    return dirname;
                }
            }
            return string.Empty;
        }
    }

    /// <summary>
    /// ファイルヘルパー
    /// </summary>
    public static class Files
    {
        /// <summary>
        /// ファイルらをZIP圧縮
        /// </summary>
        /// <param name="files"></param>
        /// <param name="zipFilename"></param>
        public static void Compress(string[] files, string zipFilename, string offsetPath)
        {
            if (File.Exists(zipFilename))
            {
                File.Delete(zipFilename);
            }
            using (var z = ZipFile.Open(zipFilename, ZipArchiveMode.Create))
            {
                foreach (var file in files)
                {
                    z.CreateEntryFromFile(file, file.Replace(offsetPath, "."), CompressionLevel.Optimal);
                }
            }
        }
    }

    /// <summary>
    /// ファイルハッシュ
    /// </summary>
    public class HashModel
    {
        public string Fullname { get; set; }
        public string Filename { get; set; }
        public string Hash { get; set; }
        public string Update { get; set; }

        /// <summary>
        /// 文字列化
        /// </summary>
        /// <returns></returns>
        public override string ToString() => $"{Filename},{Hash},{Update}";

        /// <summary>
        /// 文字列からモデル生成
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public static HashModel Parse(string line)
        {
            var rows = line.Split(',');
            if (rows.Length == 3)
            {
                return new HashModel { Filename = rows[0], Hash = rows[1], Update = rows[2] };
            }
            return null;
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public HashModel()
        {
        }

        /// <summary>
        /// コンストラクタ
        /// 引数で指定したファイルのハッシュを計算してHash値を代入する
        /// </summary>
        /// <param name="filename"></param>
        public HashModel(string filename, string offsetDir)
        {
            Fullname = filename;
            Filename = filename.Replace(offsetDir, "");
            using (var md5 = MD5.Create())
            using (var stream = File.OpenRead(filename))
            {
                var bytes = md5.ComputeHash(stream);
                Hash = string.Join("", bytes.Select(_=> _.ToString("X2")));
                Update = File.GetLastWriteTime(filename).ToString();
            }
        }
    }

    /// <summary>
    /// ハッシュリスト
    /// </summary>
    public class HashCollection : List<HashModel>
    {
        /// <summary>
        /// ハッシュリストの保存
        /// </summary>
        public void Save(string filename)
        {
            var lines = this.Select(_ => _.ToString());
            File.WriteAllLines(filename, lines);
        }

        /// <summary>
        /// ハッシュリストの呼出
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static HashCollection Load(string filename)
        {
            var collection = new HashCollection();
            if (File.Exists(filename))
            {
                var lines = File.ReadAllLines(filename, Encoding.UTF8);
                foreach (var line in lines)
                {
                    var model = HashModel.Parse(line);
                    collection.Add(model);
                }
            }
            return collection;
        }

        /// <summary>
        /// ファイルハッシュリストを作成する
        /// </summary>
        /// <param name="directoryName">検索するディレクトリ名</param>
        /// <param name="ext">検索する拡張子</param>
        /// <returns></returns>
        public static HashCollection Create(string directoryName, string ext)
        {
            var collection = new HashCollection();
            var files = Directory.GetFiles(directoryName, ext, SearchOption.AllDirectories);
            foreach (var file in files)
            {
                collection.Add(new HashModel(file, directoryName));
            }
            return collection;
        }

        /// <summary>
        /// ハッシュ比較
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Compare(HashModel model)
        {
            var _model = this.FirstOrDefault(_ => _.Filename == model.Filename);
            if (null == _model)
            {
                return true;
            }

            if (_model.Hash == model.Hash)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
