using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScreenRecorderLib;
using System.IO;
using System.Diagnostics;
using System.Net;
using System.IO.Compression;
using NAudio.Wave;
using System.Runtime.InteropServices;
using DiscordRPC;
using DiscordRPC.Logging;

namespace OpenRecorderStudio
{

    public partial class OpenRecorder : Form
    {
        WaveIn wave;
        WaveFileWriter writer;
        string outputFileName;


        public Timer _progressTimer;
        public bool _IsRecording;
        public int _secondsElapsed;
        Recorder _rec;

        string _CURRRENT_DIR = Environment.CurrentDirectory + "\\Screen Recordings\\";
        string _CURRRENT_DIR2 = Environment.CurrentDirectory + "\\Screenshots\\";
        string _CURRRENT_DIR3 = Environment.CurrentDirectory + "\\Audio Recordings\\";

        public OpenRecorder()
        {
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            InitializeComponent();
        }

        public void LoadSettings()
        {

            if (OpenRecorder_Studio.Properties.Settings.Default.Usage == "0")
            {
                MSG.Style = Guna.UI2.WinForms.MessageDialogStyle.Dark;
                MSG.Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo;
                MSG.Caption = "OpenRecorder Recommendation";
                MSG.Text = "Load recommended settings for your pc?";
                DialogResult d = MSG.Show();

                if (d == DialogResult.Yes)
                {
                    OpenRecorder_Studio.Properties.Settings.Default.Interval = "8";
                    OpenRecorder_Studio.Properties.Settings.Default.Save();

                    MSG.Style = Guna.UI2.WinForms.MessageDialogStyle.Dark;
                    MSG.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                    MSG.Caption = "Success!";
                    MSG.Text = "Settings have been modified.";
                    MSG.Show();
                }
                else if (d == DialogResult.No)
                {

                }
                OpenRecorder_Studio.Properties.Settings.Default.Usage = "1";
                OpenRecorder_Studio.Properties.Settings.Default.Save();
            }
            else
            {

            }

            if (OpenRecorder_Studio.Properties.Settings.Default.MicrophoneAudio == "true" == true)
            {
                cbRMA.Text = "true";            
            }
            else
            {
                cbRMA.Text = "false";
            }

            if (OpenRecorder_Studio.Properties.Settings.Default.ComputerAudio == "true" == true)
            {
                cbRCA.Text = "true";
            }
            else
            {
                cbRCA.Text = "false";
            }

            if (OpenRecorder_Studio.Properties.Settings.Default.PresentCurrentScreen == "true" == true)
            {
                cbPCS.Text = "true";
                ShowingScreen.Start();

            }
            else
            {
                cbPCS.Text = "false";
                ShowingScreen.Stop();
            }

            cbVFT.Text = OpenRecorder_Studio.Properties.Settings.Default.Saver;

            if (Directory.Exists(Environment.GetEnvironmentVariable(@"C:\Program Files (x86)")))
            {
                OpenRecorder_Studio.Properties.Settings.Default.SupportedProcessor = "x64";
                OpenRecorder_Studio.Properties.Settings.Default.Save();
            }
            else
            {
                OpenRecorder_Studio.Properties.Settings.Default.SupportedProcessor = "x86";
                OpenRecorder_Studio.Properties.Settings.Default.Save();
            }

            if (OpenRecorder_Studio.Properties.Settings.Default.SupportedProcessor == "x64")
            {
                tbSSP.Text = "x64";
            }
            else
            {
                tbSSP.Text = "x86";
            }

        }


        void OpenRecorderCheckForUpdate()
        {
           
            var webClient = new WebClient();
            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                if (!webClient.DownloadString("https://pastebin.com/raw/5uiF0x5u").Contains("1.4"))
                {

                    string lol = webClient.DownloadString("https://pastebin.com/raw/5uiF0x5u").ToString();

                    MSG.Style = Guna.UI2.WinForms.MessageDialogStyle.Dark;
                    MSG.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                    MSG.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                    MSG.Caption = "New Update";
                    MSG.Text = "A new update was found, Version: " + lol + ". Download in our site.";
                    MSG.Show();
                }
                else
                {
                    
                }
            }
            else
            {

            }

        }

        public DiscordRpcClient client;
        bool initialized = false;

        private void OpenRecorder_Load(object sender, EventArgs e)
        {

            InitializeSettings();

            #region DiscordRPC

            initialized = true;
            client = new DiscordRpcClient("907520693485322251");
            client.Logger = new ConsoleLogger() { Level = DiscordRPC.Logging.LogLevel.Warning };
            client.Initialize();

            #endregion



            OpenRecorderCheckForUpdate();

            string directory = Path.Combine(_CURRRENT_DIR);

            textBox_Path.Text = directory;

            LoadSettings();

            pnSettings.Hide();
            pnTools.Hide();
            pnAccounts.Hide();
            pnPlugins.Hide();
            pnSettings2.Hide();

            this.TopMost = true;
            this.TopMost = false;
            _progressTimer = new Timer();
            _progressTimer.Tick += Seconds_Tick;
            _progressTimer.Interval = 1000;

            try
            {
                if (Directory.Exists(_CURRRENT_DIR))
                {

                }
                else
                {
                    Directory.CreateDirectory(_CURRRENT_DIR);
                }
            }
            catch (Exception)
            {
                
            }


        }

        private void CleanResources()
        {
            _progressTimer?.Stop();
            _progressTimer = null;
            _secondsElapsed = 0;
            _rec?.Dispose();
            _rec = null;
            this.Visible = true;
        }

        public void _rec_OnRecordingComplete(object sender, RecordingCompleteEventArgs e)
        {
            BeginInvoke(((Action)(() =>
            {
                string filepath = e.FilePath;
                textBox_Path.Text = filepath;
                btnPauseRecording.Enabled = false;
                btnStartRecording.Text = "Start Recording";
                _IsRecording = false;
                CorrectTimer.Stop();
            })));
        }

