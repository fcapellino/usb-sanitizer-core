using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace USB_Sanitizer
{
    public partial class MainForm : Form
    {
        private readonly ManagementEventWatcher _managementEventWatcherEventType2;
        private readonly ManagementEventWatcher _managementEventWatcherEventType3;
        private readonly Debouncer _debouncer;

        public MainForm()
        {
            _debouncer = new Debouncer();
            Disposed += (s, e) => _debouncer.Dispose();

            InitializeComponent();
            LoadSettings();
            LoadRemovableDrives();
            LoadExtensionsBlackList();

            var insertQuery = new WqlEventQuery("SELECT * FROM Win32_DeviceChangeEvent WHERE EventType = 2");
            _managementEventWatcherEventType2 = new ManagementEventWatcher(insertQuery);
            _managementEventWatcherEventType2.EventArrived += DeviceInsertedEvent;
            _managementEventWatcherEventType2.Start();

            var removeQuery = new WqlEventQuery("SELECT * FROM Win32_DeviceChangeEvent WHERE EventType = 3");
            _managementEventWatcherEventType3 = new ManagementEventWatcher(removeQuery);
            _managementEventWatcherEventType3.EventArrived += DeviceRemovedEvent;
            _managementEventWatcherEventType3.Start();
        }

        private void ButtonAddExt_Click(object sender, EventArgs e)
        {
            try
            {
                var text = textBoxExt.Text;
                textBoxExt.Text = string.Empty;

                if (!string.IsNullOrEmpty(text))
                {
                    var regex = new Regex("[^a-zA-Z0-9]");
                    var ext = regex.Replace(text, "").Trim().Truncate(10).ToUpper();

                    if (!string.IsNullOrWhiteSpace(ext))
                    {
                        var containsExt = Properties.Settings.Default.EXTENSIONS.Contains(ext);
                        if (!containsExt)
                        {
                            Properties.Settings.Default.EXTENSIONS.Add(ext);
                            Properties.Settings.Default.Save();
                            LoadExtensionsBlackList();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var message = ex.GetBaseException().Message.ToUpper();
                MessageBox.Show(message, "USB SANITIZER", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonRemoveExt_Click(object sender, EventArgs e)
        {
            try
            {
                var ext = listBoxExtensions.SelectedItem?.ToString();
                if (!string.IsNullOrEmpty(ext))
                {
                    Properties.Settings.Default.EXTENSIONS.Remove(ext);
                    Properties.Settings.Default.Save();
                    LoadExtensionsBlackList();
                }
            }
            catch (Exception ex)
            {
                var message = ex.GetBaseException().Message.ToUpper();
                MessageBox.Show(message, "USB SANITIZER", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonSanitize_Click(object sender, EventArgs e)
        {
            try
            {
                DisableAllControls();
                var selectedItem = comboBoxDrives.SelectedItem;
                if (selectedItem != null)
                {
                    dynamic removableDrive = Convert.ChangeType(selectedItem, typeof(RemovableDrive));
                    SanitizeRemovableDrive(removableDrive);
                    MessageBox.Show("DRIVE HAS BEEN SANITIZED!", "USB SANITIZER", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                var message = ex.GetBaseException().Message.ToUpper();
                MessageBox.Show(message, "USB SANITIZER", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                EnableAllControls();
            }
        }

        private void CheckBoxMonitor_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.MONITOR_USB_DRIVES = checkBoxMonitor.Checked;
            Properties.Settings.Default.Save();
        }

        private void DeviceInsertedEvent(object sender, EventArrivedEventArgs e)
        {
            _debouncer.Debounce(() => Invoke(new Action(() =>
            {
                try
                {
                    DisableAllControls();
                    Helpers.ControlInvokeRequired(comboBoxDrives, () => LoadRemovableDrives());
                    if (Properties.Settings.Default.MONITOR_USB_DRIVES)
                    {
                        var removableDrives = comboBoxDrives.Items.Cast<RemovableDrive>().ToList();
                        if (removableDrives.Any())
                        {
                            removableDrives.ForEach((item) => SanitizeRemovableDrive(item));
                        }
                    }
                }
                catch (Exception ex)
                {
                    var message = ex.GetBaseException().Message.ToUpper();
                    MessageBox.Show(message, "USB SANITIZER", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    EnableAllControls();
                }
            })));
        }

        private void DeviceRemovedEvent(object sender, EventArrivedEventArgs e)
        {
            _debouncer.Debounce(() => Invoke(new Action(() =>
            {
                Helpers.ControlInvokeRequired(comboBoxDrives, () => LoadRemovableDrives());
            })));
        }

        private void DisableAllControls()
        {
            this.Enable(false);
        }

        private void EnableAllControls()
        {
            this.Enable(true);
        }

        private void LoadExtensionsBlackList()
        {
            var extensionsList = Properties.Settings.Default.EXTENSIONS.Cast<string>().OrderBy(e => e).ToArray();
            listBoxExtensions.Items.Clear();
            listBoxExtensions.Items.AddRange(extensionsList);

            if (listBoxExtensions.Items.Cast<object>().Any())
            {
                listBoxExtensions.SelectedIndex = 0;
            }
        }

        private void LoadRemovableDrives()
        {
            var removableDrives = DriveInfo.GetDrives()
                .Where(d => d.IsReady && d.DriveType == DriveType.Removable)
                .Select(d => new RemovableDrive()
                {
                    RootDirectory = d.RootDirectory.ToString(),
                    VolumeLabel = d.VolumeLabel.ToString()
                }).ToArray();

            comboBoxDrives.Items.Clear();
            comboBoxDrives.Items.AddRange(removableDrives);

            if (comboBoxDrives.Items.Cast<object>().Any())
            {
                comboBoxDrives.SelectedIndex = 0;
            }
        }

        private void LoadSettings()
        {
            checkBoxMonitor.Checked = Properties.Settings.Default.MONITOR_USB_DRIVES;
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Hide();
            }
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            string[] args = Environment.GetCommandLineArgs();
            if (args.Contains("MINIMIZED"))
            {
                WindowState = FormWindowState.Minimized;
            }
        }

        private void NotifyIconOne_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void SanitizeRemovableDrive(RemovableDrive drive)
        {
            var label = drive.RootDirectory.ToString()[0];
            Process.Start(new ProcessStartInfo()
            {
                Arguments = string.Format("-s -h -r -a /s /d {0}:*.*", label),
                CreateNoWindow = true,
                FileName = "attrib.exe",
                UseShellExecute = false,
                WindowStyle = ProcessWindowStyle.Hidden
            }).WaitForExit();

            var extensions = listBoxExtensions.Items.Cast<string>().ToList();
            if (extensions.Any())
            {
                extensions.ForEach((item) =>
                {
                    var ext = item.ToLower();
                    Process.Start(new ProcessStartInfo()
                    {
                        Arguments = string.Format("/C DEL /S \"{0}:*.{1}\"", label, ext),
                        CreateNoWindow = true,
                        FileName = "cmd.exe",
                        UseShellExecute = false,
                        WindowStyle = ProcessWindowStyle.Hidden
                    }).WaitForExit();
                });
            }
        }
    }
}
