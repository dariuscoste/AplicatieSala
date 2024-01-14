using System;
using AplicatieSala.Data;
using System.IO;

namespace AplicatieSala
{
    public partial class App : Application
    {
        static ExerciseCount database;
        public static ExerciseCount Database
        {
            get
            {
                if (database == null)
                {
                    database = new
                   ExerciseCount(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
                   LocalApplicationData), "ExerciseCount.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