        private void _rec_OnRecordingFailed(object sender, RecordingFailedEventArgs e)
        {

            BeginInvoke(((Action)(() =>
            {
                btnPauseRecording.Enabled = false;
                btnStartRecording.Text = "Start Recording";
                _IsRecording = false;
                CleanResources();
                CorrectTimer.Stop();

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
                        btnPauseRecording.Enabled = true;
                        btnStartRecording.Text = "Stop Recording";
                        txtOutput.Text = "Screen recording started/resumed.";
                        CorrectTimer.Start();


                        break;
                    case RecorderStatus.Paused:
                        if (_progressTimer != null)
                            _progressTimer.Enabled = false;
                        btnPauseRecording.Enabled = true;
                        btnPauseRecording.Text = "Resume Recording";
                        txtOutput.Text = "Screen recording has been paused.";
                        CorrectTimer.Stop();

                        break;
                    case RecorderStatus.Finishing:
                        CorrectTimer.Stop();
                        break;
                    default:
                        break;
                }


            })));
        }

        private WasapiLoopbackCapture capture;

        private void ShowingScreen_Tick(object sender, EventArgs e)
        {
            ShowingScreen.Stop();

            try
            {
                Bitmap bt = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                var g = Graphics.FromImage(bt);

                g.CopyFromScreen(0, 0, 0, 0, bt.Size);
                pbScreen.Image = bt;

                ShowingScreen.Start();
            }
            catch
            {
                ShowingScreen.Stop();
                MSG.Style = Guna.UI2.WinForms.MessageDialogStyle.Dark;
                MSG.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                MSG.Icon = Guna.UI2.WinForms.MessageDialogIcon.Error;
                MSG.Caption = "Screen Presenter Error";
                MSG.Text = "There was a problem trying to present your screen.";
                MSG.Show();

            }


        }

        [DllImport("winmm.dll", EntryPoint = "mciSendStringA", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        private static extern int record(string ipstrCommand, string ipstrReturnString, int uReturnLenth, int hwndCallback);


        private void Wave_RecordingStopped(object sender, StoppedEventArgs e)
        {
            writer.Dispose();
        }

        private void Wave_DataAvailable(object sender, WaveInEventArgs e)
        {
            writer.Write(e.Buffer, 0, e.BytesRecorded);
        }

        protected private void InitializeSettings()
        {

            

        }

        public int FPS = 60;

        private void btnStartRecording_Click(object sender, EventArgs e2)
        {
            this.ActiveControl = null;
            var FPS1 = new Int32();

            try
            {
                if (_IsRecording)
                {
                    _rec.Stop();
                    _progressTimer?.Stop();
                    _progressTimer = null;
                    _secondsElapsed = 0;
                    CorrectTimer.Stop();
                    btnPauseRecording.Enabled = false;

                    s = 0;
                    m = 0;
                    h = 0;

                    txtTiming.Text = "00:00:00";

                }

                string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss");
                string videopath = Path.Combine(_CURRRENT_DIR, timestamp + OpenRecorder_Studio.Properties.Settings.Default.Saver);

                if (_rec == null)
                {
                    if (OpenRecorder_Studio.Properties.Settings.Default.ComputerAudio == "true")
                    {

                        if (OpenRecorder_Studio.Properties.Settings.Default.FPS == "10")
                        {

                            RecorderOptions options = new RecorderOptions
                            {
                                RecorderMode = RecorderMode.Video,
                                //If throttling is disabled, out of memory exceptions may eventually crash the program,
                                //depending on encoder settings and system specifications.
                                IsThrottlingDisabled = false,
                                //Hardware encoding is enabled by default.
                                IsHardwareEncodingEnabled = true,
                                //Low latency mode provides faster encoding, but can reduce quality.
                                IsLowLatencyEnabled = false,
                                //Fast start writes the mp4 header at the beginning of the file, to facilitate streaming.
                                IsMp4FastStartEnabled = false,
                                VideoOptions = new VideoOptions
                                {
                                    Framerate = 10,
                                    IsFixedFramerate = true,
                                },
                                MouseOptions = new MouseOptions
                                {
                                    //Displays a colored dot under the mouse cursor when the left mouse button is pressed.	
                                    IsMouseClicksDetected = true,
                                    MouseClickDetectionColor = "#FFFF00",
                                    MouseRightClickDetectionColor = "#FFFF00",
                                    MouseClickDetectionRadius = 30,
                                    MouseClickDetectionDuration = 60,
                                    IsMousePointerEnabled = true,
                                    /* Polling checks every millisecond if a mouse button is pressed.
                                       Hook works better with programmatically generated mouse clicks, but may affect
                                       mouse performance and interferes with debugging.*/
                                    MouseClickDetectionMode = MouseDetectionMode.Hook
                                },
                                AudioOptions = new AudioOptions
                                {
                                    Bitrate = AudioBitrate.bitrate_128kbps,
                                    Channels = AudioChannels.Stereo,
                                    IsAudioEnabled = true
                                }
                            };

                            _rec = Recorder.CreateRecorder(options);

                        }
                        else if (OpenRecorder_Studio.Properties.Settings.Default.FPS == "20")
                        {

                            RecorderOptions options = new RecorderOptions
                            {
                                RecorderMode = RecorderMode.Video,
                                //If throttling is disabled, out of memory exceptions may eventually crash the program,
                                //depending on encoder settings and system specifications.
                                IsThrottlingDisabled = false,
                                //Hardware encoding is enabled by default.
                                IsHardwareEncodingEnabled = true,
                                //Low latency mode provides faster encoding, but can reduce quality.
                                IsLowLatencyEnabled = false,
                                //Fast start writes the mp4 header at the beginning of the file, to facilitate streaming.
                                IsMp4FastStartEnabled = false,
                                VideoOptions = new VideoOptions
                                {
                                    Framerate = 20,
                                    IsFixedFramerate = true,
                                },
                                MouseOptions = new MouseOptions
                                {
                                    //Displays a colored dot under the mouse cursor when the left mouse button is pressed.	
                                    IsMouseClicksDetected = true,
                                    MouseClickDetectionColor = "#FFFF00",
                                    MouseRightClickDetectionColor = "#FFFF00",
                                    MouseClickDetectionRadius = 30,
                                    MouseClickDetectionDuration = 60,
                                    IsMousePointerEnabled = true,
                                    /* Polling checks every millisecond if a mouse button is pressed.
                                       Hook works better with programmatically generated mouse clicks, but may affect
                                       mouse performance and interferes with debugging.*/
                                    MouseClickDetectionMode = MouseDetectionMode.Hook
                                },
                                AudioOptions = new AudioOptions
                                {
                                    Bitrate = AudioBitrate.bitrate_128kbps,
                                    Channels = AudioChannels.Stereo,
                                    IsAudioEnabled = true
                                }
                            };

                            _rec = Recorder.CreateRecorder(options);

                        }
                        else if (OpenRecorder_Studio.Properties.Settings.Default.FPS == "30")
                        {

                            RecorderOptions options = new RecorderOptions
                            {
                                RecorderMode = RecorderMode.Video,
                                //If throttling is disabled, out of memory exceptions may eventually crash the program,
                                //depending on encoder settings and system specifications.
                                IsThrottlingDisabled = false,
                                //Hardware encoding is enabled by default.
                                IsHardwareEncodingEnabled = true,
                                //Low latency mode provides faster encoding, but can reduce quality.
                                IsLowLatencyEnabled = false,
                                //Fast start writes the mp4 header at the beginning of the file, to facilitate streaming.
                                IsMp4FastStartEnabled = false,
                                VideoOptions = new VideoOptions
                                {
                                    Framerate = 30,
                                    IsFixedFramerate = true,
                                },
                                MouseOptions = new MouseOptions
                                {
                                    //Displays a colored dot under the mouse cursor when the left mouse button is pressed.	
                                    IsMouseClicksDetected = true,
                                    MouseClickDetectionColor = "#FFFF00",
                                    MouseRightClickDetectionColor = "#FFFF00",
                                    MouseClickDetectionRadius = 30,
                                    MouseClickDetectionDuration = 60,
                                    IsMousePointerEnabled = true,
                                    /* Polling checks every millisecond if a mouse button is pressed.
                                       Hook works better with programmatically generated mouse clicks, but may affect
                                       mouse performance and interferes with debugging.*/
                                    MouseClickDetectionMode = MouseDetectionMode.Hook
                                },
                                AudioOptions = new AudioOptions
                                {
                                    Bitrate = AudioBitrate.bitrate_128kbps,
                                    Channels = AudioChannels.Stereo,
                                    IsAudioEnabled = true
                                }
                            };

                            _rec = Recorder.CreateRecorder(options);

                        }
                        else if (OpenRecorder_Studio.Properties.Settings.Default.FPS == "40")
                        {

                            RecorderOptions options = new RecorderOptions
                            {
                                RecorderMode = RecorderMode.Video,
                                //If throttling is disabled, out of memory exceptions may eventually crash the program,
                                //depending on encoder settings and system specifications.
                                IsThrottlingDisabled = false,
                                //Hardware encoding is enabled by default.
                                IsHardwareEncodingEnabled = true,
                                //Low latency mode provides faster encoding, but can reduce quality.
                                IsLowLatencyEnabled = false,
                                //Fast start writes the mp4 header at the beginning of the file, to facilitate streaming.
                                IsMp4FastStartEnabled = false,
                                VideoOptions = new VideoOptions
                                {
                                    Framerate = 40,
                                    IsFixedFramerate = true,
                                },
                                MouseOptions = new MouseOptions
                                {
                                    //Displays a colored dot under the mouse cursor when the left mouse button is pressed.	
                                    IsMouseClicksDetected = true,
                                    MouseClickDetectionColor = "#FFFF00",
                                    MouseRightClickDetectionColor = "#FFFF00",
                                    MouseClickDetectionRadius = 30,
                                    MouseClickDetectionDuration = 60,
                                    IsMousePointerEnabled = true,
                                    /* Polling checks every millisecond if a mouse button is pressed.
                                       Hook works better with programmatically generated mouse clicks, but may affect
                                       mouse performance and interferes with debugging.*/
                                    MouseClickDetectionMode = MouseDetectionMode.Hook
                                },
                                AudioOptions = new AudioOptions
                                {
                                    Bitrate = AudioBitrate.bitrate_128kbps,
                                    Channels = AudioChannels.Stereo,
                                    IsAudioEnabled = true
                                }
                            };

                            _rec = Recorder.CreateRecorder(options);

                        }
                        else if (OpenRecorder_Studio.Properties.Settings.Default.FPS == "50")
                        {

                            RecorderOptions options = new RecorderOptions
                            {
                                RecorderMode = RecorderMode.Video,
                                //If throttling is disabled, out of memory exceptions may eventually crash the program,
                                //depending on encoder settings and system specifications.
                                IsThrottlingDisabled = false,
                                //Hardware encoding is enabled by default.
                                IsHardwareEncodingEnabled = true,
                                //Low latency mode provides faster encoding, but can reduce quality.
                                IsLowLatencyEnabled = false,
                                //Fast start writes the mp4 header at the beginning of the file, to facilitate streaming.
                                IsMp4FastStartEnabled = false,
                                VideoOptions = new VideoOptions
                                {
                                    Framerate = 50,
                                    IsFixedFramerate = true,
                                },
                                MouseOptions = new MouseOptions
                                {
                                    //Displays a colored dot under the mouse cursor when the left mouse button is pressed.	
                                    IsMouseClicksDetected = true,
                                    MouseClickDetectionColor = "#FFFF00",
                                    MouseRightClickDetectionColor = "#FFFF00",
                                    MouseClickDetectionRadius = 30,
                                    MouseClickDetectionDuration = 60,
                                    IsMousePointerEnabled = true,
                                    /* Polling checks every millisecond if a mouse button is pressed.
                                       Hook works better with programmatically generated mouse clicks, but may affect
                                       mouse performance and interferes with debugging.*/
                                    MouseClickDetectionMode = MouseDetectionMode.Hook
                                },
                                AudioOptions = new AudioOptions
                                {
                                    Bitrate = AudioBitrate.bitrate_128kbps,
                                    Channels = AudioChannels.Stereo,
                                    IsAudioEnabled = true
                                }
                            };

                            _rec = Recorder.CreateRecorder(options);

                        }
                        else if (OpenRecorder_Studio.Properties.Settings.Default.FPS == "60")
                        {

                            RecorderOptions options = new RecorderOptions
                            {
                                RecorderMode = RecorderMode.Video,
                                //If throttling is disabled, out of memory exceptions may eventually crash the program,
                                //depending on encoder settings and system specifications.
                                IsThrottlingDisabled = false,
                                //Hardware encoding is enabled by default.
                                IsHardwareEncodingEnabled = true,
                                //Low latency mode provides faster encoding, but can reduce quality.
                                IsLowLatencyEnabled = false,
                                //Fast start writes the mp4 header at the beginning of the file, to facilitate streaming.
                                IsMp4FastStartEnabled = false,
                                VideoOptions = new VideoOptions
                                {
                                    Framerate = 60,
                                    IsFixedFramerate = true,
                                },
                                MouseOptions = new MouseOptions
                                {
                                    //Displays a colored dot under the mouse cursor when the left mouse button is pressed.	
                                    IsMouseClicksDetected = true,
                                    MouseClickDetectionColor = "#FFFF00",
                                    MouseRightClickDetectionColor = "#FFFF00",
                                    MouseClickDetectionRadius = 30,
                                    MouseClickDetectionDuration = 60,
                                    IsMousePointerEnabled = true,
                                    /* Polling checks every millisecond if a mouse button is pressed.
                                       Hook works better with programmatically generated mouse clicks, but may affect
                                       mouse performance and interferes with debugging.*/
                                    MouseClickDetectionMode = MouseDetectionMode.Hook
                                },
                                AudioOptions = new AudioOptions
                                {
                                    Bitrate = AudioBitrate.bitrate_128kbps,
                                    Channels = AudioChannels.Stereo,
                                    IsAudioEnabled = true
                                }
                            };

                            _rec = Recorder.CreateRecorder(options);

                        }
                        else if (OpenRecorder_Studio.Properties.Settings.Default.FPS == "70")
                        {

                            RecorderOptions options = new RecorderOptions
                            {
                                RecorderMode = RecorderMode.Video,
                                //If throttling is disabled, out of memory exceptions may eventually crash the program,
                                //depending on encoder settings and system specifications.
                                IsThrottlingDisabled = false,
                                //Hardware encoding is enabled by default.
                                IsHardwareEncodingEnabled = true,
                                //Low latency mode provides faster encoding, but can reduce quality.
                                IsLowLatencyEnabled = false,
                                //Fast start writes the mp4 header at the beginning of the file, to facilitate streaming.
                                IsMp4FastStartEnabled = false,
                                VideoOptions = new VideoOptions
                                {
                                    Framerate = 70,
                                    IsFixedFramerate = true,
                                },
                                MouseOptions = new MouseOptions
                                {
                                    //Displays a colored dot under the mouse cursor when the left mouse button is pressed.	
                                    IsMouseClicksDetected = true,
                                    MouseClickDetectionColor = "#FFFF00",
                                    MouseRightClickDetectionColor = "#FFFF00",
                                    MouseClickDetectionRadius = 30,
                                    MouseClickDetectionDuration = 60,
                                    IsMousePointerEnabled = true,
                                    /* Polling checks every millisecond if a mouse button is pressed.
                                       Hook works better with programmatically generated mouse clicks, but may affect
                                       mouse performance and interferes with debugging.*/
                                    MouseClickDetectionMode = MouseDetectionMode.Hook
                                },
                                AudioOptions = new AudioOptions
                                {
                                    Bitrate = AudioBitrate.bitrate_128kbps,
                                    Channels = AudioChannels.Stereo,
                                    IsAudioEnabled = true
                                }
                            };

                            _rec = Recorder.CreateRecorder(options);

                        }
                        else if (OpenRecorder_Studio.Properties.Settings.Default.FPS == "80")
                        {

                            RecorderOptions options = new RecorderOptions
                            {
                                RecorderMode = RecorderMode.Video,
                                //If throttling is disabled, out of memory exceptions may eventually crash the program,
                                //depending on encoder settings and system specifications.
                                IsThrottlingDisabled = false,
                                //Hardware encoding is enabled by default.
                                IsHardwareEncodingEnabled = true,
                                //Low latency mode provides faster encoding, but can reduce quality.
                                IsLowLatencyEnabled = false,
                                //Fast start writes the mp4 header at the beginning of the file, to facilitate streaming.
                                IsMp4FastStartEnabled = false,
                                VideoOptions = new VideoOptions
                                {
                                    Framerate = 80,
                                    IsFixedFramerate = true,
                                },
                                MouseOptions = new MouseOptions
                                {
                                    //Displays a colored dot under the mouse cursor when the left mouse button is pressed.	
                                    IsMouseClicksDetected = true,
                                    MouseClickDetectionColor = "#FFFF00",
                                    MouseRightClickDetectionColor = "#FFFF00",
                                    MouseClickDetectionRadius = 30,
                                    MouseClickDetectionDuration = 60,
                                    IsMousePointerEnabled = true,
                                    /* Polling checks every millisecond if a mouse button is pressed.
                                       Hook works better with programmatically generated mouse clicks, but may affect
                                       mouse performance and interferes with debugging.*/
                                    MouseClickDetectionMode = MouseDetectionMode.Hook
                                },
                                AudioOptions = new AudioOptions
                                {
                                    Bitrate = AudioBitrate.bitrate_128kbps,
                                    Channels = AudioChannels.Stereo,
                                    IsAudioEnabled = true
                                }
                            };

                            _rec = Recorder.CreateRecorder(options);

                        }
                        else if (OpenRecorder_Studio.Properties.Settings.Default.FPS == "90")
                        {

                            RecorderOptions options = new RecorderOptions
                            {
                                RecorderMode = RecorderMode.Video,
                                //If throttling is disabled, out of memory exceptions may eventually crash the program,
                                //depending on encoder settings and system specifications.
                                IsThrottlingDisabled = false,
                                //Hardware encoding is enabled by default.
                                IsHardwareEncodingEnabled = true,
                                //Low latency mode provides faster encoding, but can reduce quality.
                                IsLowLatencyEnabled = false,
                                //Fast start writes the mp4 header at the beginning of the file, to facilitate streaming.
                                IsMp4FastStartEnabled = false,
                                VideoOptions = new VideoOptions
                                {
                                    Framerate = 90,
                                    IsFixedFramerate = true,
                                },
                                MouseOptions = new MouseOptions
                                {
                                    //Displays a colored dot under the mouse cursor when the left mouse button is pressed.	
                                    IsMouseClicksDetected = true,
                                    MouseClickDetectionColor = "#FFFF00",
                                    MouseRightClickDetectionColor = "#FFFF00",
                                    MouseClickDetectionRadius = 30,
                                    MouseClickDetectionDuration = 60,
                                    IsMousePointerEnabled = true,
                                    /* Polling checks every millisecond if a mouse button is pressed.
                                       Hook works better with programmatically generated mouse clicks, but may affect
                                       mouse performance and interferes with debugging.*/
                                    MouseClickDetectionMode = MouseDetectionMode.Hook
                                },
                                AudioOptions = new AudioOptions
                                {
                                    Bitrate = AudioBitrate.bitrate_128kbps,
                                    Channels = AudioChannels.Stereo,
                                    IsAudioEnabled = true
                                }
                            };

                            _rec = Recorder.CreateRecorder(options);

                        }
                        else if (OpenRecorder_Studio.Properties.Settings.Default.FPS == "100")
                        {

                            RecorderOptions options = new RecorderOptions
                            {
                                RecorderMode = RecorderMode.Video,
                                //If throttling is disabled, out of memory exceptions may eventually crash the program,
                                //depending on encoder settings and system specifications.
                                IsThrottlingDisabled = false,
                                //Hardware encoding is enabled by default.
                                IsHardwareEncodingEnabled = true,
                                //Low latency mode provides faster encoding, but can reduce quality.
                                IsLowLatencyEnabled = false,
                                //Fast start writes the mp4 header at the beginning of the file, to facilitate streaming.
                                IsMp4FastStartEnabled = false,
                                VideoOptions = new VideoOptions
                                {
                                    Framerate = 100,
                                    IsFixedFramerate = true,
                                },
                                MouseOptions = new MouseOptions
                                {
                                    //Displays a colored dot under the mouse cursor when the left mouse button is pressed.	
                                    IsMouseClicksDetected = true,
                                    MouseClickDetectionColor = "#FFFF00",
                                    MouseRightClickDetectionColor = "#FFFF00",
                                    MouseClickDetectionRadius = 30,
                                    MouseClickDetectionDuration = 60,
                                    IsMousePointerEnabled = true,
                                    /* Polling checks every millisecond if a mouse button is pressed.
                                       Hook works better with programmatically generated mouse clicks, but may affect
                                       mouse performance and interferes with debugging.*/
                                    MouseClickDetectionMode = MouseDetectionMode.Hook
                                },
                                AudioOptions = new AudioOptions
                                {
                                    Bitrate = AudioBitrate.bitrate_128kbps,
                                    Channels = AudioChannels.Stereo,
                                    IsAudioEnabled = true
                                }
                            };

                            _rec = Recorder.CreateRecorder(options);

                        }
                        else if (OpenRecorder_Studio.Properties.Settings.Default.FPS == "150")
                        {

                            RecorderOptions options = new RecorderOptions
                            {
                                RecorderMode = RecorderMode.Video,
                                //If throttling is disabled, out of memory exceptions may eventually crash the program,
                                //depending on encoder settings and system specifications.
                                IsThrottlingDisabled = false,
                                //Hardware encoding is enabled by default.
                                IsHardwareEncodingEnabled = true,
                                //Low latency mode provides faster encoding, but can reduce quality.
                                IsLowLatencyEnabled = false,
                                //Fast start writes the mp4 header at the beginning of the file, to facilitate streaming.
                                IsMp4FastStartEnabled = false,
                                VideoOptions = new VideoOptions
                                {
                                    Framerate = 150,
                                    IsFixedFramerate = true,
                                },
                                MouseOptions = new MouseOptions
                                {
                                    //Displays a colored dot under the mouse cursor when the left mouse button is pressed.	
                                    IsMouseClicksDetected = true,
                                    MouseClickDetectionColor = "#FFFF00",
                                    MouseRightClickDetectionColor = "#FFFF00",
                                    MouseClickDetectionRadius = 30,
                                    MouseClickDetectionDuration = 60,
                                    IsMousePointerEnabled = true,
                                    /* Polling checks every millisecond if a mouse button is pressed.
                                       Hook works better with programmatically generated mouse clicks, but may affect
                                       mouse performance and interferes with debugging.*/
                                    MouseClickDetectionMode = MouseDetectionMode.Hook
                                },
                                AudioOptions = new AudioOptions
                                {
                                    Bitrate = AudioBitrate.bitrate_128kbps,
                                    Channels = AudioChannels.Stereo,
                                    IsAudioEnabled = true
                                }
                            };

                            _rec = Recorder.CreateRecorder(options);

                        }
                        else if (OpenRecorder_Studio.Properties.Settings.Default.FPS == "200")
                        {

                            RecorderOptions options = new RecorderOptions
                            {
                                RecorderMode = RecorderMode.Video,
                                //If throttling is disabled, out of memory exceptions may eventually crash the program,
                                //depending on encoder settings and system specifications.
                                IsThrottlingDisabled = false,
                                //Hardware encoding is enabled by default.
                                IsHardwareEncodingEnabled = true,
                                //Low latency mode provides faster encoding, but can reduce quality.
                                IsLowLatencyEnabled = false,
                                //Fast start writes the mp4 header at the beginning of the file, to facilitate streaming.
                                IsMp4FastStartEnabled = false,
                                VideoOptions = new VideoOptions
                                {
                                    Framerate = 200,
                                    IsFixedFramerate = true,
                                },
                                MouseOptions = new MouseOptions
                                {
                                    //Displays a colored dot under the mouse cursor when the left mouse button is pressed.	
                                    IsMouseClicksDetected = true,
                                    MouseClickDetectionColor = "#FFFF00",
                                    MouseRightClickDetectionColor = "#FFFF00",
                                    MouseClickDetectionRadius = 30,
                                    MouseClickDetectionDuration = 60,
                                    IsMousePointerEnabled = true,
                                    /* Polling checks every millisecond if a mouse button is pressed.
                                       Hook works better with programmatically generated mouse clicks, but may affect
                                       mouse performance and interferes with debugging.*/
                                    MouseClickDetectionMode = MouseDetectionMode.Hook
                                },
                                AudioOptions = new AudioOptions
                                {
                                    Bitrate = AudioBitrate.bitrate_128kbps,
                                    Channels = AudioChannels.Stereo,
                                    IsAudioEnabled = true
                                }
                            };

                            _rec = Recorder.CreateRecorder(options);

                        }

                    }
                    else
                    {

                        if (OpenRecorder_Studio.Properties.Settings.Default.FPS == "10")
                        {

                            RecorderOptions options = new RecorderOptions
                            {
                                RecorderMode = RecorderMode.Video,
                                //If throttling is disabled, out of memory exceptions may eventually crash the program,
                                //depending on encoder settings and system specifications.
                                IsThrottlingDisabled = false,
                                //Hardware encoding is enabled by default.
                                IsHardwareEncodingEnabled = true,
                                //Low latency mode provides faster encoding, but can reduce quality.
                                IsLowLatencyEnabled = false,
                                //Fast start writes the mp4 header at the beginning of the file, to facilitate streaming.
                                IsMp4FastStartEnabled = false,
                                VideoOptions = new VideoOptions
                                {
                                    Framerate = 10,
                                    IsFixedFramerate = true,
                                },
                                MouseOptions = new MouseOptions
                                {
                                    //Displays a colored dot under the mouse cursor when the left mouse button is pressed.	
                                    IsMouseClicksDetected = true,
                                    MouseClickDetectionColor = "#FFFF00",
                                    MouseRightClickDetectionColor = "#FFFF00",
                                    MouseClickDetectionRadius = 30,
                                    MouseClickDetectionDuration = 60,
                                    IsMousePointerEnabled = true,
                                    /* Polling checks every millisecond if a mouse button is pressed.
                                       Hook works better with programmatically generated mouse clicks, but may affect
                                       mouse performance and interferes with debugging.*/
                                    MouseClickDetectionMode = MouseDetectionMode.Hook
                                }
                            };

                            _rec = Recorder.CreateRecorder(options);

                        }
                        else if (OpenRecorder_Studio.Properties.Settings.Default.FPS == "20")
                        {

                            RecorderOptions options = new RecorderOptions
                            {
                                RecorderMode = RecorderMode.Video,
                                //If throttling is disabled, out of memory exceptions may eventually crash the program,
                                //depending on encoder settings and system specifications.
                                IsThrottlingDisabled = false,
                                //Hardware encoding is enabled by default.
                                IsHardwareEncodingEnabled = true,
                                //Low latency mode provides faster encoding, but can reduce quality.
                                IsLowLatencyEnabled = false,
                                //Fast start writes the mp4 header at the beginning of the file, to facilitate streaming.
                                IsMp4FastStartEnabled = false,
                                VideoOptions = new VideoOptions
                                {
                                    Framerate = 20,
                                    IsFixedFramerate = true,
                                },
                                MouseOptions = new MouseOptions
                                {
                                    //Displays a colored dot under the mouse cursor when the left mouse button is pressed.	
                                    IsMouseClicksDetected = true,
                                    MouseClickDetectionColor = "#FFFF00",
                                    MouseRightClickDetectionColor = "#FFFF00",
                                    MouseClickDetectionRadius = 30,
                                    MouseClickDetectionDuration = 60,
                                    IsMousePointerEnabled = true,
                                    /* Polling checks every millisecond if a mouse button is pressed.
                                       Hook works better with programmatically generated mouse clicks, but may affect
                                       mouse performance and interferes with debugging.*/
                                    MouseClickDetectionMode = MouseDetectionMode.Hook
                                }
                            };

                            _rec = Recorder.CreateRecorder(options);

                        }
                        else if (OpenRecorder_Studio.Properties.Settings.Default.FPS == "30")
                        {

                            RecorderOptions options = new RecorderOptions
                            {
                                RecorderMode = RecorderMode.Video,
                                //If throttling is disabled, out of memory exceptions may eventually crash the program,
                                //depending on encoder settings and system specifications.
                                IsThrottlingDisabled = false,
                                //Hardware encoding is enabled by default.
                                IsHardwareEncodingEnabled = true,
                                //Low latency mode provides faster encoding, but can reduce quality.
                                IsLowLatencyEnabled = false,
                                //Fast start writes the mp4 header at the beginning of the file, to facilitate streaming.
                                IsMp4FastStartEnabled = false,
                                VideoOptions = new VideoOptions
                                {
                                    Framerate = 30,
                                    IsFixedFramerate = true,
                                },
                                MouseOptions = new MouseOptions
                                {
                                    //Displays a colored dot under the mouse cursor when the left mouse button is pressed.	
                                    IsMouseClicksDetected = true,
                                    MouseClickDetectionColor = "#FFFF00",
                                    MouseRightClickDetectionColor = "#FFFF00",
                                    MouseClickDetectionRadius = 30,
                                    MouseClickDetectionDuration = 60,
                                    IsMousePointerEnabled = true,
                                    /* Polling checks every millisecond if a mouse button is pressed.
                                       Hook works better with programmatically generated mouse clicks, but may affect
                                       mouse performance and interferes with debugging.*/
                                    MouseClickDetectionMode = MouseDetectionMode.Hook
                                }
                            };

                            _rec = Recorder.CreateRecorder(options);

                        }
                        else if (OpenRecorder_Studio.Properties.Settings.Default.FPS == "40")
                        {

                            RecorderOptions options = new RecorderOptions
                            {
                                RecorderMode = RecorderMode.Video,
                                //If throttling is disabled, out of memory exceptions may eventually crash the program,
                                //depending on encoder settings and system specifications.
                                IsThrottlingDisabled = false,
                                //Hardware encoding is enabled by default.
                                IsHardwareEncodingEnabled = true,
                                //Low latency mode provides faster encoding, but can reduce quality.
                                IsLowLatencyEnabled = false,
                                //Fast start writes the mp4 header at the beginning of the file, to facilitate streaming.
                                IsMp4FastStartEnabled = false,
                                VideoOptions = new VideoOptions
                                {
                                    Framerate = 40,
                                    IsFixedFramerate = true,
                                },
                                MouseOptions = new MouseOptions
                                {
                                    //Displays a colored dot under the mouse cursor when the left mouse button is pressed.	
                                    IsMouseClicksDetected = true,
                                    MouseClickDetectionColor = "#FFFF00",
                                    MouseRightClickDetectionColor = "#FFFF00",
                                    MouseClickDetectionRadius = 30,
                                    MouseClickDetectionDuration = 60,
                                    IsMousePointerEnabled = true,
                                    /* Polling checks every millisecond if a mouse button is pressed.
                                       Hook works better with programmatically generated mouse clicks, but may affect
                                       mouse performance and interferes with debugging.*/
                                    MouseClickDetectionMode = MouseDetectionMode.Hook
                                }
                            };

                            _rec = Recorder.CreateRecorder(options);

                        }
                        else if (OpenRecorder_Studio.Properties.Settings.Default.FPS == "50")
                        {

                            RecorderOptions options = new RecorderOptions
                            {
                                RecorderMode = RecorderMode.Video,
                                //If throttling is disabled, out of memory exceptions may eventually crash the program,
                                //depending on encoder settings and system specifications.
                                IsThrottlingDisabled = false,
                                //Hardware encoding is enabled by default.
                                IsHardwareEncodingEnabled = true,
                                //Low latency mode provides faster encoding, but can reduce quality.
                                IsLowLatencyEnabled = false,
                                //Fast start writes the mp4 header at the beginning of the file, to facilitate streaming.
                                IsMp4FastStartEnabled = false,
                                VideoOptions = new VideoOptions
                                {
                                    Framerate = 50,
                                    IsFixedFramerate = true,
                                },
                                MouseOptions = new MouseOptions
                                {
                                    //Displays a colored dot under the mouse cursor when the left mouse button is pressed.	
                                    IsMouseClicksDetected = true,
                                    MouseClickDetectionColor = "#FFFF00",
                                    MouseRightClickDetectionColor = "#FFFF00",
                                    MouseClickDetectionRadius = 30,
                                    MouseClickDetectionDuration = 60,
                                    IsMousePointerEnabled = true,
                                    /* Polling checks every millisecond if a mouse button is pressed.
                                       Hook works better with programmatically generated mouse clicks, but may affect
                                       mouse performance and interferes with debugging.*/
                                    MouseClickDetectionMode = MouseDetectionMode.Hook
                                }
                            };

                            _rec = Recorder.CreateRecorder(options);

                        }
                        else if (OpenRecorder_Studio.Properties.Settings.Default.FPS == "60")
                        {

                            RecorderOptions options = new RecorderOptions
                            {
                                RecorderMode = RecorderMode.Video,
                                //If throttling is disabled, out of memory exceptions may eventually crash the program,
                                //depending on encoder settings and system specifications.
                                IsThrottlingDisabled = false,
                                //Hardware encoding is enabled by default.
                                IsHardwareEncodingEnabled = true,
                                //Low latency mode provides faster encoding, but can reduce quality.
                                IsLowLatencyEnabled = false,
                                //Fast start writes the mp4 header at the beginning of the file, to facilitate streaming.
                                IsMp4FastStartEnabled = false,
                                VideoOptions = new VideoOptions
                                {
                                    Framerate = 60,
                                    IsFixedFramerate = true,
                                },
                                MouseOptions = new MouseOptions
                                {
                                    //Displays a colored dot under the mouse cursor when the left mouse button is pressed.	
                                    IsMouseClicksDetected = true,
                                    MouseClickDetectionColor = "#FFFF00",
                                    MouseRightClickDetectionColor = "#FFFF00",
                                    MouseClickDetectionRadius = 30,
                                    MouseClickDetectionDuration = 60,
                                    IsMousePointerEnabled = true,
                                    /* Polling checks every millisecond if a mouse button is pressed.
                                       Hook works better with programmatically generated mouse clicks, but may affect
                                       mouse performance and interferes with debugging.*/
                                    MouseClickDetectionMode = MouseDetectionMode.Hook
                                }
                            };

                            _rec = Recorder.CreateRecorder(options);

                        }
                        else if (OpenRecorder_Studio.Properties.Settings.Default.FPS == "70")
                        {

                            RecorderOptions options = new RecorderOptions
                            {
                                RecorderMode = RecorderMode.Video,
                                //If throttling is disabled, out of memory exceptions may eventually crash the program,
                                //depending on encoder settings and system specifications.
                                IsThrottlingDisabled = false,
                                //Hardware encoding is enabled by default.
                                IsHardwareEncodingEnabled = true,
                                //Low latency mode provides faster encoding, but can reduce quality.
                                IsLowLatencyEnabled = false,
                                //Fast start writes the mp4 header at the beginning of the file, to facilitate streaming.
                                IsMp4FastStartEnabled = false,
                                VideoOptions = new VideoOptions
                                {
                                    Framerate = 70,
                                    IsFixedFramerate = true,
                                },
                                MouseOptions = new MouseOptions
                                {
                                    //Displays a colored dot under the mouse cursor when the left mouse button is pressed.	
                                    IsMouseClicksDetected = true,
                                    MouseClickDetectionColor = "#FFFF00",
                                    MouseRightClickDetectionColor = "#FFFF00",
                                    MouseClickDetectionRadius = 30,
                                    MouseClickDetectionDuration = 60,
                                    IsMousePointerEnabled = true,
                                    /* Polling checks every millisecond if a mouse button is pressed.
                                       Hook works better with programmatically generated mouse clicks, but may affect
                                       mouse performance and interferes with debugging.*/
                                    MouseClickDetectionMode = MouseDetectionMode.Hook
                                }
                            };

                            _rec = Recorder.CreateRecorder(options);

                        }
                        else if (OpenRecorder_Studio.Properties.Settings.Default.FPS == "80")
                        {

                            RecorderOptions options = new RecorderOptions
                            {
                                RecorderMode = RecorderMode.Video,
                                //If throttling is disabled, out of memory exceptions may eventually crash the program,
                                //depending on encoder settings and system specifications.
                                IsThrottlingDisabled = false,
                                //Hardware encoding is enabled by default.
                                IsHardwareEncodingEnabled = true,
                                //Low latency mode provides faster encoding, but can reduce quality.
                                IsLowLatencyEnabled = false,
                                //Fast start writes the mp4 header at the beginning of the file, to facilitate streaming.
                                IsMp4FastStartEnabled = false,
                                VideoOptions = new VideoOptions
                                {
                                    Framerate = 80,
                                    IsFixedFramerate = true,
                                },
                                MouseOptions = new MouseOptions
                                {
                                    //Displays a colored dot under the mouse cursor when the left mouse button is pressed.	
                                    IsMouseClicksDetected = true,
                                    MouseClickDetectionColor = "#FFFF00",
                                    MouseRightClickDetectionColor = "#FFFF00",
                                    MouseClickDetectionRadius = 30,
                                    MouseClickDetectionDuration = 60,
                                    IsMousePointerEnabled = true,
                                    /* Polling checks every millisecond if a mouse button is pressed.
                                       Hook works better with programmatically generated mouse clicks, but may affect
                                       mouse performance and interferes with debugging.*/
                                    MouseClickDetectionMode = MouseDetectionMode.Hook
                                }
                            };

                            _rec = Recorder.CreateRecorder(options);

                        }
                        else if (OpenRecorder_Studio.Properties.Settings.Default.FPS == "90")
                        {

                            RecorderOptions options = new RecorderOptions
                            {
                                RecorderMode = RecorderMode.Video,
                                //If throttling is disabled, out of memory exceptions may eventually crash the program,
                                //depending on encoder settings and system specifications.
                                IsThrottlingDisabled = false,
                                //Hardware encoding is enabled by default.
                                IsHardwareEncodingEnabled = true,
                                //Low latency mode provides faster encoding, but can reduce quality.
                                IsLowLatencyEnabled = false,
                                //Fast start writes the mp4 header at the beginning of the file, to facilitate streaming.
                                IsMp4FastStartEnabled = false,
                                VideoOptions = new VideoOptions
                                {
                                    Framerate = 90,
                                    IsFixedFramerate = true,
                                },
                                MouseOptions = new MouseOptions
                                {
                                    //Displays a colored dot under the mouse cursor when the left mouse button is pressed.	
                                    IsMouseClicksDetected = true,
                                    MouseClickDetectionColor = "#FFFF00",
                                    MouseRightClickDetectionColor = "#FFFF00",
                                    MouseClickDetectionRadius = 30,
                                    MouseClickDetectionDuration = 60,
                                    IsMousePointerEnabled = true,
                                    /* Polling checks every millisecond if a mouse button is pressed.
                                       Hook works better with programmatically generated mouse clicks, but may affect
                                       mouse performance and interferes with debugging.*/
                                    MouseClickDetectionMode = MouseDetectionMode.Hook
                                }
                            };

                            _rec = Recorder.CreateRecorder(options);

                        }
                        else if (OpenRecorder_Studio.Properties.Settings.Default.FPS == "100")
                        {

                            RecorderOptions options = new RecorderOptions
                            {
                                RecorderMode = RecorderMode.Video,
                                //If throttling is disabled, out of memory exceptions may eventually crash the program,
                                //depending on encoder settings and system specifications.
                                IsThrottlingDisabled = false,
                                //Hardware encoding is enabled by default.
                                IsHardwareEncodingEnabled = true,
                                //Low latency mode provides faster encoding, but can reduce quality.
                                IsLowLatencyEnabled = false,
                                //Fast start writes the mp4 header at the beginning of the file, to facilitate streaming.
                                IsMp4FastStartEnabled = false,
                                VideoOptions = new VideoOptions
                                {
                                    Framerate = 100,
                                    IsFixedFramerate = true,
                                },
                                MouseOptions = new MouseOptions
                                {
                                    //Displays a colored dot under the mouse cursor when the left mouse button is pressed.	
                                    IsMouseClicksDetected = true,
                                    MouseClickDetectionColor = "#FFFF00",
                                    MouseRightClickDetectionColor = "#FFFF00",
                                    MouseClickDetectionRadius = 30,
                                    MouseClickDetectionDuration = 60,
                                    IsMousePointerEnabled = true,
                                    /* Polling checks every millisecond if a mouse button is pressed.
                                       Hook works better with programmatically generated mouse clicks, but may affect
                                       mouse performance and interferes with debugging.*/
                                    MouseClickDetectionMode = MouseDetectionMode.Hook
                                }
                            };

                            _rec = Recorder.CreateRecorder(options);

                        }
                        else if (OpenRecorder_Studio.Properties.Settings.Default.FPS == "150")
                        {

                            RecorderOptions options = new RecorderOptions
                            {
                                RecorderMode = RecorderMode.Video,
                                //If throttling is disabled, out of memory exceptions may eventually crash the program,
                                //depending on encoder settings and system specifications.
                                IsThrottlingDisabled = false,
                                //Hardware encoding is enabled by default.
                                IsHardwareEncodingEnabled = true,
                                //Low latency mode provides faster encoding, but can reduce quality.
                                IsLowLatencyEnabled = false,
                                //Fast start writes the mp4 header at the beginning of the file, to facilitate streaming.
                                IsMp4FastStartEnabled = false,
                                VideoOptions = new VideoOptions
                                {
                                    Framerate = 150,
                                    IsFixedFramerate = true,
                                },
                                MouseOptions = new MouseOptions
                                {
                                    //Displays a colored dot under the mouse cursor when the left mouse button is pressed.	
                                    IsMouseClicksDetected = true,
                                    MouseClickDetectionColor = "#FFFF00",
                                    MouseRightClickDetectionColor = "#FFFF00",
                                    MouseClickDetectionRadius = 30,
                                    MouseClickDetectionDuration = 60,
                                    IsMousePointerEnabled = true,
                                    /* Polling checks every millisecond if a mouse button is pressed.
                                       Hook works better with programmatically generated mouse clicks, but may affect
                                       mouse performance and interferes with debugging.*/
                                    MouseClickDetectionMode = MouseDetectionMode.Hook
                                }
                            };

                            _rec = Recorder.CreateRecorder(options);

                        }
                        else if (OpenRecorder_Studio.Properties.Settings.Default.FPS == "200")
                        {

                            RecorderOptions options = new RecorderOptions
                            {
                                RecorderMode = RecorderMode.Video,
                                //If throttling is disabled, out of memory exceptions may eventually crash the program,
                                //depending on encoder settings and system specifications.
                                IsThrottlingDisabled = false,
                                //Hardware encoding is enabled by default.
                                IsHardwareEncodingEnabled = true,
                                //Low latency mode provides faster encoding, but can reduce quality.
                                IsLowLatencyEnabled = false,
                                //Fast start writes the mp4 header at the beginning of the file, to facilitate streaming.
                                IsMp4FastStartEnabled = false,
                                VideoOptions = new VideoOptions
                                {
                                    Framerate = 200,
                                    IsFixedFramerate = true,
                                },
                                MouseOptions = new MouseOptions
                                {
                                    //Displays a colored dot under the mouse cursor when the left mouse button is pressed.	
                                    IsMouseClicksDetected = true,
                                    MouseClickDetectionColor = "#FFFF00",
                                    MouseRightClickDetectionColor = "#FFFF00",
                                    MouseClickDetectionRadius = 30,
                                    MouseClickDetectionDuration = 60,
                                    IsMousePointerEnabled = true,
                                    /* Polling checks every millisecond if a mouse button is pressed.
                                       Hook works better with programmatically generated mouse clicks, but may affect
                                       mouse performance and interferes with debugging.*/
                                    MouseClickDetectionMode = MouseDetectionMode.Hook
                                }
                            };

                            _rec = Recorder.CreateRecorder(options);

                        }

                    }
                    _rec.OnRecordingComplete += _rec_OnRecordingComplete;
                    _rec.OnRecordingFailed += _rec_OnRecordingFailed;
                    _rec.OnStatusChanged += _rec_OnStatusChanged;
                }

                _rec.Record(videopath);
                _secondsElapsed = 0;
                _IsRecording = true;
                CorrectTimer.Start();
                btnPauseRecording.Enabled = true;

            }
            catch (Exception)
            {
                //
            }
        }

        private void LoadDevices()
        {
            for (int deviceId = 0; deviceId < WaveIn.DeviceCount; deviceId++)
            {
                var deviceInfo = WaveIn.GetCapabilities(deviceId);
            }

            for (int deviceId = 0; deviceId < WaveOut.DeviceCount; deviceId++)
            {
                var deviceInfo = WaveOut.GetCapabilities(deviceId);
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
                    txtOutput.Text = "Screen recording resumed.";

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
            if (Directory.Exists(_CURRRENT_DIR2))
            {

            }
            else
            {
                Directory.CreateDirectory(_CURRRENT_DIR2);
            }

            string datetime1 = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss");
            this.Hide();
            using (var bt = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
Screen.PrimaryScreen.Bounds.Height))
            {
                sfd.InitialDirectory = _CURRRENT_DIR2;
                sfd.ShowDialog();
                Graphics g = Graphics.FromImage(bt);
                g.CopyFromScreen(0, 0, 0, 0, bt.Size);
                string name = sfd.FileName;
                try
                {
                    if (sfd.Filter.Contains(".jpg"))
                    {
                        bt.Save(name, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    else if (sfd.Filter.Contains(".png"))
                    {
                        bt.Save(name, System.Drawing.Imaging.ImageFormat.Png);
                    }
                    else
                    {
                        MessageBox.Show("Unknown file extension.");
                    }
                }
                catch
                {

                }
            }
            this.Show();
            this.TopMost = true;
            this.TopMost = false;
        }

        private void btnStartStreaming_Click(object sender, EventArgs e)
        {
            MSG.Style = Guna.UI2.WinForms.MessageDialogStyle.Dark;
            MSG.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
            MSG.Caption = "Feature unavailable.";
            MSG.Text = "Sorry, this feature is currently under dev.";
            MSG.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {

            btnTools.Checked = false;
            btnPlugins.Checked = false;
            btnSettings2.Checked = false;

            if (btnAccount.Checked == true)
            {

                pnAccounts.Show();
                pnTools.Hide();
                pnPlugins.Hide();
                pnSettings2.Hide();

            }
            else if (btnAccount.Checked == false)
            {

                pnAccounts.Hide();

            }
        }

        private void btnTools_Click(object sender, EventArgs e)
        {

            btnAccount.Checked = false;
            btnPlugins.Checked = false;
            btnSettings2.Checked = false;

            if (btnTools.Checked == true)
            {

                pnTools.Show();
                pnAccounts.Hide();
                pnPlugins.Hide();
                pnSettings2.Hide();

            }
            else if (btnTools.Checked == false)
            {

                pnTools.Hide();

            }
        }

        private void btnSupport_Click(object sender, EventArgs e)
        {
            Process.Start("https://discord.io/recorder");
            MSG.Style = Guna.UI2.WinForms.MessageDialogStyle.Dark;
            MSG.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
            MSG.Caption = "Discord Server Launched.";
            MSG.Text = "Join our discord server to get support.";
            MSG.Show();
        }

        private void btnOpenNote_Click(object sender, EventArgs e)
        {
            pnTools.Hide();
            Form newForm = new OpenRecorder_Studio.OpenNote();    
            newForm.ShowDialog();
        }

        private void btnCloseTools_Click(object sender, EventArgs e)
        {
            pnTools.Hide();
        }

        private void btnOpenBrowser_Click(object sender, EventArgs e)
        {
            pnTools.Hide();
            if (File.Exists("OpenBrowser.exe"))
            {
                Process.Start("OpenBrowser.exe");
            }
            else
            {
                DialogResult d = MessageBox.Show("OpenBrowser was not found on your computer, would you like to install it?", "Download & Install OpenBrowser", MessageBoxButtons.YesNo);
                if (d == DialogResult.Yes)
                {
                    var client = new WebClient();
                    client.DownloadFile("https://jyjuuj.000webhostapp.com/update/OpenBrowser.zip", "OpenBrowser.zip");
                    string zipPath = @".\OpenBrowser.zip";
                    string extractPath = @".\";
                    ZipFile.ExtractToDirectory(zipPath, extractPath);
                    File.Delete("OpenBrowser.zip");
                    Process.Start("OpenBrowser.exe");
                }
                else if (d == DialogResult.No)
                {

                }
            }
        }

        private void btnPrimary_Click(object sender, EventArgs e)
        {
            pnControls.BringToFront();
            pnOther.BringToFront();
            pnSettings.Hide();
            pnControls.Show();
            pnOther.Show();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            pnSettings.BringToFront();
            pnOther.Hide();
            pnControls.Hide();
            pnSettings.Show();
        }

        private void cbRCA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbRCA.Text == "true")
            {
                OpenRecorder_Studio.Properties.Settings.Default.ComputerAudio = "true";
                OpenRecorder_Studio.Properties.Settings.Default.Save();
            }
            else
            {
                OpenRecorder_Studio.Properties.Settings.Default.ComputerAudio = "false";
                OpenRecorder_Studio.Properties.Settings.Default.Save();
            }
        }

        private void cbRMA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbRMA.Text == "true")
            {
                MSG.Style = Guna.UI2.WinForms.MessageDialogStyle.Dark;
                MSG.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                MSG.Caption = "Feature unavailable.";
                MSG.Text = "Sorry, this feature is currently under dev.";
                MSG.Show();

                OpenRecorder_Studio.Properties.Settings.Default.MicrophoneAudio = "true";
                OpenRecorder_Studio.Properties.Settings.Default.Save();
            }
            else
            {
                OpenRecorder_Studio.Properties.Settings.Default.MicrophoneAudio = "false";
                OpenRecorder_Studio.Properties.Settings.Default.Save();
            }
        }

        private void cbPCS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPCS.Text == "true")
            {
                System.Threading.Thread.Sleep(500);
                ShowingScreen.Start();
 
                OpenRecorder_Studio.Properties.Settings.Default.PresentCurrentScreen = "true";
                OpenRecorder_Studio.Properties.Settings.Default.Save();
            }
            else
            {
                System.Threading.Thread.Sleep(500);
                ShowingScreen.Stop();
                ShowingScreen.Stop();
                ShowingScreen.Stop();
                OpenRecorder_Studio.Properties.Settings.Default.PresentCurrentScreen = "false";
                OpenRecorder_Studio.Properties.Settings.Default.Save();
            }
        }

        private void txtPCS_Click(object sender, EventArgs e)
        {
            MessageBox.Show("INFO: Can help with reducing lag when disabled and may also reduce animation lag.", "Feature Information", MessageBoxButtons.OK);
        }

        private void Seconds_Tick(object sender, EventArgs e)
        {
            
        }

        int s, m, h;

        private void btnVisitWebsite_Click(object sender, EventArgs e)
        {
            Process.Start("https://discord.gg/fXT2bCMyn4");
        }

        private void btnCloseAccounts_Click(object sender, EventArgs e)
        {
            pnAccounts.Hide();
        }

        private void pnControls_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnOpenPaint_Click(object sender, EventArgs e)
        {
            pnTools.Hide();
            Form newForm = new OpenRecorder_Studio.OpenPaint();
            newForm.ShowDialog();
        }

        private void btnClosePlugins_Click(object sender, EventArgs e)
        {
            pnPlugins.Hide();
        }

        private void btnPlugins_Click(object sender, EventArgs e)
        {

            btnAccount.Checked = false;
            btnTools.Checked = false;
            btnSettings2.Checked = false;

            if (btnPlugins.Checked == true)
            {

                pnPlugins.Show();
                pnAccounts.Hide();
                pnTools.Hide();
                pnSettings2.Hide();

            }
            else if (btnPlugins.Checked == false)
            {

                pnPlugins.Hide();

            }
        }

        private void btnCreatePlugin_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(Application.StartupPath + @"\Plugins\") == false)
            {
                Directory.CreateDirectory(Application.StartupPath + @"\Plugins\");
                Directory.CreateDirectory(Application.StartupPath + @"\Plugins\My Plugins");
            }
            else
            {
                // Already exists
            }

            if (Directory.Exists(Application.StartupPath + @"\Plugins\My Plugins") == false)
            {
                Directory.CreateDirectory(Application.StartupPath + @"\Plugins\My Plugins");
            }
            else
            {
                // Already exists
            }

            FileInfo t = new FileInfo(Application.StartupPath + @"\Plugins\My Plugins\" + DateTime.Now.ToString("yyyy-mm-ddd") + ".orscl");
            StreamWriter Tex = t.CreateText();
            Tex.WriteLine("// Instructions:");
            Tex.WriteLine("\n// Get started with ORSCL by learning how to use it first. Don't know how to get started? Head over to the Documentation after opening up the Plugins bar in the home page of the recorder.");
            Tex.WriteLine("// We provide the easiest ways to customize this recorder for you and for others, just don't inject any viruses in 'em :P");
            Tex.WriteLine("// Tutorial:");
            Tex.WriteLine("\n// Start off by importing some important packages that will be needed. If you're thinking about creating a plugin that accesses your files, then import System.Files and System.Permissions.\n // If you're looking forward to creating a regular plugin then just import System.Permissions, that way, this plugin will have permissions to run without any system checkups or scans.");
            Tex.WriteLine("// You can start the creation of your first ever plugin below this text, also feel free to delete those notes if you've already done this before.\n \n");
            Tex.Write(Tex.NewLine);
            Tex.Close();

            Process.Start(Application.StartupPath + @"\Plugins\My Plugins\" + DateTime.Now.ToString("yyyy-mm-ddd") + ".orscl");

        }

        private void State_Tick(object sender, EventArgs e)
        {
            State.Stop();

            if (_IsRecording == true)
            {
                if (initialized == false)
                {

                }
                else
                {
                    client.SetPresence(new DiscordRPC.RichPresence()
                    {
                        Details = $"Recording.",
                        State = $"On home page.",
                        Timestamps = Timestamps.Now,
                        Assets = new Assets()
                        {
                            LargeImageKey = $"OpenRecorder",
                            LargeImageText = "OpenRecorder Studio",
                            SmallImageKey = $"pronner_studios",
                            SmallImageText = "Created & Published by Pronner Studios"
                        }
                    });
                }
            }
            else
            {
                if (initialized == false)
                {

                }
                else
                {
                    client.SetPresence(new DiscordRPC.RichPresence()
                    {
                        Details = $"Not Recording.",
                        State = $"On home page.",
                        Timestamps = Timestamps.Now,
                        Assets = new Assets()
                        {
                            LargeImageKey = $"OpenRecorder",
                            LargeImageText = "OpenRecorder Studio",
                            SmallImageKey = $"pronner_studios",
                            SmallImageText = "Created & Published by Pronner Studios"
                        }
                    });
                }
            }
            State.Start();
        }

        private void pbScreen_Click(object sender, EventArgs e)
        {

        }

        private void btnSettings2_Click(object sender, EventArgs e)
        {

            pnPMCBE.Hide();

            #region LoadSettings


            cbFPS.Text = OpenRecorder_Studio.Properties.Settings.Default.FPS;


            #endregion

            btnAccount.Checked = false;
            btnTools.Checked = false;
            btnPlugins.Checked = false;

            if (btnSettings2.Checked == true)
            {

                pnSettings2.Show();
                pnAccounts.Hide();
                pnTools.Hide();
                pnPlugins.Hide();

            }
            else if (btnSettings2.Checked == false)
            {

                pnSettings2.Hide();

            }
        }

        private void cbFPS_SelectedIndexChanged(object sender, EventArgs e)
        {
            OpenRecorder_Studio.Properties.Settings.Default.FPS = cbFPS.Text;
            OpenRecorder_Studio.Properties.Settings.Default.Save();
            
        }

        private void btnPMCBE_Click(object sender, EventArgs e)
        {
            pnPMCBE.Show();
            pnPMCBE.BringToFront();
        }

        private void btnPROBLOX_Click(object sender, EventArgs e)
        {
            MSG.Style = Guna.UI2.WinForms.MessageDialogStyle.Dark;
            MSG.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
            MSG.Caption = "Menu unavailable.";
            MSG.Text = "Menu is currently under development.";
            MSG.Show();
        }

        private void btnSRekaNetwork_Click(object sender, EventArgs e)
        {
            MSG.Style = Guna.UI2.WinForms.MessageDialogStyle.Dark;
            MSG.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
            MSG.Caption = "Server Information.";
            MSG.Text = "reka.mcpe.lol:19132";
            MSG.Show();
        }

        private void btnSTheHive_Click(object sender, EventArgs e)
        {
            MSG.Style = Guna.UI2.WinForms.MessageDialogStyle.Dark;
            MSG.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
            MSG.Caption = "Server Information.";
            MSG.Text = "play.hivemc.com:19132";
            MSG.Show();
        }

        private void btnDocumentation_Click(object sender, EventArgs e)
        {
            MSG.Style = Guna.UI2.WinForms.MessageDialogStyle.Dark;
            MSG.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
            MSG.Caption = "Menu unavailable.";
            MSG.Text = "Menu is currently under development.";
            MSG.Show();
        }

        private void btnPluginBrowsing_Click(object sender, EventArgs e)
        {
            MSG.Style = Guna.UI2.WinForms.MessageDialogStyle.Dark;
            MSG.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
            MSG.Caption = "Menu unavailable.";
            MSG.Text = "Menu is currently under development.";
            MSG.Show();
        }

        private void btnAccounts_Click(object sender, EventArgs e)
        {
            MSG.Style = Guna.UI2.WinForms.MessageDialogStyle.Dark;
            MSG.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
            MSG.Caption = "Menu unavailable.";
            MSG.Text = "Menu is currently under development.";
            MSG.Show();
        }

        private void btnAccountSettings_Click(object sender, EventArgs e)
        {
            MSG.Style = Guna.UI2.WinForms.MessageDialogStyle.Dark;
            MSG.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
            MSG.Caption = "Menu unavailable.";
            MSG.Text = "Menu is currently under development.";
            MSG.Show();
        }

        private void cbVFT_SelectedIndexChanged(object sender, EventArgs e)
        {
            OpenRecorder_Studio.Properties.Settings.Default.Saver = cbVFT.Text;
            OpenRecorder_Studio.Properties.Settings.Default.Save();
        }

        private void CorrectTimer_Tick(object sender, EventArgs e)
        {
            s += 1;

            if (s == 60)
            {
                m += 1;
                s = 0;
            }

            if (m == 60)
            {
                m = 0;
                h += 1;
            }

            txtTiming.Text = string.Format("{0}:{1}:{2}", h.ToString().PadLeft(2, '0'), m.ToString().PadLeft(2, '0'), s.ToString().PadLeft(2, '0'));
        }
    }
}