using System.Media;
using Timer=System.Timers.Timer;
namespace BeerPong{
    public class KonamiSequence
    {
        readonly Keys[] _code = { Keys.Up, Keys.Up, Keys.Down, Keys.Down, Keys.Left, Keys.Right, Keys.Left, Keys.Right, Keys.B, Keys.A };

        private int _sequenceIndex;

        private readonly int _codeLength;
        private readonly int _sequenceMax;

        private readonly Timer _quantum = new Timer();

        public SoundPlayer sound;

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
                    sound = new SoundPlayer(Resource1.urss);
                    sound.Play();
                    konamiCounter++;
                    break;
                case 1:
                    sound = new SoundPlayer(Resource1.dross);
                    sound.Play();
                    konamiCounter++;
                    break;
                case 2:
                    sound = new SoundPlayer(Resource1.lavender);
                    sound.Play();
                    konamiCounter++;
                    break;
                case 3:
                    sound = new SoundPlayer(Resource1.scream);
                    sound.Play();
                    konamiCounter++;
                    break;
                case 4:
                    sound = new SoundPlayer(Resource1.selene);
                    sound.Play();
                    konamiCounter++;
                    break;
                case 5:
                    sound = new SoundPlayer(Resource1.walrus);
                    sound.Play();
                    konamiCounter++;
                    break;
                case 6:
                    MessageBox.Show("01001001 00100000 01000001 01001101 00100000 01000111 01001111 01000100");
                    break;
            }
            
        }
    }
}