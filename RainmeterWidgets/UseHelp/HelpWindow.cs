using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Runtime.InteropServices;

namespace UseHelp
{
    public partial class HelpWindow : Form
    {
        // 程序版本
        private const string programVersion = "1.0";

        // 字体缓存
        private FontCache fontCache = FontCache.Instance;

        /// <summary>
        /// 构造函数
        /// </summary>
        public HelpWindow()
        {
            InitializeComponent();

            DecorationIcon.Image = SystemIcons.Information.ToBitmap();
            InfoLabel.Text = $"程序版本：{programVersion}\n运行时版本：{RuntimeInformation.FrameworkDescription}";
        }

        /// <summary>
        /// 访问联机帮助
        /// </summary>
        private void VisitOnlineHelp()
        {
            try
            {
                // 使用默认浏览器打开联机帮助页面
                _ = Process.Start(new ProcessStartInfo()
                {
                    FileName = "https://eggyui-help.neocities.org/", // Redirect Link
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"联机帮助访问失败：{ex.Message}", "提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// 从XML文件加载帮助内容
        /// </summary>
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

        private void ApplyFont()
        {
            string preferredFontName = "方正兰亭圆简体_中";
            foreach (var control in this.Controls.OfType<Control>())
            {
                // Preserve the current font size and style
                float fontSize = control.Font.Size;
                FontStyle fontStyle = control.Font.Style;
                GraphicsUnit graphicsUnit = control.Font.Unit;

                // Get the preferred font or fallback
                control.Font = fontCache.GetFont(preferredFontName, fontSize, fontStyle, graphicsUnit);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ApplyFont();
            try
            {
                LoadHelpFromXML();
            }
            catch (Exception ex)
            {
                // 加载帮助内容失败，提示用户并提供访问联机帮助的选项
                if (MessageBox.Show($"加载帮助内容失败：{ex.Message}\n是否要打开联机帮助？", "提示",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    VisitOnlineHelp();
                }
                this.Close();
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

        private void HelpWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            fontCache.ClearAll();
            fontCache.Dispose();
        }
    }
}
