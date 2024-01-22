using System.Collections.ObjectModel;

namespace pushups.Models
{
    class AllPushups
    {
        public ObservableCollection<Pushup> Pushups { get; set; } = new ObservableCollection<Pushup>();

        public AllPushups() => LoadPushups();

        public void LoadPushups()
        {
            Pushups.Clear();

            // Get the folder where the notes are stored.
            string appDataPath = FileSystem.AppDataDirectory;

            // Use Linq extensions to load the *.notes.txt files.
            IEnumerable<Pushup> pushups = Directory

                                        // Select the file names from the directory
                                        .EnumerateFiles(appDataPath, "*.pushups.txt")

                                        // Each file name is used to create a new Note
                                        .Select(filename => new Pushup()
                                        {
                                            Filename = filename,
                                            PushupAmount = Int32.Parse(File.ReadAllText(filename)),
                                            Date = File.GetCreationTime(filename)
                                        })

                                        // With the final collection of notes, order them by date
                                        .OrderBy(pushup => pushup.Date);

            // Add each note into the ObservableCollection
            foreach (Pushup pushup in pushups)
                Pushups.Add(pushup);
        }
    }
}
