using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using Timer=System.Timers.Timer;
namespace BeerPong{
    public class KonamiSequence
    {
        readonly Keys[] _code = { Keys.Up, Keys.Up, Keys.Down, Keys.Down, Keys.Left, Keys.Right, Keys.Left, Keys.Right, Keys.B, Keys.A };

        private int _sequenceIndex;

        private readonly int _codeLength;
        private readonly int _sequenceMax;

        private readonly Timer _quantum = new Timer();

        private WaveOutEvent outputDevice;
        private AudioFileReader audioFile;

        private int konamiCounter;

        public KonamiSequence()
        {
            konamiCounter = 0;
            _codeLength = _code.Length - 1;
            _sequenceMax = _code.Length;

            _quantum.Interval = 5000; //ms before reset
            _quantum.Elapsed += timeout;
        }

        public bool IsCompletedBy(Keys key)
        {
            _quantum.Start();

            _sequenceIndex %= _sequenceMax;
            _sequenceIndex = (_code[_sequenceIndex] == key) ? ++_sequenceIndex : 0;

            return _sequenceIndex > _codeLength;
        }

        private void timeout(object o, EventArgs e)
        {
            _quantum.Stop();
            _sequenceIndex = 0;

        }

        public void EasterEgg()
        {
            switch (konamiCounter)
            {
                case 0:
                    outputDevice = new WaveOutEvent();
                    outputDevice.PlaybackStopped += OnPlaybackStopped;
                    audioFile = new AudioFileReader(@"..\..\..\Resources\urss.mp3");
                    outputDevice.Init(audioFile);
                    outputDevice.Play();
                    konamiCounter++;
                    break;
                case 1:
                    if(outputDevice == null && audioFile == null)
                    {
                        outputDevice = new WaveOutEvent();
                        outputDevice.PlaybackStopped += OnPlaybackStopped;
                        audioFile = new AudioFileReader(@"..\..\..\Resources\dross.mp3");
                        outputDevice.Init(audioFile);
                        outputDevice.Play();
                    }
                    else
                    {
                        outputDevice.Stop();
                        outputDevice = new WaveOutEvent();
                        outputDevice.PlaybackStopped += OnPlaybackStopped;
                        audioFile = new AudioFileReader(@"..\..\..\Resources\dross.mp3");
                        outputDevice.Init(audioFile);
                        outputDevice.Play();
                    }
                    
                    konamiCounter++;
                    break;
                case 2:
                    if (outputDevice == null && audioFile == null)
                    {
                        outputDevice = new WaveOutEvent();
                        outputDevice.PlaybackStopped += OnPlaybackStopped;
                        audioFile = new AudioFileReader(@"..\..\..\Resources\lavender.mp3");
                        outputDevice.Init(audioFile);
                        outputDevice.Play();
                    }
                    else
                    {
                        outputDevice.Stop();
                        outputDevice = new WaveOutEvent();
                        outputDevice.PlaybackStopped += OnPlaybackStopped;
                        audioFile = new AudioFileReader(@"..\..\..\Resources\lavender.mp3");
                        outputDevice.Init(audioFile);
                        outputDevice.Play();
                    }
                    konamiCounter++;
                    break;
                case 3:
                    if (outputDevice == null && audioFile == null)
                    {
                        outputDevice = new WaveOutEvent();
                        outputDevice.PlaybackStopped += OnPlaybackStopped;
                        audioFile = new AudioFileReader(@"..\..\..\Resources\scream.mp3");
                        outputDevice.Init(audioFile);
                        outputDevice.Play();
                    }
                    else
                    {
                        outputDevice.Stop();
                        outputDevice = new WaveOutEvent();
                        outputDevice.PlaybackStopped += OnPlaybackStopped;
                        audioFile = new AudioFileReader(@"..\..\..\Resources\scream.mp3");
                        outputDevice.Init(audioFile);
                        outputDevice.Play();
                    }
                    konamiCounter++;
                    break;
                case 4:
                    if (outputDevice == null && audioFile == null)
                    {
                        outputDevice = new WaveOutEvent();
                        outputDevice.PlaybackStopped += OnPlaybackStopped;
                        audioFile = new AudioFileReader(@"..\..\..\Resources\selene.mp3");
                        outputDevice.Init(audioFile);
                        outputDevice.Play();
                    }
                    else
                    {
                        outputDevice.Stop();
                        outputDevice = new WaveOutEvent();
                        outputDevice.PlaybackStopped += OnPlaybackStopped;
                        audioFile = new AudioFileReader(@"..\..\..\Resources\selene.mp3");
                        outputDevice.Init(audioFile);
                        outputDevice.Play();
                    }
                    konamiCounter++;
                    break;
                case 5:
                    if (outputDevice == null && audioFile == null)
                    {
                        outputDevice = new WaveOutEvent();
                        outputDevice.PlaybackStopped += OnPlaybackStopped;
                        audioFile = new AudioFileReader(@"..\..\..\Resources\walrus.mp3");
                        outputDevice.Init(audioFile);
                        outputDevice.Play();
                    }
                    else
                    {
                        outputDevice.Stop();
                        outputDevice = new WaveOutEvent();
                        outputDevice.PlaybackStopped += OnPlaybackStopped;
                        audioFile = new AudioFileReader(@"..\..\..\Resources\walrus.mp3");
                        outputDevice.Init(audioFile);
                        outputDevice.Play();
                    }
                    konamiCounter++;
                    break;
                case 6:
                    MessageBox.Show("01001001 00100000 01000001 01001101 00100000 01000111 01001111 01000100");
                    break;
            }
            
        }

        private void OnPlaybackStopped(object sender, StoppedEventArgs args)
        {
            //outputDevice.Dispose();
            outputDevice = null;
            //audioFile.Dispose();
            audioFile = null;
        }
    }
}