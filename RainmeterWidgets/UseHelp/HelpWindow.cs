using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace UseHelp
{
    public partial class HelpWindow : Form
    {
        public HelpWindow()
        {
            InitializeComponent();
        }

        private void LoadHelpFromXML()
        {
            // 尝试加载 HelpContent.xml 并将节点添加到 HelpListView
            try
            {
                // 一组可能的位置，按优先级查找
                string baseDir = AppContext.BaseDirectory;
                string[] candidates = new string[]
                {
                    Path.Combine(baseDir, "HelpContent.xml"),
                    Path.Combine(baseDir, "Resources", "HelpContent.xml"),
                    Path.Combine(Directory.GetCurrentDirectory(), "HelpContent.xml")
                };

                string? filePath = candidates.FirstOrDefault(File.Exists);

                if (filePath is null)
                {
                    // 未找到帮助文件，不阻止程序运行
                    return;
                }

                var doc = XDocument.Load(filePath);
                HelpListView.Nodes.Clear();

                var root = doc.Root;
                if (root is null)
                {
                    return;
                }

                foreach (var category in root.Elements("Category"))
                {
                    string catText = category.Attribute("Text")?.Value ?? "未命名分类";
                    TreeNode catNode = new TreeNode(catText);

                    foreach (var item in category.Elements("Item"))
                    {
                        string itemText = item.Attribute("Text")?.Value ?? item.Value ?? string.Empty;
                        catNode.Nodes.Add(new TreeNode(itemText));
                    }

                    HelpListView.Nodes.Add(catNode);
                }
            }
            catch
            {
                throw; // 让调用者处理异常，保持代码简洁
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DecorationIcon.Image = SystemIcons.Information.ToBitmap();

            try
            {
                LoadHelpFromXML();
            }
            catch (Exception ex)
            {
                // 加载帮助内容失败，提示用户并提供访问联机帮助的选项
                if (MessageBox.Show($"加载帮助内容失败：{ex.Message}\n是否要打开联机帮助？", "提示",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    VisitOnlineHelp();
                }
                this.Close();
            }
        }

        private void VisitOnlineHelp()
        {
            try
            {
                // 使用默认浏览器打开联机帮助页面
                _ = Process.Start(new ProcessStartInfo()
                {
                    FileName = "https://qixiaolight.mysxl.cn/", // 临时地址，后面会替换成正式的帮助文档地址
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"联机帮助访问失败：{ex.Message}", "提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OnlineHelpButton_Click(object sender, EventArgs e)
        {
            VisitOnlineHelp();
        }
    }
}
