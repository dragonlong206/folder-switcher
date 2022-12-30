using System.Configuration;

namespace FolderSwitcher
{
    public partial class frmMain : Form
    {
        string primaryFolder;
        string secondaryFolder;
        string tempFolder;
        int highlightedButton;
        readonly Color highlightedBackColor = Color.FromArgb(16, 63, 86);
        readonly Color highlightedForeColor = Color.White;
        readonly Color defaultBackColor;
        readonly Color defaultForeColor;

        public frmMain()
        {
            primaryFolder = ConfigurationManager.AppSettings["PrimaryFolder"];
            secondaryFolder = ConfigurationManager.AppSettings["SecondaryFolder"];
            tempFolder = ConfigurationManager.AppSettings["TempFolder"];
            InitializeComponent();
            defaultBackColor = btnOption1.BackColor;
            defaultForeColor= btnOption1.ForeColor;
        }

        private void btnOption1_Click(object sender, EventArgs e)
        {
            if (highlightedButton == 2)
            {
                if (Directory.Exists(primaryFolder))
                {
                    try
                    {
                        Directory.Move(primaryFolder, tempFolder);
                        Directory.Move(secondaryFolder, primaryFolder);
                        MessageBox.Show("Chuyển đổi thành công!");
                        HighlightButton1();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show($"Thư mục {primaryFolder} không tồn tại!");
                }
            }
        }

        private void btnOption2_Click(object sender, EventArgs e)
        {
            if (highlightedButton == 1)
            {
                if (Directory.Exists(tempFolder))
                {
                    try
                    {
                        Directory.Move(primaryFolder, secondaryFolder);
                        Directory.Move(tempFolder, primaryFolder);
                        MessageBox.Show("Chuyển đổi thành công!");
                        HighlightButton2();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show($"Thư mục {tempFolder} không tồn tại!");
                }
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (Directory.Exists(primaryFolder))
            {
                if (Directory.Exists(tempFolder))
                {
                    HighlightButton1();
                }
                else
                {
                    HighlightButton2();
                }
            }
        }

        private void HighlightButton1()
        {
            highlightedButton = 1;
            btnOption1.BackColor = highlightedBackColor;
            btnOption1.ForeColor = highlightedForeColor;
            btnOption1.Cursor = Cursors.Default;

            btnOption2.BackColor = defaultBackColor;
            btnOption2.ForeColor = defaultForeColor;
            btnOption2.Cursor= Cursors.Hand;
        }

        private void HighlightButton2()
        {
            highlightedButton = 2;
            btnOption1.BackColor = defaultBackColor;
            btnOption1.ForeColor = defaultForeColor;
            btnOption1.Cursor = Cursors.Hand;

            btnOption2.BackColor = highlightedBackColor;
            btnOption2.ForeColor = highlightedForeColor;
            btnOption2.Cursor= Cursors.Default;
        }
    }
}