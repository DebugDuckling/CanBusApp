namespace CanBusApp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var model = new CanBusModel();
            var view = new Form1();
            var controller = new CanBusController(model, view);

            Application.Run(view);
        }
    }
}
