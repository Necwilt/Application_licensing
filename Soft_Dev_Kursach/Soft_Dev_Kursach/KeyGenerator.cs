using BitwiseShiftsHashPlug;
using HardDiskIdPlug;
using LicenseKeyValidator;
using MotherboardIdPlug;
using MultiplyAddHashPlug;
using PluginInterfaces;
using ProcessorIdPlugin;
using SumOfSquaresHashPlug;
using System.Text.Json;
using System.Security.Cryptography;
using System.Text;

namespace Soft_Dev_Kursach
{
    public partial class KeyGenerator : Form
    {
        private string selectedHardwareId;
        private string selectedHash;
        private ProcIDPlugin procIdPlug;
        private HardDiskIdPlugin HardDiskIdPlug;
        private MotherboardIdPlugin MotherboardIdPlug;
        private IPlugin<int, string> BitwiseShiftPlug;
        private IPlugin<int, string> MultiplyAddHashPlug;
        private IPlugin<int, string> SumOfSquaresPlug;
        private Dictionary<string, IPlugin<int, string>> plugins;
        private Dictionary<string, string> pluginDescriptions;

        public KeyGenerator()
        {
            InitializeComponent();
            // ������������� ��������
            procIdPlug = new ProcIDPlugin();
            HardDiskIdPlug = new HardDiskIdPlugin();
            MotherboardIdPlug = new MotherboardIdPlugin();
            BitwiseShiftPlug = new BitwiseShiftsHashPlugin();
            MultiplyAddHashPlug = new MultiplyAddHashPlugin();
            SumOfSquaresPlug = new SumOfSquaresHashPlugin();

            pluginDescriptions = new Dictionary<string, string>();
            plugins = new Dictionary<string, IPlugin<int, string>>();

            LicenseKeyGenerator.LoadPlugins(FileListBox, functionNameListBox, plugins, pluginDescriptions);

            foreach (string fileName in functionNameListBox.Items)
            {
                ToolStripMenuItem pluginMenuItem = new ToolStripMenuItem();
                pluginMenuItem.Text = fileName;
                pluginMenuItem.Click += PluginMenuItem_Click;
                toolStripMenuItem1.DropDownItems.Add(pluginMenuItem);
            }

        }

        private void PluginMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            string pluginName = menuItem.Text;

            if (plugins.ContainsKey(pluginName))
            {
                IPlugin<int, string> plugin = plugins[pluginName];

                // ����� ������ GetPluginDescription ��� ��������� �������� �������
                string pluginDescription = plugin.GetDescription();

                // ����������� ���� � ��������� �������
                MessageBox.Show(pluginDescription, "�������� �������");
            }
        }



        private void buttonGenerateKey_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedHardwareId) || string.IsNullOrEmpty(selectedHash))
            {
                MessageBox.Show("�������� ������� ������������ ����� � ����� �����������.", "��������������", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string additionalData = textBoxJson.Text;
                string licenseKey = LicenseKeyGenerator.GenerateLicenseKey(selectedHardwareId, selectedHash, plugins, additionalData);

                try
                {
                    string filePath = textBoxFilePath.Text;
                    if (!string.IsNullOrEmpty(filePath))
                    {

                        string directoryPath = Path.GetDirectoryName(filePath);

                        if (!Directory.Exists(directoryPath))
                        {
                            MessageBox.Show("������� ���������� ���� ���������� �����.", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        };

                        File.WriteAllText(filePath, licenseKey);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("��������� ������ ��� ���������� �����: " + ex.Message, "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                textBox1.Text = licenseKey;
            }
        }

        private void radioButtonProcessor_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonProcessor.Checked)
            {
                selectedHardwareId = procIdPlug.Execute(null);
            }
        }

        private void radioButtonStorage_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonStorage.Checked)
            {
                selectedHardwareId = HardDiskIdPlug.Execute(null);
            }
        }

        private void radioButtonMotherboard_CheckedChanged(object sender, EventArgs e)
        {

            if (radioButtonMotherboard.Checked)
            {
                selectedHardwareId = MotherboardIdPlug.Execute(null);
            }
        }

        private void BitwiseShifts_CheckedChanged(object sender, EventArgs e)
        {
            if (BitwiseShifts.Checked)
            {
                selectedHash = BitwiseShiftPlug.GetName();
            }
        }

        private void MultiplyAddHash_CheckedChanged(object sender, EventArgs e)
        {
            if (MultiplyAddHash.Checked)
            {
                selectedHash = MultiplyAddHashPlug.GetName();
            }
        }

        private void SumOfSquares_CheckedChanged(object sender, EventArgs e)
        {
            if (SumOfSquares.Checked)
            {
                selectedHash = SumOfSquaresPlug.GetName();
            }
        }

        private void CheckKey_Click(object sender, EventArgs e)
        {
            string licenseKey = textBox2.Text;

            if (LicenseKeyValid.ValidateLicenseKey(licenseKey))
            {
                MessageBox.Show("������������ ���� ������� ������!", "�����");
            }
            else
                MessageBox.Show("�������� ������������ ����.", "������");
        }

        private void buttonDecrypt_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = textBoxDecryptedData.Text;
                string ID = selectedHardwareId;

                // ���������, ������ �� ���� � �����
                if (!string.IsNullOrEmpty(textBoxDecryptedData.Text))
                {
                    // ������ ���������� �����
                    string Data = File.ReadAllText(textBoxDecryptedData.Text);
                    Data = Data.Substring(16);
                    string decryptedData = LicenseKeyValid.DecryptAdditionalData(Data, "wC/fKlFJwX2hp53+ezuwOw==");

                    // ���������� �������������� ������
                    textBoxDecryptedData.Text = decryptedData;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("��������� ������ ��� ����������� ������: " + ex.Message, "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}