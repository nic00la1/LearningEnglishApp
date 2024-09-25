namespace LearningEnglishApp
{
    public partial class MainPage : ContentPage
    {
        private int lives = 3;
        private int score = 0;
        private string currentWord = "Ptak"; // Przykładowe słowo do przetłumaczenia
        private string correctTranslation = "Bird"; // Przykładowe poprawne tłumaczenie

        public MainPage()
        {
            InitializeComponent();
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

            UpdateUI();
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
            UpdateUI();
        }
    }

}
