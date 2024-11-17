namespace DomainApp.StructurePattern
{
    public interface IAdvancePlayer
    {
        void AdvancePlay();
    }

    public class Mp4 : IAdvancePlayer
    {
        public void AdvancePlay()
        {
            Console.WriteLine("Mp4 Played");
        }
    }
    public class Vlc : IAdvancePlayer
    {
        public void AdvancePlay()
        {
            Console.WriteLine("VLC Played");
        }
    }


    public class BasicPlayerAdapter : IBasicPlayer
    {
        private IAdvancePlayer _player;
        public BasicPlayerAdapter(IAdvancePlayer player)
        {
            _player = player;
        }
      
        public void Play()
        {
            _player.AdvancePlay();
        }
    }


    public interface IBasicPlayer
    {
        void Play();
    }
    public class Mp3 : IBasicPlayer
    {
        public void Play()
        {
            Console.WriteLine("Mp3 Format Audio");
        }
    }



}
