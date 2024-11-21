namespace DomainApp.CreationPattern
{


    public class Computer
    {
        public int Ram { get; set; }
        public string Model { get; set; }
        public string Graphics { get; set; }
    }

    public interface IComputerBuilder
    {
        void SetRam(int ram);
        void SetModel(string model);
        void SetGraphics(string graphics);
        Computer BuildComputer();
    }

    public class ComputerBuilder : IComputerBuilder
    {

        private Computer _computer { get; set; }
        public ComputerBuilder()
        {
            _computer = new Computer();

        }

        public Computer BuildComputer()
        {
            return _computer;
        }

        public void SetRam(int ram)
        {
            _computer.Ram = ram;
        }

        public void SetModel(string model)
        {

            _computer.Model = model;
        }

        public void SetGraphics(string graphics)
        {
            _computer.Graphics = graphics;

        }
    }
}
