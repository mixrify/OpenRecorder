using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScreenRecorderLib;
using System.IO;
using System.Diagnostics;

namespace Screen_Recorder__CYBERS_TEAM_
{
    public partial class OpenRecorder : Form
    {

        public Timer _progressTimer;
        public bool _IsRecording;
        public int _secondsElapsed;
        Recorder _rec;

        string _CURRRENT_DIR = Environment.CurrentDirectory + "\\Screen Recorder\\";

        public OpenRecorder()
        {
            InitializeComponent();
        }

        private void _progressTimer_Tick(object sender, EventArgs e)
        {
            _secondsElapsed++;
            UpdateProgress();
        }

        private void OpenRecorder_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            _progressTimer = new Timer();
            _progressTimer.Tick += _progressTimer_Tick;
            _progressTimer.Interval = 1000;

            try
            {
                if (Directory.Exists(_CURRRENT_DIR))
                {
                    // Dir is Ready !
                }
                else
                {
                    Directory.CreateDirectory(_CURRRENT_DIR);
                }
            }
            catch (Exception)
            {
                //
            }
            this.TopMost = false;
        }

        private void CleanResources()
        {
            _progressTimer?.Stop();
            _progressTimer = null;
            _secondsElapsed = 0;
            _rec?.Dispose();
            _rec = null;
        }

        private void _rec_OnRecordingComplete(object sender, RecordingCompleteEventArgs e)
        {
            BeginInvoke(((Action)(() =>
            {
                string filepath = e.FilePath;
                textBox_Path.Text = filepath;
                btnStartRecording.Text = "Start Recording";
                _IsRecording = false;
                CleanResources();
            })));
        }

        private void _rec_OnRecordingFailed(object sender, RecordingFailedEventArgs e)
        {
            BeginInvoke(((Action)(() =>
            {
                btnStartRecording.Text = "Start Recording";
                _IsRecording = false;
                CleanResources();
            })));
        }

        private void _rec_OnStatusChanged(object sender, RecordingStatusEventArgs e)
        {
            BeginInvoke(((Action)(() =>
            {
                switch (e.Status)
                {
                    case RecorderStatus.Idle:

                        break;
                    case RecorderStatus.Recording:
                        if (_progressTimer != null)
                            _progressTimer.Enabled = true;
                        btnStartRecording.Text = "Stop Recording";

                        break;
                    case RecorderStatus.Paused:
                        if (_progressTimer != null)
                            _progressTimer.Enabled = false;
                        btnPauseRecording.Text = "Resume Recording";

                        break;
                    case RecorderStatus.Finishing:

                        break;
                    default:
                        break;
                }


            })));
        }


        private void ShowingScreen_Tick(object sender, EventArgs e)
        {
            ShowingScreen.Stop();

            Bitmap bt = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
         var g = Graphics.FromImage(bt);

        g.CopyFromScreen(0, 0, 0, 0, bt.Size);
            pbScreen.Image = bt;

            ShowingScreen.Start();

        }

        private void UpdateProgress()
        {
            txtTime.Text = TimeSpan.FromSeconds(_secondsElapsed).ToString();
        }

        private void btnStartRecording_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;

            try
            {
                if (_IsRecording)
                {
                    _rec.Stop();
                    _progressTimer?.Stop();
                    _progressTimer = null;
                    _secondsElapsed = 0;
                    //RecordButton.Enabled = false;
                    btnStartRecording.Text = "Stop Recording";
                }
                UpdateProgress();

                string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss");
                string videopath = Path.Combine(_CURRRENT_DIR, timestamp + "-Record" + ".mp4");

                if (_rec == null)
                {
                    _rec = Recorder.CreateRecorder();
                    _rec.OnRecordingComplete += _rec_OnRecordingComplete;
                    _rec.OnRecordingFailed += _rec_OnRecordingFailed;
                    _rec.OnStatusChanged += _rec_OnStatusChanged;
                }

                _rec.Record(videopath);
                _secondsElapsed = 0;
                _IsRecording = true;
            }
            catch (Exception)
            {
                //
            }
        }

        private void btnPauseRecording_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;

            try
            {
                if (_rec.Status == RecorderStatus.Paused)
                {
                    btnPauseRecording.Text = "Pause Recording";
                    _rec.Resume();
                    return;
                }

                _rec.Pause();
            }
            catch (Exception)
            {
                //
            }
        }

        private void btnFilePath_Click(object sender, EventArgs e)
        {
            string directory = Path.Combine(_CURRRENT_DIR);

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(_CURRRENT_DIR);
            }

            Process.Start(directory);
        }

        private void btnScreenshotTool_Click(object sender, EventArgs e)
        {

        }
    }
    }