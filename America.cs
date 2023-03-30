using NAudio.Wave;
using Timer = System.Timers.Timer;
namespace BeerPong
{
    public class America
    {
        readonly Keys[] _code = { Keys.A, Keys.M, Keys.E, Keys.R, Keys.I, Keys.C, Keys.A};

        private int _sequenceIndex;

        private readonly int _codeLength;
        private readonly int _sequenceMax;

        private readonly Timer _quantum = new Timer();

        private WaveOutEvent outputDevice;
        private AudioFileReader audioFile;

        private int konamiCounter;

        public America()
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

        

        private void OnPlaybackStopped(object sender, StoppedEventArgs args)
        {
            //outputDevice.Dispose();
            outputDevice = null;
            //audioFile.Dispose();
            audioFile = null;
        }
    }
}