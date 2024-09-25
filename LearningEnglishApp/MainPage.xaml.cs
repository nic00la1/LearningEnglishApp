namespace LearningEnglishApp
{
    public partial class MainPage : ContentPage
    {
        private int lives = 3;
        private int score = 0;
        private string currentWord;
        private string correctTranslation;
        private readonly List<(string Polish, string English)> words = new()
            {
                ("Ptak", "Bird"),
                ("Kot", "Cat"),
                ("Pies", "Dog"),
                ("Dom", "House"),
                ("Samochód", "Car"),
                ("Drzewo", "Tree"),
                ("Kwiat", "Flower"),
                ("Książka", "Book"),
                ("Stół", "Table"),
                ("Krzesło", "Chair"),
                ("Okno", "Window"),
                ("Drzwi", "Door"),
                ("Telefon", "Phone"),
                ("Komputer", "Computer"),
                ("Jabłko", "Apple"),
                ("Pomarańcza", "Orange"),
                ("Banana", "Banana"),
                ("Szkoła", "School"),
                ("Nauczyciel", "Teacher"),
                ("Uczeń", "Student"),
                ("Miasto", "City"),
                ("Wieś", "Village"),
                ("Rzeka", "River"),
                ("Morze", "Sea"),
                ("Góra", "Mountain"),
                ("Plaża", "Beach"),
                ("Las", "Forest"),
                ("Droga", "Road"),
                ("Most", "Bridge"),
                ("Samolot", "Plane")
            };

        public MainPage()
        {
            InitializeComponent();
            SelectRandomWord();
            UpdateUI();
        }

        private async void OnCheckTranslationClicked(object sender, EventArgs e)
        {
            if (TranslationEntry.Text.ToLower() == correctTranslation.ToLower())
            {
                score++;
                FeedbackLabel.Text = "Poprawnie!";
                FeedbackLabel.TextColor = Colors.Green;
                await DisplayAlert("Dobrze!", "Poprawna odpowiedź", "OK");
            }
            else
            {
                lives--;
                FeedbackLabel.Text = "Błędna odpowiedź!";
                FeedbackLabel.TextColor = Colors.Red;
                await DisplayAlert("Niedobrze!", $"To nie jest poprawna odpowiedź. Poprawna odpowiedź to {correctTranslation}. Pozostało Ci: {lives} życia!", "OK");
            }

            if (lives == 0)
            {
                await DisplayAlert("Koniec", $"Niestety przegrałeś/aś! Przetłumaczono poprawnie {score} słów", "OK");
                ResetGame();
            }
            else
            {
                SelectRandomWord();
            }

            UpdateUI();
        }

        private void SelectRandomWord()
        {
            var random = new Random();
            var randomIndex = random.Next(words.Count);
            currentWord = words[randomIndex].Polish;
            correctTranslation = words[randomIndex].English;
        }

        private void UpdateUI()
        {
            PolishWordLabel.Text = currentWord;
            LivesLabel.Text = $"Życia: {lives}";
            ScoreLabel.Text = $"Przetłumaczono: {score}";
            TranslationEntry.Text = string.Empty;
        }

        private void ResetGame()
        {
            lives = 3;
            score = 0;
            FeedbackLabel.Text = string.Empty;
            SelectRandomWord();
            UpdateUI();
        }
    }

}
